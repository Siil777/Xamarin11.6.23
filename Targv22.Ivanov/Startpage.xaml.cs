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
            Button StepperSlider_btn = new Button
            {
                Text="StepperSlider Page",
                BackgroundColor = Color.Azure


            };
            Button Frame_btn = new Button
            {
                Text="Frame page",
                BackgroundColor=Color.Azure

            };
            Button valgusfor_btn = new Button
            {
                Text = "Valgusfor",
                BackgroundColor=Color.Azure

            };
         
            Button Table_page_btn = new Button
            {
                Text = "Table page",
                BackgroundColor = Color.Azure

            };
            Button Table_View_Page = new Button
            {
                Text = "Table page 1",
                BackgroundColor = Color.Azure

            };
            Button Picker_Internet = new Button
            {
                Text = "Picker Internet",
                BackgroundColor = Color.Azure

            };



            StackLayout st =new StackLayout
            {
                //all elements on the page pictures, buttons...call them from the structure above Button Ent_btn=new Button, Button Time_btn = new Button
                Children = {Ent_btn, Time_btn, VievBox_btn, Date_Time_btn, StepperSlider_btn, Frame_btn, valgusfor_btn, Table_page_btn, Table_View_Page, Picker_Internet },
                BackgroundColor=Color.Beige


            };
            //in contect we call elements from stackLayot and button
            Content= st;
            Ent_btn.Clicked += Ent_btn_Clicked;
            Time_btn.Clicked += Time_btn_Clicked;
            VievBox_btn.Clicked += VievBox_btn_Clicked;
            Date_Time_btn.Clicked += Date_Time_btn_Clicked;
            StepperSlider_btn.Clicked += StepperSlider_btn_Clicked;
            Frame_btn.Clicked += Frame_btn_Clicked;
            valgusfor_btn.Clicked += Valgusfor_btn_Clicked;
            
            Table_page_btn.Clicked += Table_page_btn_Clicked;
            Table_View_Page.Clicked += Table_View_Page_Clicked;
            Picker_Internet.Clicked += Picker_Internet_Clicked;




        }

        private async void Picker_Internet_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Picker_Internet());
        }

        private async void Table_View_Page_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Table_Page_View());
        }

        private async void Table_page_btn_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Table_Page());

        }

        private async void Valgusfor_btn_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Valgusfor_Page());


        }

        private async void Frame_btn_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Frame_page());

        }

        private async void StepperSlider_btn_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new StepperSlider_Page());
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