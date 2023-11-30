using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Plugin.Messaging;

namespace Targv22.Ivanov
{
    [XamlCompilation(XamlCompilationOptions.Compile)]




    public partial class Table_Page : ContentPage
    {
        TableView tableView;
        EntryCell phoneNumbereEntry;

        public Table_Page()
        {   //constructor. The method is called when an object of the class is created
            //EntryCell named phoneNumbereEntry
            //sets properties Label, Placeholder, and Keyboard

            phoneNumbereEntry = new EntryCell
            {
                Label = "phone number",
                Placeholder = "Enter phonenumber",
                Keyboard = Keyboard.Text
            };

            // make new table

            tableView = new TableView

            {
               
            //Intent property to TableIntent.Form
            //использование таблицы, которое может влиять на ее внешний вид и поведение.
            Intent = TableIntent.Form,
                //root property with new root title 
                Root = new TableRoot("andmete sisestamine")
            {
                new TableSection("Lisavõimalused")
                {
                    // ViewCell containing a horizontal StackLayout
                    new ViewCell
                    {

                        View = new StackLayout
                        {
                            Orientation = StackOrientation.Horizontal,
                            Children =
                            {
                                //Commands for buttons
                                new Button
                                {
                                    Text = "HELISTA",
                                    Command = new Command(() => MakePhoneCall(phoneNumbereEntry.Text))
                                },
                                new Button
                                {
                                    Text = "SAADA SMS",
                                    Command = new Command(() => SendSMS(phoneNumbereEntry.Text, "Default SMS Message")) 
                                }
                            }
                        }
                    },
                    new ViewCell
                    {
                        View = new StackLayout
                        {
                            Orientation = StackOrientation.Horizontal,
                            Children =
                            {
                                new Button
                                {
                                    Text = "SAADA EMAIL",
                                    Command = new Command(() => SendEmail("Default Email Message")) 
                                }
                            }
                        }
                    }
                }
            }
            };

            Content = tableView;
        }

        private void MakePhoneCall(string phoneNumber)
        {
            //PhoneDialer from the CrossMessaging plugin
            //CrossMessaging API для доступа к функциям обмена сообщениями на различных платформах
            var phoneDialer = CrossMessaging.Current.PhoneDialer;

            if (phoneDialer.CanMakePhoneCall)
                phoneDialer.MakePhoneCall(phoneNumber);
        }

        private void SendSMS(string phoneNumber, string smsMessage)
        {
            //CrossMessaging.Current экземпляр класса MessagingCenter, который используется для доступа к различным
            //функциям обмена сообщениями.
            var smsMessenger = CrossMessaging.Current.SmsMessenger;

            if (smsMessenger.CanSendSms)
                smsMessenger.SendSms(phoneNumber, smsMessage);
        }

        private void SendEmail(string emailMessage)
        {
            var emailMessenger = CrossMessaging.Current.EmailMessenger;

            if (emailMessenger.CanSendEmail)
                emailMessenger.SendEmail("", "", emailMessage);
        }
    }

}

