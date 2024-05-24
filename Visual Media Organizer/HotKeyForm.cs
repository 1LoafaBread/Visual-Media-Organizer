using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Visual_Media_Organizer
{
    public partial class HotKeyForm : Form
    {
        public Keys BackKey { get; private set; }
        public Keys SaveKey { get; private set; }
        public Keys NextKey { get; private set; }

        private bool listeningForKey = false;

        public HotKeyForm()
        {
            InitializeComponent();
            this.KeyPreview = true;
            this.KeyDown += HotKeyForm_KeyDown;
        }

        private void btnBackChange_Click(object sender, EventArgs e)
        {
            listeningForKey = true;
            lblStatus.Text = "Status: Listening";
        }

        private void btnSaveChange_Click(object sender, EventArgs e)
        {
            listeningForKey = true;
            lblStatus.Text = "Status: Listening";
        }

        private void btnNextChange_Click(object sender, EventArgs e)
        {
            listeningForKey = true;
            lblStatus.Text = "Status: Listening";
        }

        public void LoadKeybinds()
        {
            string configFilePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Visual Media Organizer", "config.cfg");
            if (File.Exists(configFilePath))
            {
                string json = File.ReadAllText(configFilePath);
                var keybinds = JsonConvert.DeserializeObject<Keybinds>(json);
                if (keybinds != null)
                {
                    BackKey = keybinds.BackKey;
                    SaveKey = keybinds.SaveKey;
                    NextKey = keybinds.NextKey;
                }
            }
        }

        private void SaveKeybinds()
        {
            string configFilePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Visual Media Organizer", "config.cfg");
            var keybinds = new Keybinds
            {
                BackKey = BackKey,
                SaveKey = SaveKey,
                NextKey = NextKey
            };
            string json = JsonConvert.SerializeObject(keybinds);
            File.WriteAllText(configFilePath, json);
        }

        private void HotKeyForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (listeningForKey)
            {
                if (btnBackChange.Focused)
                {
                    txtboxBackKeybind.Text = e.KeyCode.ToString();
                    BackKey = e.KeyCode;
                }
                else if (btnSaveChange.Focused)
                {
                    txtboxSaveKeybind.Text = e.KeyCode.ToString();
                    SaveKey = e.KeyCode;
                }
                else if (btnNextChange.Focused)
                {
                    txtboxNextKeybind.Text = e.KeyCode.ToString();
                    NextKey = e.KeyCode;
                }

                SaveKeybinds();
                listeningForKey = false;
                lblStatus.Text = "Status: Captured";
            }
        }
    }

    public class Keybinds
    {
        public Keys BackKey { get; set; }
        public Keys SaveKey { get; set; }
        public Keys NextKey { get; set; }
    }
}
