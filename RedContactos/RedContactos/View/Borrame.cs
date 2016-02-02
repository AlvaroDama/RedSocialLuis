using Xamarin.Forms;

namespace RedContactos.View
{
    public class Borrame : ContentPage
    {
        public Borrame()
        {
            Content = new StackLayout
            {
                Children = {
                    new Label { Text = "Hello ContentPage" }
                }
            };
        }
    }
}
