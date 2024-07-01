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
            InitializeComboBoxes();
            LoadViewedFiles();
            LoadHotKeyForm();
        }

        private void InitializeComboBoxes()
        {
            comboBoxOrgType.SelectedIndex = 0;
            comboBoxMediaType.SelectedIndex = 0;
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
            string selectedMediaType = comboBoxMediaType.SelectedItem as string;
            var allowedExtensions = new List<string>();

            if (string.IsNullOrEmpty(selectedMediaType) || selectedMediaType == "Videos and Images")
            {
                allowedExtensions.AddRange(new[] { ".jpg", ".png", ".bmp", ".gif", ".mp4", ".avi", ".mov", ".wmv" });
            }
            else if (selectedMediaType == "Videos")
            {
                allowedExtensions.AddRange(new[] { ".mp4", ".avi", ".mov", ".wmv" });
            }
            else if (selectedMediaType == "Images")
            {
                allowedExtensions.AddRange(new[] { ".jpg", ".png", ".bmp", ".gif" });
            }

            fileList = Directory.GetFiles(selectedFolder, "*.*", SearchOption.TopDirectoryOnly)
                .Where(file => !File.GetAttributes(file).HasFlag(FileAttributes.Directory) &&
                                allowedExtensions.Contains(Path.GetExtension(file).ToLower()))
                .ToList();

            string selectedSort = comboBoxOrgType.SelectedItem as string;

            if (string.IsNullOrEmpty(selectedSort))
            {
                selectedSort = "Date Modified (Old->New)";
            }

            switch (selectedSort)
            {
                case "Date Modified (New->Old)":
                    fileList = fileList.OrderByDescending(file => File.GetLastWriteTime(file)).ToList();
                    break;

                case "Date Modified (Old->New)":
                    fileList = fileList.OrderBy(file => File.GetLastWriteTime(file)).ToList();
                    break;

                case "Name (A->Z)":
                    fileList = fileList.OrderBy(file => Path.GetFileName(file)).ToList();
                    break;

                case "Name (Z->A)":
                    fileList = fileList.OrderByDescending(file => Path.GetFileName(file)).ToList();
                    break;

                case "Random":
                    Random rand = new Random();
                    fileList = fileList.OrderBy(file => rand.Next()).ToList();
                    break;

                default:
                    fileList = fileList.OrderBy(file => File.GetLastWriteTime(file)).ToList();
                    break;
            }

            return;
        }

        private void btnSelectFolder_Click(object sender, EventArgs e)
        {
            savedLabel.Visible = false;

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
                    btnNextFolder.Enabled = true;
                    btnRefresh.Enabled = true;
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
            try
            {
                savedLabel.Text = "Saving...";
                savedLabel.Visible = true;
                this.Refresh();

                string saveFolder = Path.Combine(Path.GetDirectoryName(fileList[currentIndex]), "VMO_Saved");

                if (!Directory.Exists(saveFolder))
                {
                    Directory.CreateDirectory(saveFolder);
                }

                string fileName = Path.GetFileName(fileList[currentIndex]);
                string destPath = Path.Combine(saveFolder, fileName);

                File.Copy(fileList[currentIndex], destPath, true);

                savedLabel.Text = "Saved!";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while saving: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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
                else if (keyData == hotKeyForm.NextFolderKey)
                {
                    btnNextFolder_Click(null, null);
                    return true;
                }
            }

            return base.ProcessCmdKey(ref msg, keyData);
        }

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

                    lblFileName.Text = $"{Path.GetFileName(selectedFolder)}\\{Path.GetFileName(filePath)}";
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

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            savedLabel.Visible = false;

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
                lblFilesView.Text = $"{currentIndex + 1}/{fileList.Count}";
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

            SaveViewedFiles();
        }

        private void btnNextFolder_Click(object sender, EventArgs e)
        {
            savedLabel.Visible = false;

            try
            {
                string parentDirectory = Directory.GetParent(selectedFolder).FullName;

                string[] subdirectories = Directory.GetDirectories(parentDirectory, "*", SearchOption.TopDirectoryOnly);

                Array.Sort(subdirectories);

                currentIndex = Array.IndexOf(subdirectories, selectedFolder);

                if (currentIndex < subdirectories.Length - 1)
                {
                    selectedFolder = subdirectories[currentIndex + 1];

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
                        lblFilesView.Text = $"{currentIndex + 1}/{fileList.Count}";
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

                    SaveViewedFiles();
                }
                else
                {
                    MessageBox.Show("No more folders in this directory.", "End of Folders", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
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
