namespace KATAMINO;

public partial class PageEtape : ContentPage
{
	public PageEtape()
	{
		InitializeComponent();
	}
    private async void OnRetourButtonClicked(object sender, EventArgs e)
    {
        await Navigation.PopAsync();
    }
}