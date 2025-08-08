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
            statusStrip1 = new StatusStrip();
            menuStrip1 = new MenuStrip();
            FilesToolStripMenuItem = new ToolStripMenuItem();
            OpenToolStripMenuItem = new ToolStripMenuItem();
            ExitToolStripMenuItem = new ToolStripMenuItem();
            panel1 = new Panel();
            OutputDirSelectButton = new Button();
            OutputDirlabel = new Label();
            OutputDirComboBox = new ComboBox();
            LogRichTextBox = new RichTextBox();
            folderBrowserDialog1 = new FolderBrowserDialog();
            menuStrip1.SuspendLayout();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // MaximumResComboBox
            // 
            MaximumResComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            MaximumResComboBox.FormattingEnabled = true;
            MaximumResComboBox.Items.AddRange(new object[] { "変換なし", "1920 x 1080", "1280 x 720", " 960 x 960", " 720 x 480", " 640 x 480", " 320 x 240" });
            MaximumResComboBox.Location = new Point(104, 13);
            MaximumResComboBox.Name = "MaximumResComboBox";
            MaximumResComboBox.Size = new Size(152, 23);
            MaximumResComboBox.TabIndex = 0;
            // 
            // MaximumResLabel
            // 
            MaximumResLabel.AutoSize = true;
            MaximumResLabel.Location = new Point(12, 17);
            MaximumResLabel.Name = "MaximumResLabel";
            MaximumResLabel.Size = new Size(67, 15);
            MaximumResLabel.TabIndex = 1;
            MaximumResLabel.Text = "最大解像度";
            // 
            // BorderCheckBox
            // 
            BorderCheckBox.AutoSize = true;
            BorderCheckBox.Location = new Point(276, 16);
            BorderCheckBox.Name = "BorderCheckBox";
            BorderCheckBox.Size = new Size(97, 19);
            BorderCheckBox.TabIndex = 2;
            BorderCheckBox.Text = "縁取りを付ける";
            BorderCheckBox.UseVisualStyleBackColor = true;
            // 
            // statusStrip1
            // 
            statusStrip1.Location = new Point(0, 277);
            statusStrip1.Name = "statusStrip1";
            statusStrip1.Size = new Size(457, 22);
            statusStrip1.TabIndex = 4;
            statusStrip1.Text = "statusStrip1";
            // 
            // menuStrip1
            // 
            menuStrip1.Items.AddRange(new ToolStripItem[] { FilesToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(457, 24);
            menuStrip1.TabIndex = 5;
            menuStrip1.Text = "menuStrip1";
            // 
            // FilesToolStripMenuItem
            // 
            FilesToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { OpenToolStripMenuItem, ExitToolStripMenuItem });
            FilesToolStripMenuItem.Name = "FilesToolStripMenuItem";
            FilesToolStripMenuItem.Size = new Size(67, 20);
            FilesToolStripMenuItem.Text = "ファイル(&F)";
            // 
            // OpenToolStripMenuItem
            // 
            OpenToolStripMenuItem.Name = "OpenToolStripMenuItem";
            OpenToolStripMenuItem.Size = new Size(119, 22);
            OpenToolStripMenuItem.Text = "開く(&O)...";
            // 
            // ExitToolStripMenuItem
            // 
            ExitToolStripMenuItem.Name = "ExitToolStripMenuItem";
            ExitToolStripMenuItem.Size = new Size(119, 22);
            ExitToolStripMenuItem.Text = "終了(&E)";
            // 
            // panel1
            // 
            panel1.Controls.Add(OutputDirSelectButton);
            panel1.Controls.Add(OutputDirlabel);
            panel1.Controls.Add(OutputDirComboBox);
            panel1.Controls.Add(MaximumResComboBox);
            panel1.Controls.Add(MaximumResLabel);
            panel1.Controls.Add(BorderCheckBox);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 24);
            panel1.Name = "panel1";
            panel1.Size = new Size(457, 76);
            panel1.TabIndex = 6;
            // 
            // OutputDirSelectButton
            // 
            OutputDirSelectButton.Location = new Point(262, 43);
            OutputDirSelectButton.Name = "OutputDirSelectButton";
            OutputDirSelectButton.Size = new Size(73, 23);
            OutputDirSelectButton.TabIndex = 5;
            OutputDirSelectButton.Text = "フォルダ...";
            OutputDirSelectButton.UseVisualStyleBackColor = true;
            OutputDirSelectButton.Click += button1_Click;
            // 
            // OutputDirlabel
            // 
            OutputDirlabel.AutoSize = true;
            OutputDirlabel.Location = new Point(12, 46);
            OutputDirlabel.Name = "OutputDirlabel";
            OutputDirlabel.Size = new Size(86, 15);
            OutputDirlabel.TabIndex = 4;
            OutputDirlabel.Text = "出力先フォルダー";
            // 
            // OutputDirComboBox
            // 
            OutputDirComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            OutputDirComboBox.FormattingEnabled = true;
            OutputDirComboBox.Items.AddRange(new object[] { "入力ファイルと同じ場所", "一時ファイルに出力", "指定したフォルダーに出力" });
            OutputDirComboBox.Location = new Point(104, 43);
            OutputDirComboBox.Name = "OutputDirComboBox";
            OutputDirComboBox.Size = new Size(152, 23);
            OutputDirComboBox.TabIndex = 0;
            OutputDirComboBox.SelectedIndexChanged += OutputDirComboBox_SelectedIndexChanged;
            // 
            // LogRichTextBox
            // 
            LogRichTextBox.Dock = DockStyle.Fill;
            LogRichTextBox.Location = new Point(0, 100);
            LogRichTextBox.Name = "LogRichTextBox";
            LogRichTextBox.ReadOnly = true;
            LogRichTextBox.Size = new Size(457, 177);
            LogRichTextBox.TabIndex = 7;
            LogRichTextBox.Text = "";
            LogRichTextBox.WordWrap = false;
            LogRichTextBox.LinkClicked += LogRichTextBox_LinkClicked;
            // 
            // folderBrowserDialog1
            // 
            folderBrowserDialog1.Description = "出力フォルダーを選択してください。";
            // 
            // Form1
            // 
            AllowDrop = true;
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(457, 299);
            Controls.Add(LogRichTextBox);
            Controls.Add(statusStrip1);
            Controls.Add(panel1);
            Controls.Add(menuStrip1);
            MainMenuStrip = menuStrip1;
            Name = "Form1";
            Text = "画像減色ツール";
            FormClosing += Form1_FormClosing;
            DragDrop += Form1_DragDrop;
            DragEnter += Form1_DragEnter;
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ComboBox MaximumResComboBox;
        private Label MaximumResLabel;
        private CheckBox BorderCheckBox;
        private StatusStrip statusStrip1;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem FilesToolStripMenuItem;
        private ToolStripMenuItem OpenToolStripMenuItem;
        private ToolStripMenuItem ExitToolStripMenuItem;
        private Panel panel1;
        private RichTextBox LogRichTextBox;
        private ComboBox OutputDirComboBox;
        private Label OutputDirlabel;
        private Button OutputDirSelectButton;
        private FolderBrowserDialog folderBrowserDialog1;
    }
}
