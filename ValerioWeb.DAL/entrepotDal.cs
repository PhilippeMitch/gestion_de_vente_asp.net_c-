using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ValerioWeb.Domaine;
namespace ValerioWeb.DAL
{
    public class entrepotDal
    {
        public static int Enregistrer_Depot(entrepot dep,TraceSystem tr)
        {
            int result = 0;
            string con = Properties.Settings.Default.ValerioDB_Connect;
            using (SqlConnection connection = new SqlConnection(con))
            {
                connection.Open();
                SqlTransaction transaction = connection.BeginTransaction();
                SqlCommand cmd = connection.CreateCommand();
                SqlCommand cmd1 = connection.CreateCommand();
                cmd.Transaction = transaction;
                cmd1.Transaction = transaction;
                try
                {
                    cmd.CommandText = "insert into Depot values(@id,@date,@active,@nom)";
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.AddWithValue("@id", dep.Id_entrepot);
                    cmd.Parameters.AddWithValue("@nom", dep.Nom_entrepot);
                    cmd.Parameters.AddWithValue("@date", dep.Date_enregistrement);
                    cmd.Parameters.AddWithValue("@active",1);
                    cmd.ExecuteNonQuery();

                    cmd1.CommandText = "insert into Trace_User values(@id_act,@descritpion_act,@date_act,@id_user)";
                    cmd1.CommandType = CommandType.Text;
                    cmd1.Parameters.AddWithValue("@id_act", tr.Id_trace);
                    cmd1.Parameters.AddWithValue("@descritpion_act", tr.Description);
                    cmd1.Parameters.AddWithValue("@date_act", tr.Date_act);
                    cmd1.Parameters.AddWithValue("@id_user", tr.Nom_user);
                    cmd1.ExecuteNonQuery();

                    transaction.Commit();
                    result = 1;
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    throw new Exception(ex.Message);
                }
                finally
                {
                    if (connection != null) { connection.Close(); }
                }
            }
            return result;
        }
        public static entrepot Rechercher_entrepot(string nom)
        {
            entrepot dep = null;
            SqlConnection con = null;
            SqlCommand cmd = null;
            SqlDataReader rd = null;
            try
            {
                con = new SqlConnection(Properties.Settings.Default.ValerioDB_Connect);
                string req = "select * from Depot where (Nom_depot=@num and Active=@active) ";
                con.Open();
                cmd = new SqlCommand(req, con);
                cmd.Parameters.AddWithValue("@num", nom);
                cmd.Parameters.AddWithValue("@active", 1);
                rd = cmd.ExecuteReader();
                while (rd.Read())
                {
                    dep = new entrepot(rd.GetInt32(0), rd.GetString(3), rd.GetString(1));
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                if (con != null) { con.Close(); }
            }
            return dep;
        } 
        public static int Modifier_entrepot(entrepot dep,TraceSystem tr,int id)
        {
            int result = 0;
            string con = Properties.Settings.Default.ValerioDB_Connect;
            using (SqlConnection connection = new SqlConnection(con))
            {
                connection.Open();
                SqlTransaction transaction = connection.BeginTransaction();
                SqlCommand cmd = connection.CreateCommand();
                SqlCommand cmd1 = connection.CreateCommand();
                cmd.Transaction = transaction;
                cmd1.Transaction = transaction;
                try
                {
                    cmd.CommandText = "update Depot set Date_enregistrement=@date, Nom_depot=@nom where Id_depot=@id";
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.Parameters.AddWithValue("@nom", dep.Nom_entrepot);
                    cmd.Parameters.AddWithValue("@date", dep.Date_enregistrement);
                    cmd.ExecuteNonQuery();

                    cmd1.CommandText = "insert into Trace_User values(@id_act,@descritpion_act,@date_act,@id_user)";
                    cmd1.CommandType = CommandType.Text;
                    cmd1.Parameters.AddWithValue("@id_act", tr.Id_trace);
                    cmd1.Parameters.AddWithValue("@descritpion_act", tr.Description);
                    cmd1.Parameters.AddWithValue("@date_act", tr.Date_act);
                    cmd1.Parameters.AddWithValue("@id_user", tr.Id_user);
                    cmd1.ExecuteNonQuery();

                    transaction.Commit();
                    result = 1;
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    throw new Exception(ex.Message);
                }
                finally
                {
                    if (connection != null) { connection.Close(); }
                }
            }
            return result;
        }
    }
}
