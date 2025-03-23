using System.ComponentModel;
using System.Diagnostics;
using System.Threading.Tasks;

namespace udemyMAUI1;

public partial class Tabb1 : TabbedPage, INotifyPropertyChanged
{
    #region UI Properties
    public string Spotlight
    {
        get => spotlight;
        set
        {
            spotlight = value;
            OnPropertyChanged();
        }
    }
    #endregion

    #region Fields
    List<string> words = new List<string>()
    {
        "python",
        "javascript",
        "maui",
        "csharp",
        "mongodb",
        "sql",
        "xaml",
        "word",
        "excel",
        "powerpoint",
        "code",
        "hotreload",
        "snippets"
    };
    string answer = "";
    private string spotlight;
    List<char> guessed = new List<char>();
    #endregion

    #region Game Engine
    private void PickWord()
    {
        answer = words[new Random().Next(0, words.Count)];
        Debug.WriteLine(answer);
    }

    private void CalculateWord(string answer, List<char> guessed)
    {
        var temp = answer.Select(x => (guessed.IndexOf(x) >= 0 ? x : '_')).ToArray();
        Spotlight = string.Join(' ', temp);
    }
    #endregion

    public Tabb1()
	{
		InitializeComponent();
        BindingContext = this;
        PickWord();
        CalculateWord(answer, guessed);
	}

    private void RadioButton_CheckedChanged(object sender, CheckedChangedEventArgs e)
    {
        RadioButton rb = (RadioButton)sender;
        if (e.Value)
        { 
            DisplayAlert("Hallo", "Option: " + rb.Content, "Schließen");
        }
    }

    private void searchControl_SearchButtonPressed(object sender, EventArgs e)
    {
        indicator.IsRunning = !indicator.IsRunning;
        //DisplayAlert("Suche", "Vielen Dank für Ihre Geduld", "Schließen");
        //indicator.IsRunning = false;
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

    private void Picker_HandlerChanged(object sender, EventArgs e)
    {
        candyImage.Source = picker.SelectedItem.ToString();
    }
}
