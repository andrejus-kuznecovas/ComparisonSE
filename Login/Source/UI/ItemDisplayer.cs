using System;
using Android.App;
using Android.OS;
using Android.Widget;
using AndroidNetUri = Android.Net.Uri;
using Login.Source.Controllers.OCR;
using System.Threading;

namespace Login.Source.UI
{
    [Activity(Theme = "@style/Theme.Brand")]
    class ItemDisplayer:Activity
    {
        private TextView textView;

        

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);


            SetContentView(Resource.Layout.ShowText);

            textView = FindViewById<TextView>(Resource.Id.showTxt);
            var image = SnapingCamera.Image;

            var imageRecognizer = new ImageRecognitionScanbot(this);
            imageRecognizer.OnOCRComplete += SetText;


            Thread imageRecognitionThread = new Thread(delegate ()
            {
                imageRecognizer.GetTextFromImage(image);
            });
            imageRecognitionThread.Start();


        }

        protected void SetText(object sender, OCRText result)
        {
            textView = FindViewById<TextView>(Resource.Id.showTxt);
            string text = result.text;
            textView.Text = String.IsNullOrEmpty(text) ? "NULL" : text;
        }
    }
    
}