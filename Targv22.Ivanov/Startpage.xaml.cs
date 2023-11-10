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
    public partial class Startpage : ContentPage
    {
        public Startpage()
        {
            Button Ent_btn=new Button
            {
                Text="Entry page",
                BackgroundColor=Color.Azure
            };
            Button Time_btn = new Button
            {
                Text = "Time page",
                BackgroundColor = Color.Azure
            };
            Button VievBox_btn = new Button
            {
                Text = "View Box",
                BackgroundColor = Color.Azure
            };
            Button Date_Time_btn = new Button
            {
                Text="DateTime Page",
                BackgroundColor = Color.Azure

            };


            StackLayout st =new StackLayout
            {
                //all elements on the page pictures, buttons...call them from the structure above Button Ent_btn=new Button, Button Time_btn = new Button
                Children = {Ent_btn, Time_btn, VievBox_btn, Date_Time_btn },
                BackgroundColor=Color.Beige


            };
            //in contect we call elements from stackLayot and button
            Content= st;
            Ent_btn.Clicked += Ent_btn_Clicked;
            Time_btn.Clicked += Time_btn_Clicked;
            VievBox_btn.Clicked += VievBox_btn_Clicked;
            Date_Time_btn.Clicked += Date_Time_btn_Clicked;


        }

        //Display button in app navigation
        private async void Date_Time_btn_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new DtaeTime_Page());
        }

        private async void VievBox_btn_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new BoxView_Page());

        }

        private async void Time_btn_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new TimerPage());
        }

        private async void Ent_btn_Clicked(object sender, EventArgs e)
        {
           await Navigation.PushAsync(new EntryPage()); 
        }
    }
}