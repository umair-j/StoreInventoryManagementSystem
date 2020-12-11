using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace assignment2EAD.Model
{
    class customerService
    {
        public ObservableCollection<customer> customerList { get; set; }
        public ObservableCollection<customer> getAllCustomers()
        {
            return customerList;
        }
        public customerService()
        {
            customerList = new ObservableCollection<customer>() { 
            new customer { Username = "umair", Password = "pass1", Phonenumber = 12345 }

            };
        }
        public void addCustomer(customer c)
        {
            customerList.Add(c);
        }

    }
}
