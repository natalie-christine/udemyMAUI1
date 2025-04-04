namespace udemyMAUI1;
using System;

public partial class Page1 : ContentPage
{

	Random random = new Random();

	List<string> quotes = new List<string>();
	bool isBlack = true;

    async Task LoadMauiAsset()
    {
        using var stream = await FileSystem.OpenAppPackageFileAsync("quotes.txt");
        using var reader = new StreamReader(stream);

        var content = reader.ReadToEnd();
        quotes.AddRange((content ?? "nöööööööö! Jetzt nicht!").Split("\n"));
    }

    public Page1()
	{
		InitializeComponent();
	}

	protected override async void OnAppearing()
	{
        base.OnAppearing();
        await LoadMauiAsset();
        changeQuote();
    }

	private void Button_Clicked(object sender, EventArgs e)
	{
        Navigation.PopAsync();
    }

    private void btnChangeTextColor_Clicked(object sender, EventArgs e)
	{
		isBlack = !isBlack;

        if (isBlack)
		{
			quoteslabel.TextColor = Color.FromArgb("#000000");
        }
		else
		{
            quoteslabel.TextColor = Color.FromArgb("#ffffff");
        }
	}

    private void btnGenerateQuotes_Clicked(object sender, EventArgs e)
	{
		// generate random quote
		changeQuote();
    }

	private void changeQuote()
	{
        int index = random.Next(quotes.Count);
        quoteslabel.Text = quotes[index];
    }

	private void btnGenerateColor_Clicked(object sender, EventArgs e)
	{
		var startColor =
			System.Drawing.Color.FromArgb(
				random.Next(0, 256),
				random.Next(0, 256),
				random.Next(0, 256)
				);

        var middleColor =
            System.Drawing.Color.FromArgb(
                random.Next(0, 256),
                random.Next(0, 256),
                random.Next(0, 256)
                );

        var middleColor1 =
            System.Drawing.Color.FromArgb(
                random.Next(0, 256),
                random.Next(0, 256),
                random.Next(0, 256)
                );

         var middleColor2 =
            System.Drawing.Color.FromArgb(
            random.Next(0, 256),
            random.Next(0, 256),
            random.Next(0, 256)
            );


        var endColor =
            System.Drawing.Color.FromArgb(
            random.Next(0, 256),
            random.Next(0, 256),
            random.Next(0, 256));


		var stops = new GradientStopCollection();

		stops.Add(new GradientStop(Color.FromArgb(startColor.Name), 0));
        stops.Add(new GradientStop(Color.FromArgb(middleColor.Name), .25f ));
        stops.Add(new GradientStop(Color.FromArgb(middleColor1.Name), .5f));
        stops.Add(new GradientStop(Color.FromArgb(middleColor2.Name), .75f));
        stops.Add(new GradientStop(Color.FromArgb(endColor.Name), 1));
  
		var gradient = new LinearGradientBrush(stops, new Point(0,0), new Point (1,1));

		background.Background = gradient;


    }
}