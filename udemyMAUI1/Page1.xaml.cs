namespace udemyMAUI1;

public partial class Page1 : ContentPage
{
	public Page1()
	{
		InitializeComponent();
	}

	private void Button_Clicked(object sender, EventArgs e)
	{
        Navigation.PopAsync();
    }
}