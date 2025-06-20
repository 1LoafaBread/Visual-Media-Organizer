﻿namespace Visual_Media_Organizer
{
    partial class HotKeyForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(HotKeyForm));
            txtboxBackKeybind = new TextBox();
            txtboxSaveKeybind = new TextBox();
            txtboxNextKeybind = new TextBox();
            lblBack = new Label();
            lblSave = new Label();
            lblNext = new Label();
            btnBackChange = new Button();
            btnSaveChange = new Button();
            btnNextChange = new Button();
            lblStatus = new Label();
            btnNextFolderChange = new Button();
            lblNextFolder = new Label();
            txtboxNextFolderKeybind = new TextBox();
            btnBackFolderChange = new Button();
            lblBackFolder = new Label();
            txtboxBackFolderKeybind = new TextBox();
            btnUnsaveChange = new Button();
            lblUnsave = new Label();
            txtboxUnsaveKeybind = new TextBox();
            SuspendLayout();
            // 
            // txtboxBackKeybind
            // 
            txtboxBackKeybind.Enabled = false;
            txtboxBackKeybind.Location = new Point(12, 152);
            txtboxBackKeybind.Name = "txtboxBackKeybind";
            txtboxBackKeybind.PlaceholderText = "None";
            txtboxBackKeybind.ReadOnly = true;
            txtboxBackKeybind.Size = new Size(100, 23);
            txtboxBackKeybind.TabIndex = 0;
            // 
            // txtboxSaveKeybind
            // 
            txtboxSaveKeybind.Enabled = false;
            txtboxSaveKeybind.Location = new Point(12, 93);
            txtboxSaveKeybind.Name = "txtboxSaveKeybind";
            txtboxSaveKeybind.PlaceholderText = "None";
            txtboxSaveKeybind.ReadOnly = true;
            txtboxSaveKeybind.Size = new Size(100, 23);
            txtboxSaveKeybind.TabIndex = 1;
            // 
            // txtboxNextKeybind
            // 
            txtboxNextKeybind.Enabled = false;
            txtboxNextKeybind.Location = new Point(12, 35);
            txtboxNextKeybind.Name = "txtboxNextKeybind";
            txtboxNextKeybind.PlaceholderText = "None";
            txtboxNextKeybind.ReadOnly = true;
            txtboxNextKeybind.Size = new Size(100, 23);
            txtboxNextKeybind.TabIndex = 2;
            // 
            // lblBack
            // 
            lblBack.AutoSize = true;
            lblBack.Font = new Font("Sitka Small", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblBack.Location = new Point(12, 126);
            lblBack.Name = "lblBack";
            lblBack.Size = new Size(48, 21);
            lblBack.TabIndex = 3;
            lblBack.Text = "Back";
            // 
            // lblSave
            // 
            lblSave.AutoSize = true;
            lblSave.Font = new Font("Sitka Small", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblSave.Location = new Point(12, 67);
            lblSave.Name = "lblSave";
            lblSave.Size = new Size(47, 21);
            lblSave.TabIndex = 4;
            lblSave.Text = "Save";
            // 
            // lblNext
            // 
            lblNext.AutoSize = true;
            lblNext.Font = new Font("Sitka Small", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblNext.Location = new Point(12, 9);
            lblNext.Name = "lblNext";
            lblNext.Size = new Size(47, 21);
            lblNext.TabIndex = 5;
            lblNext.Text = "Next";
            // 
            // btnBackChange
            // 
            btnBackChange.Location = new Point(118, 151);
            btnBackChange.Name = "btnBackChange";
            btnBackChange.Size = new Size(75, 23);
            btnBackChange.TabIndex = 6;
            btnBackChange.Text = "Change";
            btnBackChange.UseVisualStyleBackColor = true;
            btnBackChange.Click += btnBackChange_Click;
            // 
            // btnSaveChange
            // 
            btnSaveChange.Location = new Point(118, 93);
            btnSaveChange.Name = "btnSaveChange";
            btnSaveChange.Size = new Size(75, 23);
            btnSaveChange.TabIndex = 7;
            btnSaveChange.Text = "Change";
            btnSaveChange.UseVisualStyleBackColor = true;
            btnSaveChange.Click += btnSaveChange_Click;
            // 
            // btnNextChange
            // 
            btnNextChange.Location = new Point(118, 35);
            btnNextChange.Name = "btnNextChange";
            btnNextChange.Size = new Size(75, 23);
            btnNextChange.TabIndex = 8;
            btnNextChange.Text = "Change";
            btnNextChange.UseVisualStyleBackColor = true;
            btnNextChange.Click += btnNextChange_Click;
            // 
            // lblStatus
            // 
            lblStatus.AutoSize = true;
            lblStatus.Font = new Font("Stencil", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblStatus.Location = new Point(137, 183);
            lblStatus.Name = "lblStatus";
            lblStatus.Size = new Size(109, 18);
            lblStatus.TabIndex = 9;
            lblStatus.Text = "Status: None";
            // 
            // btnNextFolderChange
            // 
            btnNextFolderChange.Location = new Point(305, 35);
            btnNextFolderChange.Name = "btnNextFolderChange";
            btnNextFolderChange.Size = new Size(75, 23);
            btnNextFolderChange.TabIndex = 12;
            btnNextFolderChange.Text = "Change";
            btnNextFolderChange.UseVisualStyleBackColor = true;
            btnNextFolderChange.Click += btnNextFolderChange_Click;
            // 
            // lblNextFolder
            // 
            lblNextFolder.AutoSize = true;
            lblNextFolder.Font = new Font("Sitka Small", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblNextFolder.Location = new Point(199, 9);
            lblNextFolder.Name = "lblNextFolder";
            lblNextFolder.Size = new Size(105, 21);
            lblNextFolder.TabIndex = 11;
            lblNextFolder.Text = "Next Folder";
            // 
            // txtboxNextFolderKeybind
            // 
            txtboxNextFolderKeybind.Enabled = false;
            txtboxNextFolderKeybind.Location = new Point(199, 35);
            txtboxNextFolderKeybind.Name = "txtboxNextFolderKeybind";
            txtboxNextFolderKeybind.PlaceholderText = "None";
            txtboxNextFolderKeybind.ReadOnly = true;
            txtboxNextFolderKeybind.Size = new Size(100, 23);
            txtboxNextFolderKeybind.TabIndex = 10;
            // 
            // btnBackFolderChange
            // 
            btnBackFolderChange.Location = new Point(305, 93);
            btnBackFolderChange.Name = "btnBackFolderChange";
            btnBackFolderChange.Size = new Size(75, 23);
            btnBackFolderChange.TabIndex = 15;
            btnBackFolderChange.Text = "Change";
            btnBackFolderChange.UseVisualStyleBackColor = true;
            btnBackFolderChange.Click += btnBackFolderChange_Click;
            // 
            // lblBackFolder
            // 
            lblBackFolder.AutoSize = true;
            lblBackFolder.Font = new Font("Sitka Small", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblBackFolder.Location = new Point(199, 67);
            lblBackFolder.Name = "lblBackFolder";
            lblBackFolder.Size = new Size(106, 21);
            lblBackFolder.TabIndex = 14;
            lblBackFolder.Text = "Back Folder";
            // 
            // txtboxBackFolderKeybind
            // 
            txtboxBackFolderKeybind.Enabled = false;
            txtboxBackFolderKeybind.Location = new Point(199, 93);
            txtboxBackFolderKeybind.Name = "txtboxBackFolderKeybind";
            txtboxBackFolderKeybind.PlaceholderText = "None";
            txtboxBackFolderKeybind.ReadOnly = true;
            txtboxBackFolderKeybind.Size = new Size(100, 23);
            txtboxBackFolderKeybind.TabIndex = 13;
            // 
            // btnUnsaveChange
            // 
            btnUnsaveChange.Location = new Point(305, 152);
            btnUnsaveChange.Name = "btnUnsaveChange";
            btnUnsaveChange.Size = new Size(75, 23);
            btnUnsaveChange.TabIndex = 18;
            btnUnsaveChange.Text = "Change";
            btnUnsaveChange.UseVisualStyleBackColor = true;
            btnUnsaveChange.Click += btnUnsave_Click;
            // 
            // lblUnsave
            // 
            lblUnsave.AutoSize = true;
            lblUnsave.Font = new Font("Sitka Small", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblUnsave.Location = new Point(199, 126);
            lblUnsave.Name = "lblUnsave";
            lblUnsave.Size = new Size(67, 21);
            lblUnsave.TabIndex = 17;
            lblUnsave.Text = "Unsave";
            // 
            // txtboxUnsaveKeybind
            // 
            txtboxUnsaveKeybind.Enabled = false;
            txtboxUnsaveKeybind.Location = new Point(199, 152);
            txtboxUnsaveKeybind.Name = "txtboxUnsaveKeybind";
            txtboxUnsaveKeybind.PlaceholderText = "None";
            txtboxUnsaveKeybind.ReadOnly = true;
            txtboxUnsaveKeybind.Size = new Size(100, 23);
            txtboxUnsaveKeybind.TabIndex = 16;
            // 
            // HotKeyForm
            // 
            AutoScaleMode = AutoScaleMode.None;
            ClientSize = new Size(393, 210);
            Controls.Add(btnUnsaveChange);
            Controls.Add(lblUnsave);
            Controls.Add(txtboxUnsaveKeybind);
            Controls.Add(btnBackFolderChange);
            Controls.Add(lblBackFolder);
            Controls.Add(txtboxBackFolderKeybind);
            Controls.Add(btnNextFolderChange);
            Controls.Add(lblNextFolder);
            Controls.Add(txtboxNextFolderKeybind);
            Controls.Add(lblStatus);
            Controls.Add(btnNextChange);
            Controls.Add(btnSaveChange);
            Controls.Add(btnBackChange);
            Controls.Add(lblNext);
            Controls.Add(lblSave);
            Controls.Add(lblBack);
            Controls.Add(txtboxNextKeybind);
            Controls.Add(txtboxSaveKeybind);
            Controls.Add(txtboxBackKeybind);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            KeyPreview = true;
            MaximizeBox = false;
            MinimizeBox = false;
            MinimumSize = new Size(226, 240);
            Name = "HotKeyForm";
            Text = "Keybinds";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtboxBackKeybind;
        private TextBox txtboxSaveKeybind;
        private TextBox txtboxNextKeybind;
        private Label lblBack;
        private Label lblSave;
        private Label lblNext;
        private Button btnBackChange;
        private Button btnSaveChange;
        private Button btnNextChange;
        private Label lblStatus;
        private Button btnNextFolderChange;
        private Label lblNextFolder;
        private TextBox txtboxNextFolderKeybind;
        private Button btnBackFolderChange;
        private Label lblBackFolder;
        private TextBox txtboxBackFolderKeybind;
        private Button btnUnsaveChange;
        private Label lblUnsave;
        private TextBox txtboxUnsaveKeybind;
    }
}