using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;
using Microsoft.Data.SqlClient;

namespace assignment2EAD.Model
{
    class productService
    {
        
        public ObservableCollection<product> productList;
        public productService()
        {
            productList = new ObservableCollection<product>();
            load();
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
        public void load()
        {
            string connString = @"Data Source=(localdb)\ProjectsV13;Initial Catalog=MyDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            SqlConnection con = new SqlConnection(connString);
            con.Open();
            string query = "SELECT * FROM PRODUCTS";
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                product p = new product();
                p.ProductID = dr.GetValue(0) as string;
                p.ProductName = dr.GetValue(1) as string;
                p.Price = System.Convert.ToInt32(dr.GetValue(2));
                p.Quantity = System.Convert.ToInt32(dr.GetValue(3));
                productList.Add(p);
            }
            con.Close();
        }
    }
}
