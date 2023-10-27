using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.SqlClient;
using System.Data;
using Entwithproc00.Models;
using Newtonsoft.Json;

namespace Entwithproc00.Controllers
{
    public class EmployeeController : Controller
    {
        SqlConnection con = new SqlConnection("data source=RAHUL\\SQLEXPRESS;initial catalog=DB7906_02;integrated security=true");
        public ActionResult EmployeeForm()
        {
            return View();
        }

        public void EmployeeInsert(EmployeeModel obj)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("tblinsert", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@name",obj.Name);
            cmd.Parameters.AddWithValue("@gender", obj.Gender);
            cmd.Parameters.AddWithValue("@age", obj.Age);
            cmd.Parameters.AddWithValue("@salary", obj.Salary);
            cmd.Parameters.AddWithValue("@country", obj.Country);
            cmd.Parameters.AddWithValue("@state", obj.State);
            cmd.ExecuteNonQuery();
            con.Close();
        
        }


        public void EmployeeUpdate(EmployeeModel obj)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("tblupdate", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@id", obj.Id);
            cmd.Parameters.AddWithValue("@name", obj.Name);
            cmd.Parameters.AddWithValue("@gender", obj.Gender);
            cmd.Parameters.AddWithValue("@age", obj.Age);
            cmd.Parameters.AddWithValue("@salary", obj.Salary);
            cmd.Parameters.AddWithValue("@country", obj.Country);
            cmd.Parameters.AddWithValue("@state", obj.State);
            cmd.ExecuteNonQuery();
            con.Close();

        }

        public JsonResult EmployeeShow()
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("tblshow", con);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            con.Close();

            string data = JsonConvert.SerializeObject(dt);
            return Json(data, JsonRequestBehavior.AllowGet);
        }

        public JsonResult EmployeeCountry()
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("countrydata", con);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            con.Close();

            string data = JsonConvert.SerializeObject(dt);
            return Json(data, JsonRequestBehavior.AllowGet);
        }

        public JsonResult EmployeeState(int A)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("statedata", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@cid",A);
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            con.Close();

            string data = JsonConvert.SerializeObject(dt);
            return Json(data, JsonRequestBehavior.AllowGet);
        }


        public JsonResult EmployeeEdit(int A)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("tbledit", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@id", A);
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            con.Close();

            string data = JsonConvert.SerializeObject(dt);
            return Json(data, JsonRequestBehavior.AllowGet);
        }

        public void EmployeeDeletee(int A)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("tbldelete",con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@id",A);

            cmd.ExecuteNonQuery();
            con.Close();

        }
    }


}