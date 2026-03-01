using CountTogether.MacroDeckPlugin.Configuration;
using CountTogether.PublicApiSdk.Client;
using SuchByte.MacroDeck.GUI.CustomControls;
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

public partial class PluginConfig : DialogForm
{
    private PluginConfiguration _pluginConfiguration;

    public PluginConfig()
    {
        _pluginConfiguration = PluginConfiguration.Load();
        InitializeComponent();
    }

    private void PluginConfig_Load(object sender, EventArgs e)
    {
        this.inputToken.Text = _pluginConfiguration.ApiToken ?? string.Empty;
    }

    private async void BtnApply_Click(object sender, EventArgs e)
    {
        try
        {
            CountTogetherClientWrapper.Stop();
            using var countTogetherClient = new CountTogetherClient();
            await countTogetherClient.StartAsync(config => config.ApiToken = this.inputToken.Text);
            _pluginConfiguration.ApiToken = this.inputToken.Text;
            PluginConfiguration.Save(_pluginConfiguration);
            CountTogetherClientWrapper.Start();
            this.Close();
        } catch {
            using var messageBox = new SuchByte.MacroDeck.GUI.CustomControls.MessageBox();
            messageBox.ShowDialog("Unable to connect to CountTogether", "Maybe the api token is invalid.", MessageBoxButtons.OK);
        }
    }
}
