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

    private void slider_ValueChanged(object sender, ValueChangedEventArgs e)
    {
        if (slider != null)
        {
            sliderLabel.Text = Math.Round(slider.Value).ToString();
        }
    }

    private void ImageButtonDown_Clicked(object sender, EventArgs e)
    {
        if (slider != null)
        {
            slider.Value--;
        }
    }

    private void ImageButtonUp_Clicked(object sender, EventArgs e)
    {
        if (slider != null)
        {
            slider.Value++;
        }
    }
}
