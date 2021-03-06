﻿using System.ComponentModel;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace XamarinCustomUI.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CustomLoaderSample : ContentPage, INotifyPropertyChanged
    {
        private bool isBusy;

        public bool ShowLoader
        {
            get { return isBusy; }
            set
            {
                isBusy = value;
                OnPropertyChanged("ShowLoader");
            }
        }
        public CustomLoaderSample()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            ShowLoader = true;

        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string propertyName)
        {
            var handler = PropertyChanged;
            if (handler != null)
                handler(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}