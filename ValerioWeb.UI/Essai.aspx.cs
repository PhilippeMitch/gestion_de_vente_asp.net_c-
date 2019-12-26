using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ValerioWeb.UI
{
    public partial class Essai : System.Web.UI.Page
    {
        public enum MessageType { Success, Error, Info, Warning };


        protected void Page_Load(object sender, EventArgs e)

        {

            DataTable dt = new DataTable();

            String strConnString = System.Configuration.ConfigurationManager.

                ConnectionStrings["conString"].ConnectionString;

            string strQuery = "select ID, Name from tblFiles order by ID";

            SqlCommand cmd = new SqlCommand(strQuery);

            SqlConnection con = new SqlConnection(strConnString);

            SqlDataAdapter sda = new SqlDataAdapter();

            cmd.CommandType = CommandType.Text;

            cmd.Connection = con;

            try

            {

                con.Open();

                sda.SelectCommand = cmd;

                sda.Fill(dt);

                GridView1.DataSource = dt;

                GridView1.DataBind();
         
            }

            catch (Exception ex)

            {

                Response.Write(ex.Message);

            }

            finally

            {

                con.Close();

                sda.Dispose();

                con.Dispose();

                dt.Dispose();

            }

        }

        protected void btnUpload_Click(object sender, EventArgs e)

        {

            // Read the file and convert it to Byte Array

            string filePath = FileUpload1.PostedFile.FileName;

            string filename = Path.GetFileName(filePath);

            string ext = Path.GetExtension(filename);
            lblMessage.Text = filename;
        }
        protected void ShowMessage(string Message, MessageType type)
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), System.Guid.NewGuid().ToString(), "ShowMessage('" + Message + "','" + type + "');", true);
        }
        protected void btnSuccess_Click(object sender, EventArgs e)
        {
            ShowMessage("Record submitted successfully", MessageType.Success);
        }
        protected void btnDanger_Click(object sender, EventArgs e)
        {
            ShowMessage("A problem has occurred while submitting data", MessageType.Error);
        }
        protected void btnWarning_Click(object sender, EventArgs e)
        {
            ShowMessage("There was a problem with your internet connection", MessageType.Warning);
        }
        protected void btnInfo_Click(object sender, EventArgs e)
        {
            ShowMessage("Please verify your data before submitting", MessageType.Info);
        }

       
    }
}