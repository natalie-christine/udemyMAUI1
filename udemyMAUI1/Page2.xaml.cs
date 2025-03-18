using System.ComponentModel;
using udemyMAUI1.Models;



namespace udemyMAUI1
{

    public partial class Page2 : ContentPage, INotifyPropertyChanged
    {

        Person person = new Person
        {
            Name = "John",
            Phone = "1234",
            Address = "Straﬂe 1"
        };

        public Page2()
        {
            InitializeComponent();
        }

        override protected void OnAppearing()
        {

            base.OnAppearing();

            BindingContext = person;

        }

        private void OnClicked(object sender, EventArgs e)
        {
            
            person.Name = "Jane";
            person.Phone = "5678";
            person.Address = "Straﬂe 2";


            // Variante 2
            //txtName.BindingContext = person;
            //txtName.SetBinding(Label.TextProperty, "Name");


            // Variante 1
            //Binding personBinding = new Binding();
            //personBinding.Source = person;
            //personBinding.Path = "Name";

            //txtName.SetBinding(Label.TextProperty, personBinding);
        }

    }

}