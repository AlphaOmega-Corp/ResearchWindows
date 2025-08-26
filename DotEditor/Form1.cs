namespace DotEditor
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void OpenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult Result = openFileDialog1.ShowDialog();
            if (Result == DialogResult.OK)
            {
                LoadImage(openFileDialog1.FileName);
            }
        }

        private void ExitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }
        private void CenterPictureBox()
        {
            int x = (panel1.ClientSize.Width - pictureBox1.Width) / 2;
            int y = (panel1.ClientSize.Height - pictureBox1.Height) / 2;
            Point center = new Point( Math.Max(0, x), Math.Max(0, y));
            pictureBox1.Location = center;
        }

        private void panel1_Resize(object sender, EventArgs e)
        {
            CenterPictureBox();
        }

        private void Form1_DragDrop(object sender, DragEventArgs e)
        {
            var fileNames = e.Data?.GetData(DataFormats.FileDrop, false) as string[];
            if (fileNames != null)
            {
                foreach (var file in fileNames)
                {
                    LoadImage(file);
                }
            }
        }

        private void Form1_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data != null)
            {
                e.Effect = !e.Data.GetDataPresent(DataFormats.FileDrop) ? DragDropEffects.None : DragDropEffects.All;
            }
        }
        private void LoadImage(string FileName)
        {
            // 元画像を読み込み
            Image original = Image.FromFile(FileName);

            // 拡大倍率（例：8倍）
            int scale = 8;
            int newWidth = (int)(original.Width * scale);
            int newHeight = (int)(original.Height * scale);

            // 拡大画像を作成
            Bitmap enlarged = new Bitmap(newWidth, newHeight);
            using (Graphics g = Graphics.FromImage(enlarged))
            {
                //g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
                g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.NearestNeighbor;
                g.DrawImage(original, scale / 2, scale / 2, newWidth, newHeight);
                // Glid Line
                for (int x = 0; x < original.Width; x++)
                {
                    int sx = x * scale;
                    g.DrawLine(Pens.Black, sx, 0, sx, newHeight);
                }
                for (int y = 0; y < original.Height; y++)
                {
                    int sy = y * scale;
                    g.DrawLine(Pens.Black, 0, sy, newWidth, sy);
                }
            }

            // PictureBox に表示
            pictureBox1.Image = enlarged;

            CenterPictureBox();
        }
    }
}
