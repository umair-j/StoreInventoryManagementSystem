﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace assignment2EAD.Model
{
    class product : INotifyPropertyChanged
    {
        private string productid;
        private string productname;
        private int price;
        private int quantity;
        public string ProductID {
            get { return productid; }
            set { productid = value; onPropertyChanged(ProductID); }
        }
        public string ProductName {
            get { return productname; }
            set { productname = value; onPropertyChanged(ProductName); }
        }
        public int Price {
            get
            {
                return price;
            }
            set
            {
                price = value;
                onPropertyChanged(Price.ToString());
            }
        }
        public int Quantity
        {
            get
            {
                return quantity;
            }
            set
            {
                quantity = value;
                onPropertyChanged(Quantity.ToString());
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void onPropertyChanged(string propName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propName));
            }
        }
    }
}