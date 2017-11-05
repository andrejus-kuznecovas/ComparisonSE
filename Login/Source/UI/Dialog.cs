using System;
using Android.App;
using Android.OS;
using Android.Views;
using Android.Widget;
using Login.Source.Controllers;

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


        public OnSignUpEventArgs(string name, string surname, string email, string username, string password) : base()
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
        private AlertDialog.Builder alertDialog;

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
        /// <summary>
        /// Validator checks if all the input fields are entered correctly and then processes to another view
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SignUpBtn_Click(object sender, EventArgs e)
        {
            Validator validator = new Validator();
            bool validation = true;

            if (!validator.CheckName(name.Text))
            {
                showMsg(GetString(Resource.String.Register_Name_Error));
                validation = false;
            }
            else
            {
                validation = true;
            }
            if (!validator.CheckSurname(surname.Text))
            {
                showMsg(GetString(Resource.String.Register_Surname_Error));
                validation = false;
            }
            else
            {
                validation = true;
            }
            if (!validator.CheckNickname(username.Text))
            {
                showMsg(GetString(Resource.String.Register_Nickname_Error));
                validation = false;
            }
            else
            {
                validation = true;
            }
            if (!validator.CheckPassword(password.Text))
            {
                showMsg(GetString(Resource.String.Register_Password_Error));
                validation = false;
            }
            else
            {
                validation = true;
            }
            if (!validator.CheckEmail(email.Text))
            {
                showMsg(GetString(Resource.String.Register_Email_Error));
                validation = false;
            }
            else
            {
                validation = true;
            }

            if (name.Text.Length != 0 && password.Text.Length != 0 && email.Text.Length != 0 && username.Text.Length != 0
                && surname.Text.Length != 0 && validation)
            {
                signUpComplete.Invoke(this, new OnSignUpEventArgs(name.Text, surname.Text, email.Text, username.Text, password.Text));
                this.Dismiss();

            }
            else
            {
                showMsg(GetString(Resource.String.Register_Empty_Fields_Error));
            }


        }

        public override void OnActivityCreated(Bundle savedInstanceState)
        {
            Dialog.Window.RequestFeature(WindowFeatures.NoTitle);
            base.OnActivityCreated(savedInstanceState);
            Dialog.Window.Attributes.WindowAnimations = Resource.Style.dialog_anim;
        }
        /// <summary>
        /// Creates alerDialog and displays message about wrong input
        /// </summary>
        /// <param name="text"></param>
        public void showMsg(string text)
        {
            alertDialog = new AlertDialog.Builder(this.Activity);
            alertDialog.SetMessage(text);
            alertDialog.SetNeutralButton("Tæsti", delegate
            {
                alertDialog.Dispose();
            });
            alertDialog.Show();
        }

    }


}