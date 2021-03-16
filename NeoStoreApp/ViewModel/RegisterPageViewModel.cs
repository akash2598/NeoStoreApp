using NeoStoreApp.Model.Register;
using NeoStoreApp.Service.Register;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace NeoStoreApp.ViewModel
{
    class RegisterPageViewModel:BindableObject
    {
        private RegisterService _registerService;
        //creating private variable to store xmal page value so that it will not changed.
        private string _firstName,_lastName,_email,_password,_Cpassword,_Gender, _phoneNum;

        private bool _chkBox, _Male, _Female,_isRun;
        public RegisterPageViewModel()
        {
            _registerService = new RegisterService();
           
        }
        //storing value in private variable
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
        public string firstName
        {
            get
            {
                return _firstName;
            }
            set
            {
                _firstName = value;
                OnPropertyChanged("fisrtName");
            }
        }
        public string lastName
        {
            get
            {
                return _lastName;
            }
            set
            {
                _lastName = value;
                OnPropertyChanged("lastName");
            }
        }
        public string email
        {
            get
            {
                return _email;
            }
            set
            {
                _email = value;
                OnPropertyChanged("email");
            }
        }
        public string password
        {
            get
            {
                return _password;
            }
            set
            {
                _password = value;
                OnPropertyChanged("password");
            }
        }
       
         public string Cpassword
        {
            get
            {
                return _Cpassword;
            }
            set
            {
                _Cpassword = value;
                OnPropertyChanged("Cpassword");
            }
        }
        public string phoneNum
        {
            get
            {
                return _phoneNum;
            }
            set
            {
                _phoneNum = value;
                OnPropertyChanged("phoneNum");
            }
        }
        public bool chkBox
        {
            get
            {
                return _chkBox;
            }
            set
            {
                _chkBox = value;
                OnPropertyChanged("chkBox");
            }
        }
        public bool Male
        {
            get
            {
                return _Male;
            }
            set
            {
                _Male = value;
                OnPropertyChanged("Male");
            }
        }
        public bool Female
        {
            get
            {
                return _Female;
            }
            set
            {
                _Female = value;
                OnPropertyChanged("Female");
            }
        }
        
        //checked valid entry
        private bool isValidEnter()
        {
            
           
            if (_chkBox)
            {
                if (_Male)
                {
                    _Gender = "M";
                }
                else if (_Female)
                {
                    _Gender = "F";
                }
                else
                {
                    _Gender = null;
                }
                //fisrt name validity
                if (string.IsNullOrEmpty(_firstName))
                {
                     Application.Current.MainPage.DisplayAlert("Alert", "Please enter first name.", "OK");
                    return false;
                }
                //last name validity
                if (string.IsNullOrEmpty(_lastName))
                {
                    Application.Current.MainPage.DisplayAlert("Alert", "Please enter last name.", "OK");
                    return false;
                }
                //email validity
                if (string.IsNullOrEmpty(_email))
                {
                    Application.Current.MainPage.DisplayAlert("Alert", "Please enter email id.", "OK");
                    return false;
                }
                if (string.IsNullOrEmpty(_password))
                {
                    Application.Current.MainPage.DisplayAlert("Alert", "Please enter password.", "OK");
                    return false;
                }
                if (string.IsNullOrEmpty(_Cpassword))
                {
                    Application.Current.MainPage.DisplayAlert("Alert", "Please enter confirm password.", "OK");
                    return false;
                }
                if (string.IsNullOrEmpty(_phoneNum))
                {
                    Application.Current.MainPage.DisplayAlert("Alert", "Please enter phone number.", "OK");
                    return false;
                }
                if (string.IsNullOrEmpty(_Gender))
                {
                    Application.Current.MainPage.DisplayAlert("Alert", "Please select gender.", "OK");
                    return false;
                }
                if (_password != _Cpassword)
                {
                    Application.Current.MainPage.DisplayAlert("Alert", "Password and Confirm Password doesn't match", "OK");
                    return false;
                }
                return true;
            }
            else
            {
                 Application.Current.MainPage.DisplayAlert("ValidEnter", "Please accept the terms and conditions.", "OK");
                return false;
            }
        }

        private  void doRegister()
        {
            if (isValidEnter())
            {
                try
                {
                    RegisterRequestModel request = new RegisterRequestModel();
                    request.firstName = _firstName;
                    request.lastName = _lastName;
                    request.password = _password;
                    request.confirm_password = _Cpassword;
                    request.email = _email;
                    request.gender = _Gender;
                    request.phone_no = _phoneNum;
                    //registerService api call
                    _isRun = true;
                      var respone=  _registerService.PerformUserRegister(request);
                    if (respone == null)
                    {
                        Application.Current.MainPage.DisplayAlert("Alert", "Register Unsuccessful", "OK");
                    }
                    else
                    {
                        Application.Current.MainPage.DisplayAlert("Alert", "Register Success", "OK");
                    }
                    _isRun = false;
                    Console.WriteLine(respone); 

                }
                catch(Exception e)
                {
                    Console.WriteLine(e.Message);
                     Application.Current.MainPage.DisplayAlert("DoRegister", e.Message, "OK");
                }
            }
          
        }

        public ICommand userRegister
        {
            get
            {
                return new Command(() => {
                    doRegister();
                });

            }
        }



    }
}
