using udemyMAUI1.MVVM.ViewModels;

namespace udemyMAUI1;

public partial class TaskerPage : ContentPage
{
	public TaskerPage()
	{
		InitializeComponent();
		BindingContext = new TaskerViewModel();
	}
}