namespace DotEditor
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
            panel1 = new Panel();
            pictureBox1 = new PictureBox();
            menuStrip1 = new MenuStrip();
            FilesToolStripMenuItem = new ToolStripMenuItem();
            NewToolStripMenuItem = new ToolStripMenuItem();
            OpenToolStripMenuItem = new ToolStripMenuItem();
            SaveAsToolStripMenuItem = new ToolStripMenuItem();
            ExitToolStripMenuItem = new ToolStripMenuItem();
            DisplayToolStripMenuItem = new ToolStripMenuItem();
            ColorDialogToolStripMenuItem = new ToolStripMenuItem();
            openFileDialog1 = new OpenFileDialog();
            statusStrip1 = new StatusStrip();
            toolStripStatusLabel1 = new ToolStripStatusLabel();
            saveFileDialog1 = new SaveFileDialog();
            panel2 = new Panel();
            ColorSelectButton = new Button();
            label1 = new Label();
            ZoomComboBox = new ComboBox();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            menuStrip1.SuspendLayout();
            statusStrip1.SuspendLayout();
            panel2.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.AutoScroll = true;
            panel1.BackColor = SystemColors.ControlDark;
            panel1.Controls.Add(pictureBox1);
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(0, 75);
            panel1.Name = "panel1";
            panel1.Size = new Size(624, 344);
            panel1.TabIndex = 0;
            panel1.Resize += panel1_Resize;
            // 
            // pictureBox1
            // 
            pictureBox1.Location = new Point(0, 0);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(100, 50);
            pictureBox1.SizeMode = PictureBoxSizeMode.AutoSize;
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            pictureBox1.MouseClick += pictureBox1_MouseClick;
            pictureBox1.MouseDown += pictureBox1_MouseDown;
            pictureBox1.MouseMove += pictureBox1_MouseMove;
            // 
            // menuStrip1
            // 
            menuStrip1.Items.AddRange(new ToolStripItem[] { FilesToolStripMenuItem, DisplayToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(624, 24);
            menuStrip1.TabIndex = 1;
            // 
            // FilesToolStripMenuItem
            // 
            FilesToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { NewToolStripMenuItem, OpenToolStripMenuItem, SaveAsToolStripMenuItem, ExitToolStripMenuItem });
            FilesToolStripMenuItem.Name = "FilesToolStripMenuItem";
            FilesToolStripMenuItem.Size = new Size(67, 20);
            FilesToolStripMenuItem.Text = "ファイル(&F)";
            // 
            // NewToolStripMenuItem
            // 
            NewToolStripMenuItem.Name = "NewToolStripMenuItem";
            NewToolStripMenuItem.Size = new Size(186, 22);
            NewToolStripMenuItem.Text = "新規作成(&N)...";
            // 
            // OpenToolStripMenuItem
            // 
            OpenToolStripMenuItem.Name = "OpenToolStripMenuItem";
            OpenToolStripMenuItem.Size = new Size(186, 22);
            OpenToolStripMenuItem.Text = "開く(&O)...";
            OpenToolStripMenuItem.Click += OpenToolStripMenuItem_Click;
            // 
            // SaveAsToolStripMenuItem
            // 
            SaveAsToolStripMenuItem.Name = "SaveAsToolStripMenuItem";
            SaveAsToolStripMenuItem.Size = new Size(186, 22);
            SaveAsToolStripMenuItem.Text = "名前を付けて保存(&A)...";
            SaveAsToolStripMenuItem.Click += SaveAsToolStripMenuItem_Click;
            // 
            // ExitToolStripMenuItem
            // 
            ExitToolStripMenuItem.Name = "ExitToolStripMenuItem";
            ExitToolStripMenuItem.Size = new Size(186, 22);
            ExitToolStripMenuItem.Text = "終了(&E)";
            ExitToolStripMenuItem.Click += ExitToolStripMenuItem_Click;
            // 
            // DisplayToolStripMenuItem
            // 
            DisplayToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { ColorDialogToolStripMenuItem });
            DisplayToolStripMenuItem.Name = "DisplayToolStripMenuItem";
            DisplayToolStripMenuItem.Size = new Size(57, 20);
            DisplayToolStripMenuItem.Text = "表示(&F)";
            // 
            // ColorDialogToolStripMenuItem
            // 
            ColorDialogToolStripMenuItem.Name = "ColorDialogToolStripMenuItem";
            ColorDialogToolStripMenuItem.Size = new Size(101, 22);
            ColorDialogToolStripMenuItem.Text = "色(&C)";
            ColorDialogToolStripMenuItem.Click += ColorDialogToolStripMenuItem_Click;
            // 
            // openFileDialog1
            // 
            openFileDialog1.FileName = "openFileDialog1";
            openFileDialog1.Filter = "画像ファイル|*.png;*.jpg;*.jpeg;*.bmp;*.gif;*.tif;*.tiff;*.webp|すべてのファイル|*.*";
            openFileDialog1.Title = "画像を選択";
            // 
            // statusStrip1
            // 
            statusStrip1.Items.AddRange(new ToolStripItem[] { toolStripStatusLabel1 });
            statusStrip1.Location = new Point(0, 419);
            statusStrip1.Name = "statusStrip1";
            statusStrip1.Size = new Size(624, 22);
            statusStrip1.TabIndex = 1;
            // 
            // toolStripStatusLabel1
            // 
            toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            toolStripStatusLabel1.Size = new Size(0, 17);
            // 
            // saveFileDialog1
            // 
            saveFileDialog1.Filter = "画像ファイル|*.png;*.jpg;*.jpeg;*.bmp;*.gif;*.tif;*.tiff;*.webp|すべてのファイル|*.*";
            saveFileDialog1.Title = "画像を選択";
            // 
            // panel2
            // 
            panel2.BackColor = SystemColors.ControlLight;
            panel2.Controls.Add(ColorSelectButton);
            panel2.Controls.Add(label1);
            panel2.Controls.Add(ZoomComboBox);
            panel2.Dock = DockStyle.Top;
            panel2.Location = new Point(0, 24);
            panel2.Name = "panel2";
            panel2.Size = new Size(624, 51);
            panel2.TabIndex = 1;
            // 
            // ColorSelectButton
            // 
            ColorSelectButton.Location = new Point(163, 12);
            ColorSelectButton.Name = "ColorSelectButton";
            ColorSelectButton.Size = new Size(100, 23);
            ColorSelectButton.TabIndex = 2;
            ColorSelectButton.Text = "色の選択...";
            ColorSelectButton.UseVisualStyleBackColor = true;
            ColorSelectButton.Click += ColorSelectButton_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(4, 16);
            label1.Name = "label1";
            label1.Size = new Size(43, 15);
            label1.TabIndex = 1;
            label1.Text = "拡大率";
            // 
            // ZoomComboBox
            // 
            ZoomComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            ZoomComboBox.FormattingEnabled = true;
            ZoomComboBox.Location = new Point(53, 13);
            ZoomComboBox.Name = "ZoomComboBox";
            ZoomComboBox.Size = new Size(83, 23);
            ZoomComboBox.TabIndex = 0;
            ZoomComboBox.SelectedIndexChanged += ZoomComboBox_SelectedIndexChanged;
            // 
            // Form1
            // 
            AllowDrop = true;
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(624, 441);
            Controls.Add(panel1);
            Controls.Add(panel2);
            Controls.Add(menuStrip1);
            Controls.Add(statusStrip1);
            MainMenuStrip = menuStrip1;
            Name = "Form1";
            Text = "Dot Editor";
            DragDrop += Form1_DragDrop;
            DragEnter += Form1_DragEnter;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            statusStrip1.ResumeLayout(false);
            statusStrip1.PerformLayout();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel panel1;
        private PictureBox pictureBox1;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem NewToolStripMenuItem;
        private ToolStripMenuItem FilesToolStripMenuItem;
        private ToolStripMenuItem OpenToolStripMenuItem;
        private ToolStripMenuItem SaveAsToolStripMenuItem;
        private ToolStripMenuItem ExitToolStripMenuItem;
        private OpenFileDialog openFileDialog1;
        private StatusStrip statusStrip1;
        private ToolStripStatusLabel toolStripStatusLabel1;
        private ToolStripMenuItem DisplayToolStripMenuItem;
        private ToolStripMenuItem ColorDialogToolStripMenuItem;
        private SaveFileDialog saveFileDialog1;
        private Panel panel2;
        private Label label1;
        private ComboBox ZoomComboBox;
        private Button ColorSelectButton;
    }
}
