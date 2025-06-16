namespace Visual_Media_Organizer
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            btnNext = new Button();
            btnSave = new Button();
            btnBack = new Button();
            btnSelectFolder = new Button();
            pictureBox = new PictureBox();
            folderBrowserDialog1 = new FolderBrowserDialog();
            savedLabel = new Label();
            btnClearCache = new Button();
            lblFileName = new Label();
            axWindowsMediaPlayer1 = new AxWMPLib.AxWindowsMediaPlayer();
            lblFilesView = new Label();
            btnKeybinds = new Button();
            comboBoxOrgType = new ComboBox();
            lblOrganizeType = new Label();
            btnRefresh = new Button();
            btnNextFolder = new Button();
            lblMediaType = new Label();
            comboBoxMediaType = new ComboBox();
            btnBackFolder = new Button();
            btnOpenSource = new Button();
            chkbxVideoSound = new CheckBox();
            btnUnsave = new Button();
            chkbxSaveNext = new CheckBox();
            lblSaveType = new Label();
            comboBoxSaveType = new ComboBox();
            ((System.ComponentModel.ISupportInitialize)pictureBox).BeginInit();
            ((System.ComponentModel.ISupportInitialize)axWindowsMediaPlayer1).BeginInit();
            SuspendLayout();
            // 
            // btnNext
            // 
            btnNext.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnNext.Enabled = false;
            btnNext.Font = new Font("Sitka Text", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnNext.Location = new Point(1424, 644);
            btnNext.Name = "btnNext";
            btnNext.Size = new Size(48, 25);
            btnNext.TabIndex = 4;
            btnNext.Text = "Next";
            btnNext.UseVisualStyleBackColor = true;
            btnNext.Click += btnNext_Click;
            // 
            // btnSave
            // 
            btnSave.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnSave.Enabled = false;
            btnSave.Font = new Font("Sitka Text", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnSave.Location = new Point(1370, 644);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(48, 25);
            btnSave.TabIndex = 5;
            btnSave.Text = "Save";
            btnSave.UseVisualStyleBackColor = true;
            btnSave.Click += btnSave_Click;
            // 
            // btnBack
            // 
            btnBack.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnBack.Enabled = false;
            btnBack.Font = new Font("Sitka Text", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnBack.Location = new Point(1244, 644);
            btnBack.Name = "btnBack";
            btnBack.Size = new Size(48, 25);
            btnBack.TabIndex = 6;
            btnBack.Text = "Back";
            btnBack.UseVisualStyleBackColor = true;
            btnBack.Click += btnBack_Click;
            // 
            // btnSelectFolder
            // 
            btnSelectFolder.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnSelectFolder.Font = new Font("Sitka Text", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnSelectFolder.Location = new Point(1226, 143);
            btnSelectFolder.Name = "btnSelectFolder";
            btnSelectFolder.Size = new Size(90, 25);
            btnSelectFolder.TabIndex = 7;
            btnSelectFolder.Text = "Select Folder";
            btnSelectFolder.UseVisualStyleBackColor = true;
            btnSelectFolder.Click += btnSelectFolder_Click;
            // 
            // pictureBox
            // 
            pictureBox.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            pictureBox.BorderStyle = BorderStyle.FixedSingle;
            pictureBox.Location = new Point(40, 12);
            pictureBox.Name = "pictureBox";
            pictureBox.Size = new Size(1180, 620);
            pictureBox.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox.TabIndex = 8;
            pictureBox.TabStop = false;
            // 
            // savedLabel
            // 
            savedLabel.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            savedLabel.AutoSize = true;
            savedLabel.Font = new Font("Sitka Text", 11.249999F, FontStyle.Bold, GraphicsUnit.Point, 0);
            savedLabel.Location = new Point(1244, 589);
            savedLabel.Name = "savedLabel";
            savedLabel.Size = new Size(60, 21);
            savedLabel.TabIndex = 9;
            savedLabel.Text = "Saved!";
            savedLabel.Visible = false;
            // 
            // btnClearCache
            // 
            btnClearCache.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnClearCache.Enabled = false;
            btnClearCache.Font = new Font("Sitka Text", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnClearCache.Location = new Point(1226, 174);
            btnClearCache.Name = "btnClearCache";
            btnClearCache.Size = new Size(90, 25);
            btnClearCache.TabIndex = 10;
            btnClearCache.Text = "Clear Cache";
            btnClearCache.UseVisualStyleBackColor = true;
            btnClearCache.Click += btnClearCache_Click;
            // 
            // lblFileName
            // 
            lblFileName.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            lblFileName.AutoSize = true;
            lblFileName.BackColor = Color.Transparent;
            lblFileName.Font = new Font("Sitka Text", 11.249999F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblFileName.Location = new Point(1, 651);
            lblFileName.Name = "lblFileName";
            lblFileName.Size = new Size(74, 21);
            lblFileName.TabIndex = 11;
            lblFileName.Text = "fileName";
            lblFileName.Visible = false;
            // 
            // axWindowsMediaPlayer1
            // 
            axWindowsMediaPlayer1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            axWindowsMediaPlayer1.Enabled = true;
            axWindowsMediaPlayer1.Location = new Point(40, 12);
            axWindowsMediaPlayer1.Name = "axWindowsMediaPlayer1";
            axWindowsMediaPlayer1.OcxState = (AxHost.State)resources.GetObject("axWindowsMediaPlayer1.OcxState");
            axWindowsMediaPlayer1.Size = new Size(1180, 620);
            axWindowsMediaPlayer1.TabIndex = 12;
            axWindowsMediaPlayer1.Visible = false;
            // 
            // lblFilesView
            // 
            lblFilesView.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            lblFilesView.AutoSize = true;
            lblFilesView.BackColor = Color.Transparent;
            lblFilesView.Font = new Font("Sitka Text", 11.249999F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblFilesView.Location = new Point(1, 634);
            lblFilesView.Name = "lblFilesView";
            lblFilesView.Size = new Size(38, 21);
            lblFilesView.TabIndex = 13;
            lblFilesView.Text = "N/A";
            lblFilesView.Visible = false;
            // 
            // btnKeybinds
            // 
            btnKeybinds.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnKeybinds.Font = new Font("Sitka Text", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnKeybinds.Location = new Point(1321, 143);
            btnKeybinds.Name = "btnKeybinds";
            btnKeybinds.Size = new Size(90, 25);
            btnKeybinds.TabIndex = 14;
            btnKeybinds.Text = "Keybinds";
            btnKeybinds.UseVisualStyleBackColor = true;
            btnKeybinds.Click += btnKeybinds_Click;
            // 
            // comboBoxOrgType
            // 
            comboBoxOrgType.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            comboBoxOrgType.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxOrgType.FormattingEnabled = true;
            comboBoxOrgType.Items.AddRange(new object[] { "Date Modified (Old->New)", "Date Modified (New->Old)", "Name (Z->A)", "Name (A->Z)", "Random" });
            comboBoxOrgType.Location = new Point(1226, 28);
            comboBoxOrgType.Name = "comboBoxOrgType";
            comboBoxOrgType.Size = new Size(174, 23);
            comboBoxOrgType.TabIndex = 15;
            // 
            // lblOrganizeType
            // 
            lblOrganizeType.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lblOrganizeType.AutoSize = true;
            lblOrganizeType.Location = new Point(1226, 12);
            lblOrganizeType.Name = "lblOrganizeType";
            lblOrganizeType.Size = new Size(82, 15);
            lblOrganizeType.TabIndex = 16;
            lblOrganizeType.Text = "Organize Type";
            // 
            // btnRefresh
            // 
            btnRefresh.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnRefresh.Enabled = false;
            btnRefresh.Location = new Point(1406, 54);
            btnRefresh.Name = "btnRefresh";
            btnRefresh.Size = new Size(54, 23);
            btnRefresh.TabIndex = 17;
            btnRefresh.Text = "Refresh";
            btnRefresh.UseVisualStyleBackColor = true;
            btnRefresh.Click += btnRefresh_Click;
            // 
            // btnNextFolder
            // 
            btnNextFolder.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnNextFolder.Enabled = false;
            btnNextFolder.Font = new Font("Sitka Text", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnNextFolder.Location = new Point(1333, 613);
            btnNextFolder.Name = "btnNextFolder";
            btnNextFolder.Size = new Size(83, 25);
            btnNextFolder.TabIndex = 19;
            btnNextFolder.Text = "Next Folder";
            btnNextFolder.UseVisualStyleBackColor = true;
            btnNextFolder.Click += btnNextFolder_Click;
            // 
            // lblMediaType
            // 
            lblMediaType.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lblMediaType.AutoSize = true;
            lblMediaType.Location = new Point(1226, 54);
            lblMediaType.Name = "lblMediaType";
            lblMediaType.Size = new Size(68, 15);
            lblMediaType.TabIndex = 21;
            lblMediaType.Text = "Media Type";
            // 
            // comboBoxMediaType
            // 
            comboBoxMediaType.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            comboBoxMediaType.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxMediaType.FormattingEnabled = true;
            comboBoxMediaType.Items.AddRange(new object[] { "Videos and Images", "Videos", "Images" });
            comboBoxMediaType.Location = new Point(1226, 71);
            comboBoxMediaType.Name = "comboBoxMediaType";
            comboBoxMediaType.Size = new Size(142, 23);
            comboBoxMediaType.TabIndex = 20;
            // 
            // btnBackFolder
            // 
            btnBackFolder.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnBackFolder.Enabled = false;
            btnBackFolder.Font = new Font("Sitka Text", 8.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnBackFolder.Location = new Point(1244, 613);
            btnBackFolder.Name = "btnBackFolder";
            btnBackFolder.Size = new Size(83, 25);
            btnBackFolder.TabIndex = 22;
            btnBackFolder.Text = "Back Folder";
            btnBackFolder.UseVisualStyleBackColor = true;
            btnBackFolder.Click += btnBackFolder_Click;
            // 
            // btnOpenSource
            // 
            btnOpenSource.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnOpenSource.Font = new Font("Sitka Text", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnOpenSource.Location = new Point(1322, 174);
            btnOpenSource.Name = "btnOpenSource";
            btnOpenSource.Size = new Size(90, 25);
            btnOpenSource.TabIndex = 23;
            btnOpenSource.Text = "Open Source";
            btnOpenSource.UseVisualStyleBackColor = true;
            btnOpenSource.Click += btnOpenSource_Click;
            // 
            // chkbxVideoSound
            // 
            chkbxVideoSound.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            chkbxVideoSound.Checked = true;
            chkbxVideoSound.CheckState = CheckState.Checked;
            chkbxVideoSound.Location = new Point(1226, 205);
            chkbxVideoSound.Name = "chkbxVideoSound";
            chkbxVideoSound.Size = new Size(93, 19);
            chkbxVideoSound.TabIndex = 24;
            chkbxVideoSound.Text = "Mute Video";
            chkbxVideoSound.UseVisualStyleBackColor = true;
            chkbxVideoSound.CheckedChanged += chkbxVideoSound_CheckedChanged;
            // 
            // btnUnsave
            // 
            btnUnsave.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnUnsave.Enabled = false;
            btnUnsave.Font = new Font("Sitka Text", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnUnsave.Location = new Point(1298, 644);
            btnUnsave.Name = "btnUnsave";
            btnUnsave.Size = new Size(66, 25);
            btnUnsave.TabIndex = 25;
            btnUnsave.Text = "Unsave";
            btnUnsave.UseVisualStyleBackColor = true;
            btnUnsave.Click += btnUnsave_Click;
            // 
            // chkbxSaveNext
            // 
            chkbxSaveNext.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            chkbxSaveNext.BackColor = Color.Transparent;
            chkbxSaveNext.Location = new Point(1226, 230);
            chkbxSaveNext.Name = "chkbxSaveNext";
            chkbxSaveNext.Size = new Size(111, 19);
            chkbxSaveNext.TabIndex = 26;
            chkbxSaveNext.Text = "Save Goto Next";
            chkbxSaveNext.UseVisualStyleBackColor = false;
            // 
            // lblSaveType
            // 
            lblSaveType.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lblSaveType.AutoSize = true;
            lblSaveType.Location = new Point(1226, 97);
            lblSaveType.Name = "lblSaveType";
            lblSaveType.Size = new Size(59, 15);
            lblSaveType.TabIndex = 28;
            lblSaveType.Text = "Save Type";
            // 
            // comboBoxSaveType
            // 
            comboBoxSaveType.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            comboBoxSaveType.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxSaveType.FormattingEnabled = true;
            comboBoxSaveType.Items.AddRange(new object[] { "Copy", "Move" });
            comboBoxSaveType.Location = new Point(1226, 114);
            comboBoxSaveType.Name = "comboBoxSaveType";
            comboBoxSaveType.Size = new Size(142, 23);
            comboBoxSaveType.TabIndex = 27;
            // 
            // Form1
            // 
            AutoScaleMode = AutoScaleMode.None;
            ClientSize = new Size(1484, 681);
            Controls.Add(lblSaveType);
            Controls.Add(comboBoxSaveType);
            Controls.Add(chkbxSaveNext);
            Controls.Add(btnUnsave);
            Controls.Add(chkbxVideoSound);
            Controls.Add(btnOpenSource);
            Controls.Add(btnBackFolder);
            Controls.Add(lblMediaType);
            Controls.Add(comboBoxMediaType);
            Controls.Add(btnNextFolder);
            Controls.Add(btnRefresh);
            Controls.Add(lblOrganizeType);
            Controls.Add(comboBoxOrgType);
            Controls.Add(btnKeybinds);
            Controls.Add(lblFilesView);
            Controls.Add(axWindowsMediaPlayer1);
            Controls.Add(lblFileName);
            Controls.Add(btnClearCache);
            Controls.Add(savedLabel);
            Controls.Add(pictureBox);
            Controls.Add(btnSelectFolder);
            Controls.Add(btnBack);
            Controls.Add(btnSave);
            Controls.Add(btnNext);
            Icon = (Icon)resources.GetObject("$this.Icon");
            MinimumSize = new Size(960, 540);
            Name = "Form1";
            Text = "Visual Media Organizer";
            ((System.ComponentModel.ISupportInitialize)pictureBox).EndInit();
            ((System.ComponentModel.ISupportInitialize)axWindowsMediaPlayer1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnNext;
        private Button btnSave;
        private Button btnBack;
        private Button btnSelectFolder;
        private PictureBox pictureBox;
        private FolderBrowserDialog folderBrowserDialog1;
        private Label savedLabel;
        private Button btnClearCache;
        private Label lblFileName;
        private AxWMPLib.AxWindowsMediaPlayer axWindowsMediaPlayer1;
        private Label lblFilesView;
        private Button btnKeybinds;
        private ComboBox comboBoxOrgType;
        private Label lblOrganizeType;
        private Button btnRefresh;
        private Button btnNextFolder;
        private Label lblMediaType;
        private ComboBox comboBoxMediaType;
        private Button btnBackFolder;
        private Button btnOpenSource;
        private CheckBox chkbxVideoSound;
        private Button btnUnsave;
        private CheckBox chkbxSaveNext;
        private Label lblSaveType;
        private ComboBox comboBoxSaveType;
    }
}
