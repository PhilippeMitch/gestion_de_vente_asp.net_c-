using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ValerioWeb.Domaine;

namespace ValerioWeb.DAL
{
    public class TraceSystemDal
    {
        public static int Enregistrer_Trace(TraceSystem tr)
        {
            int result = 0;
            SqlCommand cmd = null;
            SqlConnection con = null;
            try
            {
                con = new SqlConnection(Properties.Settings.Default.ValerioDB_Connect);
                con.Open();
                string req = "insert into Trace_User values(@id_act,@descritpion_act,@date_act,@id_user)";
                con.Open();
                cmd = new SqlCommand(req, con);
                cmd.Parameters.AddWithValue("@id_act", tr.Id_trace);
                cmd.Parameters.AddWithValue("@descritpion_act", tr.Description);
                cmd.Parameters.AddWithValue("@date_act", tr.Date_act);
                cmd.Parameters.AddWithValue("@id_user", tr.Id_user);
                cmd.ExecuteNonQuery();
                result = 1;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                if (con != null) { con.Close();}
            }
            return result;
        }
    }
}
