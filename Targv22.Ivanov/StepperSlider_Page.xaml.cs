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
    public partial class StepperSlider_Page : ContentPage
    {
        //Storing these variables at the class level to make them accessible throughout the entire class
        Label lbl;
        Slider sld;
        Stepper stp;
        public StepperSlider_Page()
        {
            //Initialization of UI Elements
            lbl = new Label
            {
                Text = "...",
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.CenterAndExpand,

               
            };
            //Initialization of UI Elements
            //Minimum value set to 0, maximum value set to 100, and the initial value set to 30
            sld = new Slider
            {
                Minimum = 0,
                Maximum = 100,
                Value=30,
                MinimumTrackColor = Color.White,
                MaximumTrackColor=Color.Black,
                ThumbColor = Color.Red,


            };
            //Event handler to handle the value changed event
            sld.ValueChanged += Sld_ValueChanged;

            //Minimum value set to 0, maximum value set to 100, and the increment set to 1.
            //Positioned at the center horizontally and expanded vertically
            stp = new Stepper
            {
                Minimum = 0,
                Maximum = 100,
                Increment=1,
                HorizontalOptions= LayoutOptions.Center,
                VerticalOptions= LayoutOptions.CenterAndExpand,

            };
            //event handler 
            stp.ValueChanged += Stp_ValueChanged;


            StackLayout st = new StackLayout
            {
                Children = { lbl, sld,stp }

            };
            //content of the page is set to the stack layout
            Content = st;

        }
        //Updates the label's text, font size, and rotation based on the slider's value
        private void Stp_ValueChanged(object sender, ValueChangedEventArgs e)
        {
            lbl.Text = String.Format("Valitud: {0:F1}", e.NewValue);
            lbl.FontSize=e.NewValue; 
            lbl.Rotation=e.NewValue;
        }
        //Updates the label's text, font size, and rotation based on the slider's value
        private void Sld_ValueChanged(object sender, ValueChangedEventArgs e)
        {
            lbl.Text = String.Format("Valitud: {0:F1}", e.NewValue);
            lbl.FontSize = e.NewValue;
            lbl.Rotation = e.NewValue;


        }
    }
}