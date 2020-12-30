using System;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using XamarinCustomUI.Droid.Effects;
using XamarinCustomUI.Effects;

[assembly: ExportEffect(typeof(AndroidSingleClickEffect), "SingleClickEffect")]
namespace XamarinCustomUI.Droid.Effects
{
    public class AndroidSingleClickEffect : PlatformEffect
    {
        private bool _attached;

        /// <summary>
        /// Initializer to avoid linking out
        /// </summary>
        public static void Initialize() { }

        /// <summary>
        /// Initializes a new instance of the
        /// Empty constructor required for the odd Xamarin.Forms reflection constructor search
        /// </summary>
        public AndroidSingleClickEffect()
        {
        }

        /// <summary>
        /// Apply the handler
        /// </summary>
        protected override void OnAttached()
        {
            //because an effect can be detached immediately after attached (happens in listview), only attach the handler one time.
            if (!_attached)
            {
                if (Control != null)
                {
                    Control.Clickable = true;
                    Control.Click += Control_Click;
                }
                else
                {
                    Container.Clickable = true;
                    Container.Click += Control_Click;
                }
                _attached = true;
            }
        }

        private void Control_Click(object sender, EventArgs e)
        {
            Console.WriteLine("Invoking single click command");
            var command = SingleClickEffect.GetCommand(Element);
            command?.Execute(SingleClickEffect.GetCommandParameter(Element));
        }


        /// <summary>
        /// Clean the event handler on detach
        /// </summary>
        protected override void OnDetached()
        {
            if (_attached)
            {
                if (Control != null)
                {
                    Control.Clickable = true;
                    Control.Click -= Control_Click;
                }
                else
                {
                    Container.Clickable = true;
                    Container.Click -= Control_Click;
                }
                _attached = false;
            }
        }
    }
}