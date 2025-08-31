namespace DotEditor
{
    public partial class Form1 : Form
    {
        private int GridSize = 4;
        private Color currentColor = Color.White;
        private Image originalImage;

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

        private void SaveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (originalImage != null)
            {
                DialogResult Result = saveFileDialog.ShowDialog();
                if (Result == DialogResult.OK)
                {
                    originalImage.Save(saveFileDialog.FileName);
                }
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
            Text = $"{FileName} - Dot Editor";
            originalImage = Image.FromFile(FileName);
            DrawImage();
        }

        private void DrawImage()
        {
            if (originalImage == null) return;
            try
            {
                // 拡大倍率
                int newWidth = (int)(originalImage.Width * GridSize);
                int newHeight = (int)(originalImage.Height * GridSize);

                if (newWidth <= 0 || newHeight <= 0)
                    throw new ArgumentOutOfRangeException("width/height must be positive.");

                const int bpp = 4;
                long need = (long)newWidth * newHeight * bpp;
                if (need <= 0 || need > (1L << 31)) // アプリ方針で閾値調整
                    throw new ArgumentException("Requested bitmap is too large.");

                Bitmap enlarged = new Bitmap(newWidth, newHeight);
                using (Graphics g = Graphics.FromImage(enlarged))
                {
                    // 拡大画像を作成
                    g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.NearestNeighbor;
                    g.PixelOffsetMode = System.Drawing.Drawing2D.PixelOffsetMode.Half;
                    g.DrawImage(originalImage, 0, 0, newWidth, newHeight);

                    // 線描画に切替
                    g.PixelOffsetMode = System.Drawing.Drawing2D.PixelOffsetMode.Default;
                    // Grid Line
                    using (var blackPen = new Pen(Color.Black, 1))
                    using (var dashPen = new Pen(Color.White, 1) { DashStyle = System.Drawing.Drawing2D.DashStyle.Dash })
                    {
                        for (int x = 0; x < originalImage.Width; x++)
                        {
                            int sx = (x + 1) * GridSize - 1;
                            bool DashFlag = (x % 8 == 7);
                            if (GridSize >= 3 || DashFlag)
                            {
                                Pen pen = DashFlag ? dashPen : blackPen;
                                g.DrawLine(pen, sx, 0, sx, newHeight);
                            }
                        }
                        for (int y = 0; y < originalImage.Height; y++)
                        {
                            int sy = (y + 1) * GridSize - 1;
                            bool DashFlag = (y % 8 == 7);
                            if (GridSize >= 3 || DashFlag)
                            {
                                Pen pen = DashFlag ? dashPen : blackPen;
                                g.DrawLine(pen, 0, sy, newWidth, sy);
                            }
                        }
                    }
#if false
                // 赤枠（4辺を個別に）
                using (var red = new Pen(Color.Red, 1))
                {
                    g.DrawLine(red, 0, 0, newWidth - 1, 0);
                    g.DrawLine(red, newWidth - 1, 0, newWidth - 1, newHeight - 1);
                    g.DrawLine(red, newWidth - 1, newHeight - 1, 0, newHeight - 1);
                    g.DrawLine(red, 0, newHeight - 1, 0, 0);
                }
#endif
                }

                // PictureBox に表示
                pictureBox1.Image = enlarged;

                CenterPictureBox();
            }
            catch (ArgumentException)
            {
                MessageBox.Show("画像が大きすぎます。", "Dot Editor", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            catch (OutOfMemoryException)
            {
                MessageBox.Show("画像が大きすぎます。", "Dot Editor", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
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
            if (x >= 0 && x < pictureBox1.Image.Width && y >= 0 && y < pictureBox1.Image.Height)
            {
                x /= GridSize;
                y /= GridSize;
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

        private void ColorDialogToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (var dlg = new ColorDialog())
            {
                if (dlg.ShowDialog() == DialogResult.OK)
                    currentColor = dlg.Color;
            }
        }

#if false
        private void ZoomComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            Dictionary<int, int> ZoomDics = new()
            {
                { 0, 1 }, // 　等倍
                { 1, 2 }, // 　２倍
                { 2, 3 }, // 　３倍
                { 3, 4 }, // 　４倍
                { 4, 6 }, // 　６倍
                { 5, 8 }, // 　８倍
                { 6, 16 },// １６倍
                { 7, 32 },// ３２倍
            };
            if (ZoomDics.TryGetValue(ZoomComboBox.SelectedIndex, out var ZoomValue))
            {
                GridSize = ZoomValue;
                DrawImage();
            }
        }
#endif

    }
}
