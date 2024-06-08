using Microsoft.Maui.Controls;

namespace KATAMINO
{
    public partial class ViewParam : ContentView
    {
        public ViewParam()
        {
            InitializeComponent();
        }

        private async void OnRegleButtonClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Regle());
        }


    }
}
