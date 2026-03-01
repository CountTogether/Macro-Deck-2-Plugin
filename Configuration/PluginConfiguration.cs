using MacroDeck.CountTogetherPlugin;
using SuchByte.MacroDeck.Plugins;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CountTogether.MacroDeckPlugin.Configuration;

internal class PluginConfiguration
{
    public string? ApiToken { get; set; }

    public bool IsConfigured => !string.IsNullOrWhiteSpace(ApiToken);

    public static PluginConfiguration Load()
    {
        var credentialsList = PluginCredentials.GetPluginCredentials(Main.Instance);
        if (credentialsList != null && credentialsList.Count > 0)
        {
            Dictionary<string, string>? credentials = null;
            if (credentialsList.Count > 0)
            {
                credentials = credentialsList[0];
            }

            if (credentials != null && !string.IsNullOrWhiteSpace(credentials["apiToken"]))
            {
                return new PluginConfiguration
                {
                    ApiToken = credentials["apiToken"],
                };
            }
        }

        return new PluginConfiguration();
    }

    public static void Save(PluginConfiguration pluginConfiguration)
    {
        var credentials = new Dictionary<string, string>
        {
            { "apiToken", pluginConfiguration.ApiToken ?? string.Empty },
        };

        PluginCredentials.SetCredentials(Main.Instance, credentials);
    }
}
