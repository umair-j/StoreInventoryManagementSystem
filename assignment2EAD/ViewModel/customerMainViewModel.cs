using assignment2EAD.commands;
using assignment2EAD.Model;
using assignment2EAD.View;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows;

namespace assignment2EAD.ViewModel
{
    class customerMainViewModel
    {
        public DelegateCommand signUpCommand { get; set; }
        public DelegateCommand signInCommand { get; set; }
        public customerService service { get; set; }

        public string Username1 { get; set; }
        public string Password1 { get; set; }
        public string Username2 { get; set; }
        public string Password2 { get; set; }
        public int PhoneNumber { get; set; }
        public ObservableCollection<customer> list;
        public customerMainViewModel()
        {
            service = new customerService();
            //list = new ObservableCollection<customer>();
            list = service.getAllCustomers();
            
            signUpCommand = new DelegateCommand(signup,cansignup);
            signInCommand = new DelegateCommand(signin,canSignin);
        }

        public void signin(object obj)
        {
            bool allow = false;
            foreach (customer cstmr in list)
            {
                if (cstmr.Username == Username2 && cstmr.Password==Password2)
                {
                    MessageBox.Show("Welcome User");
                    allow = true;
                    addToCartWindow w = new addToCartWindow();
                    w.Show();
                    
                    
                }
            }
            if(allow == false)
            {
                MessageBox.Show("access Denied");
            }
        }

        public bool canSignin(object obj)
        {
            bool allowed;
            if(string.IsNullOrEmpty(Username1) || string.IsNullOrEmpty(Password1))
            {
                allowed = false;
            }
            else
            {
                allowed = true;
            }
            return allowed;
        }

        public bool cansignup(object obj)
        {
            bool allowed;
            if (string.IsNullOrEmpty(Username2) || string.IsNullOrEmpty(Password2) || PhoneNumber.Equals(0))
            {
                allowed = false;
            }
            else
            {
                allowed = true;
            }
            return allowed;
        }

        public void signup(object obj)
        {
            bool exists = default;
            customer c = new customer();
            c.Username = Username2;
            c.Password = Password2;
            c.Phonenumber = PhoneNumber;
            foreach(customer cstmr in list)
            {
                if(cstmr.Username == Username2)
                {
                    MessageBox.Show("User already exists");
                    exists = true;
                }
            }
            if (!exists)
            {
                service.addCustomer(c);
                MessageBox.Show("user created");
            }
            
            //MessageBox.Show(c.Username);
        }
    }
}
