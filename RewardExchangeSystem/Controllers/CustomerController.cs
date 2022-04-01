using RewardExchangeSystem.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RewardExchangeSystem.Controllers
{
    public class CustomerController : Controller
    {
        // GET: Customer
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public void AddCustomer(Customer customer)
        {
            if (ModelState.IsValid)
            {
                string connectionStr = ConfigurationManager.ConnectionStrings["dbconnection"].ConnectionString;
                SqlConnection sqlconn = new SqlConnection(connectionStr);
                SqlCommand cmd = new SqlCommand("proc_Customer", sqlconn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@CustomerName", customer.CustomerName);
                cmd.Parameters.AddWithValue("@CustomerAddress", customer.CustomerAddress);
                cmd.Parameters.AddWithValue("@Contact", customer.Contact);
                cmd.Parameters.AddWithValue("@Quantity", customer.Quantity);
                cmd.Parameters.AddWithValue("@TotalPoints", customer.TotalPoints);
                cmd.Parameters.AddWithValue("@RemaningPoint", customer.RemaningPoint);

                if (ConnectionState.Closed == sqlconn.State)
                {
                    sqlconn.Open();
                }

                cmd.ExecuteNonQuery();
                sqlconn.Close();
            }

        }
        [HttpPost]
        public List<Customer> GetAllData()
        {
            List<Customer> list = new List<Customer>();
            string connectionStr = ConfigurationManager.ConnectionStrings["dbconnection"].ConnectionString;

            SqlConnection sqlconn = new SqlConnection(connectionStr);
            SqlCommand cmd = new SqlCommand("SelectCustomer", sqlconn);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            if (ConnectionState.Closed == sqlconn.State)
            {
                sqlconn.Open();
            }
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                Customer customer = new Customer();
               customer.Id = Convert.ToInt32(dr["Id"]);
               customer.CustomerName = dr["CustomerName"].ToString();
               customer.CustomerAddress = dr["CustomerAddress"].ToString();
               customer.Contact = dr["Contact"].ToString();
               customer.Quantity = dr["Quantity"].ToString();
                customer.TotalPoints = dr["TotalPoints"].ToString();
               customer.RemaningPoint = dr["RemaningPoint"].ToString();


                list.Add(customer);
            }
            sqlconn.Close();
            return list;

        }
        public JsonResult getlist()
        {
            return Json(GetAllData(), JsonRequestBehavior.AllowGet);
        }

        //for DeleteData
        [HttpGet]
        public JsonResult DeleteRecord(int Id)
        {

            string connectionStr = ConfigurationManager.ConnectionStrings["dbconnection"].ConnectionString;

            SqlConnection sqlconn = new SqlConnection(connectionStr);
            SqlCommand cmd = new SqlCommand("DeleteCustomer", sqlconn);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@Id", Id);

            if (ConnectionState.Closed == sqlconn.State)
            {
                sqlconn.Open();
            }

            cmd.ExecuteNonQuery();
            sqlconn.Close();
            return Json("", JsonRequestBehavior.AllowGet);
        }

        public void UpdateCustomer(Customer customer)
        {
            if (ModelState.IsValid)
            {
                string connectionStr = ConfigurationManager.ConnectionStrings["dbconnection"].ConnectionString;
                SqlConnection sqlconn = new SqlConnection(connectionStr);
                SqlCommand cmd = new SqlCommand("proc_UpdateCustomer", sqlconn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Id", customer.Id);
                cmd.Parameters.AddWithValue("@CustomerName", customer.CustomerName);
                cmd.Parameters.AddWithValue("@CustomerAddress", customer.CustomerAddress);
                cmd.Parameters.AddWithValue("@Contact", customer.Contact);
                cmd.Parameters.AddWithValue("@Quantity", customer.Quantity);

                if (ConnectionState.Closed == sqlconn.State)
                {
                    sqlconn.Open();
                }

                cmd.ExecuteNonQuery();
                sqlconn.Close();
            }

        }
    }
}