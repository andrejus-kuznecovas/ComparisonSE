using Android.Graphics;
using ScanbotSDK.Xamarin;
using ScanbotSDK.Xamarin.Android.Wrapper;

namespace Login.Source.Controllers.OCR
{
    public class ImagePreparer
    {
        /// <summary>
        /// Prepare image for text recognition by applying grayscale filter
        /// </summary>
        /// <param name="image">Image to be prepared</param>
        /// <returns></returns>
        public static Bitmap PrepareForRecognition(Bitmap image)
        {
            var binarized = Binarize(image);
            var rotated = Rotate(binarized, 90);
            return rotated;
        }

        /// <summary>
        /// Make photo black and white thus removing noise and shadows
        /// </summary>
        /// <param name="image"></param>
        /// <returns></returns>
        public static Bitmap Binarize(Bitmap image)
        {
            return SBSDK.ApplyImageFilter(image, ImageFilter.Binarized);
        }


        /// <summary>
        /// Rotate image by defined degrees
        /// </summary>
        /// <param name="image"></param>
        /// <returns></returns>
        public static Bitmap Rotate(Bitmap image, int degrees)
        {
            Matrix matrix = new Matrix();
            matrix.PostRotate(degrees);

            return Bitmap.CreateBitmap(image, 0, 0, image.Width,
                                            image.Height, matrix, true);
        }
    }
}