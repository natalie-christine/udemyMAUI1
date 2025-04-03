namespace udemyMAUI1
{
    public partial class App : Application
    {
        public App() // not useless at all
        {
            InitializeComponent();

            MainPage = new NavigationPage(new MainPage());
        }
    }
}
