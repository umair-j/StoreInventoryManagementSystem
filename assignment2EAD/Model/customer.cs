using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace assignment2EAD.Model
{

    class customer : INotifyPropertyChanged
    {
        //customer details
        private string username;
        private string password;
        private long phonenumber;
        //details' getter setters
        public string Username
        {
            get
            {
                return username;
            }
            set
            {
                username = value;
                onPropertyChanged(Username);
            }
        }
        public string Password
        {
            get
            {
                return password;
            }
            set
            {
                password = value;
                onPropertyChanged(Password);
            }
        }
        public long Phonenumber
        {
            get
            {
                return phonenumber;
            }
            set
            {
                phonenumber = value;
                onPropertyChanged(Phonenumber.ToString());
            }
        }
        //property change event
        public event PropertyChangedEventHandler PropertyChanged;
        //function to call event in case of property change
        public void onPropertyChanged(string propName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propName));
            }
        }
    }
}
