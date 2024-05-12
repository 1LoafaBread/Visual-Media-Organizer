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

        public Form1()
        {
            InitializeComponent();

            this.FormClosing += Form1_FormClosing;

            LoadViewedFiles();
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
            fileList = Directory.GetFiles(selectedFolder, "*.*", SearchOption.AllDirectories)
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
                    displayFile(fileList[currentIndex]);

                    btnClearCache.Enabled = true;
                    btnNext.Enabled = true;
                    btnSave.Enabled = true;
                    btnBack.Enabled = true;
                }
                else
                {
                    MessageBox.Show("No image or video files found in the selected folder.", "No Files Found", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                    string prevFilePath = fileList[currentIndex-1];

                    displayFile(filePath);

                    savedLabel.Visible = false;
                    viewedFiles.FolderPaths[Path.GetDirectoryName(prevFilePath)].Add(prevFilePath);
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
            if (fileList != null && fileList.Count > 0)
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
        }

        //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

        private void displayFile(string filePath)
        {
            if (File.Exists(filePath))
            {
                if (pictureBox.Image != null)
                {
                    pictureBox.Image.Dispose();
                }

                lblFileName.Text = Path.GetFileName(filePath);
                lblFileName.Visible = true;

                axWindowsMediaPlayer1.close();

                if (filePath.ToLower().EndsWith(".jpg") || filePath.ToLower().EndsWith(".png") ||
                    filePath.ToLower().EndsWith(".bmp") || filePath.ToLower().EndsWith(".gif"))
                {
                    pictureBox.SizeMode = PictureBoxSizeMode.Zoom;
                    pictureBox.Image = new Bitmap(filePath);
                    pictureBox.Visible = true;

                    axWindowsMediaPlayer1.Visible = false;
                }
                else if (filePath.ToLower().EndsWith(".mp4") || filePath.ToLower().EndsWith(".avi") ||
                         filePath.ToLower().EndsWith(".mov") || filePath.ToLower().EndsWith(".wmv"))
                {
                    pictureBox.Visible = false;
                    axWindowsMediaPlayer1.Visible = true;

                    axWindowsMediaPlayer1.uiMode = "none";
                    axWindowsMediaPlayer1.URL = filePath;
                    axWindowsMediaPlayer1.settings.autoStart = true;
                    axWindowsMediaPlayer1.stretchToFit = true;
                    axWindowsMediaPlayer1.settings.setMode("loop", true);

                }
            }
        }

        //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            SaveViewedFiles();
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
