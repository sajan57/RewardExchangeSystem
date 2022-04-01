using RewardExchangeSystem.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RewardExchangeSystem.Controllers
{
    public class ProductController : Controller
    {
        // GET: Product
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public List<Product>GetProducts()
        {
            List<Product> list = new List<Product>();
            string connectionStr = ConfigurationManager.ConnectionStrings["dbconnection"].ConnectionString;
            using (SqlConnection conn = new SqlConnection(connectionStr))
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.CommandText = "select * from Product";
                    cmd.CommandType = System.Data.CommandType.Text;
                    cmd.Connection = conn;

                    conn.Open();

                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            Product product = new Product();
                            product.Id = Convert.ToInt32(reader["Id"]);
                            product.ProductName = reader["ProductName"].ToString();

                            list.Add(product);
                        }
                    }
                    return list;

                }
            }
        }
        [HttpGet]
        public JsonResult getproduct ()
        {
            return Json(GetProducts(), JsonRequestBehavior.AllowGet);
        }
        [HttpGet]
        public JsonResult GetProductDetails(int id)
        {
            return Json(GetProductsByID(id), JsonRequestBehavior.AllowGet);
        }

        private Product GetProductsByID(int id)
        {
            Product pro = new Product();
            string connectionStr = ConfigurationManager.ConnectionStrings["dbconnection"].ConnectionString;
            using (SqlConnection conn = new SqlConnection(connectionStr))
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.CommandText = "select * from Product where Id= @Id ";
                    cmd.CommandType = System.Data.CommandType.Text;
                    cmd.Connection = conn;
                    cmd.Parameters.AddWithValue("@Id", id);
                    conn.Open();

                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                    
                            pro.Id = Convert.ToInt32(reader["Id"]);
                            pro.ProductName = reader["ProductName"].ToString();
                            pro.ProductPoints = Convert.ToInt32(reader["ProductPoints"]);
                            
                        }
                    }
                    return pro;

                }
            }
        }
    }
  


}
