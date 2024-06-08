using System;
using System.Windows;

namespace KATAMINO
{
    public partial class MainPage : ContentPage
    {

        public MainPage()
        {
            InitializeComponent();
            anim(monImage);
            anim(monImage2);
            anim(monImage3);
            anim(monImage4);
            anim(monImage5);
            anim(monImage6);
            anim(monImage7);
            anim(monImage8);
            anim(monImage9);
            anim(monImage10);
        }
        private async void anim(Image image)
        {
            while (true)
            {
                await Task.WhenAll<bool>
                (
                    image.RotateTo(360, 5000),
                    image.TranslateTo(0, 600, 5000)
                );
                image.Rotation = 0;
                await image.TranslateTo(0, 0, 0);
            }
        }

        private async void OnPlayButtonClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ModePage());
        }


    }

}
