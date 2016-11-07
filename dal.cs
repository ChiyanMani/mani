using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Data.Sql;
using System.Web.Mvc;
using Addsample.Models;

namespace Addsample.Models
{
    public class dal
    {
        string connection = "Data source=Web-Server\\SQLEXPRESS;initial catalog=Freshers; uid=fresher;pwd=fresher;";
        SqlConnection conn = null;
        SqlCommand cmd = null;      
           
    
        public string save(Class1 obj1)
        {
           
            using (conn = new SqlConnection(connection)) 
            {
                conn.Open();
                conn.CreateCommand();
               // List<Class1> ojset = new List<Class1>();
                using (cmd = new SqlCommand("sp_demoaddd", conn))
               
                {

                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("name",obj1.name));
                    cmd.Parameters.Add(new SqlParameter("age", obj1.age));
                    cmd.Parameters.Add(new SqlParameter("id", obj1.id));
                    cmd.Parameters.Add(new SqlParameter("place", obj1.place));
                    cmd.Parameters.Add(new SqlParameter("country", obj1.country));
                    cmd.ExecuteNonQuery();
                }
                return "";
            }
        }
    }
}