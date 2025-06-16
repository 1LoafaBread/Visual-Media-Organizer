using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
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
        public Keys NextFolderKey { get; private set; }
        public Keys BackFolderKey { get; private set; }

        private bool listeningForKey = false;

        public HotKeyForm()
        {
            InitializeComponent();
            this.KeyPreview = true;
            this.KeyDown += HotKeyForm_KeyDown;
            this.Load += HotKeyForm_Load;
        }

        private void HotKeyForm_Load(object sender, EventArgs e)
        {
            LoadKeybinds();
        }

        private void btnBackChange_Click(object sender, EventArgs e)
        {
            StartListening();
        }

        private void btnSaveChange_Click(object sender, EventArgs e)
        {
            StartListening();
        }

        private void btnNextChange_Click(object sender, EventArgs e)
        {
            StartListening();
        }

        private void btnNextFolderChange_Click(object sender, EventArgs e)
        {
            StartListening();
        }

        private void btnBackFolderChange_Click(object sender, EventArgs e)
        {
            StartListening();
        }

        private void StartListening()
        {
            listeningForKey = true;
            lblStatus.Text = "Status: Listening - Press any key";
        }

        public void LoadKeybinds()
        {
            try
            {
                string configFilePath = Path.Combine(
                    Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData),
                    "Visual Media Organizer",
                    "config.cfg"
                );

                if (File.Exists(configFilePath))
                {
                    string json = File.ReadAllText(configFilePath);
                    var keybinds = JsonConvert.DeserializeObject<Keybinds>(json);

                    if (keybinds != null)
                    {
                        BackKey = keybinds.BackKey;
                        txtboxBackKeybind.Text = BackKey.ToString();

                        SaveKey = keybinds.SaveKey;
                        txtboxSaveKeybind.Text = SaveKey.ToString();

                        NextKey = keybinds.NextKey;
                        txtboxNextKeybind.Text = NextKey.ToString();

                        NextFolderKey = keybinds.NextFolderKey;
                        txtboxNextFolderKeybind.Text = NextFolderKey.ToString();

                        BackFolderKey = keybinds.BackFolderKey;
                        txtboxBackFolderKeybind.Text = BackFolderKey.ToString();
                    }
                }
                else
                {
                    txtboxBackKeybind.Text = "None";
                    txtboxSaveKeybind.Text = "None";
                    txtboxNextKeybind.Text = "None";
                    txtboxNextFolderKeybind.Text = "None";
                    txtboxBackFolderKeybind.Text = "None";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading keybinds: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void SaveKeybinds()
        {
            try
            {
                string configFilePath = Path.Combine(
                    Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData),
                    "Visual Media Organizer",
                    "config.cfg"
                );

                var keybinds = new Keybinds
                {
                    BackKey = BackKey,
                    SaveKey = SaveKey,
                    NextKey = NextKey,
                    NextFolderKey = NextFolderKey,
                    BackFolderKey = BackFolderKey
                };

                string json = JsonConvert.SerializeObject(keybinds, Formatting.Indented);
                Directory.CreateDirectory(Path.GetDirectoryName(configFilePath));
                File.WriteAllText(configFilePath, json);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error saving keybinds: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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
                else if (btnNextFolderChange.Focused)
                {
                    txtboxNextFolderKeybind.Text = e.KeyCode.ToString();
                    NextFolderKey = e.KeyCode;
                }
                else if (btnBackFolderChange.Focused)
                {
                    txtboxBackFolderKeybind.Text = e.KeyCode.ToString();
                    BackFolderKey = e.KeyCode;
                }

                SaveKeybinds();
                listeningForKey = false;
                lblStatus.Text = "Status: Key captured";
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }

    public class Keybinds
    {
        public Keys BackKey { get; set; } = Keys.None;
        public Keys SaveKey { get; set; } = Keys.None;
        public Keys NextKey { get; set; } = Keys.None;
        public Keys NextFolderKey { get; set; } = Keys.None;
        public Keys BackFolderKey { get; set; } = Keys.None;
    }
}