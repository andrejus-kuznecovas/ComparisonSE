using System;
using Android.App;
using System.Threading.Tasks;
using Tesseract.Droid;
using System.IO;

namespace Login.Source.Controllers.OCR
{
    public class ImageRecognition: IOCR
    {
        // Event to be called after the recognition is done
        public EventHandler<OCRText> OnRecognition;

        /// <summary>
        /// Extract text from the given image using Tesseract OCR
        /// </summary>
        /// <param name="image">Image to be recognized from</param>
        
        public async Task GetTextFromImage(byte[] image)
        {
            try
            {
                // Get Tesseract API for current context
                using (var tesseract = new TesseractApi(Application.Context, AssetsDeployment.OncePerInitialization))
                {
                    // Initialize Tesseract with Lithuanian language trained data
                    await tesseract.Init("lit+eng",Tesseract.OcrEngineMode.TesseractOnly);

                    // Set special code segmentation mode for receipts
                    tesseract.SetPageSegmentationMode(Tesseract.PageSegmentationMode.SingleBlock);

                    // Set Image and perform recognition on another thread
                    var successful = await Task.Run(
                        () => tesseract.SetImage(image)
                    );

                    if (successful)
                    {
                        
                        if (OnRecognition != null)
                        {
                            // If text detection was successful, return text from the image
                            OnRecognition(new ImageRecognition(), new OCRText(tesseract.Text));
                        }
                    }
                    else
                    {
                        if (OnRecognition != null)
                        {
                            // If text detection was not successful, return null
                            OnRecognition(new ImageRecognition(), new OCRText(null));
                        }
                    }
                }
            }
            catch (InvalidOperationException e)
            {
                // Is thrown when we try to get text if API is not initalized
                throw new InvalidOperationException("Tesseract API was not initalized");
            }

            catch (ArgumentNullException e)
            {
                // Is thrown when image is not set
                throw new ArgumentNullException("Image was not set");
            }
        }

    }

    public class OCRText : EventArgs
    {
        public string text;

        public OCRText(string text)
        {
            this.text = text;
        }
    }
}