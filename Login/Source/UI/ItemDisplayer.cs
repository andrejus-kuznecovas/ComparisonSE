using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Login.Source.Controllers.OCR;
using Android.Graphics;
using System.Threading.Tasks;

namespace Login.Source.UI
{
    [Activity(Theme = "@style/Theme.Brand")]
    class ItemDisplayer:Activity
    {
        private TextView textView;
        private ImageView img;
        byte[] image;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.ShowText);
            textView = FindViewById<TextView>(Resource.Id.showTxt);
            



            image = CameraStream.GetImage();
           // Bitmap bitmap = BitmapFactory.DecodeByteArray(image, 0, image.Length);
          

            // bbz kodel neveikia
            Task.Run(async () =>
            {
                var textFromImg = await ImageRecognition.GetTextFromImage(image);
                textView.Text = "Text:" + textFromImg + "pabaiga";
            });

            }
       
        
    }
}