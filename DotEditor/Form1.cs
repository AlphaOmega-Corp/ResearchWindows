namespace DotEditor
{
    public partial class Form1 : Form
    {
        private const int GridSize = 8;
        private Color currentColor = Color.White;

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
            Point center = new Point(Math.Max(0, x), Math.Max(0, y));
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

            // 拡大倍率
            int newWidth = (int)(original.Width * GridSize);
            int newHeight = (int)(original.Height * GridSize);

            // 拡大画像を作成
            Bitmap enlarged = new Bitmap(newWidth, newHeight);
            using (Graphics g = Graphics.FromImage(enlarged))
            {
                //g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
                g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.NearestNeighbor;
                g.DrawImage(original, GridSize / 2, GridSize / 2, newWidth, newHeight);
                // Grid Line
                Pen blackPen = new Pen(Color.Black, 1);
                Pen DashPen = new Pen(Color.White, 1);
                DashPen.DashStyle = System.Drawing.Drawing2D.DashStyle.Dash;
                for (int x = 0; x < original.Width; x++)
                {
                    int sx = x * GridSize + GridSize -1;
                    Pen pen = (x % 8 == 7) ? DashPen : blackPen;
                    g.DrawLine(pen, sx, 0, sx, newHeight);
                }
                for (int y = 0; y < original.Height; y++)
                {
                    int sy = y * GridSize + GridSize - 1;
                    Pen pen = (y % 8 == 7) ? DashPen : blackPen;
                    g.DrawLine(pen, 0, sy, newWidth, sy);
                }
                // リソース開放
                blackPen.Dispose();
                DashPen.Dispose();
            }

            // PictureBox に表示
            pictureBox1.Image = enlarged;

            CenterPictureBox();
        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                // 左ボタンが押されているときの処理をここに記述
                DrawDot(e.X, e.Y);
            }
        }
        private void pictureBox1_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                // 右ボタンが押されているときの処理をここに記述
                Color color = GetPixelColor(e.X, e.Y);
                if (color != Color.Empty)
                {
                    currentColor = color;
                    toolStripStatusLabel1.Text = $"Dot Editor - R:{color.R} G:{color.G} B:{color.B}";
                }
            }
        }
        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                // 左ボタンが押されているときの処理をここに記述
                DrawDot(e.X, e.Y);
            }
        }
        private void DrawDot(int x, int y)
        {
            if (pictureBox1.Image == null) return;
            x /= GridSize;
            y /= GridSize;
            if (x >= 0 && x < pictureBox1.Image.Width && y >= 0 && y < pictureBox1.Image.Height)
            {
                using (var brush = new SolidBrush(currentColor))
                {
                    var g = pictureBox1.CreateGraphics();
                    g.FillRectangle(brush, x * GridSize, y * GridSize, GridSize - 1, GridSize - 1);
                }
            }
        }
        private Color GetPixelColor(int x, int y)
        {
            if (pictureBox1.Image == null) return Color.Empty;
            if (x >= 0 && x < pictureBox1.Image.Width && y >= 0 && y < pictureBox1.Image.Height)
            {
                Bitmap bitmap = (Bitmap)pictureBox1.Image;
                return bitmap.GetPixel(x, y);
            }
            return Color.Empty;
        }

    }
}
