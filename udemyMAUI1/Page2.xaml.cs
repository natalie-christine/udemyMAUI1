namespace udemyMAUI1
{

    public partial class Page2 : ContentPage
    {
        public Page2()
        {
            InitializeComponent();
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            Navigation.PopAsync();
            //Navigation.PushAsync(new MainPage());
        }
    }

}