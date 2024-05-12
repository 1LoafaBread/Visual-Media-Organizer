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
            ((System.ComponentModel.ISupportInitialize)pictureBox).BeginInit();
            ((System.ComponentModel.ISupportInitialize)axWindowsMediaPlayer1).BeginInit();
            SuspendLayout();
            // 
            // btnNext
            // 
            btnNext.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btnNext.Enabled = false;
            btnNext.Font = new Font("Sitka Text", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnNext.Location = new Point(120, 413);
            btnNext.Name = "btnNext";
            btnNext.Size = new Size(48, 25);
            btnNext.TabIndex = 4;
            btnNext.Text = "Next";
            btnNext.UseVisualStyleBackColor = true;
            btnNext.Click += btnNext_Click;
            // 
            // btnSave
            // 
            btnSave.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btnSave.Enabled = false;
            btnSave.Font = new Font("Sitka Text", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnSave.Location = new Point(66, 413);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(48, 25);
            btnSave.TabIndex = 5;
            btnSave.Text = "Save";
            btnSave.UseVisualStyleBackColor = true;
            btnSave.Click += btnSave_Click;
            // 
            // btnBack
            // 
            btnBack.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btnBack.Enabled = false;
            btnBack.Font = new Font("Sitka Text", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnBack.Location = new Point(12, 413);
            btnBack.Name = "btnBack";
            btnBack.Size = new Size(48, 25);
            btnBack.TabIndex = 6;
            btnBack.Text = "Back";
            btnBack.UseVisualStyleBackColor = true;
            btnBack.Click += btnBack_Click;
            // 
            // btnSelectFolder
            // 
            btnSelectFolder.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnSelectFolder.Font = new Font("Sitka Text", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnSelectFolder.Location = new Point(698, 413);
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
            pictureBox.Location = new Point(12, 12);
            pictureBox.Name = "pictureBox";
            pictureBox.Size = new Size(776, 395);
            pictureBox.TabIndex = 8;
            pictureBox.TabStop = false;
            // 
            // savedLabel
            // 
            savedLabel.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            savedLabel.AutoSize = true;
            savedLabel.Font = new Font("Sitka Text", 11.249999F, FontStyle.Bold, GraphicsUnit.Point, 0);
            savedLabel.Location = new Point(174, 408);
            savedLabel.Name = "savedLabel";
            savedLabel.Size = new Size(60, 21);
            savedLabel.TabIndex = 9;
            savedLabel.Text = "Saved!";
            savedLabel.Visible = false;
            // 
            // btnClearCache
            // 
            btnClearCache.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnClearCache.Enabled = false;
            btnClearCache.Font = new Font("Sitka Text", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnClearCache.Location = new Point(602, 413);
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
            lblFileName.Font = new Font("Sitka Text", 11.249999F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblFileName.Location = new Point(174, 429);
            lblFileName.Name = "lblFileName";
            lblFileName.Size = new Size(78, 21);
            lblFileName.TabIndex = 11;
            lblFileName.Text = "fileName";
            lblFileName.Visible = false;
            // 
            // axWindowsMediaPlayer1
            // 
            axWindowsMediaPlayer1.Enabled = true;
            axWindowsMediaPlayer1.Location = new Point(12, 12);
            axWindowsMediaPlayer1.Name = "axWindowsMediaPlayer1";
            axWindowsMediaPlayer1.OcxState = (AxHost.State)resources.GetObject("axWindowsMediaPlayer1.OcxState");
            axWindowsMediaPlayer1.Size = new Size(776, 395);
            axWindowsMediaPlayer1.TabIndex = 12;
            axWindowsMediaPlayer1.Visible = false;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoSize = true;
            ClientSize = new Size(800, 450);
            Controls.Add(axWindowsMediaPlayer1);
            Controls.Add(lblFileName);
            Controls.Add(btnClearCache);
            Controls.Add(savedLabel);
            Controls.Add(pictureBox);
            Controls.Add(btnSelectFolder);
            Controls.Add(btnBack);
            Controls.Add(btnSave);
            Controls.Add(btnNext);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "Form1";
            Text = "Visual Media Organizer";
            FormClosing += Form1_FormClosing;
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
    }
}
