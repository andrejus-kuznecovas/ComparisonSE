using System;

using Android.App;
using Android.Content;
using Android.OS;

using Android.Widget;
using Login.Source.Controllers;
using Login.Source.UI;
using OxyPlot.Xamarin.Android;
using System.Json;
using Login.Source.Controllers.Auth;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Login
{
    [Activity(Theme = "@style/Theme.Brand")]
    class WelcomeScreen : Activity
    {
        private Button photoButton;
        private Button statisticButton;
        private TextView welcomeText;
        private PlotView plotView;
        private Spinner type;
        private Dictionary<string, float> pieChartData = new Dictionary<string, float>();
        private Dictionary<DateTime, float> linearChartData = new Dictionary<DateTime, float>();
        
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
             
            photoButton = FindViewById<Button>(Resource.Id.photoButton);
            plotView = FindViewById<PlotView>(Resource.Id.plot_View);
            type = FindViewById<Spinner>(Resource.Id.categoryType);

            
            



            photoButton.Click += PhotoButton_Click;
            type.ItemSelected += ChooseItem;
        }

        public void DisplayPieChart()
        {
            if(pieChartData.Count <= 0)
            {
                // Get the data from the server
                StatisticsApiManager.OnDataRetrieved = PopulatePieChartData;
                Task.Run(() => StatisticsApiManager.TotalSpendings(UserController.GetUserID, UserController.UserToken));
            }
            this.RunOnUiThread(() => plotView.Model = Statistics.pieChart(pieChartData));
        }

        public void PopulatePieChartData(object sender, StatisticsEventArgs eventArgs)
        {
            if (eventArgs != null)
            {
                dynamic data = eventArgs.statistics.data;
                foreach (dynamic dataPoint in data)
                {
                    pieChartData.Add((string)dataPoint.name, (float)dataPoint.sum);
                }
            }
            this.RunOnUiThread(() => plotView.Model = Statistics.pieChart(pieChartData));
        }

        public void DisplayLinearGraph()
        {
            if (linearChartData.Count <= 0)
            {
                // Get the data from the server
                StatisticsApiManager.OnDataRetrieved = PopulateLinearChartData;

                // ADD DROPDOWN TO SELECT CATEGORY LATER
                Task.Run(() => StatisticsApiManager.PriceChange(Category.BREAD_PRODUCTS));
            }
            this.RunOnUiThread(() => plotView.Model = Statistics.linearChart(linearChartData));
            
        }


        public void PopulateLinearChartData(object sender, StatisticsEventArgs eventArgs)
        {
            if (eventArgs != null)
            {
                dynamic data = eventArgs.statistics.data;
                foreach (dynamic dataPoint in data)
                {
                    linearChartData.Add(Convert.ToDateTime((string)dataPoint.date), (float)dataPoint.average_price);
                }
            }
            this.RunOnUiThread(() => plotView.Model = Statistics.linearChart(linearChartData));
        }

        private void ChooseItem(object sender, EventArgs e)
        {
            if (type.SelectedItem.ToString() == type.GetItemAtPosition(0).ToString())
            {
                DisplayPieChart();
            }
            if (type.SelectedItem.ToString() == type.GetItemAtPosition(1).ToString())
            {
                DisplayLinearGraph();
            }
           
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
