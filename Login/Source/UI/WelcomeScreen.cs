using System;

using Android.App;
using Android.Content;
using Android.OS;

using Android.Widget;
using Login.Source.Controllers;
using Login.Source.UI;

namespace Login
{
    [Activity(Theme = "@style/Theme.AppCompat")]
    class WelcomeScreen : Activity
    {
        private ImageView imageView;
        private Button photoButton;
        private Button statisticButton;
        private TextView welcomeText;
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);


            SetContentView(Resource.Layout.first);
            welcomeText = FindViewById<TextView>(Resource.Id.logged_in_welcome_text);
            if (UserController.IsUserInitialized())
            {
                string name = UserController.UserName;
                string surname = UserController.UserSurname;
                welcomeText.Text = String.Format("{0}, {1} {2}", Resources.GetString(Resource.String.welcome_text), name, surname );
            }
            imageView = FindViewById<ImageView>(Resource.Id.imageView);
            photoButton = FindViewById<Button>(Resource.Id.photoButton);
            statisticButton = FindViewById<Button>(Resource.Id.showAnalyseButton);
            photoButton.Click += PhotoButton_Click;
            statisticButton.Click += StatisticButton_Click;
        }

        private void StatisticButton_Click(object sender, EventArgs e)
        {
            Intent intent = new Intent(this, typeof(Statistics));
            StartActivity(intent);
        }

        private void PhotoButton_Click(object sender, EventArgs e)
        {
            Intent intent = new Intent(this, typeof(SnapingCamera));
            StartActivity(intent);

        }

    }


}
//ToolBar reikes ateityje
/*
drawerLayout = FindViewById<DrawerLayout>(Resource.Id.drawer_layout);
leftDrawer = FindViewById<ListView>(Resource.Id.left_drawer);
leftItems.Add("Vienas");
leftItems.Add("Du");
leftItems.Add("Trys");
leftItems.Add("Keturi");
leftItems.Add("Penki");
leftItems.Add("Sesi");
leftItems.Add("Septyni");


leftAdapter = new ArrayAdapter<string>(this, Android.Resource.Layout.SimpleListItem1, leftItems);
drawerToggle = new MyActionBarDrawerToggle(this, drawerLayout, Resource.String.open_drawer, Resource.String.close_drawer);
leftDrawer.Adapter = leftAdapter;

drawerLayout.SetDrawerListener(drawerToggle);

mToolbar = FindViewById<SupportToolbar>(Resource.Id.toolbar);
SetSupportActionBar(mToolbar);

SupportActionBar.SetDisplayHomeAsUpEnabled(true);
SupportActionBar.SetHomeButtonEnabled(true);
SupportActionBar.SetDisplayShowTitleEnabled(true);
}

*/
