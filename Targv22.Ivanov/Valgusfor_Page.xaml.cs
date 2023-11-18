using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Internals;
using Xamarin.Forms.Xaml;
using static System.Net.Mime.MediaTypeNames;

namespace Targv22.Ivanov
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Valgusfor_Page : ContentPage
    {
        //Storing these lists and variables at the class level to make them accessible throughout the entire class
        List<Color> colors = new List<Color> { Color.Gray, Color.Gray, Color.Gray };

        List<Color> color = new List<Color> { Color.Red, Color.Yellow, Color.Green };

        List<string> circleText = new List<string>() { "Punane", "Kollane", "Roheline" };
        List<string> buttonText = new List<string>() { "Sisse", "Välja" };
        List<string> circleText1 = new List<string>() { "Stop", "Oota", "Minne" };
        

        Frame fr;
        Button btn;

        StackLayout vf = new StackLayout();
        StackLayout nd = new StackLayout();
        StackLayout st = new StackLayout();


        //loop is used to create three Frame elements (fr) within vf, each representing a circle with a specific
        //background color, corner radius, height, and border color.

        public Valgusfor_Page()
        {
            vf.Margin = new Thickness(40);
            for (int i = 0; i < 3; i++)
            {
                

                fr = new Frame
                {
                    TabIndex = i,
                    BackgroundColor = colors[i],
                    CornerRadius = 70,
                    HeightRequest = 150,
                    BorderColor = Color.Black,
                    Content = new StackLayout
                    {
                        VerticalOptions = LayoutOptions.Center,
                        HorizontalOptions = LayoutOptions.Center,
                        Children =
                {
                    new Label
                    {
                        Text = circleText[i],
                        TextColor = Color.Black,
                        FontSize = 18
                         

                    }
                }
                    }
                };
                vf.Children.Add(fr);
            }
            //nd is given a margin of 10 and set to start horizontally
            nd.Margin = new Thickness(10);
            nd.HorizontalOptions = LayoutOptions.StartAndExpand;
            nd.Orientation = StackOrientation.Horizontal;

            //loop is used to create two buttons (btn)
            //These buttons are added to the nd StackLayout.
            for (int i = 0; i < 2; i++)
            {
                btn = new Button
                {
                    Text = buttonText[i],
                    BackgroundColor = Color.Aqua,
                    TabIndex = i,
                };
                nd.Children.Add(btn);
                btn.Clicked += Btn_Clicked;
            }
            //vf and nd are added to st, creating a vertical arrangement
            st.Children.Add(vf);
            st.Children.Add(nd);
            Content = st;
        }
       
        private void Btn_Clicked(object sender, EventArgs e)
        {
            //retrieves the Button instance that triggered the event
            Button btn = (Button)sender;
            


            //initialize loop to call all elemets vfStackLayout
            for (int i = 0; i < vf.Children.Count; i++)
            {
                //extraxt each element with index

                Frame circleFrame = (Frame)vf.Children[i];
                //Content property is cast to a StackLayout 
                StackLayout stackLayout = (StackLayout)circleFrame.Content;
                //stackLayout become a reference to the StackLayout and retrieves the first child of the StackLayout
                //(Label)stackLayout.Children[0];
                Label circleLabel = (Label)stackLayout.Children[0];




                //if the value is equal index btn = 0
                if (btn.TabIndex == 0)
                {

                        //call list of cclor by clicking the button
                   
                        circleFrame.BackgroundColor = color[i];
                        //call list of text by clicking the button
                        circleLabel.Text = circleText1[i];
                        




                }
                else if (btn.TabIndex == 1)
                {
                    //call initial color by clicking the button

                    
                    circleFrame.BackgroundColor = Color.Gray;

                    //call initial text 
                    circleLabel.Text = circleText[i];


                }
               

                    
            }
           
        }


    }
}
