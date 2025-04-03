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
}