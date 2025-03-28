using udemyMAUI1.MVVM.ViewModels;

namespace udemyMAUI1.MVVM.Views;

public partial class ConverterView : ContentPage
{
	public ConverterView()
	{
		InitializeComponent();
	}

    private void Picker_SelectedIndexChanged(object sender, EventArgs e)
    {
		var viewModel = (ConverterViewModel)BindingContext;
		viewModel.Convert();
    }
}