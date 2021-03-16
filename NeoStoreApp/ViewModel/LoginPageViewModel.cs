using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;
using System.Threading;
using NeoStoreApp.Model.Login;
using NeoStoreApp.Service.Login;
using NeoStoreApp.View;
using System.ComponentModel;

namespace NeoStoreApp.ViewModel 
{
    class LoginPageViewModel : BindableObject
    {
        //string varible to store username and password entered by user.
        private string username, password;
        private LoginService _LoginService;
        
        public LoginPageViewModel()
        {
            _LoginService = new LoginService();
        }

        private bool _isRun;
        public bool isRun
        {//for loader
            get
            {
                return _isRun;
            }
            set
            {
                _isRun = value;
                OnPropertyChanged("isRun");
               
            }
        }
        //Binded in login page xaml .
        public string userName
        {
            get
            {
                return username;
            }
            set
            {
                username = value;
                OnPropertyChanged("userName");
            }
        }
        public string userPass
        {
            get
            {
                return password;
            }
            set
            {
                password = value;
                OnPropertyChanged("userPass");
            }
        }
        //checked whether username or password enterd by user is empty or not.
        private bool IsvalidEntered(string username,string password)
        {
            
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                isRun = false;
               // Application.Current.MainPage.DisplayAlert("Alert", "Please enter valid username and password", "OK");
                return false;
            }
            return true;
        }
        /// <summary>
        /// perform login action with api 
        /// </summary>
        private  void doLogin()
        {
           
            if (IsvalidEntered(username, password))
            {
                //api call.
                try {
                    //request variable of login request model to store username and password.
                    LoginRequestModel request = new LoginRequestModel();
                    request.email = username;
                    request.password = password;
                    //api request
                    
                    var Response = _LoginService.PerformUserLogin(request);
                    if (Response == null)
                    {
                        isRun = false;
                        Application.Current.MainPage.DisplayAlert("Alert", "Login Unsuccessful", "OK");
                    }
                    else
                    {
                        isRun = false;
                        Application.Current.MainPage.DisplayAlert("Alert", "Login Success", "OK");
                        Application.Current.MainPage = new NavigationPage(new HomeScreenPage()
                        {
                            Title = "NeoStore"
                            
                        });

                        //setting variable value true to set login success
                        Application.Current.Properties["IsLoggedIn"] = Boolean.TrueString;




                    }
                    
                    Console.WriteLine(Response);
                   

                }
                catch(Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
            else
            {
                isRun = false;
                Application.Current.MainPage.DisplayAlert("Alert", "Please enter valid Details.", "OK");

            }
                   

        }

       
        /// <summary>
        /// button command to check login creditinals.
        /// </summary>
        public ICommand userLogin
        {
            get
            {
               
                return new Command(() => {
                    isRun = true;
                    doLogin(); 
                });

            }
           
        }
        //methdod to open register page.
        public ICommand OpenRegisterPage
        {
            get
            {
                return new Command(() => {
                    Application.Current.MainPage.Navigation.PushAsync(new RegisterPage());

                });

            }
        }


    }
}
