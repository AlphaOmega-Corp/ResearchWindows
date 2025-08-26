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
                // å≥âÊëúÇì«Ç›çûÇ›
                Image original = Image.FromFile(openFileDialog1.FileName);

                // ägëÂî{ó¶Åió·ÅF8î{Åj
                float scale = 8.0f;
                int newWidth = (int)(original.Width * scale);
                int newHeight = (int)(original.Height * scale);

                // ägëÂâÊëúÇçÏê¨
                Bitmap enlarged = new Bitmap(newWidth, newHeight);
                using (Graphics g = Graphics.FromImage(enlarged))
                {
                    //g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
                    g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.NearestNeighbor;
                    g.DrawImage(original, 0, 0, newWidth, newHeight);
                }

                // PictureBox Ç…ï\é¶
                pictureBox1.Image = enlarged;
            }
        }

        private void ExitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
