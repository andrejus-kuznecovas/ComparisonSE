using Android.App;
using Android.Content;
using Android.Views;
using Android.Widget;
using Android.OS;
using SupportToolbar = Android.Support.V7.Widget.Toolbar;
using Android.Support.V7.App;
using Android.Support.V4.Widget;
using System.Collections.Generic;
using Login.Source.Controllers;
using Android.Views.InputMethods;


namespace Login
{
    [Activity(Label = "Login", MainLauncher = true, Icon = "@drawable/billyicon", Theme = "@style/CustomActionBarTheme")]
    public class MainActivity : Activity
    {

        ProgressBar circle;
        DrawerLayout drawerLayout;
        List<string> leftItems = new List<string>();
        ArrayAdapter<string> leftAdapter;
        ListView leftDrawer;
        ActionBarDrawerToggle drawerToggle;
        private SupportToolbar mToolbar;
       
        //USER INPUT
        private string pass;
        static public string name;
        private string email;
        //
        private bool ableToStart = false;
        private Android.App.AlertDialog.Builder alertDialog;

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

        private async void SignIn_Click(object sender, System.EventArgs e)
        {
            bool isReady = true;
            EditText usernameField = FindViewById<EditText>(Resource.Id.login_username);
            EditText passwordField = FindViewById<EditText>(Resource.Id.login_password);

            // Hide Keyboard when SignIn button is clicked
            InputMethodManager imm = (InputMethodManager)GetSystemService(Context.InputMethodService);
            imm.HideSoftInputFromWindow(passwordField.WindowToken, 0);

            if (usernameField.Text.Length > 0 && passwordField.Text.Length > 0)
            {
                string username = usernameField.Text;
                string password = passwordField.Text;
                circle.Visibility = Android.Views.ViewStates.Visible;
                if (await Authentication.Authenticate(username, password))
                {
                    Intent intent = new Intent(this, typeof(WelcomeScreen));
                    StartActivity(intent);
                }
                else
                {
                    alertDialog = new Android.App.AlertDialog.Builder(this.ApplicationContext);
                    alertDialog.SetMessage(GetString(Resource.String.Login_Authentication_Error));
                    alertDialog.SetNeutralButton("Tęsti", delegate
                    {
                        alertDialog.Dispose();
                    });
                    alertDialog.Show();
                    circle.Visibility = ViewStates.Visible;
                }
                
            }
            else
            {
               
                alertDialog = new Android.App.AlertDialog.Builder(this);
                alertDialog.SetMessage(GetString(Resource.String.Login_Empty_Fields_Error));
                alertDialog.SetNeutralButton(GetString(Resource.String.Continue_work), delegate
                {
                    alertDialog.Dispose();
                });
                alertDialog.Show();
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
        async void signUpD_signUpComplete(object sender, OnSignUpEventArgs e)
        {
            circle.Visibility = Android.Views.ViewStates.Visible;
            if ((e.Name != null) && (e.Surname != null) && (e.Email != null)
                && (e.Username != null) && (e.Password != null))
            {
                if (await Authentication.Register(e.Name, e.Surname,
                    e.Email,
                    e.Username, e.Password))
                {
                    Intent intent = new Intent(this, typeof(WelcomeScreen));
                    StartActivity(intent);
                }
            }

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

