using assignment2EAD.commands;
using assignment2EAD.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace assignment2EAD.ViewModel
{
    class productDisplayViewModel
    {
        public DelegateCommand showProductCommand { get; set; }
        productService service { get; set; }
        public ObservableCollection<product> list { get; set; }
        public productDisplayViewModel()
        {
            service = new productService();

            list = service.getAllProducts();
            showProductCommand = new DelegateCommand(display, canDisplay);
        }
        public void display(object obj)
        {
            //list = service.getAllProducts();

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
