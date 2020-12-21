using System;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace XamarinCustomUI.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CustomTabsSample : ContentPage
    {
        public static readonly BindableProperty SelectedTabProperty = BindableProperty.Create(nameof(SelectedTab), returnType: typeof(int), declaringType: typeof(int), defaultValue: 0);

        public int SelectedTab
        {
            get
            {
                return (int)GetValue(SelectedTabProperty);
            }
            set
            {
                SetValue(SelectedTabProperty, value);
            }
        }


        //public Command BackButtonTapped { get; set; }
        //public Command BellButtonTapped { get; set; }

        public CustomTabsSample()
        {
            try
            {
                InitializeComponent();
            }
            catch (Exception ex)
            {
            }

            //BackButtonTapped = new Command(OnBackButtonTapped);
            //BellButtonTapped = new Command(OnBellButtonTapped);
        }

        ///// <summary>
        ///// On Back Button Tapped
        ///// </summary>
        //private void OnBackButtonTapped()
        //{
        //    try
        //    {
        //    }
        //    catch (Exception ex)
        //    {
        //    }
        //}

        ///// <summary>
        ///// On Bell Button Tapped
        ///// </summary>
        //private void OnBellButtonTapped()
        //{
        //    try
        //    {
        //    }
        //    catch (Exception ex)
        //    {
        //    }
        //}

    }
}