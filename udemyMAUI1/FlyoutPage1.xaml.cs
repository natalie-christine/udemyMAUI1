namespace udemyMAUI1;

public partial class FlyoutPage1 : FlyoutPage
{
	decimal bill;
	int tip;
	int noPersons = 1;

	public FlyoutPage1()
	{
		InitializeComponent();
	}

    private void CalculateTotal()
    {
		var totalTip = (bill * tip) / 100;

		// Tip by Person
		var tipByPerson = (totalTip / noPersons);
		lblTipByPerson.Text = $"{tipByPerson:C}";

		// Subtotal
		var subtotal = (bill / noPersons);
		lblSubtotal.Text = $"{subtotal:C}";

		// Total by Person
		var totalByPerson = (bill + totalTip) / noPersons;
		lblTotal.Text = $"{totalByPerson:C}";
    }

    private void txtBill_Completed(object sender, EventArgs e)
    {
		bill = decimal.Parse(txtBill.Text);
        CalculateTotal();
    }

    private void sldTip_ValueChanged(object sender, ValueChangedEventArgs e)
    {
		tip = (int)sldTip.Value;
		lblTip.Text = $"Tip: {tip}%";
		CalculateTotal();
    }

    private void Button_Clicked(object sender, EventArgs e)
    {
		if (sender is Button)
		{
			var btn = (Button)sender;
			var percentage = int.Parse(btn.Text.Replace("%", ""));
			sldTip.Value = percentage;
		}
    }

    private void btnMinus_Clicked(object sender, EventArgs e)
    {
		if (noPersons > 1)
		{
			noPersons--;
		}
		lblNoPersons.Text = noPersons.ToString();
		CalculateTotal();
    }

    private void btnPlus_Clicked(object sender, EventArgs e)
    {
        noPersons++;
        lblNoPersons.Text = noPersons.ToString();
        CalculateTotal();
    }

    private void Burger_Clicked_1(object sender, EventArgs e)
    {
        IsPresented = false;
        IsPresented = true;
    }
}
