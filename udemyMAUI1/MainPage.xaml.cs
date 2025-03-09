using System.Runtime.InteropServices;

namespace udemyMAUI1
{
    public partial class MainPage : ContentPage
    {
        int count = 0;

        public MainPage()
        {
            InitializeComponent();
        }

        private void OnCounterClicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new Page1());
        }

        private void OnTabbedClicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new Tabb1());
        }

        private void OnFlyoutClicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new FlyoutPage1());
        }

        private void ImageButton_Clicked(object sender, EventArgs e)
        {
            DisplayAlert("Hallo", "Welt :)", "Schließen");
        }

        private void Slider_ValueChanged(object sender, ValueChangedEventArgs e)
        {
            var red = sldRed.Value;
            var green = sldGreen.Value;
            var blue = sldBlue.Value;

            Color color = Color.FromRgb(red, green, blue);
            SetColor(color);
        }

        private void SetColor(Color color)
        {
            CounterBtn.BackgroundColor = color;
            TabbedBtn.BackgroundColor = color;
            FlyoutBtn.BackgroundColor = color;
            lblHex.Text = color.ToHex();
        }
    }

}
