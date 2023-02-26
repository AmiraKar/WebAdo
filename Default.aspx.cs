using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Web.Configuration;

namespace WebAdo
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Response.Write("<center><h1>Read data from a database</h1></center><hr/>");
            Response.Write("<br/>");
            //Step 1 Read connection string
            string s = ConfigurationManager.ConnectionStrings["MyDB"].ConnectionString;

            //Step2 - create a sqlconnection
            SqlConnection con= new SqlConnection(s);

            //Set up query string
            string sqlString = "select * from customers";

            //Set sql command object
            SqlCommand cmd=new SqlCommand(sqlString, con);

            //Open the connection
            con.Open();

            //Excecute the command

            //Use cmd.ExecuteReader() for SELECT statement.

            //Use cmd.ExecuteScalar for return of count or single numbers.
            SqlDataReader dr= cmd.ExecuteReader();

            //Use cmd.ExecuteNonQuery() for INSERT,UPDATE,DELETE.

            //Setup datasource for GridView
            GridView1.DataSource = dr;

            //Bind datasource to GridView
            GridView1.DataBind();

            //Close datareader
            dr.Close();

            //close the connection
            con.Close();
            

        }
    }
}