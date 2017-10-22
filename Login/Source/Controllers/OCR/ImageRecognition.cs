using System;
using Android.App;
using System.Threading.Tasks;
using Tesseract.Droid;

namespace Login.Source.Controllers.OCR
{
    class ImageRecognition
    {
        public static async Task<string> GetTextFromImage(byte[] image)
        {
            try
            {
                // Get Tesseract API for current context
                using (var tesseract = new TesseractApi(Application.Context, AssetsDeployment.OncePerInitialization))
                {
                    // Initialize Tesseract with Lithuanian language trained data
                    await tesseract.Init("lit+eng");

                    // Set special code segmentation mode for receipts
                    tesseract.SetPageSegmentationMode(Tesseract.PageSegmentationMode.SingleBlock);

                    // Set Image and perform recognition on another thread
                    var successful = await Task.Run(
                        () => tesseract.SetImage(image)
                    );

                    if (successful)
                    {
                        // If text detection was successful, return text from the image
                        return tesseract.Text;
                    }
                    return "";
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
}