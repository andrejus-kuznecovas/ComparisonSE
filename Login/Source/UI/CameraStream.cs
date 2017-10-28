using System;

using Android.App;
using Android.OS;
using Android.Views;
using Android.Widget;
using Android.Hardware;
using Android.Graphics;
using Android.Content.PM;


using Camera = Android.Hardware.Camera;
using Color = Android.Graphics.Color;
using Console = System.Console;
using View = Android.Views.View;
using System.IO;
using Login.Source.UI;
using Android.Content;
using System.Threading.Tasks;
using Java.Nio;
using System.Drawing;
using Login.Source.Controllers.OCR;
using Android.Support.V4.Content;

namespace Login
{
    [Activity(ScreenOrientation = ScreenOrientation.Portrait, Theme = "@style/Theme.Brand")]
    public class CameraStream : Activity, TextureView.ISurfaceTextureListener
    {
        private Android.Hardware.Camera _camera;
        private TextureView _textureView;
        private SurfaceView _surfaceView;
        private ISurfaceHolder holder;
        private Button takePhoto;
        private Button analyseButton;
        private Button retakeButton;
        private TextView txt;
        int screenWidth;
        int screenHeight;
        static byte[] img = null;


        protected override void OnCreate(Bundle bundle)
        {
            screenWidth = Resources.DisplayMetrics.WidthPixels;
            screenHeight = Resources.DisplayMetrics.HeightPixels;
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.CameraLayout);
            analyseButton = FindViewById<Button>(Resource.Id.show);
            analyseButton.Visibility = ViewStates.Invisible;
            retakeButton = FindViewById<Button>(Resource.Id.retake);
            retakeButton.Visibility = ViewStates.Invisible;
            _textureView = FindViewById<TextureView>(Resource.Id.textureView);
            _textureView.SurfaceTextureListener = this;
            _surfaceView = FindViewById<SurfaceView>(Resource.Id.surfaceView);
            takePhoto = FindViewById<Button>(Resource.Id.captureImage);
            _surfaceView.SetZOrderOnTop(true);
            txt = FindViewById<TextView>(Resource.Id.place_items_hint);
            //set the background to transparent

            _surfaceView.Holder.SetFormat(Format.Transparent);
            holder = _surfaceView.Holder;

            takePhoto.Click += TakePhoto_Click;
            analyseButton.Click += analyseButton_Click;
            retakeButton.Click += RetakeButton_Click;
        }

        private void RetakeButton_Click(object sender, EventArgs e)
        {
            _camera.StartPreview();
            takePhoto.Visibility = ViewStates.Visible;
            analyseButton.Visibility = ViewStates.Invisible;
            retakeButton.Visibility = ViewStates.Invisible;

        }

        private void analyseButton_Click(object sender, EventArgs e)
        {
            Intent intent = new Intent(this, typeof(ItemDisplayer));
            StartActivity(intent);
        }

        private async void TakePhoto_Click(object sender, EventArgs e)
        {
            try
            {
                _camera.StopPreview();
                var imageBitmap = _textureView.Bitmap;
                analyseButton.Visibility = ViewStates.Visible;
                retakeButton.Visibility = ViewStates.Visible;
                takePhoto.Visibility = ViewStates.Invisible;
                using (var imageStream = new MemoryStream())
                {
                    double scalingFactor = 0.5;
                    int imageWidth = (int)(imageBitmap.Width * scalingFactor);
                    int imageHeight = (int)(imageBitmap.Height * scalingFactor);
                    var resizedBitmap = Bitmap.CreateScaledBitmap(imageBitmap, imageWidth, imageHeight, true);
                    
                    var preparedBitmap = ImageConverter.PrepareForRecognition(resizedBitmap);
                    await preparedBitmap.CompressAsync(Bitmap.CompressFormat.Jpeg, 100, imageStream);
                    
                    img = imageStream.ToArray();
                    imageBitmap.Recycle();
                    resizedBitmap.Recycle();
                    preparedBitmap.Recycle();

                };
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("*************************\n"+ex.Message);
            }

            


        }

        public static byte[] GetImage()
        {
            return img;
        }


        public void OnSurfaceTextureAvailable(Android.Graphics.SurfaceTexture surface, int w, int h)
        {
            _camera = Camera.Open();

            try
            {
                _camera.SetPreviewTexture(surface);

                _camera.SetDisplayOrientation(90);
                _camera.StartPreview();


            }
            catch (Java.IO.IOException ex)
            {
                Console.WriteLine(ex.Message);
            }
            Camera.Parameters tmp = _camera.GetParameters();
            tmp.FocusMode = Camera.Parameters.FocusModeContinuousPicture;
            _camera.SetParameters(tmp);
            DrawRectangle();
        }

        public bool OnSurfaceTextureDestroyed(Android.Graphics.SurfaceTexture surface)
        {
            _camera.StopPreview();
            _camera.Release();

            return true;
        }

        public void OnSurfaceTextureSizeChanged(Android.Graphics.SurfaceTexture surface, int width, int height)
        {
            // camera takes care of this
        }

        public void OnSurfaceTextureUpdated(Android.Graphics.SurfaceTexture surface)
        {

        }
        private void DrawRectangle()
        {
            //define the paintbrush
            Paint mpaint = new Paint();
            mpaint.Color = new Color(ContextCompat.GetColor(Application.Context ,Resource.Color.brand_dark));
            mpaint.SetStyle(Paint.Style.Stroke);
            mpaint.StrokeWidth = 5f;
            mpaint.SetPathEffect(new DashPathEffect(new float[] { 30, 20 }, 0));
            int paddingLeft = screenWidth / 20;
            int paddingTop = screenHeight / 20;

            Canvas canvas = holder.LockCanvas();

            canvas.DrawColor(Color.Transparent, PorterDuff.Mode.Clear);
            Rect r = new Rect(paddingLeft, paddingTop, screenWidth - paddingLeft, screenHeight - paddingTop * 3);


            canvas.DrawRect(r, mpaint);
            holder.UnlockCanvasAndPost(canvas);

        }
    }
}