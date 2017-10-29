using Android.App;
using Android.Runtime;
using ScanbotSDK.Xamarin.Android.Wrapper;
using System;

namespace Login.Source.UI
{
    [Application(LargeHeap = true)]
    public partial class MainApplication : Application
    {
        public MainApplication(IntPtr handle, JniHandleOwnership transfer) : base(handle, transfer)
        {

        }

        public override void OnCreate()
        {
            base.OnCreate();
            //SBSDK.Initialize(this, null, true);
        }
    }
}