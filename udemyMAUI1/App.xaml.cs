namespace udemyMAUI1
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

           var navPage =  new NavigationPage (new MainPage());

            navPage.BarBackground = Colors.Blue;
            navPage.BarTextColor = Colors.SlateBlue;

            MainPage = navPage ;

                
        }
    }
}
