using CountTogether.MacroDeckPlugin.Configuration;
using CountTogether.PublicApiSdk.Abstractions.Client;
using CountTogether.PublicApiSdk.Client;
using CountTogether.PublicApiSdk.Models;
using MacroDeck.CountTogetherPlugin;
using SuchByte.MacroDeck.Logging;
using SuchByte.MacroDeck.Variables;
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace CountTogether.MacroDeckPlugin;

internal static class CountTogetherClientWrapper
{
    private static bool _running = false;

    private static ICountTogetherClient? _client;

    public static void Start()
    {
        if (_running)
        {
            return;
        }

        var token = PluginConfiguration.Load().ApiToken;
        if (string.IsNullOrEmpty(token))
        {
            MacroDeckLogger.Warning(Main.Instance, "No API token found. Count Together client will not be started.");
            return;
        }

        Task.Run(async () => await StartAsync(token));
    }

    public static void Stop()
    {
        if (!_running)
        {
            return;
        }

        try
        {
            if (_client != null)
            {
                _client.CounterUpdated -= Client_CounterUpdated;
                _client.CounterDeleted -= Client_CounterDeleted;
                _client.Dispose();
            }
            _running = false;
            MacroDeckLogger.Info(Main.Instance, "Count Together client stopped successfully.");
        }
        catch (Exception ex)
        {
            MacroDeckLogger.Error(Main.Instance, $"Failed to stop Count Together client: {ex.Message}");
        }
    }

    public static async Task<List<Counter>> GetCounters()
    {
        if (_client == null)
        {
            return [];
        }
        try
        {
            var counters = await _client.GetCountersAsync();
            return [.. counters.Where(x => x.Type == CounterType.UpDown)];
        }
        catch (Exception ex)
        {
            MacroDeckLogger.Error(Main.Instance, $"Failed to get counters from Count Together client: {ex.Message}");
            return [];
        }
    }

    public static async Task IncrementCounter(Guid counterId)
    {
        if (_client == null)
        {
            return;
        }

        try
        {
            await _client.IncrementCounterAsync(counterId);
        }
        catch (Exception ex)
        {
            MacroDeckLogger.Error(Main.Instance, $"Failed to increment counter in Count Together client: {ex.Message}");
        }
    }

    public static async Task DecrementCounter(Guid counterId)
    {
        if (_client == null)
        {
            return;
        }

        try
        {
            await _client.DecrementCounterAsync(counterId);
        }
        catch (Exception ex)
        {
            MacroDeckLogger.Error(Main.Instance, $"Failed to decrement counter in Count Together client: {ex.Message}");
        }
    }

    private static async Task StartAsync(string token)
    {
        try
        {
            _client = new CountTogetherClient();
            _client.CounterUpdated += Client_CounterUpdated;
            _client.CounterDeleted += Client_CounterDeleted;

            await _client.StartAsync(config => config.ApiToken = token);
            _running = true;
            MacroDeckLogger.Info(Main.Instance, "Count Together client started successfully.");

            await UpdateVariables();
        }
        catch (Exception ex)
        {
            MacroDeckLogger.Error(Main.Instance, $"Failed to start Count Together client, maybe the api token is invalid: {ex.Message}");
        }
    }

    private static async void Client_CounterDeleted(Guid obj)
    {
        await UpdateVariables();
    }

    private static async void Client_CounterUpdated(Counter obj)
    {
        await UpdateVariables();
    }

    private static async Task UpdateVariables()
    {
        if (_client == null)
        {
            return;
        }

        var counters = await _client.GetCountersAsync();
        foreach (var counter in counters)
        {
            UpdateCounter(counter);
        }

        var allVariables = VariableManager.GetVariables(Main.Instance);
        foreach (var variable in allVariables)
        {
            var variableName = variable.Name;
            if (variableName.StartsWith("counttogether_", StringComparison.OrdinalIgnoreCase))
            {
                var counterName = variableName.Substring("counttogether_".Length);
                if (!counters.Any(c => VariableManager.ConvertNameString(c.DisplayName) == counterName && c.Type == CounterType.UpDown))
                {
                    VariableManager.DeleteVariable(variable.Name);
                }
            }
        }
    }

    private static void UpdateCounter(Counter counter)
    {
        var name = VariableManager.ConvertNameString(counter.DisplayName);
        switch (counter.Type)
        {
            case CounterType.UpDown:
                var data = counter.Data?.Deserialize<PublicV1UpDownCounterData>();
                if (data != null)
                {
                    VariableManager.SetValue($"counttogether_{name}", data.Value, VariableType.Integer, Main.Instance, suggestions: []);
                }
                break;
            case CounterType.FromDate:
            case CounterType.ToDate:
                // Currently not supported
                break;
        }
    }
}
