using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
namespace Targv22.Ivanov
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class BoxView_Page : ContentPage





    {
        BoxView box;
        Label label;


        public BoxView_Page()
        {
            rnd = new Random();

            int r = 0, g = 0, b = 0;



            box = new BoxView
            {
                Color = Color.FromRgb(r, g, b),
                CornerRadius = rnd.Next(1, 10),
                WidthRequest = rnd.Next(1, 200),
                HeightRequest = rnd.Next(1, 400),
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.CenterAndExpand



            };

            label = new Label
            {
                Text = "Pealkiri",
                HorizontalOptions = LayoutOptions.Start,
                VerticalOptions = LayoutOptions.Center,
                TextColor = Color.Green,
                BackgroundColor = Color.Black,
                FontSize = 24

            };


            TapGestureRecognizer tap = new TapGestureRecognizer();
            tap.Tapped += Tap_Tapped;
            box.GestureRecognizers.Add(tap);


            //button to reset count of numbers
            Button c = new Button
            {
                Text = "Restart count",
                HorizontalOptions = LayoutOptions.End,
                VerticalOptions = LayoutOptions.Center,

            };
            //button to go back
            Button d = new Button
            {

                Text = "Back",
                HorizontalOptions = LayoutOptions.StartAndExpand,
                VerticalOptions = LayoutOptions.Center,


            };

            c.Clicked += C_Clicked;
            d.Clicked += D_Clicked;

            StackLayout st = new StackLayout { Children = { label, box, c, d } };
            BackgroundColor = Color.White;
            Content = st;


        }

        private async void D_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }

        Random rnd;
        int tapCount = 0;
        private void Tap_Tapped(object sender, EventArgs e)
        {
            

            tapCount++;
            label.Text = "Taps: " + tapCount;



            rnd = new Random();
            box.Color = Color.FromRgb(rnd.Next(0, 255), rnd.Next(0, 255),
                rnd.Next(0, 255));


            box.CornerRadius = rnd.Next(1, 10);
            box.WidthRequest = rnd.Next(1, 200);
            box.HeightRequest = rnd.Next(1, 400);



        }

        private void C_Clicked(object sender, EventArgs e)
        {
            ResetShapeProperties();


            tapCount = 0;
            label.Text = "Taps: " + tapCount;


        }
        private void ResetShapeProperties()
        {
            // Reset the shape's properties to their initial values
            int r = 0, g = 0, b = 0;
            box.Color = Color.FromRgb(r, g, b);
            box.CornerRadius = rnd.Next(1, 10);
            box.WidthRequest = rnd.Next(1, 200);
            box.HeightRequest = rnd.Next(1, 400);
        }
    }


}