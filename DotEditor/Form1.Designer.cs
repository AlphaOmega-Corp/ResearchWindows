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
            OpenToolStripMenuItem = new ToolStripMenuItem();
            ExitToolStripMenuItem = new ToolStripMenuItem();
            DisplayToolStripMenuItem = new ToolStripMenuItem();
            ColorDialogToolStripMenuItem = new ToolStripMenuItem();
            openFileDialog1 = new OpenFileDialog();
            statusStrip1 = new StatusStrip();
            toolStripStatusLabel1 = new ToolStripStatusLabel();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            menuStrip1.SuspendLayout();
            statusStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.AutoScroll = true;
            panel1.Controls.Add(pictureBox1);
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(0, 24);
            panel1.Name = "panel1";
            panel1.Size = new Size(800, 404);
            panel1.TabIndex = 0;
            panel1.Resize += panel1_Resize;
            // 
            // pictureBox1
            // 
            pictureBox1.Location = new Point(0, 0);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(800, 426);
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
            menuStrip1.Size = new Size(800, 24);
            menuStrip1.TabIndex = 1;
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
            OpenToolStripMenuItem.Click += OpenToolStripMenuItem_Click;
            // 
            // ExitToolStripMenuItem
            // 
            ExitToolStripMenuItem.Name = "ExitToolStripMenuItem";
            ExitToolStripMenuItem.Size = new Size(119, 22);
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
            ColorDialogToolStripMenuItem.Size = new Size(180, 22);
            ColorDialogToolStripMenuItem.Text = "色(&C)";
            ColorDialogToolStripMenuItem.Click += ColorDialogToolStripMenuItem_Click;
            // 
            // openFileDialog1
            // 
            openFileDialog1.FileName = "openFileDialog1";
            // 
            // statusStrip1
            // 
            statusStrip1.Items.AddRange(new ToolStripItem[] { toolStripStatusLabel1 });
            statusStrip1.Location = new Point(0, 428);
            statusStrip1.Name = "statusStrip1";
            statusStrip1.Size = new Size(800, 22);
            statusStrip1.TabIndex = 1;
            // 
            // toolStripStatusLabel1
            // 
            toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            toolStripStatusLabel1.Size = new Size(0, 17);
            // 
            // Form1
            // 
            AllowDrop = true;
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(panel1);
            Controls.Add(menuStrip1);
            Controls.Add(statusStrip1);
            MainMenuStrip = menuStrip1;
            Name = "Form1";
            Text = "ドットエディタ";
            DragDrop += Form1_DragDrop;
            DragEnter += Form1_DragEnter;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            statusStrip1.ResumeLayout(false);
            statusStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel panel1;
        private PictureBox pictureBox1;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem FilesToolStripMenuItem;
        private ToolStripMenuItem OpenToolStripMenuItem;
        private ToolStripMenuItem ExitToolStripMenuItem;
        private OpenFileDialog openFileDialog1;
        private StatusStrip statusStrip1;
        private ToolStripStatusLabel toolStripStatusLabel1;
        private ToolStripMenuItem DisplayToolStripMenuItem;
        private ToolStripMenuItem ColorDialogToolStripMenuItem;
    }
}
