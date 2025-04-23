using udemyMAUI1.MVVM.ViewModels;

namespace udemyMAUI1.MVVM.Views;

public partial class WeatherView : ContentPage
{
	public WeatherView()
	{
		InitializeComponent();
        WeatherViewModel viewModel = new WeatherViewModel();
        BindingContext = viewModel;
        viewModel.SearchCommand.Execute("Linz");
    }
}