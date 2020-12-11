using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;

namespace assignment2EAD.Model
{
    class productService
    {
        public ObservableCollection<product> productList;
        public productService()
        {
            productList = new ObservableCollection<product>() {
            new product { ProductName="chair", ProductID = "4E", Price=2000, Quantity=4}
        };
            }
        public void addProduct(product p)
        {
            productList.Add(p);
        }
        public bool deleteProduct(product p)
        {
            bool success = productList.Remove(p);
            return success;
        }
        public ObservableCollection<product> getAllProducts()
        {
            return productList;
        }
    }
}
