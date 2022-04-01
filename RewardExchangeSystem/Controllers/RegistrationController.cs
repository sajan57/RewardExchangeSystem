using RewardExchangeSystem.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;
using System.Web.UI.WebControls;
using System.Configuration;

namespace RewardExchangeSystem.Controllers
{
    public class RegistrationController : Controller
    {
        // GET: Registration


        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Registration()
        {
            return View();
        }
        [HttpPost]
        public void InsertRecord(Registration rr)
        {



            string connectionStr = ConfigurationManager.ConnectionStrings["dbconnection"].ConnectionString; 
            SqlConnection sqlconn = new SqlConnection(connectionStr);
            SqlCommand cmd = new SqlCommand("InsertData", sqlconn);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@FirstName", rr.FirstName);
                cmd.Parameters.AddWithValue("@LastName", rr.LastName);
                cmd.Parameters.AddWithValue("@Address", rr.Address);
                cmd.Parameters.AddWithValue("@DateOfBirth", rr.DateOfBirth);
                cmd.Parameters.AddWithValue("@UserName", rr.UserName);
                cmd.Parameters.AddWithValue("@Password", rr.Password);
            if (ConnectionState.Closed == sqlconn.State)
            {
                sqlconn.Open();
            }

            cmd.ExecuteNonQuery();
            sqlconn.Close();

        }
        [HttpGet]
        public List<Registration>GetAllData()
        {
            List<Registration> list = new List<Registration>();
            string connectionStr = ConfigurationManager.ConnectionStrings["dbconnection"].ConnectionString;

            SqlConnection sqlconn = new SqlConnection(connectionStr);
            SqlCommand cmd = new SqlCommand("SelectData",sqlconn);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            if (ConnectionState.Closed == sqlconn.State)
            {
                sqlconn.Open();
            }
            SqlDataReader dr = cmd.ExecuteReader();
            while(dr.Read())
            {
                Registration registration = new Registration();
                registration.Id = Convert.ToInt32(dr["Id"]);
                registration.FirstName = dr["FirstName"].ToString();
                registration.LastName = dr["LastName"].ToString();
                registration.Address = dr["Address"].ToString();
                registration.DateOfBirth = Convert.ToDateTime(dr["DateOfBirth"].ToString());
                registration.UserName = dr["UserName"].ToString();
                registration.Password = dr["Password"].ToString();
              

                list.Add(registration);
            }
            sqlconn.Close();
            return list;

        }
        //for select data or GetAllData controller
        public JsonResult getlist()
        {
            return Json(GetAllData(), JsonRequestBehavior.AllowGet);
        }



        // for Login
        [HttpPost]
        public ActionResult Login (LoginClass login)
        {
            string connectionStr = ConfigurationManager.ConnectionStrings["dbconnection"].ConnectionString;

            SqlConnection sqlconn = new SqlConnection(connectionStr);
            string sqlquery = "select UserName, Password from dbo.Registration where UserName = @UserName and Password = @Password";
            sqlconn.Open();
            SqlCommand sqlcomm = new SqlCommand(sqlquery, sqlconn);
            sqlcomm.Parameters.AddWithValue("@UserName", login.UserName);
            sqlcomm.Parameters.AddWithValue("@Password", login.Password);
            SqlDataReader sdr = sqlcomm.ExecuteReader();
            if (sdr.Read())
            {
                Session["UserName"] = login.UserName.ToString();
                return RedirectToAction("RewardPage");
            }
            else
            {
                ViewData["Message"] = "Login Failed !";
            }
            sqlconn.Close();
            return View();
        }

        public ActionResult Login()
        {
            return View();
        }
        public ActionResult RewardPage()
        {
            return View();
        }


        //for DeleteData
        public JsonResult DeleteRecord(int Id)
        {

            string connectionStr = ConfigurationManager.ConnectionStrings["dbconnection"].ConnectionString;

            SqlConnection sqlconn = new SqlConnection(connectionStr);
            SqlCommand cmd = new SqlCommand("DeleteData", sqlconn);
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

        public void UpdateRecord(Registration rr)
        {



            string connectionStr = ConfigurationManager.ConnectionStrings["dbconnection"].ConnectionString;
            SqlConnection sqlconn = new SqlConnection(connectionStr);
            SqlCommand cmd = new SqlCommand("UpdateData", sqlconn);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@FirstName", rr.FirstName);
            cmd.Parameters.AddWithValue("@LastName", rr.LastName);
            cmd.Parameters.AddWithValue("@Address", rr.Address);
            cmd.Parameters.AddWithValue("@DateOfBirth", rr.DateOfBirth);
            cmd.Parameters.AddWithValue("@UserName", rr.UserName);
            cmd.Parameters.AddWithValue("@Password", rr.Password);
            if (ConnectionState.Closed == sqlconn.State)
            {
                sqlconn.Open();
            }

            cmd.ExecuteNonQuery();
            sqlconn.Close();

        }

    }
    
}