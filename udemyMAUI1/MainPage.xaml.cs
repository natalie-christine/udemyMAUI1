﻿namespace udemyMAUI1
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

        private void OnFlyoutPageBtnClicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new FlyoutPage1());
        }
    }

}
