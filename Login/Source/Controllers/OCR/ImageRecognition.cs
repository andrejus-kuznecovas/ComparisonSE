/*using System;
using Android.App;
using System.Threading.Tasks;
using Tesseract.Droid;
using Android.Graphics;
using System.IO;

namespace Login.Source.Controllers.OCR
{
    public class ImageRecognition: ITextRecognizer
    {
        // Event to be called after the recognition is done
        private EventHandler<OCRText> OnOCRComplete;

        public void AddOnCompleteHandler(EventHandler<OCRText> action)
        {
            OnOCRComplete = action;
        }

        /// <summary>
        /// Extract text from the given image using Tesseract OCR
        /// </summary>
        /// <param name="image">Image to be recognized from</param>
        
        public async void GetTextFromImage(Bitmap image)
        {
            try
            {
                // Get Tesseract API for current context
                using (var tesseract = new TesseractApi(Application.Context, AssetsDeployment.OncePerInitialization))
                {
                    // Convert image to byte[] for this Tesseract implementation
                    byte[] imageBytes;
                    using (var stream = new MemoryStream())
                    {
                        image.Compress(Bitmap.CompressFormat.Png, 0, stream);
                        imageBytes = stream.ToArray();
                    }

                    // Initialize Tesseract with Lithuanian language trained data
                    await tesseract.Init("lit+eng",Tesseract.OcrEngineMode.TesseractOnly);

                    // Set special code segmentation mode for receipts
                    tesseract.SetPageSegmentationMode(Tesseract.PageSegmentationMode.SingleBlock);

                    // Set Image and perform recognition on another thread
                    var successful = await Task.Run(
                        () => tesseract.SetImage(imageBytes)
                    );

                    if (successful)
                    {
                        
                        if (OnOCRComplete != null)
                        {
                            // If text detection was successful, return text from the image
                            OnOCRComplete(new ImageRecognition(), new OCRText(tesseract.Text));
                        }
                    }
                    else
                    {
                        if (OnOCRComplete != null)
                        {
                            // If text detection was not successful, return null
                            OnOCRComplete(new ImageRecognition(), new OCRText(null));
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
}*/