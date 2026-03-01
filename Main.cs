using CountTogether.MacroDeckPlugin;
using CountTogether.MacroDeckPlugin.Actions;
using CountTogether.MacroDeckPlugin.GUI;
using SuchByte.MacroDeck.Plugins;

namespace MacroDeck.CountTogetherPlugin;

public class Main : MacroDeckPlugin
{
    public static Main Instance { get; private set; } = null!;

    public override bool CanConfigure => true;

    public Main()
    {
        Instance = this;
    }

    public override void Enable()
    {
        CountTogetherClientWrapper.Start();

        Actions = [
            new IncrementCounterAction(),
            new DecrementCounterAction()
        ];
    }

    public override void OpenConfigurator()
    {
        using var pluginConfig = new PluginConfig();
        pluginConfig.ShowDialog();
    }
}
