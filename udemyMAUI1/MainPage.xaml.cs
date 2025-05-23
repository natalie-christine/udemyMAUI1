﻿using System.Diagnostics;
using CommunityToolkit.Maui.Alerts;
using Microsoft.Maui.Controls;
using udemyMAUI1.MVVM.Views;

namespace udemyMAUI1
{
    public partial class MainPage : ContentPage
    {
        bool isRandom = false;
        bool isMobileview = false;
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
                isMobileview = false;
                HeaderContainer.Orientation = StackOrientation.Horizontal;
                Templateview.Orientation = StackOrientation.Horizontal;
            }
            else
            {
                HeaderContainer.Orientation = StackOrientation.Vertical;
                Templateview.Orientation = StackOrientation.Vertical;
                isMobileview = true;
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

        private void OnWeatherClicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new WeatherView());
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
        private void OnTaskerClicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new TaskerPage(new NewTask()));
        }

        private void OnProsperDailyClicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new ProsperDaily());
        }
        private async void ImageButton_Clicked(object sender, EventArgs e)
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

            if (!isMobileview)
            {


            await Title.TranslateTo(0, -100);
            await Car.TranslateTo(2000, 0, 1000);
            await Title.TranslateTo(0, 0);
            await Car.TranslateTo(0, 0, 0);
            }
            else
            { 
                await Car.FadeTo(0);
                await Car.FadeTo(1);
                await Car.TranslateTo(1000, 0, 1000);
                await Car.TranslateTo(0, 0, 0);
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
            void SetColors(string p, Color c)
            {
                Application.Current.Resources[p] = c.ToHex();
                Application.Current.Resources[p + "Light"] = c.WithLuminosity(c.GetLuminosity() + 0.2f).ToHex();
                Application.Current.Resources[p + "Dark"] = c.WithLuminosity(c.GetLuminosity() - 0.2f).ToHex();
                Application.Current.Resources[p + "Text"] = c.GetLuminosity() > 0.5 ?
                        c.WithLuminosity(0f).ToHex() :
                        c.WithLuminosity(1f).ToHex();

                Application.Current.Resources[p + "Brush"] = new SolidColorBrush(c);
            }

            Color RotateColor(Color c, float r)
            {
                c.ToHsl(out var h, out var s, out var l);
                h += r;
                h %= 1.0f;
                return Color.FromHsla(h, s, l);
            }

            SetColors("DynamicPrimary", color);
            SetColors("DynamicSecondary", RotateColor(color, 0.50f));
            SetColors("DynamicTertiary", RotateColor(color, 0.25f));
            SetColors("DynamicQuartary", RotateColor(color, 0.75f));

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
