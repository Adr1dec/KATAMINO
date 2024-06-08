namespace KATAMINO;

public partial class ModePage : ContentPage
{
	public ModePage()
	{
        InitializeComponent();
    }
    
    private async void OnRetourButtonClicked(object sender, EventArgs e)
    {
        await Navigation.PopAsync();
    }
    private async void OnGrandButtonClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new GrandChelem());
    }
    private async void OnPetitButtonClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new PageEtape());
    }



}