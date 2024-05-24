using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace Visual_Media_Organizer
{
    public partial class Form1 : Form
    {
        private List<string> fileList;
        private int currentIndex;
        private ViewedFiles viewedFiles;
        private string selectedFolder;

        private HotKeyForm hotKeyForm;

        public Form1()
        {
            InitializeComponent();
            LoadViewedFiles();
            LoadHotKeyForm();
        }

        private void LoadHotKeyForm()
        {
            hotKeyForm = new HotKeyForm();
            hotKeyForm.LoadKeybinds();
        }

        private void LoadViewedFiles()
        {
            string filePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Visual Media Organizer", "ViewedFiles.json");

            if (File.Exists(filePath))
            {
                string json = File.ReadAllText(filePath);
                viewedFiles = JsonConvert.DeserializeObject<ViewedFiles>(json);
            }
            else
            {
                viewedFiles = new ViewedFiles();
            }

            if (viewedFiles == null)
            {
                viewedFiles = new ViewedFiles();
            }

            if (viewedFiles.FolderPaths == null)
            {
                viewedFiles.FolderPaths = new Dictionary<string, List<string>>();
            }
        }

        private void SaveViewedFiles()
        {
            string filePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Visual Media Organizer", "ViewedFiles.json");
            string json = JsonConvert.SerializeObject(viewedFiles);
            Directory.CreateDirectory(Path.GetDirectoryName(filePath));
            File.WriteAllText(filePath, json);
        }

        private void getFileList()
        {
            fileList = Directory.GetFiles(selectedFolder, "*.*", SearchOption.TopDirectoryOnly)
                    .Where(file => !File.GetAttributes(file).HasFlag(FileAttributes.Directory) &&
                                    (file.ToLower().EndsWith(".jpg") || file.ToLower().EndsWith(".png") ||
                                    file.ToLower().EndsWith(".bmp") || file.ToLower().EndsWith(".gif") ||
                                    file.ToLower().EndsWith(".mp4") || file.ToLower().EndsWith(".avi") ||
                                    file.ToLower().EndsWith(".mov") || file.ToLower().EndsWith(".wmv")))
                    .ToList();

            return;
        }

        //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

        private void btnSelectFolder_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                selectedFolder = folderBrowserDialog1.SelectedPath;
                getFileList();

                if (!viewedFiles.FolderPaths.ContainsKey(selectedFolder))
                {
                    viewedFiles.FolderPaths[selectedFolder] = new List<string>();
                }
                else
                {
                    List<string> viewedFilesInFolder = viewedFiles.FolderPaths[selectedFolder];
                    fileList.RemoveAll(file => viewedFilesInFolder.Contains(file));
                }

                if (fileList.Count > 0)
                {
                    currentIndex = 0;
                    lblFilesView.Text = $"{currentIndex}/{fileList.Count}";
                    displayFile(fileList[currentIndex]);

                    btnClearCache.Enabled = true;
                    btnNext.Enabled = true;
                    btnSave.Enabled = true;
                    btnBack.Enabled = true;
                    lblFilesView.Visible = true;
                }
                else
                {
                    MessageBox.Show("No media files found in the selected folder, or all files have already been viewed. Click the 'Clear Cache' button now if you want to re-view the media in this folder.", "No Media Found", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }

            SaveViewedFiles();
        }

        private void btnClearCache_Click(object sender, EventArgs e)
        {
            if (viewedFiles.FolderPaths.ContainsKey(selectedFolder))
            {
                viewedFiles.FolderPaths[selectedFolder].Clear();
            }

            SaveViewedFiles();
            getFileList();

            if (fileList.Count > 0)
            {
                currentIndex = 0;
                displayFile(fileList[currentIndex]);
            }
            else
            {
                MessageBox.Show("No image or video files found in the selected folder.", "No Files Found", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            if (fileList != null && fileList.Count > 0)
            {
                if (currentIndex < fileList.Count - 1)
                {
                    currentIndex++;

                    string filePath = fileList[currentIndex];
                    string prevFilePath = fileList[currentIndex - 1];

                    displayFile(filePath);

                    savedLabel.Visible = false;
                    viewedFiles.FolderPaths[Path.GetDirectoryName(prevFilePath)].Add(prevFilePath);
                    SaveViewedFiles();
                }
                else
                {
                    MessageBox.Show("Already at the last file.", "End of List", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                MessageBox.Show("No files to display.", "Empty List", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            if (fileList != null && fileList.Count > 0)
            {
                if (currentIndex > 0)
                {
                    currentIndex--;
                    displayFile(fileList[currentIndex]);
                    savedLabel.Visible = false;
                }
                else
                {
                    MessageBox.Show("Already at the first file.", "Start of List", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                MessageBox.Show("No files to display.", "Empty List", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string saveFolder = Path.Combine(Path.GetDirectoryName(fileList[currentIndex]), "VMO_Saved");

            if (!Directory.Exists(saveFolder))
            {
                Directory.CreateDirectory(saveFolder);
            }

            string fileName = Path.GetFileName(fileList[currentIndex]);
            string destPath = Path.Combine(saveFolder, fileName);

            File.Copy(fileList[currentIndex], destPath, true);
            savedLabel.Visible = true;
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (hotKeyForm != null)
            {
                if (keyData == hotKeyForm.BackKey)
                {
                    btnBack_Click(null, null);
                    return true;
                }
                else if (keyData == hotKeyForm.SaveKey)
                {
                    btnSave_Click(null, null);
                    return true;
                }
                else if (keyData == hotKeyForm.NextKey)
                {
                    btnNext_Click(null, null);
                    return true;
                }
            }

            return base.ProcessCmdKey(ref msg, keyData);
        }

        //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

        private async void displayFile(string filePath)
        {
            if (File.Exists(filePath))
            {
                try
                {
                    if (pictureBox.Image != null)
                    {
                        pictureBox.Image.Dispose();
                    }

                    lblFileName.Text = Path.GetFileName(filePath);
                    lblFileName.Visible = true;

                    lblFilesView.Text = $"{currentIndex + 1}/{fileList.Count}";

                    axWindowsMediaPlayer1.close();
                    axWindowsMediaPlayer1.Visible = false;
                    pictureBox.Visible = false;

                    if (filePath.ToLower().EndsWith(".jpg") || filePath.ToLower().EndsWith(".png") ||
                        filePath.ToLower().EndsWith(".bmp") || filePath.ToLower().EndsWith(".gif"))
                    {
                        pictureBox.Image = new Bitmap(filePath);
                        pictureBox.Visible = true;
                    }
                    else if (filePath.ToLower().EndsWith(".mp4") || filePath.ToLower().EndsWith(".avi") ||
                             filePath.ToLower().EndsWith(".mov") || filePath.ToLower().EndsWith(".wmv"))
                    {
                        await LoadVideoAsync(filePath);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error displaying file: {lblFileName.Text}\nFile may be corrupt.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    btnNext_Click(null, null);
                }
            }
        }

        private async Task LoadVideoAsync(string filePath)
        {
            await Task.Run(() =>
            {
                Invoke(new Action(() =>
                {
                    axWindowsMediaPlayer1.Visible = true;

                    axWindowsMediaPlayer1.uiMode = "none";
                    axWindowsMediaPlayer1.URL = filePath;
                    axWindowsMediaPlayer1.settings.autoStart = true;
                    axWindowsMediaPlayer1.stretchToFit = true;
                    axWindowsMediaPlayer1.settings.setMode("loop", true);
                }));
            });
        }

        private void btnKeybinds_Click(object sender, EventArgs e)
        {
            hotKeyForm = new HotKeyForm();
            hotKeyForm.ShowDialog();
        }

        //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
    }

    public class ViewedFiles
    {
        public Dictionary<string, List<string>> FolderPaths { get; set; }

        public ViewedFiles()
        {
            FolderPaths = new Dictionary<string, List<string>>();
        }
    }
}
