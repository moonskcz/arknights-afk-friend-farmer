using IronOcr;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace arknight_mission_clicker
{
    class ImageProcessor
    {

        public ImageProcessor()
        {

        }

        public Bitmap GetScreenshot (int posX = 0, int posY = 0, int width = 0, int height = 0)
        {
            Bitmap bmp = new Bitmap(width, height);

            Rectangle captureRectangle = new Rectangle();

            captureRectangle.Width = width;
            captureRectangle.Height = height;

            Graphics captureGraphics = Graphics.FromImage(bmp);

            captureGraphics.CopyFromScreen(posX + 100, posY + 100, 0, 0, captureRectangle.Size);

            //debug shit
            //bmp.Save(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\testScreen.bmp");

            return bmp;
        }

        public Bitmap InvertImage (Bitmap imageToInvert)
        {
            Bitmap pic = imageToInvert;
            for (int y = 0; (y <= (pic.Height - 1)); y++)
            {
                for (int x = 0; (x <= (pic.Width - 1)); x++)
                {
                    Color inv = pic.GetPixel(x, y);
                    inv = Color.FromArgb(255, (255 - inv.R), (255 - inv.G), (255 - inv.B));
                    pic.SetPixel(x, y, inv);
                }
            }
            return pic;
        }

        public void DEBUGsave (Bitmap bmp)
        {
            bmp.Save(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\testScreen.bmp");
        }

        private Bitmap getEpisodeImage ()
        {
            Bitmap bmp = GetScreenshot(790, 530, 44, 24);
            //debug shit
            bmp.Save(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\testScreen.bmp");
            return bmp;
        }

        public string GetEpisodeText()
        {
            var Ocr = new AdvancedOcr()
            {
                CleanBackgroundNoise = false,
                EnhanceContrast = false,
                EnhanceResolution = false,
                AcceptedOcrCharacters = "0123456789",
                Language = IronOcr.Languages.English.OcrLanguagePack,
                Strategy = IronOcr.AdvancedOcr.OcrStrategy.Advanced,
                ColorSpace = AdvancedOcr.OcrColorSpace.GrayScale,
                DetectWhiteTextOnDarkBackgrounds = true,
                InputImageType = AdvancedOcr.InputTypes.AutoDetect,
                RotateAndStraighten = false,
                ReadBarCodes = false,
                ColorDepth = 0
            };
            var Result = Ocr.Read(getEpisodeImage());

            return Result.Text;
        }

        public string GetEpisodeText (Bitmap bmp)
        {
            var Ocr = new AutoOcr();
            var Result = Ocr.Read(bmp);
            return Result.Text;
        }

        public string GetTextFromBitmap (Bitmap bmp)
        {
            var Ocr = new AdvancedOcr()
            {
                CleanBackgroundNoise = false,
                EnhanceContrast = false,
                EnhanceResolution = false,
                Language = IronOcr.Languages.English.OcrLanguagePack,
                Strategy = IronOcr.AdvancedOcr.OcrStrategy.Advanced,
                ColorSpace = AdvancedOcr.OcrColorSpace.GrayScale,
                DetectWhiteTextOnDarkBackgrounds = true,
                InputImageType = AdvancedOcr.InputTypes.AutoDetect,
                RotateAndStraighten = false,
                ReadBarCodes = false,
                ColorDepth = 0
            };
            var Result = Ocr.Read(bmp);

            //debug shit
            bmp.Save(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\testScreen.bmp");

            return Result.Text;
        }

        public string GetNumbersFromBitmap(Bitmap bmp)
        {
            var Ocr = new AdvancedOcr()
            {
                CleanBackgroundNoise = false,
                EnhanceContrast = false,
                EnhanceResolution = false,
                AcceptedOcrCharacters = "0123456789",
                Language = IronOcr.Languages.English.OcrLanguagePack,
                Strategy = IronOcr.AdvancedOcr.OcrStrategy.Advanced,
                ColorSpace = AdvancedOcr.OcrColorSpace.GrayScale,
                DetectWhiteTextOnDarkBackgrounds = true,
                InputImageType = AdvancedOcr.InputTypes.AutoDetect,
                RotateAndStraighten = false,
                ReadBarCodes = false,
                ColorDepth = 0
            };
            Ocr.AcceptedOcrCharacters = "0123456789";
            var Result = Ocr.Read(bmp);

            //debug shit
            bmp.Save(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\testScreen.bmp");

            return Result.Text;
        }

    }
}
