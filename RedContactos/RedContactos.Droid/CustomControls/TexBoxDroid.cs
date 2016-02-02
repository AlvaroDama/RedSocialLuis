using RedContactos.CustomControls;
using RedContactos.Droid.CustomControls;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(TextBox), typeof(TexBoxDroid))]
namespace RedContactos.Droid.CustomControls
{
    public class TexBoxDroid:EntryRenderer
    {
        protected override void OnElementChanged(ElementChangedEventArgs<Entry> e)
        {
            base.OnElementChanged(e);

            Control.SetTextColor(global::Android.Graphics.Color.BlueViolet);
            Control.SetBackgroundColor(global::Android.Graphics.Color.DeepPink);
        }
    }
}