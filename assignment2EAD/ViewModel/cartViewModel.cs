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

    class cartViewModel
    {
        //helper class object for product class declared
        public productService service { get; set; }
        //total and current list declared
        public ObservableCollection<product> totalList { get; set; }
        public ObservableCollection<product> addedList { get; set; }
        //item id and quantity properties declared
        public string itemID { get; set; }
        public int itemQuantity { get; set; }
        //add and finish commands declared
        public DelegateCommand addCommand { get; set; }
        public DelegateCommand finishCommand { get; set; }
        
        //default constructor
        public cartViewModel()
        {
            
            service = new productService();
            totalList = service.getAllProducts();
            addedList = new ObservableCollection<product>();
            addCommand = new DelegateCommand(add,canAdd);
            finishCommand = new DelegateCommand(finish,canFinish);
        }
        //function to enable/disable finish button 
        public bool canFinish(object obj)
        {
            bool allow = default;
            //check if any products are added to cart
            if (addedList.Count > 0)
            {
                allow = true;
            }
            else
            {
                allow = false;
            }
            return allow;
        }
        //function to call after finish button is clicked
        public void finish(object obj)
        {   
            foreach(product p in addedList)
            {
                totalBill += p.Price * p.Quantity;
            }
        }
        //function to enable/disable add button
        public bool canAdd(object obj)
        {
            bool allow = default;
            //check if textboxes are empty or not
            if(string.IsNullOrEmpty(itemID) || itemQuantity<=0)
            {
                allow = false;
            }
            else
            {
                allow = true;
            }
            return allow;
        }
        //function to add product to list
        public void add(object obj)
        {
            totalList = service.getAllProducts();
            foreach(product p in totalList)
            { 
                bool ret = false;
                //check if quantity in inventory is enough to be added
                if (p.ProductID == itemID && p.Quantity >= itemQuantity)
                {
                    foreach (product z in addedList)
                    {
                        if (z.ProductID.Equals(itemID))
                        {
                            MessageBox.Show("Item already added");
                            ret = true;
                        }
                    }
                    if (ret == false)
                    {
                        p.Quantity = p.Quantity - itemQuantity;
                        //update to database
                        service.updateProduct(p);
                        product q = new product();
                        q = p;
                        q.Quantity = itemQuantity;
                        //add bought product to list
                        addedList.Add(q);
                        totalBill += q.Price * q.Quantity;
                        itemID = "";

                    }
                }
            }
        }
        public int totalBill { get; set; }
    }
}
