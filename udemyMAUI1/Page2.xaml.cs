using udemyMAUI1.Models;



namespace udemyMAUI1
{

    public partial class Page2 : ContentPage
    {
        public Page2()
        {
            InitializeComponent();
        }

        private void OnClicked(object sender, EventArgs e)
        {
            var person = new Person
            {
                Name = "John",
                Phone = "1234",
                Address = "Straﬂe 1"
            };

            // Variante 3
            BindingContext = person;

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