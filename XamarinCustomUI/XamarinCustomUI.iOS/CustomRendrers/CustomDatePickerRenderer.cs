using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using FFImageLoading;
using FFImageLoading.Svg.Platform;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;
using XamarinCustomUI.Controls;
using XamarinCustomUI.iOS.CustomRendrers;

[assembly: ExportRenderer(typeof(CustomDatePickerControl), typeof(CustomDatePickerRenderer))]

namespace XamarinCustomUI.iOS.CustomRendrers
{
    public class CustomDatePickerRenderer : DatePickerRenderer
    {

        protected override async void OnElementChanged(ElementChangedEventArgs<DatePicker> e)
        {
            base.OnElementChanged(e);

            if (e.NewElement != null && this.Control != null)
            {
                //this.AddClearButton();

                //LoadImage();

                var _arrow = await ImageService.Instance.LoadFileFromApplicationBundle("datepickerimage")
                    .WithCustomDataResolver(new SvgDataResolver(10, 10, true))
                    .AsUIImageAsync();
                Control.RightView = new UIImageView(_arrow);
                Control.RightViewMode = UITextFieldViewMode.Always;
                Control.BorderStyle = UITextBorderStyle.None;
                Control.TextColor = e.NewElement.TextColor.ToUIColor();
                Control.ReturnKeyType = UIReturnKeyType.Done;

                var entry = (CustomDatePickerControl)this.Element;
                if (!entry.NullableDate.HasValue)
                {
                    this.Control.Text = entry.PlaceHolder;
                }

                if (Device.Idiom == TargetIdiom.Tablet)
                {
                    this.Control.Font = UIFont.SystemFontOfSize(25);
                }
            }
        }

        protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            // Check if the property we are updating is the format property
            if (e.PropertyName == Xamarin.Forms.DatePicker.DateProperty.PropertyName || e.PropertyName == DatePicker.FormatProperty.PropertyName)
            {
                var entry = (CustomDatePickerControl)this.Element;

                // If we are updating the format to the placeholder then just update the text and return
                if (this.Element.Format == entry.PlaceHolder)
                {
                    this.Control.Text = entry.PlaceHolder;
                    return;
                }
            }

            base.OnElementPropertyChanged(sender, e);
        }

        private void AddClearButton()
        {
            var originalToolbar = this.Control.InputAccessoryView as UIToolbar;

            if (originalToolbar != null && originalToolbar.Items.Length <= 2)
            {
                var clearButton = new UIBarButtonItem("Clear", UIBarButtonItemStyle.Plain, ((sender, ev) =>
                {
                    CustomDatePickerControl baseDatePicker = this.Element as CustomDatePickerControl;
                    this.Element.Unfocus();
                    this.Element.Date = DateTime.Now;
                    baseDatePicker.CleanDate();

                }));

                var newItems = new List<UIBarButtonItem>();
                foreach (var item in originalToolbar.Items)
                {
                    newItems.Add(item);
                }

                newItems.Insert(0, clearButton);

                originalToolbar.Items = newItems.ToArray();
                originalToolbar.SetNeedsDisplay();
            }

        }



        //protected override void OnElementChanged(ElementChangedEventArgs<DatePicker> e)
        //{
        //    base.OnElementChanged(e);


        //   var element = (CustomDatePicker)this.Element;

        //    if (Control != null && element != null)
        //    {
        //        LoadImage();
        //        Control.RightViewMode = UITextFieldViewMode.Always;
        //        Control.BorderStyle = UITextBorderStyle.None;
        //        Control.Text = element.Text;
        //        Control.TextColor = element.TextColor.ToUIColor();
        //        Control.ReturnKeyType = UIReturnKeyType.Done;



        //        //Control.ShouldEndEditing += (textField) =>
        //        //{
        //        //    var seletedDate = (UITextField)textField;
        //        //    var text = seletedDate.Text;
        //        //    if (text == "")
        //        //    {
        //        //        Control.Text = DateTime.Now.ToString("dd/MM/yyyy");
        //        //    }
        //        //    return true;
        //        //};
        //    }
        //}

        private async void LoadImage()
        {
            UIImage downArrow = await ImageService.Instance.LoadFileFromApplicationBundle("calendar.svg")
                            .WithCustomDataResolver(new SvgDataResolver(20, 20, true))
                            .AsUIImageAsync();
            var uiImageView = new UIImageView(downArrow)
            {
                Frame = new RectangleF(0, 0, 20, 20)
            };

            UIView objLeftView = new UIView(new RectangleF(0, 0, 20, 20));
            objLeftView.AddSubview(uiImageView);
            Control.RightView = objLeftView;
        }
    }
}
