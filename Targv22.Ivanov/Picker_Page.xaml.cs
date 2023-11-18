using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Internals;
using Xamarin.Forms.Xaml;

namespace Targv22.Ivanov
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Picker_Page : ContentPage
    {
        
        WebView webView;
        StackLayout st;
        Entry addressBar;
        Button homeButton;
        Button backButton;
        Button forwardButton;
        Button refreshButton;
       

        public Picker_Page()
        {



            //UI to diplay the entry to input an website address
            // ReturnType.Go - type of action when the enter key is pressed
            addressBar = new Entry
            {
                Placeholder = "Enter URL",
                ReturnType = ReturnType.Go,
                HorizontalOptions = LayoutOptions.FillAndExpand,
            };
            addressBar.Completed += AddressBar_Completed;

            //home button
            homeButton = new Button
            {
                Text = "Home",
                // when button pressed it trigers the Command
                Command = new Command(() => Navigate("https://www.voa.com")),
            };
            //button go back
            backButton = new Button
            {
                Text = "Back",
                // when button pressed it trigers command back
                Command = new Command(() => webView.GoBack()),
                IsEnabled = false,  //initial state disabled
            };
            //button forward
            forwardButton = new Button
            {
                Text = "Forward",
                Command = new Command(() => webView.GoForward()),
                IsEnabled = false,
            };
             //refresh button
            refreshButton = new Button
            {
                Text = "Refresh",
                Command = new Command(() => webView.Reload()),
            };
            //to display web content
            webView = new WebView { };

            // Navigated event.
            webView.Navigated += WebView_Navigated;

            st = new StackLayout { Children = { addressBar, homeButton, backButton, forwardButton, refreshButton, webView } };

            Content = st;
        }

        //method is called when the WebView finishes navigating. It updates the state of the back and forward buttons
        private void WebView_Navigated(object sender, WebNavigatedEventArgs e)
        {
            backButton.IsEnabled = webView.CanGoBack;
            forwardButton.IsEnabled = webView.CanGoForward;
        }

        // method is called when the user hits the "Enter" key in the address bar
        private void AddressBar_Completed(object sender, EventArgs e)
        {
            Navigate(addressBar.Text);
        }


        // method is an asynchronous method that prompts the user to enter a custom URL

        //At the moment it does not work!!!
        private async void Navigate(string uri)
        {
            try
            {
                await Browser.OpenAsync(uri, BrowserLaunchMode.SystemPreferred);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception in Navigate: {ex.Message}");
            }
        }
    }






}
