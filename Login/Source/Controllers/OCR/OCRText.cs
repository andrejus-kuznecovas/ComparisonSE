using System;

namespace Login.Source.Controllers.OCR
{
    /// <summary>
    /// Event Args that have Recognition text in it
    /// </summary>
    public class OCRText : EventArgs
    {
        public string text;

        public OCRText(string text)
        {
            this.text = text;
        }

    }
}