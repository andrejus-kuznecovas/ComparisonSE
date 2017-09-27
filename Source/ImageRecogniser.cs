using System;
using System.Diagnostics;

namespace Tesseract.ConsoleDemo
{
    public class ImageRecogniser
    {
        public string getText(string path)
        {
            
            var testImagePath = "./phototest.tif";
            if (path.Length > 0)
            {
                testImagePath = path;
                //return null;
            }

            try
            {
                using (var engine = new TesseractEngine(@"./tessdata", "lit", EngineMode.Default))
                {
                   
                    using (var img = Pix.LoadFromFile(testImagePath))
                    {
                        using (var page = engine.Process(img))
                        {
                            var text = page.GetText();
                         
                            using (var iter = page.GetIterator())
                            {
                                iter.Begin();

                                do
                                {
                                    do
                                    {
                                        do
                                        {
                                            do
                                            {
                                                if (iter.IsAtBeginningOf(PageIteratorLevel.Block))
                                                {
                                                    
                                                }

                                                Console.Write(iter.GetText(PageIteratorLevel.Word));
                                                Console.Write(" ");

                                                if (iter.IsAtFinalOf(PageIteratorLevel.TextLine, PageIteratorLevel.Word))
                                                {
                                                    Console.WriteLine();
                                                }
                                            } while (iter.Next(PageIteratorLevel.TextLine, PageIteratorLevel.Word));

                                            if (iter.IsAtFinalOf(PageIteratorLevel.Para, PageIteratorLevel.TextLine))
                                            {
                                                Console.WriteLine();
                                            }
                                        } while (iter.Next(PageIteratorLevel.Para, PageIteratorLevel.TextLine));
                                    } while (iter.Next(PageIteratorLevel.Block, PageIteratorLevel.Para));
                                } while (iter.Next(PageIteratorLevel.Block));
                            }
                            return text;
                        }
                    }
                }
                
            }
            catch (Exception e)
            {
                Trace.TraceError(e.ToString());
                
                return "Unexpected error" + e.Message;
            }
            //Console.Write("Press any key to continue . . . ");
            //Console.ReadKey(true);
        }
    }
}
