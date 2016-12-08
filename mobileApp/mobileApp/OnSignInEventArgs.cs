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
    class OnSignInEventArgs : EventArgs
    {
        public string LoginName
        {
            get;
            set;
        }
        public string LoginPassword
        {
            get;
            set;
        }
        public OnSignInEventArgs(string loginName, string loginPassword) : base()
        {
            LoginName = loginName;
            LoginName = loginName;
            LoginPassword = loginPassword;
        }
    }
}