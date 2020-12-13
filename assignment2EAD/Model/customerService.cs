using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace assignment2EAD.Model
{
    //helper class that contains customer class related functions
    class customerService
    {
        //list of all customers
        public ObservableCollection<customer> customerList { get; set; }
        //method to return list of all customers
        public ObservableCollection<customer> getAllCustomers()
        {
            //load();
            return customerList;
        }
        //default constructor
        public customerService()
        {   
            customerList = new ObservableCollection<customer>();
            //function to load data from database
            load();
        }
        public void addCustomer(customer c)
        {
            //setting up connection with database
            string connString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=DB;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            SqlConnection con = new SqlConnection(connString);
            con.Open();
            string query = $"INSERT INTO CUSTOMER(PHONE,NAME,PASSWORD) VALUES('{c.Phonenumber}','{c.Username}','{c.Password}')";
            SqlCommand cmd = new SqlCommand(query, con);
            //executing query
            cmd.ExecuteNonQuery();
            //adding customer object to list of all customers
            customerList.Add(c);
        }
         public void load()
         {
            //setting up connection with database
             string connString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=DB;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
             SqlConnection con = new SqlConnection(connString);
             con.Open();
            //initializing query for database
             string query = "SELECT * FROM CUSTOMER";
             SqlCommand cmd = new SqlCommand(query, con);
             SqlDataReader dr = cmd.ExecuteReader();
            //loop to get all values from database to list 
            while (dr.Read())
             {
                 customer c = new customer();
                 c.Username = dr.GetValue(2) as string;
                 c.Password = dr.GetValue(1) as string;
                 c.Phonenumber= (long)dr.GetValue(0);

                 customerList.Add(c);
             }
            //closing connection
             con.Close();
         }
        
    }
}
