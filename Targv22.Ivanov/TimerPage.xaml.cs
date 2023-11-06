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
    public partial class TimerPage : ContentPage
    {
        public TimerPage()
        {
            InitializeComponent();
        }

        private async void btn_tagasi_Clicked(object sender, EventArgs e)
        {
            //close page PopAsync();

            await Navigation.PopAsync();

        }
        bool onoff = false;
        private async void Showtime()
        {
            while (onoff)
            {
               


                timer_value.Text = DateTime.Now.ToString("T");
                await Task.Delay(1000);

            }
        }

        private void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
           
            if (onoff==true)
            {

                onoff= false;
                timer_start.Text = "Start";//!

            }
            else 
            {

                
                onoff = true;
                Showtime();
                timer_start.Text = "Stop";//!

            }

        }
    }
}