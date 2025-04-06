using System.Diagnostics;
using CommunityToolkit.Maui.Alerts;
using udemyMAUI1.MVVM.Views;

namespace udemyMAUI1
{
    public partial class MainPage : ContentPage
    {
        bool isRandom = false;
        StackOrientation ResponsiveStackOrientation = StackOrientation.Horizontal;

        public MainPage() // Most beautifully page <3
        {
            InitializeComponent();
            btnRandom_Clicked(this, new EventArgs());
        }

        protected override void OnSizeAllocated(double width, double height)
        {
            base.OnSizeAllocated(width, height);
            
            if (width > 700)
            {
                HeaderContainer.Orientation = StackOrientation.Horizontal;
                PotionContainer.Orientation = StackOrientation.Horizontal;
            }
            else
            {
                HeaderContainer.Orientation = StackOrientation.Vertical;
                PotionContainer.Orientation = StackOrientation.Vertical;
            }
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
        private void OnSupabaseClicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new SupabaseView());
        }
        private void ImageButton_Clicked(object sender, EventArgs e)
        {
            //DisplayAlert("Hallo", "Welt :)", "Schließen");
            if (Application.Current.RequestedTheme == AppTheme.Light)
            {
                Application.Current.UserAppTheme = AppTheme.Dark;
            }
            else
            {
                Application.Current.UserAppTheme = AppTheme.Light;
            }
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
            Color textColor;
            if (color.GetLuminosity() > 0.5)
            {
                textColor = Color.FromRgb(0, 0, 0);
            }
            else
            {
                textColor = Color.FromRgb(255, 255, 255);
            }

            Application.Current.Resources["DynamicPrimary"] = color.ToHex();
            Application.Current.Resources["DynamicPrimaryLight"] = color.WithLuminosity(color.GetLuminosity() + 0.2f).ToHex();
            Application.Current.Resources["DynamicPrimaryDark"] = color.WithLuminosity(color.GetLuminosity() - 0.2f).ToHex();
            Application.Current.Resources["DynamicPrimaryText"] = textColor.ToHex();
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
