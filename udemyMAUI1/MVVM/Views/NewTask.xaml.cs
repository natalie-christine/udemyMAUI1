using Microsoft.VisualBasic;
using System.Threading.Tasks;
using udemyMAUI1.MVVM.Models;
using udemyMAUI1.MVVM.ViewModels;

namespace udemyMAUI1.MVVM.Views;

public partial class NewTask : ContentPage
{
	public NewTask()
	{
		InitializeComponent();
	}

    private async void Button_Clicked(object sender, EventArgs e)
    {
		var vm = BindingContext as NewTaskViewModel;
		var selectedCategory = vm.Categories.Where(x => x.IsSelected).FirstOrDefault();

        if (selectedCategory != null)
        {
            var task = new MyTask
            {
                TaskName = vm.Task,
                CategoryId = selectedCategory.Id,
            };

            vm.Tasks.Add(task);
            await Navigation.PopAsync();
        }
        else
        {
            await DisplayAlert("Error", "Please select a category", "OK");
        }
    }

    private async void AddCategoryClicked(object sender, EventArgs e)
    {
        var vm = BindingContext as NewTaskViewModel;
        string category = await DisplayPromptAsync("New Category", "Write the new category name", maxLength: 15, keyboard: Keyboard.Text);
        var r = new Random();
        if (!string.IsNullOrEmpty(category))
        {
            vm.Categories.Add(new Category
            {
                Id = vm.Categories.Max(x => x.Id) + 1,
                Color = Color.FromRgb(r.Next(0,255), r.Next(0, 255), r.Next(0, 255)).ToHex(),
                CategoryName = category
            });
        }
    }
}