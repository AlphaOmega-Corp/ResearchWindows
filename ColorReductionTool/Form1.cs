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
        enum EOutputDir
        {
            /// <summary>入力ファイルと同じ</summary>
            SameInputFile,
            /// <summary>一時フォルダ</summary>
            TempFolder,
            /// <summary>選択したフォルダー</summary>
            SelectedFolder,
        }

        public Form1()
        {
            InitializeComponent();
            if (Properties.Settings.Default.FormSize.Width != 0 && Properties.Settings.Default.FormSize.Height != 0)
            {
                this.Size = Properties.Settings.Default.FormSize;
            }
            BorderCheckBox.Checked = Properties.Settings.Default.Border;
            folderBrowserDialog1.SelectedPath = Properties.Settings.Default.OutputDirPath;
            MaximumResComboBox.SelectedIndex = Properties.Settings.Default.MaximumRes;
            OutputDirComboBox.SelectedIndex = Properties.Settings.Default.OutputDirType;
        }

        private void Form1_DragDrop(object sender, DragEventArgs e)
        {
            var fileNames = e.Data?.GetData(DataFormats.FileDrop, false) as string[];
            if (fileNames != null)
            {
                ImageConvert(fileNames);
            }
        }

        private void ImageConvert(string[] fileNames)
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
                            { 6, (320, 240) },
                            { 7, (256, 240) },
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
                    string DirectoryName = GetOutputDirectoryName(file);
                    if (!Directory.Exists(DirectoryName))
                    {
                        // 存在しないフォルダーを使用する場合は、フォルダーを作成
                        Directory.CreateDirectory(DirectoryName);
                    }
                    if (OutputDirComboBox.SelectedIndex == (int)EOutputDir.SelectedFolder)
                    {
                        LogRichTextBox.AppendText($"出力フォルダ:  \"file:{DirectoryName}\"\n");
                    }

                    // ファイル名部分を取得
                    string fileName = Path.GetFileNameWithoutExtension(file);
                    // 拡張子を取得
                    string extension = Path.GetExtension(file);

                    string file_4bit = $"{fileName}_4bit.png";
                    string file_8bit = $"{fileName}_8bit.png";

                    string filename_4bit = Path.Combine(DirectoryName, file_4bit);
                    string filename_8bit = Path.Combine(DirectoryName, file_8bit);

                    srcImage.Save(filename_4bit, encoder4Bit);
                    srcImage.Save(filename_8bit, encoder8Bit);

                    FileInfo InputFileInfo = new FileInfo(file);
                    FileInfo OutputFileInfo1 = new FileInfo(filename_4bit);
                    FileInfo OutputFileInfo2 = new FileInfo(filename_8bit);

                    Action<FileInfo, string, FileInfo> OutputFileInfo = (InputFileInfo, file, OutputFileInfo) =>
                    {
                        float CompressRate = 100.0f * OutputFileInfo.Length / InputFileInfo.Length;
                        LogRichTextBox.SelectionBackColor = CompressRate < 100 ? System.Drawing.Color.LightGreen : System.Drawing.Color.OrangeRed;
                        string CompressRateString = CompressRate.ToString("F2");
                        // 
                        string[] sizes = { "B", "KB", "MB", "GB", "TB" };
                        double len = OutputFileInfo.Length;
                        int order = 0;
                        while (len >= 1024 && order < sizes.Length - 1)
                        {
                            order++;
                            len /= 1024;
                        }
                        string sizeString = $"{len.ToString("F2")} {sizes[order]}";
                        LogRichTextBox.AppendText($"コンバート: {file} サイズ:{sizeString} 圧縮率:{CompressRateString}% \n");
                    };
                    System.Drawing.Color Tmep = LogRichTextBox.SelectionBackColor;
                    OutputFileInfo(InputFileInfo, file_4bit, OutputFileInfo1);
                    OutputFileInfo(InputFileInfo, file_8bit, OutputFileInfo2);
                    LogRichTextBox.SelectionBackColor = Tmep;

                    // 仮でフォルダーを開く
                    // System.Diagnostics.Process.Start("EXPLORER.EXE", DirectoryName);
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
            if (this.WindowState == FormWindowState.Normal)
            {
                // ウインドウステートがNormalな場合には位置（location）とサイズ（size）を記憶する。
                Properties.Settings.Default.FormSize = this.Size;
            }
            else
            {
                // もし最小化（minimized）や最大化（maximized）の場合には、RestoreBoundsを記憶する。
                Properties.Settings.Default.FormSize = this.RestoreBounds.Size;
            }
            Properties.Settings.Default.MaximumRes = MaximumResComboBox.SelectedIndex;
            Properties.Settings.Default.Border = BorderCheckBox.Checked;
            Properties.Settings.Default.OutputDirType = OutputDirComboBox.SelectedIndex;
            Properties.Settings.Default.OutputDirPath = folderBrowserDialog1.SelectedPath;
            // ここで設定を保存する
            Properties.Settings.Default.Save();
        }

        private void LogRichTextBox_LinkClicked(object sender, LinkClickedEventArgs e)
        {
            string? path = e.LinkText;
            if (path != null)
            {
                // 
                System.Diagnostics.Process.Start("explorer.exe", path);
                LogRichTextBox.AppendText($"フォルダーをエクスプローラーで開きます。\n");
            }
            else
            {
                LogRichTextBox.AppendText($"フォルダーをエクスプローラーで開けなかった。\n");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult Result = folderBrowserDialog1.ShowDialog();
            if (Result == DialogResult.OK)
            {
                int Type = 2;
                if (OutputDirComboBox.SelectedIndex != Type)
                {
                    OutputDirComboBox.SelectedIndex = Type;
                }
                else
                {
                    PrintOutputDirComboBoxSelectedIndex();
                }
            }
        }

        private void OutputDirComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            // 出力フォルダーを作成
            CreateOutputDirectory();
            //
            PrintOutputDirComboBoxSelectedIndex();
        }

        private string GetOutputDirectoryName(string filename)
        {
            EOutputDir UseTempDirType = (EOutputDir)OutputDirComboBox.SelectedIndex;
            string DirectoryName;
            switch (UseTempDirType)
            {
                default:
                case EOutputDir.SameInputFile: // 
                    if (string.IsNullOrEmpty(filename) == false)
                    {
                        string FullPath = Path.GetFullPath(filename);
                        DirectoryName = Path.GetDirectoryName(FullPath) ?? string.Empty;
                    }
                    else
                    {
                        DirectoryName = "";
                    }
                    break;
                case EOutputDir.TempFolder: // 一時フォルダーを使用
                    string exeName = Process.GetCurrentProcess().ProcessName;
                    DirectoryName = Path.Combine(System.IO.Path.GetTempPath(), exeName);
                    break;
                case EOutputDir.SelectedFolder: // ユーザーが選択したフォルダーを使用
                    DirectoryName = folderBrowserDialog1.SelectedPath;
                    break;
            }
            return DirectoryName;
        }

        private void CreateOutputDirectory()
        {
            EOutputDir UseTempDirType = (EOutputDir)OutputDirComboBox.SelectedIndex;
            if (UseTempDirType == EOutputDir.TempFolder) // 一時フォルダーを使用
            {
                string exeName = Process.GetCurrentProcess().ProcessName;
                string DirectoryName = Path.Combine(System.IO.Path.GetTempPath(), exeName);
                if (!Directory.Exists(DirectoryName))
                {
                    // 存在しないフォルダーを使用する場合は、フォルダーを作成
                    Directory.CreateDirectory(DirectoryName);
                }
            }
        }

        private void PrintOutputDirComboBoxSelectedIndex()
        {
            string DirectoryName = GetOutputDirectoryName("");
            if (string.IsNullOrEmpty(DirectoryName) == false)
            {
                LogRichTextBox.AppendText($"出力フォルダ:  \"file:{DirectoryName}\"\n");
            }
            else
            {
                LogRichTextBox.AppendText($"出力フォルダは入力ファイルと同じ場所に出力されます\n");
            }
        }

        private void OpenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult Result = openFileDialog1.ShowDialog();
            if (Result == DialogResult.OK)
            {
                ImageConvert(openFileDialog1.FileNames);
            }
        }

        private void ExitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void PasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Clipboard.ContainsImage())
            {
                List<string> fullpathList = new List<string>();
                try
                {
                    System.Drawing.Image image = Clipboard.GetImage();
                    if (image != null)
                    {
                        string formattedDateTime = DateTime.Now.ToString("yyyy-MM-dd_HHmmss");
                        string filename = $"clipboard_{formattedDateTime}.png";
                        string DirectoryName = GetOutputDirectoryName(filename);
                        string fullpath = Path.Combine(DirectoryName, filename);

                        // クリップボードから画像を取得して変換する
                        image.Save(fullpath);
                        // クリップボードから画像のパスを追加
                        fullpathList.Add( fullpath );
                    }
                }
                catch (Exception ex)
                {
                    LogRichTextBox.AppendText($"クリップボードから画像を取得できませんでした: {ex.Message}\n");
                }
                
                if(fullpathList.Count!=0)
                {
                    // 画像圧縮する
                    ImageConvert(fullpathList.ToArray());
                }
            }
            else
            {
                LogRichTextBox.AppendText("クリップボードに画像がありません。\n");
            }
        }
    }
}
