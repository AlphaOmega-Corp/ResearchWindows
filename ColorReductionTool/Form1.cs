using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Formats.Png;
using SixLabors.ImageSharp.PixelFormats;
using SixLabors.ImageSharp.Processing;
using System.Windows.Forms;

namespace ColorReductionTool
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
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
                        // 大きい画像は縮小する
                        int NESWidth = 1920;
                        int NESHeight = 1080;
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
                        string DirectoryName = Path.GetDirectoryName(FullPath) ?? string.Empty;
                        // ファイル名部分を取得
                        string fileName = Path.GetFileNameWithoutExtension(file);
                        // 拡張子を取得
                        string extension = Path.GetExtension(file);

                        string file_4bit = Path.Combine(DirectoryName, $"{fileName}_4{extension}");
                        string file_8bit = Path.Combine(DirectoryName, $"{fileName}_8{extension}");
                        srcImage.Save(file_4bit, encoder4Bit);
                        srcImage.Save(file_8bit, encoder8Bit);
                    }
                }
            }
        }
        private void Form1_DragEnter(object sender, DragEventArgs e)
        {
            if( e.Data !=null )
            {
                e.Effect = !e.Data.GetDataPresent(DataFormats.FileDrop) ? DragDropEffects.None : DragDropEffects.All;
            }
        }
    }
}
