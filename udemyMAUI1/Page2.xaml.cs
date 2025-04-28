using System.ComponentModel;
using udemyMAUI1.Models;
using udemyMAUI1.MVVM.ViewModels;



namespace udemyMAUI1
{

    public partial class Page2 : ContentPage, INotifyPropertyChanged
    {


        public Page2()
        {
            InitializeComponent();
            BMIPart.BindingContext = new BMIViewModel();
        }
    }

}