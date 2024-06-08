namespace KATAMINO;

public partial class Regle : ContentPage
{
	public Regle()
	{
		InitializeComponent();
	}

    private async void OnRetourButtonClicked(object sender, EventArgs e)
    {
        await Navigation.PopAsync();
    }
}