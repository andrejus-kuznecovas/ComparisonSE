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
        private string surname;
        private string email;
        private string username;
        private string password;


        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        public string Surname
        {
            get { return surname; }
            set { surname = value; }
        }
        public string Email
        {
            get { return email; }
            set { email = value; }
        }
        public string Username
        {
            get { return username; }
            set { username = value; }
        }
        public string Password
        {
            get { return password; }
            set { password = value; }
        }


        public OnSignUpEventArgs(string name, string surname, string email, string username,string password ):base()
        {
            this.name = name;
            this.surname = surname;
            this.email = email;
            this.username = username;
            this.password = password;

        }
        
    }
    public class Dialog : DialogFragment
    {
        private EditText name;
        private EditText surname;
        private EditText email;
        private EditText username;
        private EditText password;
        private Button signUpBtn;

        public EventHandler<OnSignUpEventArgs> signUpComplete;
        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
             base.OnCreateView(inflater, container, savedInstanceState);
            var view = inflater.Inflate(Resource.Layout.dialog_sign_up, container, false);

            name = view.FindViewById<EditText>(Resource.Id.popup_name);
            surname = view.FindViewById<EditText>(Resource.Id.popup_surname);
            email = view.FindViewById<EditText>(Resource.Id.popup_email);
            username = view.FindViewById<EditText>(Resource.Id.popup_username);
            password = view.FindViewById<EditText>(Resource.Id.popup_password);
            
         

            signUpBtn = view.FindViewById<Button>(Resource.Id.popup_register_button);

            signUpBtn.Click += SignUpBtn_Click;

            return view;
        }

        private void SignUpBtn_Click(object sender, EventArgs e)
        {
           
                signUpComplete.Invoke(this, new OnSignUpEventArgs(name.Text, surname.Text, email.Text, username.Text, password.Text));
                this.Dismiss();
           
        }

        public override void OnActivityCreated(Bundle savedInstanceState)
        {
            Dialog.Window.RequestFeature(WindowFeatures.NoTitle);
            base.OnActivityCreated(savedInstanceState);
            Dialog.Window.Attributes.WindowAnimations = Resource.Style.dialog_anim;
        }


     
    }
   
}