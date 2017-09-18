using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Patagames.Ocr;
using Patagames.Ocr.Enums;

namespace CSE.Source
{
    class ImageRecogniser
    {
        public string ImageToText(string imgPath)
        {
            using (var api = OcrApi.Create())
            {
                api.Init(Languages.Lithuanian);
                string plainText = api.GetTextFromImage(@imgPath);
                return plainText;
            }
        }
    }
}
