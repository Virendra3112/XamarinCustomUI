using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XamarinCustomUI.Views.TabPages;

namespace XamarinCustomUI.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class FloatingTabsSample : ContentPage
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

        public FloatingTabsSample()
        {
            InitializeComponent();
        }
    }
}