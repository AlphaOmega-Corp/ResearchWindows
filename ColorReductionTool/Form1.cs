using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Drawing.Processing;
using SixLabors.ImageSharp.Formats.Png;
using SixLabors.ImageSharp.PixelFormats;
using SixLabors.ImageSharp.Processing;
using System.Diagnostics;

namespace ColorReductionTool
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            int MaximumResValue = Properties.Settings.Default.MaximumRes;
            MaximumResComboBox.SelectedIndex = MaximumResValue; // 初期値を設定
            bool BorderValue = Properties.Settings.Default.Border;
            BorderCheckBox.Checked = BorderValue; // 初期値を設定
            bool UseTempDirValue = Properties.Settings.Default.UseTempDir;
            UseTempDirCheckBox.Checked = UseTempDirValue; // 一時フォルダーを使用するかどうかの初期値を設定
        }

        private void Form1_DragDrop(object sender, DragEventArgs e)
        {
            var fileNames = e.Data?.GetData(DataFormats.FileDrop, false) as string[];
            if (fileNames != null)
            {
                foreach (var file in fileNames)
                {
                    // Process each file
                    using (Image<Rgba32> srcImage = SixLabors.ImageSharp.Image.Load<Rgba32>(file))
                    {
                        if (MaximumResComboBox.SelectedIndex != 0)
                        {
                            Dictionary<int, (int Width, int Height)> resolutions = new()
                            {
                                { 1, (1920, 1080) },
                                { 2, (1280, 720) },
                                { 3, (960, 960) },
                                { 4, (720, 480) },
                                { 5, (640, 480) },
                                { 6, (320, 240) }
                            };
                            if (resolutions.TryGetValue(MaximumResComboBox.SelectedIndex, out var resolution))
                            {
                                // 大きい画像は縮小する
                                int NESWidth = resolution.Width;
                                int NESHeight = resolution.Height;
                                float ScaleX = (float)NESWidth / srcImage.Width;
                                float ScaleY = (float)NESHeight / srcImage.Height;
                                float Scale = Math.Min(ScaleX, ScaleY);
                                if (Scale < 1.0f)
                                {
                                    // 縮小する
                                    int newWidth = (int)(srcImage.Width * Scale);
                                    int newHeight = (int)(srcImage.Height * Scale);
                                    srcImage.Mutate(ctx => ctx.Resize(newWidth, newHeight));
                                }
                            }
                        }
                        if (BorderCheckBox.Checked)
                        {
                            // 黒く縁取りをする
                            SixLabors.ImageSharp.Rectangle rect = new(0, 0, srcImage.Width - 1, srcImage.Height - 1);
                            var borderColor = SixLabors.ImageSharp.Color.Black; // 縁取りの色
                            var thickness = 1; // 線の太さ
                            srcImage.Mutate(ctx => ctx.Draw(borderColor, thickness, rect));
                        }

                        // 画像を4bitパレット形式で保存する
                        var encoder4Bit = new PngEncoder
                        {
                            ColorType = PngColorType.Palette, // パレット形式で保存
                            BitDepth = PngBitDepth.Bit4       // 4bit インデックスカラー
                        };
                        // 画像を8bitパレット形式で保存する
                        var encoder8Bit = new PngEncoder
                        {
                            ColorType = PngColorType.Palette, // パレット形式で保存
                            BitDepth = PngBitDepth.Bit8       // 8bit インデックスカラー
                        };
                        string FullPath = Path.GetFullPath(file);
                        bool UseTempDir = UseTempDirCheckBox.Checked;
                        string exeName = Process.GetCurrentProcess().ProcessName;
                        string DirectoryName = UseTempDir
                                                ? Path.Combine( System.IO.Path.GetTempPath(), exeName )
                                                : Path.GetDirectoryName(FullPath) ?? string.Empty;
                        // 一時フォルダーを使用する場合は、フォルダーを作成
                        if ( !Directory.Exists(DirectoryName) )
                        {
                            Directory.CreateDirectory(DirectoryName);
                        }
                        // ファイル名部分を取得
                        string fileName = Path.GetFileNameWithoutExtension(file);
                        // 拡張子を取得
                        string extension = Path.GetExtension(file);

                        string file_4bit = Path.Combine(DirectoryName, $"{fileName}_4bit.png");
                        string file_8bit = Path.Combine(DirectoryName, $"{fileName}_8bit.png");
                        srcImage.Save(file_4bit, encoder4Bit);
                        srcImage.Save(file_8bit, encoder8Bit);
                        // 仮でフォルダーを開く
                        System.Diagnostics.Process.Start("EXPLORER.EXE", DirectoryName);
                    }
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

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            Properties.Settings.Default.MaximumRes = MaximumResComboBox.SelectedIndex;
            Properties.Settings.Default.Border = BorderCheckBox.Checked;
            Properties.Settings.Default.UseTempDir = UseTempDirCheckBox.Checked;
            // ここで設定を保存する
            Properties.Settings.Default.Save();
        }
    }
}
