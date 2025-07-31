namespace ColorReductionTool
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
            MaximumResComboBox = new ComboBox();
            MaximumResLabel = new Label();
            BorderCheckBox = new CheckBox();
            SuspendLayout();
            // 
            // MaximumResComboBox
            // 
            MaximumResComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            MaximumResComboBox.FormattingEnabled = true;
            MaximumResComboBox.Items.AddRange(new object[] { "変換なし", "1920 x 1080", "1280 x 720", " 960 x 960", " 720 x 480", " 640 x 480", " 320 x 240" });
            MaximumResComboBox.Location = new Point(97, 22);
            MaximumResComboBox.Name = "MaximumResComboBox";
            MaximumResComboBox.Size = new Size(201, 23);
            MaximumResComboBox.TabIndex = 0;
            // 
            // MaximumResLabel
            // 
            MaximumResLabel.AutoSize = true;
            MaximumResLabel.Location = new Point(24, 25);
            MaximumResLabel.Name = "MaximumResLabel";
            MaximumResLabel.Size = new Size(67, 15);
            MaximumResLabel.TabIndex = 1;
            MaximumResLabel.Text = "最大解像度";
            // 
            // BorderCheckBox
            // 
            BorderCheckBox.AutoSize = true;
            BorderCheckBox.Location = new Point(24, 65);
            BorderCheckBox.Name = "BorderCheckBox";
            BorderCheckBox.Size = new Size(97, 19);
            BorderCheckBox.TabIndex = 2;
            BorderCheckBox.Text = "縁取りを付ける";
            BorderCheckBox.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            AllowDrop = true;
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(320, 240);
            Controls.Add(BorderCheckBox);
            Controls.Add(MaximumResLabel);
            Controls.Add(MaximumResComboBox);
            Name = "Form1";
            Text = "画像減色ツール";
            FormClosing += Form1_FormClosing;
            DragDrop += Form1_DragDrop;
            DragEnter += Form1_DragEnter;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ComboBox MaximumResComboBox;
        private Label MaximumResLabel;
        private CheckBox BorderCheckBox;
    }
}
