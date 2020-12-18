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
        //declaring command for add show delete
        public DelegateCommand addProductCommand { get; set; }
        public DelegateCommand showProductCommand { get; set; }
        public DelegateCommand deleteProductCommand { get; set; }
        //default constructor
        public adminMainViewModel()
        {
            service = new productService();
            //storing all products in list
            list = service.getAllProducts();
            //initializing all commands
            addProductCommand = new DelegateCommand(add, canAdd);
            showProductCommand = new DelegateCommand(display, canDisplay);
            deleteProductCommand = new DelegateCommand(delete,canDelete);
        }
        //function to disable/enable delete button
        private bool canDelete(object obj)
        {
            if (string.IsNullOrEmpty(deleteId))
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        //search function for 
        public product findproduct(string id)
        {
            product p = default;
            //loop to iterate through all list
            for(int i = 0; i < list.Count; i++)
            {
                if(list[i].ProductID.Equals(id))
                {
                    p = list[i];
                    break;
                }
            }
            return p;
        }
        //function to delete product
        private void delete(object obj)
        {
            product p = null;
            //call search function
            p = findproduct(deleteId);
            if(p == null)
            {
                MessageBox.Show("Unable to remove product");
            }
            else
            {
                //call base delete function from product helper class
                service.deleteProduct(p);
                MessageBox.Show("Removed");
            }
        }
        //product object properties
        public string deleteId { get; set; }
        public string name { get; set; }
        public string id { get; set; }
        public int price { get; set; }
        public int quantity { get; set; }
        //product helper class declared
        public productService service { get; set; }
        //product list declared
        public ObservableCollection<product> list { get; set; }
        //add function to add object to list
        public void add(object obj)
        {
            //create new object and add values to it
            product prod = new product();
            prod.ProductName = this.name;
            prod.ProductID = this.id;
            prod.Price = this.price;
            prod.Quantity = this.quantity;
            //call base add function from product helper class
            service.addProduct(prod);
            MessageBox.Show("product Added");
        }
        //function to enable/disable add button
        public bool canAdd(object obj)
        {
            if (string.IsNullOrEmpty(name) || string.IsNullOrEmpty(id))
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        //function to store products into list
        public void display(object obj)
        {
            list = service.getAllProducts();

        }
        //function to enable/disable display button
        public bool canDisplay(object obj)
        {
            list = service.getAllProducts();
            if (list.Count <= 0)
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
