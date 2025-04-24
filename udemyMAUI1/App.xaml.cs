using udemyMAUI1.MVVM.Models;
using udemyMAUI1.Repositories;

namespace udemyMAUI1
{
    public partial class App : Application
    {
        public static BaseRepository<Transaction> TransactionsRepo { get; private set; }

        public App(BaseRepository<Transaction> _transcationsRepo) // not useless at all
        {
            InitializeComponent();
            TransactionsRepo = _transcationsRepo;
            MainPage = new NavigationPage(new MainPage());
        }
    }
}
