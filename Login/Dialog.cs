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

namespace Login
{
    public class OnSignUpEventArgs : EventArgs
    {
        private string name;
        private string email;
        private string password;
        private string age;
       
        public string FirstName
        {
            get { return name; }
            set { name = value; }
        }
        public string Password
        {
            get { return password; }
            set { password = value; }
        }
        public string Email
        {
            get { return email; }
            set { email = value; }
        }
        public string Age
        {
            get { return age; }
            set { age = value; }
        }
       
        public OnSignUpEventArgs(string name, string password, string email, string age):base()
        {
            this.name = name;
            this.password = password;
            this.email = email;
            this.age = age;
           
        }
        
    }
    public class Dialog : DialogFragment
    {
        private EditText name;
        private EditText password;
        private EditText email;
        static private EditText age;
        private Button signUpBtn;

        public EventHandler<OnSignUpEventArgs> signUpComplete;
        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
             base.OnCreateView(inflater, container, savedInstanceState);
            var view = inflater.Inflate(Resource.Layout.dialog_sign_up, container, false);

            name = view.FindViewById<EditText>(Resource.Id.txtFirstName);
            password = view.FindViewById<EditText>(Resource.Id.txtPassword);
            email = view.FindViewById<EditText>(Resource.Id.txtEmail);
            age = view.FindViewById<EditText>(Resource.Id.txtAge);
         

            signUpBtn = view.FindViewById<Button>(Resource.Id.btnDialogEmail);

            signUpBtn.Click += SignUpBtn_Click;

            return view;
        }
        /*double userKmi = Calculations.BmiCalc(Convert.ToDouble(weight), Convert.ToDouble(height));
          double userIntake = Calculations.DailyIntake(Convert.ToDouble(weight), Convert.ToDouble(height), Convert.ToInt16(age), Convert.ToInt16(gender));

          Console.WriteLine(userKmi);
          Console.WriteLine(userIntake);
          Console.Read();*/

        private void SignUpBtn_Click(object sender, EventArgs e)
        {
           
                signUpComplete.Invoke(this, new OnSignUpEventArgs(name.Text, password.Text, email.Text, age.Text));
                this.Dismiss();
           
        }

        public override void OnActivityCreated(Bundle savedInstanceState)
        {
            Dialog.Window.RequestFeature(WindowFeatures.NoTitle);
            base.OnActivityCreated(savedInstanceState);
            Dialog.Window.Attributes.WindowAnimations = Resource.Style.dialog_anim;
        }

       
        public static int GetAge()
        {
            return Convert.ToInt32(age);
        }
     
    }
   
}