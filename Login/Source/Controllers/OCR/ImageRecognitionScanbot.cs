using System;
using System.Threading.Tasks;
using Android.App;
using Net.Doo.Snap.Process;
using Net.Doo.Snap.Persistence;
using Net.Doo.Snap.Blob;
using System.Collections.Generic;
using Net.Doo.Snap.Entity;
using Android.Graphics;
using Net.Doo.Snap.Util;
using ScanbotSDK.Xamarin.Android.Wrapper;

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

    public class ImageRecognitionScanbot : IOCR
    {
        private static List<Language> ocrLanguages = new List<Language>();
        private PageFactory pageFactory;
        private ITextRecognition textRecognition;
        private BlobManager blobManager;
        private BlobFactory blobFactory;
        private Activity activity;


        /// <summary>
        /// Event to happen when the text is successfully detected
        /// </summary>
        public EventHandler<OCRText> OnOCRComplete;

        public ImageRecognitionScanbot(Activity activity)
        {

            // Initialize all the components needed for the SDK

            this.activity = activity;

            // Set recognition languages
            ocrLanguages.Add(Language.Lit);
            //ocrLanguages.Add(Language.Eng);


            var scanbotSDK = new Net.Doo.Snap.ScanbotSDK(activity);
            pageFactory = scanbotSDK.PageFactory();
            textRecognition = scanbotSDK.TextRecognition();
            blobManager = scanbotSDK.BlobManager();
            blobFactory = scanbotSDK.BlobFactory();
            FetchOcrBlobFiles();
        }

        private List<Blob> OcrBlobs()
        {
            // Create a collection of required OCR blobs:
            var blobs = new List<Blob>();

            // Language detector blobs of the Scanbot SDK. (see "language_classifier_blob_path" in AndroidManifest.xml!)
            foreach (var b in blobFactory.LanguageDetectorBlobs())
            {
                blobs.Add(b);
            }

            // OCR blobs of languages (see "ocr_blobs_path" in AndroidManifest.xml!)
            foreach (var lng in ocrLanguages)
            {
                foreach (var b in blobFactory.OcrLanguageBlobs(lng))
                {
                    blobs.Add(b);
                }
            }

            return blobs;
        }


        private void FetchOcrBlobFiles()
        {
            // Fetch OCR blob files from the sources defined in AndroidManifest.xml
            Task.Run(() =>
            {
                try
                {
                    foreach (var blob in OcrBlobs())
                    {
                        if (!blobManager.IsBlobAvailable(blob))
                        {
                            System.Diagnostics.Debug.WriteLine("Fetching OCR blob file: " + blob);
                            blobManager.Fetch(blob, false);
                        }
                    }
                }
                catch (Exception e)
                {
                    System.Diagnostics.Debug.WriteLine("Error fetching OCR blob files", e);
                }
            });
        }

        /// <summary>
        /// Perform OCR and get text from the given image
        /// </summary>
        /// <param name="image">Text from the image</param>
        public void GetTextFromImage(Bitmap image)
        {
            try
            {
                // Turn image into Page (needed for OCR)
                TempImageStorage storage = new TempImageStorage();
                storage.AddImage(image);
                var images = storage.GetImages();

                var path = FileChooserUtils.GetPath(activity, images[0]);
                var imageFile = new Java.IO.File(path);
                var pages = new List<Page>();
                var page = pageFactory.BuildPage(imageFile);
                pages.Add(page);

                // Result of the whole recognition
                var fullOcrResult = textRecognition.WithoutPDF(ocrLanguages, pages).Recognize();

                // Call the event in the case of success
                if (OnOCRComplete != null)
                {
                    // Save the recognized text in the event argument
                    activity.RunOnUiThread( () => OnOCRComplete(this, new OCRText(fullOcrResult.RecognizedText)));
                    
                }

            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.WriteLine("Error performing OCR" + e.Message);
            }
        }

       

    }
}