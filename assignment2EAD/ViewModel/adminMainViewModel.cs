using assignment2EAD.commands;
using assignment2EAD.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;
using System.Windows;

namespace assignment2EAD.ViewModel
{
    class adminMainViewModel
    {
        public DelegateCommand addProductCommand { get; set; }
        
        public adminMainViewModel()
        {
            service = new productService();
            
            list = service.getAllProducts();
            addProductCommand = new DelegateCommand(add, canAdd);
        }

        public string name { get; set; }
        public string id { get; set; }
        public int price { get; set; }
        public int quantity { get; set; }
        public productService service { get; set; }
        public ObservableCollection<product> list { get; set; }

        public void add(object obj)
        {
            product prod = new product();
            prod.ProductName = this.name;
            prod.ProductID = this.id;
            prod.Price = this.price;
            prod.Quantity = this.quantity;
            service.addProduct(prod);
        }
        public bool canAdd(object obj)
        {
            if(string.IsNullOrEmpty(name) || string.IsNullOrEmpty(id))
            {
                return false;
            }
            else
            {
                return true;
            }
        }

    }
}
