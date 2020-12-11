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
        public DelegateCommand showProductCommand { get; set; }
        public DelegateCommand deleteProductCommand { get; set; }
        public adminMainViewModel()
        {
            service = new productService();

            list = service.getAllProducts();
            addProductCommand = new DelegateCommand(add, canAdd);
            showProductCommand = new DelegateCommand(display, canDisplay);
            deleteProductCommand = new DelegateCommand(delete,canDelete);
        }

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
        public product findstudent(string id)
        {
            product p = default;
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
        private void delete(object obj)
        {
            product p = null;
            p = findstudent(deleteId);
            if(p == null)
            {
                MessageBox.Show("Unable to remove product");
            }
            else
            {
                service.deleteProduct(p);
                MessageBox.Show("Removed");
            }
        }
        public string deleteId { get; set; }
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
            MessageBox.Show("product Added");
        }
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
        public void display(object obj)
        {
            list = service.getAllProducts();

        }
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
