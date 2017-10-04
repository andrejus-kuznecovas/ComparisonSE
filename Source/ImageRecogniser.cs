using System;
using System.Diagnostics;

namespace Tesseract.ConsoleDemo
{
    public class ImageRecogniser
    {
        public string GetText(string path)
        {
            try
            {
                
                using (var engine = new TesseractEngine(@"./tessdata", "lit", EngineMode.Default))
                {
                    engine.DefaultPageSegMode = PageSegMode.SingleBlock; // important to read receipts
                    using (var img = Pix.LoadFromFile(path))
                    {
                        using (var page = engine.Process(img))
                        {
                            return page.GetText();
                        }
                    }
                }
                
            }
            catch (Exception e)
            {
                Trace.TraceError(e.ToString());
                
                return "Unexpected error" + e.Message;
            }
        }
    }
}
