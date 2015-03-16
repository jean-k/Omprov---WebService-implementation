using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.Services;
using The_web_app;

namespace The_web_app
{
    /// <summary>
    /// This service writes and read data to the database
    /// </summary>
    [WebService(Namespace = "Arbetsprov_Atea_Jean_Kam_2015")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    [System.Web.Script.Services.ScriptService]
    public class MessageService : System.Web.Services.WebService
    {
        string connectionStringPath = @"Data Source=(LocalDB)\v11.0;AttachDbFilename='C:\Users\Jean\Documents\Visual Studio 2013\Projects\Arbetsprov\The web app\App_Data\MessageDB.mdf';Integrated Security=True";
        [WebMethod]
        //Sparar meddelandet till databasen
        //Används av konsoll applikationen, return siffran används för att kontrollera att det har gått att spara meddelandet i databasen
        public int SaveMessage(string msg, DateTime date)
        {
            int row = 0;
            try
            {
                using (SqlConnection con = new SqlConnection(connectionStringPath))
                {
                    string query = "INSERT INTO tblMessage(Message,Date) VALUES(@msg, @date)";
                    con.Open();
                    var cmd = new SqlCommand(query, con);
                    cmd.Parameters.Add("@msg", SqlDbType.NVarChar).Value = msg;
                    cmd.Parameters.Add("@date", SqlDbType.DateTime).Value = date;
                    row = cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return row;
        }
        //Hämtar alla meddelanden från databasen
        //Används av hemsidan
        public DataTable GetAllMessages()
        {
            DataTable dt = new DataTable();
            try
            {
                using (SqlConnection con = new SqlConnection(connectionStringPath))
                {
                    string query = "SELECT Message, Date FROM tblMessage";
                    con.Open();
                    var cmd = new SqlCommand(query, con);
                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    {
                        da.Fill(dt);
                    }
                }
            }
            catch (Exception ex)
            {
                Context.Response.Write("<script language=javascript>alert('" + ex.Message + "');</script>");
            }
            return dt;
        }
    }
}
