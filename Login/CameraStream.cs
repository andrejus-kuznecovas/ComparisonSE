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
        int width;
        int height;
        

        protected override void OnCreate(Bundle bundle)
        {
            width = Resources.DisplayMetrics.WidthPixels/2;
             height = Resources.DisplayMetrics.HeightPixels/2;
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.CameraLayout);

            _textureView = FindViewById<TextureView>(Resource.Id.textureView);
            _textureView.SurfaceTextureListener = this;
            _surfaceView = FindViewById<SurfaceView>(Resource.Id.surfaceView);
            takePhoto = FindViewById<Button>(Resource.Id.captureImage);
            _surfaceView.SetZOrderOnTop(true);
            //set the background to transparent
            _surfaceView.Holder.SetFormat(Format.Transparent);
            holder = _surfaceView.Holder;
          
        }

       


        public void OnSurfaceTextureAvailable(Android.Graphics.SurfaceTexture surface, int w, int h)
        {
            _camera = Android.Hardware.Camera.Open();

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
            mpaint.Color = Color.DarkOrchid;
            mpaint.SetStyle(Paint.Style.Stroke);
            mpaint.StrokeWidth = 5f;
            mpaint.SetPathEffect(new DashPathEffect(new float[] { 30, 20 }, 0));
            int width1 = width / 20;
            int height1 = height / 20;
           
            Canvas canvas = holder.LockCanvas();
    
            canvas.DrawColor(Color.Transparent, PorterDuff.Mode.Clear);
            Rect r = new Rect(width1, height1, width*2-width1*2, height*2-height1*7);
          
            
            canvas.DrawRect(r, mpaint);
            holder.UnlockCanvasAndPost(canvas);

        }

        public void OnPreviewFrame(byte[] data, Android.Hardware.Camera camera)
        {
            throw new NotImplementedException();
        }
    }
}