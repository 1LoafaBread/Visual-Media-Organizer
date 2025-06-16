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
        private string selectedFolder;
        private HotKeyForm hotKeyForm;

        public Form1()
        {
            InitializeComponent();
            InitializeComboBoxes();
            LoadHotKeyForm();
            chkbxVideoSound.Checked = true;
        }

        private void InitializeComboBoxes()
        {
            comboBoxOrgType.SelectedIndex = 0;
            comboBoxMediaType.SelectedIndex = 0;
            comboBoxSaveType.SelectedIndex = 0;
        }

        private void LoadHotKeyForm()
        {
            hotKeyForm = new HotKeyForm();
            hotKeyForm.LoadKeybinds();
        }

        private string GetJsonFilePath(string folderPath)
        {
            string safeFolderName = folderPath.Replace(":", "").Replace("\\", "_-_-").Replace("/", "_-_-");
            return Path.Combine(folderPath, $"{safeFolderName}.json");
        }

        private List<string> LoadViewedFiles(string folderPath)
        {
            string jsonFilePath = GetJsonFilePath(folderPath);

            if (File.Exists(jsonFilePath))
            {
                try
                {
                    string json = File.ReadAllText(jsonFilePath);
                    return JsonConvert.DeserializeObject<List<string>>(json) ?? new List<string>();
                }
                catch
                {
                    return new List<string>();
                }
            }
            return new List<string>();
        }

        private void SaveViewedFiles(string folderPath, List<string> viewedFiles)
        {
            string jsonFilePath = GetJsonFilePath(folderPath);
            try
            {
                string json = JsonConvert.SerializeObject(viewedFiles);
                File.WriteAllText(jsonFilePath, json);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error saving viewed files: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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

            List<string> viewedFiles = LoadViewedFiles(selectedFolder);
            fileList = fileList.Where(file => !viewedFiles.Contains(Path.GetFileName(file))).ToList();

            string selectedSort = comboBoxOrgType.SelectedItem as string;

            if (string.IsNullOrEmpty(selectedSort))
            {
                selectedSort = "Date Modified (Old->New)";
            }

            switch (selectedSort)
            {
                case "Date Modified (New->Old)":
                    fileList = fileList.OrderByDescending(file => new FileInfo(file).LastWriteTimeUtc).ToList();
                    break;

                case "Date Modified (Old->New)":
                    fileList = fileList.OrderBy(file => new FileInfo(file).LastWriteTimeUtc).ToList();
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

            if (fileList.Count > 0)
            {
                currentIndex = 0;
                lblFilesView.Text = $"{currentIndex + 1}/{fileList.Count}";
                displayFile(fileList[currentIndex]);

                btnClearCache.Enabled = true;
                btnNext.Enabled = true;
                btnSave.Enabled = true;
                btnBack.Enabled = true;
                btnNextFolder.Enabled = true;
                btnBackFolder.Enabled = true;
                btnRefresh.Enabled = true;
                lblFilesView.Visible = true;
            }
            else
            {
                MessageBox.Show("No media files found in the selected folder, or all files have already been viewed. Click the 'Clear Cache' button now if you want to re-view the media in this folder.", "No Media Found", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnSelectFolder_Click(object sender, EventArgs e)
        {
            savedLabel.Visible = false;

            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                selectedFolder = folderBrowserDialog1.SelectedPath;
                getFileList();
            }
        }

        private void btnClearCache_Click(object sender, EventArgs e)
        {
            string jsonFilePath = GetJsonFilePath(selectedFolder);
            if (File.Exists(jsonFilePath))
            {
                try
                {
                    File.Delete(jsonFilePath);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error clearing cache: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            getFileList();
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            if (fileList != null && fileList.Count > 0)
            {
                if (currentIndex < fileList.Count - 1)
                {
                    List<string> viewedFiles = LoadViewedFiles(selectedFolder);
                    string currentFileName = Path.GetFileName(fileList[currentIndex]);

                    if (!viewedFiles.Contains(currentFileName))
                    {
                        viewedFiles.Add(currentFileName);
                        SaveViewedFiles(selectedFolder, viewedFiles);
                    }

                    currentIndex++;
                    displayFile(fileList[currentIndex]);
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

        private void ReleaseFileHandles()
        {
            if (axWindowsMediaPlayer1.playState == WMPLib.WMPPlayState.wmppsPlaying)
            {
                axWindowsMediaPlayer1.Ctlcontrols.stop();
            }
            axWindowsMediaPlayer1.close();
            axWindowsMediaPlayer1.URL = null;

            if (pictureBox.Image != null)
            {
                pictureBox.Image.Dispose();
                pictureBox.Image = null;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                btnNext.Enabled = false;
                btnBack.Enabled = false;
                btnNextFolder.Enabled = false;
                btnBackFolder.Enabled = false;
                btnSave.Enabled = false;
                btnUnsave.Enabled = false;

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

                bool fileExists = File.Exists(destPath);
                string saveType = comboBoxSaveType.SelectedItem?.ToString() ?? "Copy";

                if (saveType == "Copy")
                {
                    File.Copy(fileList[currentIndex], destPath, true);
                    savedLabel.Text = fileExists ? "Previously Saved!" : "Saved!";
                }
                else
                {
                    ReleaseFileHandles();

                    if (File.Exists(destPath))
                    {
                        File.Delete(destPath);
                    }

                    File.Move(fileList[currentIndex], destPath);
                    savedLabel.Text = fileExists ? "Moved (overwritten existing)!" : "Moved!";

                    fileList.RemoveAt(currentIndex);

                    if (currentIndex >= fileList.Count && fileList.Count > 0)
                    {
                        currentIndex = fileList.Count - 1;
                    }
                }

                btnUnsave.Enabled = true;

                if (chkbxSaveNext.Checked && fileList != null && fileList.Count > 0)
                {
                    if (saveType == "Copy")
                    {
                        List<string> viewedFiles = LoadViewedFiles(selectedFolder);
                        string currentFileName = Path.GetFileName(fileList[currentIndex]);

                        if (!viewedFiles.Contains(currentFileName))
                        {
                            viewedFiles.Add(currentFileName);
                            SaveViewedFiles(selectedFolder, viewedFiles);
                        }

                        if (currentIndex < fileList.Count - 1)
                        {
                            currentIndex++;
                        }
                    }

                    if (fileList.Count > 0 && currentIndex < fileList.Count)
                    {
                        displayFile(fileList[currentIndex]);
                    }
                }
                else if (saveType == "Move" && fileList.Count > 0)
                {
                    displayFile(fileList[currentIndex]);
                }
                else if (fileList.Count == 0)
                {
                    axWindowsMediaPlayer1.close();
                    axWindowsMediaPlayer1.Visible = false;
                    pictureBox.Image = null;
                    pictureBox.Visible = false;
                    lblFileName.Visible = false;
                    lblFilesView.Text = "0/0";
                    savedLabel.Visible = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while saving: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                btnNext.Enabled = true;
                btnBack.Enabled = true;
                btnNextFolder.Enabled = true;
                btnBackFolder.Enabled = true;
                btnSave.Enabled = true;
                btnUnsave.Enabled = true;
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
                else if (keyData == hotKeyForm.BackFolderKey)
                {
                    btnBackFolder_Click(null, null);
                    return true;
                }
                else if (keyData == hotKeyForm.UnsaveKey)
                {
                    btnUnsave_Click(null, null);
                    return true;
                }
            }

            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void displayFile(string filePath)
        {
            if (File.Exists(filePath))
            {
                try
                {
                    if (pictureBox.Image != null)
                    {
                        pictureBox.Image.Dispose();
                        pictureBox.Image = null;
                    }

                    lblFileName.Text = $"{Path.GetFileName(selectedFolder)}\\{Path.GetFileName(filePath)}";
                    lblFileName.Visible = true;

                    lblFilesView.Text = $"{currentIndex + 1}/{fileList.Count}";

                    axWindowsMediaPlayer1.close();
                    axWindowsMediaPlayer1.Visible = false;
                    pictureBox.Visible = false;

                    string saveFolder = Path.Combine(Path.GetDirectoryName(fileList[currentIndex]), "VMO_Saved");
                    string fileName = Path.GetFileName(fileList[currentIndex]);
                    string savedFilePath = Path.Combine(saveFolder, fileName);
                    bool fileExists = File.Exists(savedFilePath);

                    if (fileExists)
                    {
                        savedLabel.Text = "Previously Saved!";
                        savedLabel.Visible = true;
                        btnUnsave.Enabled = true;
                    }
                    else
                    {
                        savedLabel.Visible = false;
                        btnUnsave.Enabled = false;
                    }

                    string ext = Path.GetExtension(filePath).ToLower();
                    if (ext == ".jpg" || ext == ".png" || ext == ".bmp" || ext == ".gif")
                    {
                        pictureBox.Image = new Bitmap(filePath);
                        pictureBox.Visible = true;
                    }
                    else if (ext == ".mp4" || ext == ".avi" || ext == ".mov" || ext == ".wmv")
                    {
                        LoadVideo(filePath);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error displaying file: {lblFileName.Text}\nFile may be corrupt.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    btnNext_Click(null, null);
                }
            }
        }

        private void LoadVideo(string filePath)
        {
            axWindowsMediaPlayer1.Visible = true;
            axWindowsMediaPlayer1.uiMode = "none";
            axWindowsMediaPlayer1.URL = filePath;
            axWindowsMediaPlayer1.settings.autoStart = true;
            axWindowsMediaPlayer1.stretchToFit = true;
            axWindowsMediaPlayer1.settings.setMode("loop", true);
            axWindowsMediaPlayer1.settings.mute = !chkbxVideoSound.Checked;
        }

        private void btnKeybinds_Click(object sender, EventArgs e)
        {
            hotKeyForm = new HotKeyForm();
            hotKeyForm.ShowDialog();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            savedLabel.Visible = false;

            if (!string.IsNullOrEmpty(selectedFolder))
            {
                getFileList();
            }
        }

        private void btnNextFolder_Click(object sender, EventArgs e)
        {
            savedLabel.Visible = false;

            try
            {
                string parentDirectory = Directory.GetParent(selectedFolder).FullName;
                string[] subdirectories = Directory.GetDirectories(parentDirectory, "*", SearchOption.TopDirectoryOnly);
                Array.Sort(subdirectories);

                int currentFolderIndex = Array.IndexOf(subdirectories, selectedFolder);

                if (currentFolderIndex < subdirectories.Length - 1)
                {
                    selectedFolder = subdirectories[currentFolderIndex + 1];
                    getFileList();
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

        private void btnBackFolder_Click(object sender, EventArgs e)
        {
            savedLabel.Visible = false;

            try
            {
                string parentDirectory = Directory.GetParent(selectedFolder).FullName;
                string[] subdirectories = Directory.GetDirectories(parentDirectory, "*", SearchOption.TopDirectoryOnly);
                Array.Sort(subdirectories);

                int currentFolderIndex = Array.IndexOf(subdirectories, selectedFolder);

                if (currentFolderIndex > 0)
                {
                    selectedFolder = subdirectories[currentFolderIndex - 1];
                    getFileList();
                }
                else
                {
                    MessageBox.Show("Already at the first folder in this directory.", "Start of Folders",
                                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            ReleaseFileHandles();
        }

        private void btnOpenSource_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(selectedFolder) && Directory.Exists(selectedFolder))
            {
                try
                {
                    if (fileList != null && currentIndex >= 0 && currentIndex < fileList.Count)
                    {
                        string arguments = $"/select, \"{fileList[currentIndex]}\"";
                        System.Diagnostics.Process.Start("explorer.exe", arguments);
                    }
                    else
                    {
                        System.Diagnostics.Process.Start(selectedFolder);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error opening folder: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("No folder is currently selected or folder doesn't exist.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void chkbxVideoSound_CheckedChanged(object sender, EventArgs e)
        {
            if (axWindowsMediaPlayer1.playState == WMPLib.WMPPlayState.wmppsPlaying)
            {
                axWindowsMediaPlayer1.settings.mute = !chkbxVideoSound.Checked;
            }
        }

        private void btnUnsave_Click(object sender, EventArgs e)
        {
            try
            {
                if (fileList == null || currentIndex < 0 || currentIndex >= fileList.Count)
                {
                    MessageBox.Show("No file is currently displayed.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                string currentFilePath = fileList[currentIndex];
                string saveFolder = Path.Combine(selectedFolder, "VMO_Saved");
                string fileName = Path.GetFileName(currentFilePath);
                string savedFilePath = Path.Combine(saveFolder, fileName);

                if (File.Exists(savedFilePath))
                {
                    File.Delete(savedFilePath);
                    savedLabel.Text = "Removed from saved!";
                    savedLabel.Visible = true;
                    btnUnsave.Enabled = false;
                }
                else
                {
                    savedLabel.Text = "Not found in saved folder.";
                    savedLabel.Visible = true;
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