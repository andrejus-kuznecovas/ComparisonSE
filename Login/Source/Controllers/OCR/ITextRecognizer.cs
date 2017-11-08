using Android.Graphics;
using System;

namespace Login.Source.Controllers.OCR
{
    interface ITextRecognizer
    {
        void GetTextFromImage(Bitmap image);

        void AddOnCompleteHandler(EventHandler<OCRText> action);
    }
}