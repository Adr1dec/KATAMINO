namespace KATAMINO;

public partial class ViewButon : ContentView
{
    public static readonly BindableProperty ButtonTextProperty =BindableProperty.Create(nameof(ButtonText), typeof(string), typeof(ViewButon), default(string));
    public string ButtonText
    {
        get => (string)GetValue(ButtonTextProperty);
        set => SetValue(ButtonTextProperty, value);
    }

    public static readonly BindableProperty ChelemProperty = BindableProperty.Create(nameof(Chelem), typeof(string), typeof(ViewButon), default(string));

    public string Chelem
    {
        get => (string)GetValue(ChelemProperty);
        set
        {
            if (value == "1" || value == "2") { SetValue(ChelemProperty, value); }
            else { throw new MauvaisChelemException(); }
        }
    }
    public ViewButon()
	{
		InitializeComponent();
        BindingContext = this;
    }

    private async void OnButtonClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new PagePlateau(ButtonText, Chelem));
    }
}

class MauvaisChelemException : Exception
{
    public MauvaisChelemException() : base() { }
    public MauvaisChelemException(string message) : base(message) { }
}