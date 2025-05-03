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

        protected override void OnSizeAllocated(double width, double height)
        {
            base.OnSizeAllocated(width, height);
            // Adjust the interval based on the width of the screen
            if (width < 500)
            {
                GaugeScala.Interval = 20;
            }
            else
            {
                GaugeScala.Interval = 10;
            }
        }


    }



   

}