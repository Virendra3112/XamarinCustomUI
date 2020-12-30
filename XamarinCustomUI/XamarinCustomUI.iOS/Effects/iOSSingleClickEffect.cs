using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;
using XamarinCustomUI.Effects;
using XamarinCustomUI.iOS.Effects;

[assembly: ExportEffect(typeof(iOSSingleClickEffect), "SingleClickEffect")]
namespace XamarinCustomUI.iOS.Effects
{
    public class iOSSingleClickEffect : PlatformEffect
    {
        private bool _attached;
        private readonly UITapGestureRecognizer _singleClickRecognizer;

        /// <summary>
        /// Initializes a new instance of the
        /// </summary>
        public iOSSingleClickEffect()
        {
            _singleClickRecognizer = new UITapGestureRecognizer(HandleSingleClick);
        }

        /// <summary>
        /// Apply the handler
        /// </summary>
        protected override void OnAttached()
        {
            //because an effect can be detached immediately after attached (happens in listview), only attach the handler one time
            if (!_attached)
            {
                Container.AddGestureRecognizer(_singleClickRecognizer);
                _attached = true;
            }
        }

        /// <summary>
        /// Invoke the command if there is one
        /// </summary>
        private void HandleSingleClick()
        {
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
                Container.RemoveGestureRecognizer(_singleClickRecognizer);
                _attached = false;
            }
        }

    }
}