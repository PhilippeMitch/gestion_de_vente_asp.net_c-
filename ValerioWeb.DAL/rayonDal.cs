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
    public class rayonDal
    {
        public static int Enregistrer_Rayon(rayon ray,TraceSystem tr)
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
                    cmd.CommandText = "insert into Rayon values(@id,@nom,@date,@id_ca,@active)";
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.AddWithValue("@id", ray.Id_rayon);
                    cmd.Parameters.AddWithValue("@nom", ray.Nom_rayon);
                    cmd.Parameters.AddWithValue("@date", ray.Date_enregistrement);
                    cmd.Parameters.AddWithValue("@id_ca", ray.Id_categorie);
                    cmd.Parameters.AddWithValue("@active", ray.Active);
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
        public static rayon Rechercher_Rayon(string nom)
        {
            rayon ray = null;
            SqlConnection con = null;
            SqlCommand cmd = null;
            SqlDataReader rd = null;
            try
            {
                con = new SqlConnection(Properties.Settings.Default.ValerioDB_Connect);
                string req = "select * from Rayon where (Nom_rayon=@num and Active=@active) ";
                con.Open();
                cmd = new SqlCommand(req, con);
                cmd.Parameters.AddWithValue("@num", nom);
                cmd.Parameters.AddWithValue("@active", 1);
                rd = cmd.ExecuteReader();
                while (rd.Read())
                {
                    ray = new rayon(rd.GetInt32(0), rd.GetString(1), rd.GetString(2),rd.GetInt32(3));
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                if (con!= null) { con.Close(); }
            }
            return ray;
        }
        public static int Modifier_Rayon(rayon ray, TraceSystem tr,int id)
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
                    cmd.CommandText = "Update Rayon Set Nom_rayo=@nom,Date_enregistrement=@date,Id_categorie=@id_ca where Id_rayo=@id";
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.Parameters.AddWithValue("@nom", ray.Nom_rayon);
                    cmd.Parameters.AddWithValue("@date", ray.Date_enregistrement);
                    cmd.Parameters.AddWithValue("@id_ca", ray.Id_categorie);
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
