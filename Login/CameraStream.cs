using System;

using Android.App;
using Android.OS;
using Android.Views;
using Android.Widget;
using Android.Hardware;
using Android.Graphics;
using Android.Content.PM;

namespace Login
{
    [Activity(ScreenOrientation = ScreenOrientation.Portrait)]
    public class CameraStream : Activity, TextureView.ISurfaceTextureListener, Android.Hardware.Camera.IPreviewCallback
    {
        private Android.Hardware.Camera _camera;
        private TextureView _textureView;
        private SurfaceView _surfaceView;
        private ISurfaceHolder holder;
        private Button takePhoto;
        

        protected override void OnCreate(Bundle bundle)
        {
            
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


          int x = this.Resources.DisplayMetrics.HeightPixels/2;
            int y = this.Resources.DisplayMetrics.WidthPixels/2;
            DrawRectangle(x, y);


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
        private void DrawRectangle(float x, float y)
        {
            //define the paintbrush
            Paint mpaint = new Paint();
            mpaint.Color = Color.DarkOrchid;
            mpaint.SetStyle(Paint.Style.Stroke);
            mpaint.StrokeWidth = 2f;

           
            Canvas canvas = holder.LockCanvas();
    
            canvas.DrawColor(Color.Transparent, PorterDuff.Mode.Clear);
            Rect r = new Rect((int)x, (int)y, (int)x + 400, (int)y + 400);
            
            canvas.DrawRect(r, mpaint);
            holder.UnlockCanvasAndPost(canvas);

        }

        public void OnPreviewFrame(byte[] data, Android.Hardware.Camera camera)
        {
            throw new NotImplementedException();
        }
    }
}