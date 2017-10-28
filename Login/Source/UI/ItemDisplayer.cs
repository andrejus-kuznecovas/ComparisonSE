using System;
using Android.App;
using Android.OS;
using Android.Widget;
using Login.Source.Controllers.OCR;
using System.Threading.Tasks;

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
            

            var image = CameraStream.GetImage();

            

            var imageRecognizer = new ImageRecognition();
            imageRecognizer.OnRecognition += SetText;

            Task.Run( () => imageRecognizer.GetTextFromImage(image));
            

        }

        protected void SetText(object sender, OCRText result)
        {
            textView = FindViewById<TextView>(Resource.Id.showTxt);
            string text = result.text;
            textView.Text = String.IsNullOrEmpty(text) ? "NULL" : text;
        }
    }
}