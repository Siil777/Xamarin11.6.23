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
    public partial class EntryPage : ContentPage
    {
        Label label;
       
        public EntryPage()
        {
            //to show up some text for form , where we can input some text
            Editor editor=new Editor
            {
                //a clue 
                Placeholder="Sisesta siia text",
                BackgroundColor= Color.AntiqueWhite,
                TextColor= Color.White,

            };
            //will change text in editor
            editor.TextChanged += Editor_TextChanged;

            label = new Label
            {
                Text="Pealkiri",
                HorizontalOptions= LayoutOptions.Start,
                VerticalOptions= LayoutOptions.Center,
                TextColor= Color.Black,
                BackgroundColor= Color.White,

            };
            //back button
            Button b = new Button
            {
                Text="To start page",
                HorizontalOptions= LayoutOptions.Center,
                VerticalOptions= LayoutOptions.Center,

            };
            b.Clicked += B_Clicked;
            StackLayout st = new StackLayout
            {
                Orientation = StackOrientation.Vertical,
                //definy in which turn everything will be displayied
                Children = {label,editor, b},
                BackgroundColor = Color.White,

            };
            //Children this a kind of a list  st.Children.Add(label);
            //contect display all content we had written before
            Content= st;


        }
        int i = 0;
        int max = 0;
        int number = 1;
        private  void Editor_TextChanged(object sender, TextChangedEventArgs e)
        {
            



            string newText = e.NewTextValue.ToString();

            int count = newText.Count(c => c == 'A');


            //update count adn label text
            i = count;
            label.Text = "A" + i;





        }

        private async void B_Clicked(object sender, EventArgs e)
        {
            //program close the page where it is working now
            await Navigation.PopAsync();
        }
    }
}