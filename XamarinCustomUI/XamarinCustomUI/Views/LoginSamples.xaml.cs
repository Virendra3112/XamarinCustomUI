using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace XamarinCustomUI.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginSamples : ContentPage, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string propertyName)
        {
            var handler = PropertyChanged;
            if (handler != null)
                handler(this, new PropertyChangedEventArgs(propertyName));
        }

        private bool _isPassword;
      
        public bool IsPassword
        {
            get { return _isPassword; }
            set
            {
                _isPassword = value;
                OnPropertyChanged("IsPassword");
            }
        }

        private string _LoginEmail;
        public string LoginEmail
        {
            get { return _LoginEmail; }
            set
            {
                _LoginEmail = value;
                OnPropertyChanged("LoginEmail");
            }
        }
        private string _LoginPwd;

        public string LoginPwd
        {
            get { return _LoginPwd; }
            set
            {
                _LoginPwd = value;
                OnPropertyChanged("LoginPwd");
            }
        }


        public LoginSamples()
        {
            InitializeComponent();


            IsPassword = true;

        }

       

        private void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            if (IsPassword == true)
            {
                IsPassword = false;
            }
            else
            {
                IsPassword = true;
            }
        }
    }
}