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
    public List<char> Letters
    {
        get => letters;
        set
        {
            letters = value;
            OnPropertyChanged();
        }
    }

    public string Message
    { 
        get => message;
        set
        {
            message = value;
            OnPropertyChanged();
        }
    }

    public string GameStatus
    {
        get => gameStatus;
        set
        {
            gameStatus = value;
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
    private List <char> letters = new List<char>();  
    private string message;
    List<char> guessed = new List<char>();
    private string gameStatus;
    int mistakes = 0;
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

    private void ResetGame(object sender, EventArgs e)
    {
        mistakes = 0;
        guessed.Clear();
        PickWord();
        CalculateWord(answer, guessed);
    }
    
    private void UpdateStatus()
    {

        if (mistakes >= 6)
        {
            GameStatus = "Verloren!";
        }
        else
        {
            GameStatus = "Noch " + (6 - mistakes) + " Versuche";
        }
    }


    #endregion

    public Tabb1()
	{
		InitializeComponent();
        letters.AddRange("abcdefghijklmnopqrstuvwxyz".ToCharArray());
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

    private void Button_Clicked(object sender, EventArgs e)
    {
        var btn = sender as Button;
        if (btn != null)
        {
           var letter = btn.Text;
            btn.IsEnabled = false;
            HandleGuess(letter[0]);
        }

    }

    private void HandleGuess(char letter)
    {
        if(guessed.IndexOf(letter) == -1)
        {
            guessed.Add(letter);
        }
        if (answer.IndexOf(letter) >= 0)
        {
            CalculateWord(answer, guessed);
            CheckIfGameWon();
        }
       else if (answer.IndexOf(letter) == -1)
        {
            mistakes++;
            UpdateStatus();
            CheckIfGameLost();

        }
    }
    private void CheckIfGameWon()
    {
        if (Spotlight.Replace(" " , "" ) == answer)
        {
            Message = "Gewonnen!";
        }
    }

    private void CheckIfGameLost()
    {
        if (mistakes >= 6)
        {
            Message = "Verloren!";
        }
    }

}
