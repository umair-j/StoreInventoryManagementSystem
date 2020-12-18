using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;
using Microsoft.Data.SqlClient;

namespace assignment2EAD.Model
{
    //helper class for product class 
    class productService
    {
        //list of products
        public ObservableCollection<product> productList;
        //default constructor
        public productService()
        {
            //initializing list
            productList = new ObservableCollection<product>();
            //loading data from db into productlist
            load();
            }
        public void addProduct(product p)
        {
            //setting up connection with database
            string connString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=DB;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            SqlConnection con = new SqlConnection(connString);
            
            string query = $"INSERT INTO PRODUCT(ID,NAME,PRICE,QUANTITY) VALUES('{p.ProductID}','{p.ProductName}','{p.Price}','{p.Quantity}')";
            SqlCommand cmd = new SqlCommand(query, con);
            //opening connection
            con.Open();
            cmd.ExecuteNonQuery();
            //adding product object to list
            productList.Add(p);
        }
        public bool deleteProduct(product p)
        {
            //setting up connection with database
            string connString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=DB;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            SqlConnection con = new SqlConnection(connString);
            //initializing database query
            string query = $"DELETE FROM PRODUCT WHERE ID = '{p.ProductID}'";
            SqlCommand cmd = new SqlCommand(query, con);
            //opening connection
            con.Open();
            cmd.ExecuteNonQuery();
            //removing object from list
            bool success = productList.Remove(p);
            return success;
        }
        public ObservableCollection<product> getAllProducts()
        {
            //load();
            return productList;
        }
        public void load()
        {
            //setting up connection with database
            string connString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=DB;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            SqlConnection con = new SqlConnection(connString);
            //opening connection
            con.Open();
            //initializing query
            string query = "SELECT * FROM PRODUCT";
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataReader dr = cmd.ExecuteReader();
            //storing all data from database to list
            while (dr.Read())
            {
                product p = new product();
                p.ProductID = dr.GetValue(0) as string;
                p.ProductName = dr.GetValue(1) as string;
                p.Price = System.Convert.ToInt32(dr.GetValue(2));
                p.Quantity = System.Convert.ToInt32(dr.GetValue(3));
                productList.Add(p);
            }
            //closing connection
            con.Close();
        }
        public void updateProduct(product p)
        {
            //setting up connection with database
            string connString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=DB;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            SqlConnection con = new SqlConnection(connString);
            //initializing database query
            string query = $"UPDATE PRODUCT SET QUANTITY ='{p.Quantity}' WHERE ID = '{p.ProductID}' AND NAME = '{p.ProductName}'";
            SqlCommand cmd = new SqlCommand(query, con);
            //opening connection
            con.Open();
            //executing query
            cmd.ExecuteNonQuery();
            
            
        }
    }
}
