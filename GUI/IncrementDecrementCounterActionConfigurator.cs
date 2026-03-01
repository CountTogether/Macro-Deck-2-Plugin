using CountTogether.PublicApiSdk.Models;
using SuchByte.MacroDeck.GUI.CustomControls;
using SuchByte.MacroDeck.Plugins;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CountTogether.MacroDeckPlugin.GUI;

public partial class IncrementDecrementCounterActionConfigurator : ActionConfigControl
{
    private List<Counter> _counters = [];
    private PluginAction _action;

    public IncrementDecrementCounterActionConfigurator(PluginAction action)
    {
        _action = action;
        InitializeComponent();
    }

    protected override async void OnLoad(EventArgs e)
    {
        base.OnLoad(e);

        await LoadCounters();
        SelectConfiguredCounter();
    }

    public override bool OnActionSave()
    {
        if (this.selectedCounter.SelectedItem is not Counter counter)
        {
            return false;
        }

        _action.Configuration = counter.Id.ToString();

        return true;
    }

    private void SelectConfiguredCounter()
    {
        selectedCounter.SelectedValue = _action.Configuration;
    }

    private async Task LoadCounters()
    {
        _counters = await CountTogetherClientWrapper.GetCounters();
        selectedCounter.DataSource = null;
        selectedCounter.DisplayMember = nameof(Counter.DisplayName);
        selectedCounter.ValueMember = nameof(Counter.Id);
        selectedCounter.DataSource = _counters.Where(x => x.Type == CounterType.UpDown).ToList();
    }
}
