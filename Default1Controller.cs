using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;
using System.Data.SqlClient;
using Addsample.Models;

namespace Addsample.Controllers
{
    public class Default1Controller : Controller
    {
        string connection = "Data Source=WEB-SERVER\\SQLEXPRESS;Initial Catalog=Freshers;Persist Security Info=True;User ID=fresher;password=fresher;";
        
        SqlConnection con = null;
        SqlCommand cmd = null;


        public ActionResult Index()
        {

            var list = Bag();
            ViewBag.list = new SelectList(list.AsEnumerable(), "", "country");// country class name

            return View();
        }
        public ActionResult Imagegrid()
        {

            return View();
        }

        public ActionResult monthhgrid()
        {

            return View();
        }
        public List<Class1> Bag()
        {
            List<Class1> list = new List<Class1>();
            using (con = new SqlConnection(connection))
            {
                con.Open();
                con.CreateCommand();
                using (cmd = new SqlCommand("sp_dbcyt", con))
                {
                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        Class1 h = new Class1();
                        h.country = Convert.ToString(dr["city"]);
                        list.Add(h);
                    }
                    dr.Close();
                }
                return list;
            }
        }


        //public byte[] orgretrieveimage(int id)
        //{
        //    IDataReader reader;
        //    Class1 ggg;
        //    List<Class1> list = new List<Class1>();
            
        //    using (con = new SqlConnection(connection))
        //    {
        //        con.Open();
        //        con.CreateCommand();
        //        using (cmd = new SqlCommand("sp_orgViewimage", con))
        //        {
        //            cmd.CommandType = CommandType.StoredProcedure;
        //            cmd.Parameters.Add(new SqlParameter("employeeID", id));
        //            reader = cmd.ExecuteReader();
        //            while (reader.Read())
        //            {
        //                ggg = new Class1();

        //                 image = (byte[])reader["Empimage"];
                       
        //            }
        //            reader.Close();
        //            return image;
        //        }
            
        //    }
        //}
   
        public ActionResult grid()
        {
            return View();
        }


        public JsonResult save(List<Class1> obj1)
        {
            Class1 obj = new Class1();
            var hhh = jjj(obj1);

            return Json(new { success = 1 });

                    }


        public string jjj(List<Class1> kkk)
        {
           
            Class1 objset = new Class1();
         //   foreach (IEnumerable<Class1> bbb in kkk)
           // {
            foreach (Class1 list in kkk)
                {
                    objset.name = list.name;
                    objset.age = list.age;
                    objset.id = list.id;
                    objset.place = list.place;
                    objset.country = list.country;
                    Service1 k = new Service1();
                    var auto = k.save(objset);
                }

         //   }
            return "";

        }
        

        


        public ActionResult mygrid()
        {

            Class1 obj = new Class1();
            var sa = main();
            var result = from d in sa select new[] { d.name, d.age.ToString(), d.id.ToString(), d.place, d.country,"../../Content/trash_open.png" };
            return Json(new

                {
                    aaData = result
                },
                JsonRequestBehavior.AllowGet);




        }
        public List<Class1> main()
        {
            using (con = new SqlConnection(connection))
            {
                con.Open();
                con.CreateCommand();
                List<Class1> obj = new List<Class1>();
                using (cmd = new SqlCommand("sp_griddemoadd", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        Class1 obj1 = new Class1();
                        obj1.name = Convert.ToString(dr["name"]);
                        obj1.age = Convert.ToInt64(dr["age"]);
                        obj1.id = Convert.ToInt64(dr["id"]);
                        obj1.place = Convert.ToString(dr["place"]);
                        obj1.country = Convert.ToString(dr["country"]);

                        obj.Add(obj1);

                    }
                    dr.Close();

                }
                return obj;
            }
        }


        public ActionResult auto(string searchresult)
        {
            var d = from c in autocomp(searchresult) select new { label = c.place };
            return this.Json(d, JsonRequestBehavior.AllowGet);
        }

        public List<Class1> autocomp(string searchresult)
        {
            List<Class1> maa = new List<Class1>();
            using (con = new SqlConnection(connection))
            {
                con.Open();
                con.CreateCommand();

                using (cmd = new SqlCommand("sp_autoadd", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@place", searchresult));
                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        Class1 obj = new Class1();
                        obj.place = Convert.ToString(dr["place"]);
                        maa.Add(obj);
                    }
                    dr.Close();
                    return maa;
                }
            }
        }

        public string delete(int id) {

            Class1 sss = new Class1();
            sss.id = id;
            using (con = new SqlConnection(connection)) {
                con.Open();
                con.CreateCommand();
                using (cmd = new SqlCommand("Adddelete", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@id", sss.id));
                    cmd.ExecuteNonQuery();
                }
                return "";
            }
        }


     

 

   
   

       




    }
}