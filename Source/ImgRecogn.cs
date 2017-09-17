using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Patagames.Ocr;
using Patagames.Ocr.Enums;

namespace CSE.Source
{
    class ImgRecogn
    {
        public void ImageToText()
        {
            using (var api = OcrApi.Create())
            {
                api.Init(Languages.English);
                string plainText = api.GetTextFromImage(@"C:\Users\Marcius\Desktop\test3.jpg");
                Console.WriteLine(plainText);
            }
        }
    }
}
