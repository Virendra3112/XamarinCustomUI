using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microcharts;
using SkiaSharp;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Entry = Microcharts.ChartEntry;

namespace XamarinCustomUI.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SampleChartsPage : ContentPage, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string propertyName)
        {
            var handler = PropertyChanged;
            if (handler != null)
                handler(this, new PropertyChangedEventArgs(propertyName));
        }
        public SampleChartsPage()
        {
            InitializeComponent();

            entries = new List<Entry>();

            UpdateDataAsync();
        }

        public List<Entry> _entries;
        public List<Entry> entries
        {
            get { return _entries; }
            set
            {
                _entries = value;
                OnPropertyChanged("entries");
            }
        }


        private async Task UpdateDataAsync()
        {
            try
            {

                var test = new List<float>();

                test.Add(100);
                test.Add(-300);
                test.Add(120);
                test.Add(400);
                test.Add(785);
                test.Add(220);
                test.Add(105);
                test.Add(300);
                test.Add(470);
                test.Add(900);
                test.Add(220);
                test.Add(105);
                test.Add(300);
                test.Add(470);
                test.Add(900);

                Random rnd = new Random();



                foreach (var item in test)
                {
                    var data = new Entry(item)
                    {
                        Color = SkiaSharp.SKColor.Parse(String.Format("#{0:X6}", rnd.Next(0x1000000))),
                        //Color =  SKColor.Parse("#FF1943"),
                        Label = "Item_" + item,
                        ValueLabel = item.ToString()
                    };

                    if (entries != null)
                        entries.Add(data);

                    //remove first data if exceeded from 5 records
                    //if(entries.Count > 5)
                    //{
                    //    entries.RemoveAt(0);
                    //}


                    Chart2.Chart = new LineChart()
                    {
                        Entries = entries,
                        LineMode = LineMode.Straight,
                        LineSize = 8,
                        PointMode = PointMode.Circle,
                        PointSize = 18,
                        AnimationDuration = new TimeSpan(20),
                        AnimationProgress = 20,
                        IsAnimated = true,
                        ValueLabelOrientation = Orientation.Horizontal
                    };


                    await Task.Delay(2000);

                }

            }

            catch (Exception ex)
            {

            }

        }
    }
}