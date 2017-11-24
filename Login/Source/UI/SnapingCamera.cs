using Android.App;
using Android.Content;
using Android.Graphics;
using Android.OS;
using Android.Support.V4.Content;
using Android.Support.V7.App;
using Android.Widget;
using Login.Source.Controllers.OCR;
using Login.Source.UI;

// native SDK namespace
using Net.Doo.Snap.Camera;
using Net.Doo.Snap.Lib.Detector;
using Net.Doo.Snap.UI;

// Wrapper namespace
using ScanbotSDK.Xamarin;
using ScanbotSDK.Xamarin.Android.Wrapper;

namespace Login
{
    [Activity(Theme = "@style/Theme.Brand")]
    public class SnapingCamera : AppCompatActivity, IPictureCallback, ContourDetectorFrameHandler.IResultHandler, ICameraOpenCallback
    {
        protected ScanbotCameraView cameraView;
        protected AutoSnappingController autoSnappingController;
        protected bool flashEnabled = false;
        protected ImageView resultImageView;
        protected TextView userGuidanceTextView;

        public static Bitmap Image;


        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Use our example view (MyCameraView.axml)
            SetContentView(Resource.Layout.SnapingCameraLayout);

            SupportActionBar.Hide();

            cameraView = FindViewById<ScanbotCameraView>(Resource.Id.scanbotCameraView);
            resultImageView = FindViewById<ImageView>(Resource.Id.scanbotResultImageView);

            userGuidanceTextView = FindViewById<TextView>(Resource.Id.userGuidanceTextView);

            ContourDetectorFrameHandler contourDetectorFrameHandler = ContourDetectorFrameHandler.Attach(cameraView);
            PolygonView polygonView = FindViewById<PolygonView>(Resource.Id.scanbotPolygonView);
            contourDetectorFrameHandler.AddResultHandler(polygonView);
            contourDetectorFrameHandler.AddResultHandler(this);
            //autoSnappingController = AutoSnappingController.Attach(cameraView, contourDetectorFrameHandler);
            //// Set the sensitivity of AutoSnappingController
            //// Range is from 0 to 1, where 1 is the most sensitive. The more sensitive it is the faster it shoots.
            //autoSnappingController.SetSensitivity(1.0f);

            cameraView.AddPictureCallback(this);
            cameraView.SetCameraOpenCallback(this);

            FindViewById(Resource.Id.scanbotSnapButton).Click += delegate {
                cameraView.TakePicture(false);
            };

            FindViewById(Resource.Id.scanbotFlashButton).Click += delegate {
                cameraView.UseFlash(!flashEnabled);
                flashEnabled = !flashEnabled;
            };
        }

        protected override void OnResume()
        {
            base.OnResume();
            cameraView.OnResume();
        }

        protected override void OnPause()
        {
            base.OnPause();
            cameraView.OnPause();
        }

        public void OnCameraOpened()
        {
            cameraView.PostDelayed(() => {
                // Enable continuous focus mode
                cameraView.ContinuousFocus();
            }, 300);
        }

        public bool HandleResult(ContourDetectorFrameHandler.DetectedFrame result)
        {
            // Here you are continiously notified about contour detection results.
            // For example, you can set a localized text for user guidance depending on the detection status.

            var color = new Color(ContextCompat.GetColor(Application.Context, Resource.Color.primary_dark));
            var guideText = GetString(Resource.String.camera_view_receipt_too_far);

            if (result.Polygon == null || result.Polygon.Count == 0)
            {
                guideText = GetString(Resource.String.camera_view_receipt_not_found);
            }

            if (result.DetectionResult == DetectionResult.Ok)
            {
                guideText = GetString(Resource.String.camera_view_receipt_found);
            }
            // else ...

            // Warning: The HandleResult callback is coming from a worker thread. Use main UI thread to update the UI elements.
            userGuidanceTextView.Post(() => {
                userGuidanceTextView.Text = guideText;
                userGuidanceTextView.SetTextColor(color);
            });

            return false;
        }

        public void OnPictureTaken(byte[] image, int imageOrientation)
        {
            // Here we get the full image from the camera.

            Bitmap processedImage = BitmapFactory.DecodeByteArray(image, 0, image.Length, new BitmapFactory.Options());

            // Run document detection on image:
            var detectionResult = SBSDK.DocumentDetection(processedImage);
            if (detectionResult.Status.IsOk())
            {
                processedImage = detectionResult.Image as Bitmap;
            }
            processedImage = ImagePreparer.PrepareForRecognition(processedImage);


            


            Image = processedImage;
            
            Intent itemView = new Intent(this, typeof(ItemDisplayer));
            StartActivity(itemView);
        }
    }
}
