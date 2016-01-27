using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Data.SqlClient;
using ProductsApp.Models;
using System.Data;

namespace ProductsApp.Controllers
{
    public class UserController : ApiController
    {
        User[] users = new User[]
        {
            new User { Id = 1, UserName = "Nitin", Password="Newuser@123"},
            new User { Id = 2, UserName = "Prasanna", Password="Newuser@123"},
            new User { Id = 3, UserName = "Ejaz", Password="Newuser@123"},
            new User {Id=4,UserName="Gaurav",Password="Newuser@123" }
        };
        public IEnumerable<User> GetAllUser()
        {
            return users;
        }

        public IHttpActionResult GetUser(string userName,string passWord)
        {
            SqlDataReader reader = null;
            SqlConnection myConnection = new SqlConnection();
            //myConnection.ConnectionString = @"Server=WSD001\SQLEXPRESS;Database=Nitin;User ID=rsinngp/nitin.vaswani;Password=Newuser@123;";
            myConnection.ConnectionString = @"Data Source = WSD001\SQLEXPRESS;Initial Catalog = Nitin;Integrated Security = True";
            SqlCommand sqlCmd = new SqlCommand();
            sqlCmd.CommandType = CommandType.Text;
            sqlCmd.CommandText = string.Format("Select * from [User] where UserName='{0}' and password='{1}'", userName, passWord);
            sqlCmd.Connection = myConnection;
            myConnection.Open();
            reader = sqlCmd.ExecuteReader();
            User emp = null;
            while (reader.Read())
            {
                emp = new User();
                emp.Id = Convert.ToInt32(reader.GetValue(0));
                emp.UserName = reader.GetValue(1).ToString();
                emp.Password = reader.GetValue(2).ToString();
            }
            myConnection.Close();
            if (emp != null) { 
            return Ok(emp);
            }
            else
            {
                return NotFound();
            }
        }
        [HttpGet]
        [ActionName("GetEmployeeByID")]
        public User Get(int id=2)
        {
            SqlDataReader reader = null;
            SqlConnection myConnection = new SqlConnection();
            //myConnection.ConnectionString = @"Server=WSD001\SQLEXPRESS;Database=Nitin;User ID=rsinngp/nitin.vaswani;Password=Newuser@123;";
            myConnection.ConnectionString = @"Data Source = WSD001\SQLEXPRESS;Initial Catalog = Nitin;Integrated Security = True";
            SqlCommand sqlCmd = new SqlCommand();
            sqlCmd.CommandType = CommandType.Text;
            sqlCmd.CommandText = "Select * from User where UserId=" + id + "";
            sqlCmd.Connection = myConnection;
            myConnection.Open();
            reader = sqlCmd.ExecuteReader();
            User emp = null;
            while (reader.Read())
            {
                emp = new User();
                emp.Id = Convert.ToInt32(reader.GetValue(0));
                emp.UserName = reader.GetValue(1).ToString();
                emp.Password = reader.GetValue(2).ToString();
            }
            myConnection.Close();
            return emp;
           
        }
    }
}