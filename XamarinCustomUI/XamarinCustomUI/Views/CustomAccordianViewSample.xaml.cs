using System;
using System.Collections.Generic;
using System.Linq;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XamarinCustomUI.Controls;
using XamarinCustomUI.Models;

namespace XamarinCustomUI.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CustomAccordianViewSample : ContentPage
    {
        List<AccordianViewDemoModel> AccordianViewDemoList { get; set; }

        public CustomAccordianViewSample()
        {
            InitializeComponent();
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();

            //Add sample data
            GetData();

            CreateAndDisplayAccordianViewDemo();
        }

        private void GetData()
        {
            try
            {
                AccordianViewDemoList = new List<AccordianViewDemoModel>();

                AccordianViewDemoModel item = new AccordianViewDemoModel();

                var eq1 = new XamarinCustomUI.Models.Item
                {
                    AddressId = 1,
                    Brand = "testbrand",
                    ContractId = 111111,
                    EquipmentID = 1002,
                    ModelNumber = "Model 330827827",
                    SerialNumber = "Serial No: 373289"

                };

                var eq2 = new XamarinCustomUI.Models.Item
                {
                    AddressId = 2,
                    Brand = "testbrand 2",
                    ContractId = 22222,
                    EquipmentID = 23345,
                    ModelNumber = "Model 37883",
                    SerialNumber = "Serial No: 388389"

                };

                item.Title = "View 1";
                item.AttachedEquipments.Add(eq1);
                item.AttachedEquipments.Add(eq2);

                AccordianViewDemoList.Add(item);

                AccordianViewDemoModel item2 = new AccordianViewDemoModel();


                var eq3 = new XamarinCustomUI.Models.Item
                {
                    AddressId = 1,
                    Brand = "testbrand",
                    ContractId = 111111,
                    EquipmentID = 1002,
                    ModelNumber = "Model 330827827",
                    SerialNumber = "Serial No: 373289"

                };

                var eq4 = new XamarinCustomUI.Models.Item
                {
                    AddressId = 2,
                    Brand = "testbrand 2",
                    ContractId = 22222,
                    EquipmentID = 23345,
                    ModelNumber = "Model 37883",
                    SerialNumber = "Serial No: 388389"

                };

                item2.Title = "View 2";
                item2.AttachedEquipments.Add(eq3);
                item2.AttachedEquipments.Add(eq4);

                AccordianViewDemoList.Add(item2);
            }
            catch (Exception ex)
            {
            }
        }



        #region AccordianView Creation
        private void CreateAndDisplayAccordianViewDemo()
        {
            try
            {
                foreach (var address in AccordianViewDemoList)
                {


                    var accordianView = new AccordianView()
                    {
                        CornerRadius = 25,
                        HeaderHeight = 25,
                        BackgroundColor = Color.FromHex("#F2F6FD"),

                        HeaderContent = new Label
                        {
                            Text = address.Title, // "My Data",
                            HorizontalOptions = LayoutOptions.Fill,
                            HorizontalTextAlignment = TextAlignment.Start,
                            VerticalTextAlignment = TextAlignment.Center,
                            VerticalOptions = LayoutOptions.Center,
                            Margin = new Thickness(10, 0, 0, 0),
                            FontSize = 14,
                            TextColor = Color.FromHex("#303AE5"),
                            FontAttributes = FontAttributes.Bold,
                        },
                        BodyContent = GetChild(address),
                        IsExpanded = false

                    };

                    stackLayout.Children.Add(accordianView);
                }
            }
            catch (Exception ex)
            {

            }
        }
        private BoxView GetSeperator()
        {
            var boxView = new BoxView
            {
                HeightRequest = 1,
                BackgroundColor = Color.FromHex("#98999C"),
                Margin = new Thickness(0, 5, 5, 0)

            };
            return boxView;
        }
        private StackLayout GetChild(AccordianViewDemoModel model)
        {
            var parentlayout = new StackLayout();
            if (model.AttachedEquipments == null || model.AttachedEquipments.Count == 0)
            {
                var layout = new StackLayout();
                var text = new Label
                {
                    Text = "No Data",
                    Margin = new Thickness(10, 5, 0, 0),
                    TextColor = Color.FromHex("#808285"),
                    FontSize = 14
                };
                layout.Children.Add(text);
                parentlayout.Children.Add(layout);
            }
            else
            {
                var groupedEquip = model.AttachedEquipments.GroupBy(t => t.Brand).ToList();
                foreach (var equipment in groupedEquip)
                {

                    var layout = new StackLayout();
                    var text = new Label
                    {
                        Text = "Data" + " : " + equipment.Key,
                        Margin = new Thickness(10, 5, 0, 0),
                        TextColor = Color.FromHex("#808285"),
                        FontAttributes = FontAttributes.Bold,
                        FontSize = 14
                    };
                    layout.Children.Add(text);
                    foreach (var models in equipment)
                    {
                        layout.Children.Add(CreateModelDetails("Sample Data", models.ModelNumber));
                        layout.Children.Add(CreateModelDetails("Sample Data 2", models.SerialNumber));
                    }

                    parentlayout.Children.Add(layout);
                }

            }
            return parentlayout;

        }

        private StackLayout CreateModelDetails(string staticText, string model)
        {
            var detaillayout = new StackLayout();
            var detailStaticLbl = new Label
            {
                Text = staticText + " : ",
                FontSize = 14,
                Margin = new Thickness(25, 0, 0, 0),
                TextColor = Color.FromHex("#808285")
            };
            var detailLbl = new Label
            {
                Text = model.Trim(),
                FontSize = 14,
                TextColor = Color.FromHex("#808285")
            };
            detaillayout.Orientation = StackOrientation.Horizontal;
            detaillayout.Spacing = 2;
            detaillayout.Children.Add(detailStaticLbl);
            detaillayout.Children.Add(detailLbl);
            return detaillayout;
        }

        #endregion
    }
}