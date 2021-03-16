using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using NeoStoreApp.View;

namespace NeoStoreApp
{
    public partial class App : Application
    {
       //for logout method
        public static App Current;
        public App()
        {
            InitializeComponent();
            Device.SetFlags(new string[] { "RadioButton_Experimental" });
            Current = this;

            /*    MainPage = new NavigationPage(new HomeScreenPage())
                 {
                     BarBackgroundColor = Color.FromHex("#e91c1a")
                 }; */

            //Declaring login variable to store login status 
            bool isLoggedIn = Current.Properties.ContainsKey("IsLoggedIn") ? Convert.ToBoolean(Current.Properties["IsLoggedIn"]) : false;
                             //check whether user log in or not.
                             if (isLoggedIn)
                             {


                     MainPage = new NavigationPage(new HomeScreenPage()
                     {
                         Title="NeoStore"

                     });             


                             }
                             else
                             {
                                 MainPage = new NavigationPage(new LoginPage())
                                 {
                                     BarBackgroundColor = Color.FromHex("#e91c1a")
                                 };
                             }
                     
            //logout method


        }

        //logout Method
        public void Logout()
        {
            Properties["IsLoggedIn"] = false; // only gets set to 'true' on the LoginPage
            MainPage = new NavigationPage(new LoginPage())
            {
                BarBackgroundColor = Color.FromHex("#e91c1a")
            };
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
