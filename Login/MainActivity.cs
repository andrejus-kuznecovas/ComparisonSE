using System;

using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using SupportToolbar = Android.Support.V7.Widget.Toolbar;
using Android.Support.V7.App;
using Android.Support.V4.Widget;
using Android.Support.V7.Widget;
//using Android.Support.Design.Widget;
using System.Collections.Generic;
using SupportFragment = Android.Support.V4.App.Fragment;
using Java.Lang;
using Android.Provider;
using Android.Graphics;

namespace Login
{
    [Activity(Label = "Login", MainLauncher = true, Icon = "@drawable/billyicon", Theme = "@style/CustomActionBarTheme")]
    public class MainActivity : ActionBarActivity
    {

        ProgressBar circle;
        DrawerLayout drawerLayout;
        List<string> leftItems = new List<string>();
        ArrayAdapter<string> leftAdapter;
        ListView leftDrawer;
        ActionBarDrawerToggle drawerToggle;
        private TextView kmiNr;
        private SupportToolbar mToolbar;
       
        //USER INPUT
        private string pass;
        static public string name;
        private string email;
        private int age;
        //
        private bool ableToStart = false;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);
            Button signUpBtn = FindViewById<Button>(Resource.Id.login_signUpButton);
            signUpBtn.Click += SignUpBtn_Click;
            circle = FindViewById<ProgressBar>(Resource.Id.login_progress_bar);
            Button signIn = FindViewById<Button>(Resource.Id.login_signInButton);
            signIn.Click += SignIn_Click;
        }

        private void SignIn_Click(object sender, System.EventArgs e)
        {
            if (ableToStart)
            {
                Intent intent = new Intent(this, typeof(WelcomeScreen));
                StartActivity(intent);
               
            }
        }
      
 
        public override void OnConfigurationChanged(Android.Content.Res.Configuration newConfig)
        {
            base.OnConfigurationChanged(newConfig);
            drawerToggle.OnConfigurationChanged(newConfig);
        }
        private void SignUpBtn_Click(object sender, System.EventArgs e)
        {
            Android.App.FragmentTransaction transaction = FragmentManager.BeginTransaction();
            Dialog signUpD = new Dialog();
            signUpD.Show(transaction, "Dialog frag");


            signUpD.signUpComplete += signUpD_signUpComplete;
        }
        void signUpD_signUpComplete(object sender, OnSignUpEventArgs e)
        {
            circle.Visibility = Android.Views.ViewStates.Visible;
            Thread thread = new Thread(actRequest);
            thread.Start();
            if ((e.Password == null) && (e.FirstName == null) && (e.Email == null) &&
                (e.Age == null))
            {
                ableToStart = false;
            }
            else
            {
                ableToStart = true;
            }
            pass = e.Password;
            name = e.FirstName;
            email = e.Email;
            age = Integer.ParseInt(e.Age);


        }
        private void actRequest()
        {
            Thread.Sleep(3000);
            RunOnUiThread(() => { circle.Visibility = Android.Views.ViewStates.Invisible; });
        }
        protected override void OnPostCreate(Bundle savedInstanceState)
        {
            base.OnPostCreate(savedInstanceState);

        }
        public override bool OnOptionsItemSelected(IMenuItem item)
        {


            if (drawerToggle.OnOptionsItemSelected(item))
            {


                return true;
            }

            return base.OnOptionsItemSelected(item);

        }
    }
}

