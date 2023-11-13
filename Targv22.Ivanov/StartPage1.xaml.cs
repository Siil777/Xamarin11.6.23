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
    
    public partial class StartPage1 : ContentPage
    {
        List<ContentPage> pages = new List<ContentPage>() { new EntryPage(), new TimerPage(), new BoxView_Page(), new DtaeTime_Page(),new StepperSlider_Page() };
        List<string> tekst = new List<string> { "Entry page", "Time page", "View Box", "DateTime Page", "StepperSlider Pag" };
        StackLayout st;
        public StartPage1()
        {
            st = new StackLayout
            {
                //all elements on the page pictures, buttons...call them from the structure above Button Ent_btn=new Button, Button Time_btn = new Button
                Orientation = StackOrientation.Vertical,
                BackgroundColor = Color.Beige

            };
            for (int i = 0; i < pages.Count; i++)
            {
                Button button = new Button
                {
                    Text = tekst[i],
                    //
                    TabIndex = i,
                    BackgroundColor = Color.Black,
                    TextColor = Color.Black,

                };
                st.Children.Add(button);
                button.Clicked += Button_Clicked;

            }
            ScrollView sv = new ScrollView { Content = st };
            Content = sv;
           


        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
           Button btn= (Button)sender;
            await Navigation.PushAsync(pages[btn.TabIndex]);
        }
    }
}