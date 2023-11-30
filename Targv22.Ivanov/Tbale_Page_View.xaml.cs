using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Plugin.Messaging;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using static Xamarin.Essentials.Permissions;

namespace Targv22.Ivanov
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Table_Page_View : ContentPage
    {
        TableView tableView;
        ImageCell imageCell;
        TableSection fotosection;
        SwitchCell switchCell;
   

        public Table_Page_View()
        {
            //TableSection() a section of the table
            fotosection = new TableSection();

            // for toggling the visibility of an image
            switchCell = new SwitchCell { Text = "Näita veel..." };
            switchCell.OnChanged += SwitchCell_OnChanged;

            imageCell = new ImageCell { Text = "Foto:", ImageSource = "deer.jpg", Detail = "Kirjeldus" };

            var phoneNumbereEntry = new EntryCell
            {
                Label = "Telefon: ",
                Placeholder = "Sisesta telefon",

                // keyboard set to Keyboard.Telephone
                Keyboard = Keyboard.Telephone
            };

            var smsSendEntry = new EntryCell
            {
                Label = "SMS tekst: ",
                Placeholder = "Sisesta SMS tekst",

                // keyboard set to Keyboard.Text
                Keyboard = Keyboard.Text
            };

            var emailEntry = new EntryCell
            {
                Label = "Email: ",
                Placeholder = "Sisesta email",

                // Keyboard.Text Keyboard.Email
                Keyboard = Keyboard.Email
            };

            tableView = new TableView
            {
                Intent = TableIntent.Form,
                Root = new TableRoot("Andmed:")
        {
            // section
            new TableSection("Põhiandmed:")
            {
                new EntryCell
                {
                    Label = "Nimi: ",
                    Placeholder = "Sisesta nimi",
                    Keyboard = Keyboard.Text
                }
            },
            // section
            new TableSection("Kontakt andmed:")
            {
                phoneNumbereEntry,
                // createButtonCell associated with an action (a lambda expression) that calls the MakePhoneCall
                CreateButtonCell("HELISTA", () => MakePhoneCall(phoneNumbereEntry.Text)),
                smsSendEntry,
                // createButtonCell associated with an action (a lambda expression) that calls the SendSMS
                CreateButtonCell("SAADA SMS", () => SendSMS(phoneNumbereEntry.Text, smsSendEntry.Text)),
                emailEntry,
                // createButtonCell associated with an action (a lambda expression) that calls the SendEmail
                CreateButtonCell("SAADA EMAIL", () => SendEmail(emailEntry.Text)),
                switchCell
            },
            fotosection
        }
            };
            Content = tableView;
        }

        private void SendEmail(string emailMessage)
        {
            // retrieves the current instance of the EmailMessenger from the CrossMessaging class is
            // part of the Xamarin.Essentials library
            var emailMessenger = CrossMessaging.Current.EmailMessenger;

            //  if the device is capable of sending emails
            if (emailMessenger.CanSendEmail)
            {
                // create an EmailMessage using the EmailMessageBuilder
                var email = new EmailMessageBuilder()
                    .To("recipient@example.com")
                    .Subject("Subject")
                    .Body(emailMessage)
                    .Build();
                emailMessenger.SendEmail(email);
            }
        }

        // CreateButtonCell method is a utility method that creates a
        // ViewCell containing a StackLayout with a single Button
        private ViewCell CreateButtonCell(string buttonText, Action onClick)
        {
            //returns the created ViewCell
            return new ViewCell
            {
                // Inside the method, a new ViewCell is created. The View property of the ViewCell is set to a StackLayout.
                // The StackLayout is configured to have a horizontal orientation
                View = new StackLayout
                {
                    // children will be laid out horizontally
                    Orientation = StackOrientation.Horizontal,
                    Children =
            {
                new Button
                {
                    // specified buttonText
                    // buttonText is a parameter of the CreateButtonCell to capture "HELISTA", "SAADA SMS", "SAADA EMAIL"
                    Text = buttonText,
                    Command = new Command(onClick)
                }
            }
                }
            };
        }

        //  event of a SwitchCell to control the visibility of an image cell 
        private void SwitchCell_OnChanged(object sender, ToggledEventArgs e)
        {
            // This condition checks if the Value property of the ToggledEventArgs is true
            // If the switch is toggled on, it sets the title of the fotosection
            if (e.Value)
            {
                fotosection.Title = "Näita..";
                // add the imageCell to the fotosection
                fotosection.Add(imageCell);
                switchCell.Text = "Peida";
            }
            else
            {
                //clear the title of the fotosection, fotosection.Title = "";
                fotosection.Title = "";
                fotosection.Remove(imageCell);
                switchCell.Text = "Näita veel";
            }
        }

        private void MakePhoneCall(string phoneNumber)
        {
            try
            {
                //var phoneDialer - retrieve the phone dialer functionality using the CrossMessaging plugin
                //CrossMessaging.Current provides access to various device-specific functionalities in Xamarin.Forms
                var phoneDialer = CrossMessaging.Current.PhoneDialer;

                //condition to check if the phone dialer is capable of making a phone call
                if (phoneDialer.CanMakePhoneCall && !string.IsNullOrWhiteSpace(phoneNumber))
                {
                    //If the condition is met, it makes a phone call using the MakePhoneCall
                    //passing the phone number as an argument
                    phoneDialer.MakePhoneCall(phoneNumber);
                }
                else
                {
                    DisplayAlert("Error", "Unable to make a phone call. Please check the phone number.", "OK");
                }
            }
            //To catche any exceptions that might occur during the phone call attemp
            catch (Exception ex)
            {
                Console.WriteLine($"Exception in MakePhoneCall: {ex.Message}");
                DisplayAlert("Error", "An error occurred while making a phone call.", "OK");
            }
        }


        private void SendSMS(string phoneNumber, string smsMessage)
        {
            //retrieve the SMS messenger functionality using the CrossMessaging plugin
            var smsMessenger = CrossMessaging.Current.SmsMessenger;

            //To check if the SMS messenger is capable of sending an SMS
            if (smsMessenger.CanSendSms)

                //If the condition is met, it sends an SMS using the SendSms method of the SMS messenger,
                //passing the phone number and SMS message as arguments
                smsMessenger.SendSms(phoneNumber, smsMessage);
        }




    }

}
