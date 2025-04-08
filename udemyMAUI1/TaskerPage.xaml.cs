using udemyMAUI1.MVVM.ViewModels;
using udemyMAUI1.MVVM.Views;

namespace udemyMAUI1;

public partial class TaskerPage : ContentPage
{
	private TaskerViewModel mainViewModel = new TaskerViewModel();
    public TaskerPage(MVVM.Views.NewTask newTask)
	{
		InitializeComponent();
		BindingContext = mainViewModel;
	}

    private void checkbox_CheckedChanged(object sender, CheckedChangedEventArgs e)
    {
        mainViewModel.UpdateData();
    }

    private void Button_Clicked(object sender, EventArgs e)
    {
        var taskView = new NewTask()
        {
            BindingContext = new NewTaskViewModel()
            {
                Tasks = mainViewModel.Tasks,
                Categories = mainViewModel.Categories,
            }
        };
        Navigation.PushAsync(taskView);
    }
}