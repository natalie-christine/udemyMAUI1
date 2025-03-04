namespace udemyMAUI1;

public partial class Tabb1 : TabbedPage
{
	public Tabb1()
	{
		InitializeComponent();
	}

    private void RadioButton_CheckedChanged(object sender, CheckedChangedEventArgs e)
    {
        RadioButton rb = (RadioButton)sender;
        if (e.Value)
        { 
            DisplayAlert("Hallo", "Option: " + rb.Content, "Schlieﬂen");
        }
    }

    private void searchControl_SearchButtonPressed(object sender, EventArgs e)
    {

    }
}