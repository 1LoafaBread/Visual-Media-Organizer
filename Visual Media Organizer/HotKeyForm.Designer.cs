namespace Visual_Media_Organizer
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
            lblBack.Size = new Size(48, 23);
            lblBack.TabIndex = 3;
            lblBack.Text = "Back";
            // 
            // lblSave
            // 
            lblSave.AutoSize = true;
            lblSave.Font = new Font("Sitka Small", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblSave.Location = new Point(12, 67);
            lblSave.Name = "lblSave";
            lblSave.Size = new Size(47, 23);
            lblSave.TabIndex = 4;
            lblSave.Text = "Save";
            // 
            // lblNext
            // 
            lblNext.AutoSize = true;
            lblNext.Font = new Font("Sitka Small", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblNext.Location = new Point(12, 9);
            lblNext.Name = "lblNext";
            lblNext.Size = new Size(47, 23);
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
            lblStatus.Location = new Point(40, 178);
            lblStatus.Name = "lblStatus";
            lblStatus.Size = new Size(109, 18);
            lblStatus.TabIndex = 9;
            lblStatus.Text = "Status: None";
            // 
            // HotKeyForm
            // 
            AutoScaleMode = AutoScaleMode.None;
            ClientSize = new Size(210, 201);
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
            MaximumSize = new Size(226, 240);
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
    }
}