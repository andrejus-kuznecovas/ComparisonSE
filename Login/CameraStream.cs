using System;

using Android.App;
using Android.OS;
using Android.Views;
using Android.Widget;
using Android.Hardware;
using Android.Graphics;

namespace Login
{
    [Activity()]
    public class CameraStream : Activity, TextureView.ISurfaceTextureListener
    {
        private Android.Hardware.Camera _camera;
        private TextureView _textureView;
        private SurfaceView _surfaceView;
        private ISurfaceHolder holder;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.CameraLayout);

            _textureView = FindViewById<TextureView>(Resource.Id.textureView);
            _textureView.SurfaceTextureListener = this;
            _surfaceView = FindViewById<SurfaceView>(Resource.Id.surfaceView);
            _surfaceView.SetZOrderOnTop(true);
            //set the background to transparent
            _surfaceView.Holder.SetFormat(Format.Transparent);
            holder = _surfaceView.Holder;
            _surfaceView.Touch += OnSurfaceViewTouch;
           
        }

        private void OnSurfaceViewTouch(object sender, View.TouchEventArgs e)
        {
            DrawRectangle(e.Event.GetX(), e.Event.GetY());
        }

        public void OnSurfaceTextureAvailable(Android.Graphics.SurfaceTexture surface, int w, int h)
        {
            _camera = Android.Hardware.Camera.Open();

            

            try
            {
                _camera.SetPreviewTexture(surface);
              //  _camera.SetDisplayOrientation(90);
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
            mpaint.Color = Color.Red;
            mpaint.SetStyle(Paint.Style.Stroke);
            mpaint.StrokeWidth = 2f;

            //draw
            Canvas canvas = holder.LockCanvas();
            //clear the paint of last time
            canvas.DrawColor(Color.Transparent, PorterDuff.Mode.Clear);
            //draw a new one, set your ball's position to the rect here
            Rect r = new Rect((int)x, (int)y, (int)x + 100, (int)y + 100);
            canvas.DrawRect(r, mpaint);
            holder.UnlockCanvasAndPost(canvas);

        }

    }
}