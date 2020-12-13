using assignment2EAD.commands;
using assignment2EAD.Model;
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
            //initializing list
            ObservableCollection<product> list = new ObservableCollection<product>();
            foreach(product p in totalList)
            {
                foreach(product q in addedList)
                {
                    //checking if quantity is enough in inventory 
                    if(q == p)
                    {
                        
                        if (p.Quantity-q.Quantity > 0)
                        {
                            p.Quantity -= q.Quantity;
                            list.Add(q);
                        }
                    }
                }
            }
            foreach(product p in list)
            {

                MessageBox.Show(p.ProductName); 
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
            foreach(product p in totalList)
            {
                //check if quantity in inventory is enough to be added
                if(p.ProductID==itemID && p.Quantity >= itemQuantity)
                {
                    //p.Quantity -= itemQuantity;
                    //add to list
                    addedList.Add(p);
                }
            }
        }
    }
}
