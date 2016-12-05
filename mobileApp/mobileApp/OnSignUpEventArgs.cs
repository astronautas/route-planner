using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace mobileApp
{
    class OnSignUpEventArgs : EventArgs
    {
        public string FirstName
        {
            get;
            set;
        }
        public string Email
        {
            get;
            set;
        }
        public string Password
        {
            get;
            set;          
        }

        public OnSignUpEventArgs(string firstName, string email, string password) : base()
        {
            FirstName = firstName;
            Email = email;
            Password = password;
        }
    }
}