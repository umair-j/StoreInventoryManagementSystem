using System;
using System.Collections.Generic;
using System.Text;

namespace assignment2EAD.Model
{
    class customer
    {
        private string username;
        private string password;
        private int phonenumber;
        public string Username
        {
            get
            {
                return username;
            }
            set
            {
                username = value;
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
            }
        }
        public int Phonenumber
        {
            get
            {
                return phonenumber;
            }
            set
            {
                phonenumber = value;
            }
        }

    }
}
