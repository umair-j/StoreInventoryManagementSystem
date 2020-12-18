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
        //commands for signin signup buttons
        public DelegateCommand signUpCommand { get; set; }
        public DelegateCommand signInCommand { get; set; }
        //object of customer helper class declared
        public customerService service { get; set; }
        //customer properties declared
        public string Username1 { get; set; }
        public string Password1 { get; set; }
        public string Username2 { get; set; }
        public string Password2 { get; set; }
        public long PhoneNumber { get; set; }
        //list of customers declared
        public ObservableCollection<customer> list;
        //default constructor
        public customerMainViewModel()
        {
            //initialized
            service = new customerService();
            //list = new ObservableCollection<customer>();
            //list populated
            list = service.getAllCustomers();
            //commands initialized
            signUpCommand = new DelegateCommand(signup,cansignup);
            signInCommand = new DelegateCommand(signin,canSignin);
        }
        //function for signin button
        public void signin(object obj)
        {
            //list = service.getAllCustomers();
            bool allow = false;
            //run through all of list to match details
            foreach (customer cstmr in list)
            {
                if (cstmr.Username.Equals(Username1) && cstmr.Password.Equals(Password1))
                {              
                    allow = true;
                }
            }
            if(allow == false)
            {
                MessageBox.Show("access Denied");
            }
            else
            {
                MessageBox.Show("Welcome User");
                
                addToCartWindow w = new addToCartWindow();
                //if matched then open next window
                w.Show();
            }
        }
        //function to enable/disable signin button
        public bool canSignin(object obj)
        {
            bool allowed;
            //if both username and password textboxes are not null then enable them
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

        //function to enable/disable signup button
        public bool cansignup(object obj)
        {
            bool allowed;
            //if both username and password and phone number textboxes are not null then enable them
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
        //function to execute when signup is clicked
        public void signup(object obj)
        {
            bool exists = default;
            //customer object created and initialized 
            customer c = new customer();
            c.Username = Username2;
            c.Password = Password2;
            c.Phonenumber = PhoneNumber;
            //check through list if user already exists
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
                //call base add function from helper customer class
                service.addCustomer(c);
                MessageBox.Show("user created");
            }
            
            //MessageBox.Show(c.Username);
        }
    }
}
