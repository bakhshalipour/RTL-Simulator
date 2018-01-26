namespace RTLSimulatorV1._0
{
    partial class Form3
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form3));
            this.SaveButton = new System.Windows.Forms.Button();
            this.AssembleButton = new System.Windows.Forms.Button();
            this.RunButton = new System.Windows.Forms.Button();
            this.ClearButton = new System.Windows.Forms.Button();
            this.ReturnButton = new System.Windows.Forms.Button();
            this.regDef = new System.Windows.Forms.GroupBox();
            this.ValTextBox = new System.Windows.Forms.TextBox();
            this.RegTextBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.TextTextBox = new System.Windows.Forms.TextBox();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.debugButton = new System.Windows.Forms.Button();
            this.regDef.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // SaveButton
            // 
            this.SaveButton.AccessibleName = "NewProject";
            this.SaveButton.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.SaveButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.SaveButton.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.SaveButton.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.ControlLightLight;
            this.SaveButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.SaveButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.SaveButton.Font = new System.Drawing.Font("Segoe UI Symbol", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SaveButton.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.SaveButton.Image = global::RTLSimulatorV1._0.Properties.Resources.floppy_drive_5_14_icon;
            this.SaveButton.Location = new System.Drawing.Point(12, 12);
            this.SaveButton.Name = "SaveButton";
            this.SaveButton.Size = new System.Drawing.Size(152, 154);
            this.SaveButton.TabIndex = 1;
            this.SaveButton.Text = "Save File";
            this.SaveButton.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.SaveButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.SaveButton.UseVisualStyleBackColor = false;
            this.SaveButton.Click += new System.EventHandler(this.SaveButton_Click);
            this.SaveButton.MouseEnter += new System.EventHandler(this.SaveButton_MouseEnter);
            this.SaveButton.MouseLeave += new System.EventHandler(this.SaveButton_MouseLeave);
            // 
            // AssembleButton
            // 
            this.AssembleButton.AccessibleName = "NewProject";
            this.AssembleButton.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.AssembleButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.AssembleButton.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.AssembleButton.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.ControlLightLight;
            this.AssembleButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.AssembleButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.AssembleButton.Font = new System.Drawing.Font("Segoe UI Symbol", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AssembleButton.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.AssembleButton.Image = global::RTLSimulatorV1._0.Properties.Resources.Settings_icon;
            this.AssembleButton.Location = new System.Drawing.Point(208, 12);
            this.AssembleButton.Name = "AssembleButton";
            this.AssembleButton.Size = new System.Drawing.Size(137, 154);
            this.AssembleButton.TabIndex = 2;
            this.AssembleButton.Text = "Assemble";
            this.AssembleButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.AssembleButton.UseVisualStyleBackColor = false;
            this.AssembleButton.Click += new System.EventHandler(this.AssembleButton_Click);
            this.AssembleButton.MouseEnter += new System.EventHandler(this.AssembleButton_MouseEnter);
            this.AssembleButton.MouseLeave += new System.EventHandler(this.AssembleButton_MouseLeave);
            // 
            // RunButton
            // 
            this.RunButton.AccessibleName = "NewProject";
            this.RunButton.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.RunButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.RunButton.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.RunButton.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.ControlLightLight;
            this.RunButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.RunButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.RunButton.Font = new System.Drawing.Font("Segoe UI Symbol", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RunButton.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.RunButton.Image = global::RTLSimulatorV1._0.Properties.Resources.System_run_icon;
            this.RunButton.Location = new System.Drawing.Point(401, 12);
            this.RunButton.Name = "RunButton";
            this.RunButton.Size = new System.Drawing.Size(144, 154);
            this.RunButton.TabIndex = 3;
            this.RunButton.Text = "Run";
            this.RunButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.RunButton.UseVisualStyleBackColor = false;
            this.RunButton.Click += new System.EventHandler(this.RunButton_Click);
            this.RunButton.MouseEnter += new System.EventHandler(this.RunButton_MouseEnter);
            this.RunButton.MouseLeave += new System.EventHandler(this.RunButton_MouseLeave);
            // 
            // ClearButton
            // 
            this.ClearButton.AccessibleName = "NewProject";
            this.ClearButton.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ClearButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClearButton.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.ClearButton.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ClearButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.ClearButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ClearButton.Font = new System.Drawing.Font("Segoe UI Symbol", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ClearButton.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.ClearButton.Image = global::RTLSimulatorV1._0.Properties.Resources.clear_icon;
            this.ClearButton.Location = new System.Drawing.Point(748, 12);
            this.ClearButton.Name = "ClearButton";
            this.ClearButton.Size = new System.Drawing.Size(147, 154);
            this.ClearButton.TabIndex = 4;
            this.ClearButton.Text = "Clear All";
            this.ClearButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.ClearButton.UseVisualStyleBackColor = false;
            this.ClearButton.Click += new System.EventHandler(this.ClearButton_Click);
            this.ClearButton.MouseEnter += new System.EventHandler(this.ClearButton_MouseEnter);
            this.ClearButton.MouseLeave += new System.EventHandler(this.ClearButton_MouseLeave);
            // 
            // ReturnButton
            // 
            this.ReturnButton.AccessibleName = "NewProject";
            this.ReturnButton.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ReturnButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ReturnButton.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.ReturnButton.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ReturnButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.ReturnButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ReturnButton.Font = new System.Drawing.Font("Segoe UI Symbol", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ReturnButton.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.ReturnButton.Image = global::RTLSimulatorV1._0.Properties.Resources.Arrow_Back_icon;
            this.ReturnButton.Location = new System.Drawing.Point(901, 12);
            this.ReturnButton.Name = "ReturnButton";
            this.ReturnButton.Size = new System.Drawing.Size(152, 154);
            this.ReturnButton.TabIndex = 5;
            this.ReturnButton.Text = "Return";
            this.ReturnButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.ReturnButton.UseVisualStyleBackColor = false;
            this.ReturnButton.Click += new System.EventHandler(this.ReturnButton_Click);
            this.ReturnButton.MouseEnter += new System.EventHandler(this.ReturnButton_MouseEnter);
            this.ReturnButton.MouseLeave += new System.EventHandler(this.ReturnButton_MouseLeave);
            // 
            // regDef
            // 
            this.regDef.Controls.Add(this.ValTextBox);
            this.regDef.Controls.Add(this.RegTextBox);
            this.regDef.Controls.Add(this.label2);
            this.regDef.Controls.Add(this.label1);
            this.regDef.Location = new System.Drawing.Point(12, 229);
            this.regDef.Name = "regDef";
            this.regDef.Size = new System.Drawing.Size(1047, 86);
            this.regDef.TabIndex = 6;
            this.regDef.TabStop = false;
            this.regDef.Text = "Hardware Definition";
            // 
            // ValTextBox
            // 
            this.ValTextBox.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ValTextBox.Location = new System.Drawing.Point(91, 53);
            this.ValTextBox.Name = "ValTextBox";
            this.ValTextBox.Size = new System.Drawing.Size(950, 22);
            this.ValTextBox.TabIndex = 8;
            this.ValTextBox.TextChanged += new System.EventHandler(this.ValTextBox_TextChanged);
            // 
            // RegTextBox
            // 
            this.RegTextBox.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RegTextBox.Location = new System.Drawing.Point(91, 22);
            this.RegTextBox.Name = "RegTextBox";
            this.RegTextBox.Size = new System.Drawing.Size(950, 22);
            this.RegTextBox.TabIndex = 7;
            this.RegTextBox.TextChanged += new System.EventHandler(this.RegTextBox_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 56);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(79, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "Initial Value(s)";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(60, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Register(s)";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.TextTextBox);
            this.groupBox1.Location = new System.Drawing.Point(12, 332);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1047, 317);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "RTL Text";
            // 
            // TextTextBox
            // 
            this.TextTextBox.AcceptsReturn = true;
            this.TextTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.TextTextBox.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TextTextBox.ForeColor = System.Drawing.SystemColors.WindowText;
            this.TextTextBox.Location = new System.Drawing.Point(6, 21);
            this.TextTextBox.Multiline = true;
            this.TextTextBox.Name = "TextTextBox";
            this.TextTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.TextTextBox.Size = new System.Drawing.Size(1035, 290);
            this.TextTextBox.TabIndex = 0;
            this.TextTextBox.TextChanged += new System.EventHandler(this.TextTextBox_TextChanged);
            // 
            // saveFileDialog1
            // 
            this.saveFileDialog1.DefaultExt = "txt";
            this.saveFileDialog1.FileName = "MyRTLCode.txt";
            this.saveFileDialog1.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*";
            this.saveFileDialog1.FileOk += new System.ComponentModel.CancelEventHandler(this.saveFileDialog1_FileOk);
            // 
            // debugButton
            // 
            this.debugButton.AccessibleName = "NewProject";
            this.debugButton.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.debugButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.debugButton.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.debugButton.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.ControlLightLight;
            this.debugButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.debugButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.debugButton.Font = new System.Drawing.Font("Segoe UI Symbol", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.debugButton.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.debugButton.Image = global::RTLSimulatorV1._0.Properties.Resources.debug;
            this.debugButton.Location = new System.Drawing.Point(577, 12);
            this.debugButton.Name = "debugButton";
            this.debugButton.Size = new System.Drawing.Size(147, 154);
            this.debugButton.TabIndex = 9;
            this.debugButton.Text = "Debug";
            this.debugButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.debugButton.UseVisualStyleBackColor = false;
            this.debugButton.Click += new System.EventHandler(this.button2_Click);
            this.debugButton.MouseEnter += new System.EventHandler(this.button2_MouseEnter);
            this.debugButton.MouseLeave += new System.EventHandler(this.button2_MouseLeave);
            // 
            // Form3
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.HighlightText;
            this.ClientSize = new System.Drawing.Size(1071, 661);
            this.Controls.Add(this.debugButton);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.regDef);
            this.Controls.Add(this.ReturnButton);
            this.Controls.Add(this.ClearButton);
            this.Controls.Add(this.RunButton);
            this.Controls.Add(this.AssembleButton);
            this.Controls.Add(this.SaveButton);
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Form3";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "New RTL File";
            this.regDef.ResumeLayout(false);
            this.regDef.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.Button SaveButton;
        public System.Windows.Forms.Button AssembleButton;
        public System.Windows.Forms.Button RunButton;
        public System.Windows.Forms.Button ClearButton;
        public System.Windows.Forms.Button ReturnButton;
        public System.Windows.Forms.GroupBox regDef;
        public System.Windows.Forms.Label label2;
        public System.Windows.Forms.Label label1;
        public System.Windows.Forms.TextBox ValTextBox;
        public System.Windows.Forms.TextBox RegTextBox;
        public System.Windows.Forms.GroupBox groupBox1;
        public System.Windows.Forms.TextBox TextTextBox;
        public System.Windows.Forms.SaveFileDialog saveFileDialog1;
        public System.Windows.Forms.Button debugButton;
    }
}