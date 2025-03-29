using System.Runtime.InteropServices;
using CommunityToolkit.Maui;
using CommunityToolkit.Maui.Alerts;
using udemyMAUI1.MVVM.Views;

namespace udemyMAUI1
{
    public partial class MainPage : ContentPage
    {
        int count = 0;
        bool isRandom = false;
        string hexValue; 


        public MainPage()
        {
            InitializeComponent();
        }

        private void OnCounterClicked(object sender, EventArgs e)
        {
            // Navigation.PushModalAsync(new Page1()); // special stack for modal pages, page will be on top of the stack cannot go back
            Navigation.PushAsync(new Page1());
        }

        private void OnPage2Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new Page2());
        }

        private void OnTabbedClicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new Tabb1());
        }

        private void OnFlyoutClicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new FlyoutPage1());
        }

        private void OnMauiverterClicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new MenuView());
        }
        private void OnTest(object sender, EventArgs e)
        {
            Navigation.PushAsync(new ConverterView());
        }
        private void ImageButton_Clicked(object sender, EventArgs e)
        {
            DisplayAlert("Hallo", "Welt :)", "Schließen");
        }

        private void Slider_ValueChanged(object sender, ValueChangedEventArgs e)
        {
            if (!isRandom)
            {
                var red = sldRed.Value;
                var green = sldGreen.Value;
                var blue = sldBlue.Value;

                Color color = Color.FromRgb(red, green, blue);
                SetColor(color);
            }
        }

        private void btnRandom_Clicked(object sender, EventArgs e)
        {
            isRandom = true;
            Random random = new Random();
            var red = random.NextDouble();
            var green = random.NextDouble();
            var blue = random.NextDouble();

            Color color = Color.FromRgb(red, green, blue);
            SetColor(color);

            sldRed.Value = color.Red;
            sldGreen.Value = color.Green;
            sldBlue.Value = color.Blue;

            isRandom = false;
        }   

        private void SetColor(Color color)
        {
            CounterBtn.BackgroundColor = color;
            Page2Button.BackgroundColor = color;
            TabbedBtn.BackgroundColor = color;
            FlyoutBtn.BackgroundColor = color;

            hexValue = color.ToHex();
            lblHex.Text = color.ToHex();

            
        }

        private async void ImageButton_Clicked_1(object sender, EventArgs e)
        {
            await Clipboard.SetTextAsync(lblHex.Text);
            var toast = Toast.Make("Color copied", CommunityToolkit.Maui.Core.ToastDuration.Short, 12);
            await toast.Show();
            
        }

        private void Button_Clicked(object sender, EventArgs e)
        {

        }
    }

}
