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
    public partial class DtaeTime_Page : ContentPage
    {
        //Storing these variables at the class level to make them accessible throughout the entire class
        Label lbl;
        DatePicker dp;
        TimePicker tp;

        public DtaeTime_Page()
        {
            //Initialization of UI Elements
            lbl = new Label
            {
                Text = "Vali mingi kuupäev",
                
                BackgroundColor= Color.Chocolate,


            };
            //Initialization of UI Elements
            //active date before 5 and after 5, what we can choose
            dp = new DatePicker
            {
                Format = "D",
                MinimumDate=DateTime.Now.AddDays(-5),
                MaximumDate=DateTime.Now.AddDays(5),
                TextColor= Color.Cornsilk,

            };
            dp.DateSelected += Dp_DateSelected;

            //Initialization of UI Elements
            //default time 12:00pm
            tp = new TimePicker
            {
                Time = new TimeSpan(12,0,0),
            };
            tp.PropertyChanged += Tp_PropertyChanged;



            AbsoluteLayout abs = new AbsoluteLayout
            {
                Children = { lbl, dp, tp }

            };

            //AbsoluteLayout.SetLayoutBounds and AbsoluteLayout.SetLayoutFlags to specify the position and size of the Label
            AbsoluteLayout.SetLayoutBounds(lbl, new Rectangle(0.1, 0.2, 200, 50));
            AbsoluteLayout.SetLayoutFlags(lbl, AbsoluteLayoutFlags.PositionProportional);
            AbsoluteLayout.SetLayoutBounds(lbl, new Rectangle(0.1, 0.5, 300, 50));
            AbsoluteLayout.SetLayoutFlags(lbl, AbsoluteLayoutFlags.PositionProportional);
            AbsoluteLayout.SetLayoutBounds(lbl, new Rectangle(0.5, 0.7, 300, 50));
            AbsoluteLayout.SetLayoutFlags(lbl, AbsoluteLayoutFlags.PositionProportional);


            Content = abs;

        }



        //Event Handling PropertyChanged event of the TimePicker (tp). When the time is changed, the
        //Tp_PropertyChanged method is called, updating the label text with the selected time.
        //

        private void Tp_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            lbl.Text = "Oli valitud aeg: " + tp.Time;
            lbl.FontSize = 20;

        }
        //Event Handling DateSelected event of the DatePicker (dp). When the date is selected,
        //the Dp_DateSelected method is called, updating the label text with the selected date
        //
        private void Dp_DateSelected(object sender, DateChangedEventArgs e)
        {

            lbl.Text = "Oli valitud kuupäev" + e.NewDate.ToString("G");
            lbl.FontSize = 20;

        }
      

        
       
    }
    
}
