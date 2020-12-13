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
        public productService service { get; set; }
        public ObservableCollection<product> totalList { get; set; }
        public ObservableCollection<product> addedList { get; set; }
        public string itemID { get; set; }
        public int itemQuantity { get; set; }
        public DelegateCommand addCommand { get; set; }
        public DelegateCommand finishCommand { get; set; }
        

        public cartViewModel()
        {
            service = new productService();
            totalList = service.getAllProducts();
            addedList = new ObservableCollection<product>();
            addCommand = new DelegateCommand(add,canAdd);
            finishCommand = new DelegateCommand(finish,canFinish);
        }

        public bool canFinish(object obj)
        {
            bool allow = default;
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

        public void finish(object obj)
        {
            ObservableCollection<product> list = new ObservableCollection<product>();
            foreach(product p in totalList)
            {
                foreach(product q in addedList)
                {
                    if(q == p)
                    {
                        p.Quantity -= q.Quantity;
                        if (p.Quantity > 0)
                        {
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

        public bool canAdd(object obj)
        {
            bool allow = default;
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

        public void add(object obj)
        {
            foreach(product p in totalList)
            {
                if(p.ProductID==itemID && p.Quantity >= itemQuantity)
                {
                    //p.Quantity -= itemQuantity;
                    addedList.Add(p);
                }
            }
        }
    }
}
