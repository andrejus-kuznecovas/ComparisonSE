using Android.Graphics;

namespace Login.Source.Controllers.OCR
{
    public class ImageConverter
    {
        /// <summary>
        /// Prepare image for text recognition by applying grayscale filter
        /// </summary>
        /// <param name="image">Image to be prepared</param>
        /// <returns></returns>
        public static Bitmap PrepareForRecognition(Bitmap image)
        {
            // First of all, we need to make image grayscale, to make text recognition better
            var grayscaled = ToGrayscale(image);
            return grayscaled;
        }

        public static Bitmap ToGrayscale(Bitmap image)
        {
                // Copy original image, make it mutable
                Bitmap grayscaled = image.Copy(Bitmap.Config.Argb8888, true);

                // Create canvas based upon original image
                Canvas canvas = new Canvas(grayscaled);
                Paint paint = new Paint();


                // Make it black and white
                ColorMatrix matrix = new ColorMatrix();
                matrix.SetSaturation(0);

                // Apply filter based on matrix
                var filter = new ColorMatrixColorFilter(matrix);
                paint.SetColorFilter(filter);

                // Draw filtered image
                canvas.DrawBitmap(image, 0, 0, paint);

                // Garbage collection for old image
                image.Recycle();
                return grayscaled;

        }
    }
}