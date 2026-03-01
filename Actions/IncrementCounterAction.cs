using CountTogether.MacroDeckPlugin.GUI;
using CountTogether.PublicApiSdk.Models;
using SuchByte.MacroDeck.ActionButton;
using SuchByte.MacroDeck.GUI;
using SuchByte.MacroDeck.GUI.CustomControls;
using SuchByte.MacroDeck.Plugins;
using SuchByte.MacroDeck.Variables.Plugin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.JavaScript;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace CountTogether.MacroDeckPlugin.Actions;

public class IncrementCounterAction : PluginAction
{
    public override string Name => "Increment Counter";

    public override string Description => "Increments the counter by 1";

    public override bool CanConfigure => true;

    public override ActionConfigControl GetActionConfigControl(ActionConfigurator actionConfigurator)
    {
        return new IncrementDecrementCounterActionConfigurator(this);
    }

    public override void Trigger(string clientId, ActionButton actionButton)
    {
        if (Configuration == null)
        {
            return;
        }

        if (Guid.TryParse(Configuration, out var counterIdGuid))
        {
            Task.Run(async () => await CountTogetherClientWrapper.IncrementCounter(counterIdGuid));
        }
    }
}
