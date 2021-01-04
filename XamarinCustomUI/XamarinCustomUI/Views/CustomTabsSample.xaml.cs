using System;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XamarinCustomUI.Views.TabPages;

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
                SetTabs(value);
            }
        }

        private void SetTabs(int value)
        {
            try
            {
                switch (value)
                {

                    case 0:
                        tabFrame.Content = new SampleTab1();

                        break;

                    case 1:
                        tabFrame.Content = new SampleTab2();

                        break;

                    case 2:
                        tabFrame.Content = new SampleTab3();

                        break;

                    default:
                        tabFrame.Content = new SampleTab1();

                        break;

                }
            }
            catch (Exception)
            {

            }
        }

        public CustomTabsSample()
        {
            try
            {
                InitializeComponent();
            }
            catch (Exception ex)
            {
            }
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            SelectedTab = 0;
        }

    }
}