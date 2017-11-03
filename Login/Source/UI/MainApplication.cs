using Android.App;
using Android.Runtime;
using ScanbotSDK.Xamarin.Android.Wrapper;
using System;

namespace Login.Source.UI
{
    [Application(LargeHeap = true)]
    public partial class MainApplication : Application
    {

        private const string licenseKey = "QarRdq9Wq2yitCl2WG0aCme15JOLNb" +
          "cZmKpv/x7gxYuO6HkvY4+9IPff/xPH" +
          "C3lWm6if5r28+u/CofIkdEENrEE+T8" +
          "cvu1KJnajXYFOTIhyNnU0xwgWAZZ1Z" +
          "2JVf1ikji4zj+BW8RbcpJEeVqTbWDz" +
          "/dwAezx7BeHsrR/hEH93kJRjC1d8Jm" +
          "vf76p9aj0cNJ/oQ0erfYADQfH1uufH" +
          "hhsVhdqVlR88hUTGkkV5slFmAJJBtg" +
          "1OzyLcckycCO9Zo+bEaHDrkEDsqInJ" +
          "I79PlUfBOE1hTsBomFryQU0BZfseTQ" +
          "HxDgptU+JV8YHiLpQ+7bCMiCe9mMIw" +
          "oxSrWvtLN5rQ==\nU2NhbmJvdFNESw" +
          "ptaWYudnUuYmlsbHkKMTUxMjI1OTE5" +
          "OQo5NAoy\n";

        public MainApplication(IntPtr handle, JniHandleOwnership transfer) : base(handle, transfer)
        {

        }

        public override void OnCreate()
        {
            base.OnCreate();
            SBSDK.Initialize(this, licenseKey, true);
        }
    }
}