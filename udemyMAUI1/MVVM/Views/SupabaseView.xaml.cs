using udemyMAUI1.Helper;
using udemyMAUI1.MVVM.ViewModels;

namespace udemyMAUI1.MVVM.Views;

public partial class SupabaseView : ContentPage
{
    private SupabaseViewModel supabaseViewModel;

	public SupabaseView()
	{
		InitializeComponent();
        supabaseViewModel = ServiceHelper.GetService<SupabaseViewModel>();
        BindingContext = supabaseViewModel;

    }

    private async void OnLoginClicked(object sender, EventArgs e)
    {
        await supabaseViewModel.LogIn(entryUsername.Text, entryPassword.Text);
    }

    private async void OnLogoutClicked(object sender, EventArgs e)
    {
        await supabaseViewModel.LogOut();
    }

    private async void OnLoadTodosClicked(object sender, EventArgs e)
    {
        await supabaseViewModel.LoadTodos();
    }
}