namespace KATAMINO;

public partial class GrandChelem : ContentPage
{
	public GrandChelem()
	{
		InitializeComponent();
	}

    private async void OnRetourButtonClicked(object sender, EventArgs e)
    {
        await Navigation.PopAsync();
    }
}