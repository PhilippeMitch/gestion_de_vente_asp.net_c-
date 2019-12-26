using System;
using System.Collections.Generic;
using System.Linq;
using ValerioWeb.Domaine;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace ValerioWeb.DAL
{
    public class categorieDal
    {
        public static int Enrefistrer_categorie(categorie cat,TraceSystem tr)
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
                    cmd.CommandText = "insert into Categorie values(@id,@nom,@date,@id_de,@active)";
                    cmd.Parameters.AddWithValue("@id", cat.Id_categorie);
                    cmd.Parameters.AddWithValue("@nom", cat.Nom_categorie);
                    cmd.Parameters.AddWithValue("@date", cat.Date_enregistrement);
                    cmd.Parameters.AddWithValue("@id_de", cat.Id_depot);
                    cmd.Parameters.AddWithValue("@active", cat.Active);
                    cmd.ExecuteNonQuery();

                    cmd1.CommandText = "insert into Trace_User values(@id_act,@descritpion_act,@date_act,@id_user)";
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
        public static categorie Rechercher_categorie(string nom)
        {
            categorie cat = null;
            SqlConnection con = null;
            SqlCommand cmd = null;
            SqlDataReader rd = null;
            try
            {
                con = new SqlConnection(Properties.Settings.Default.ValerioDB_Connect);
                string req = "select * from Categorie where (Nom_categorie=@num and Active=@active) ";
                con.Open();
                cmd = new SqlCommand(req, con);
                cmd.Parameters.AddWithValue("@num", nom);
                cmd.Parameters.AddWithValue("@active", 1);
                rd = cmd.ExecuteReader();
                while (rd.Read())
                {
                    cat = new categorie(rd.GetInt32(0), rd.GetString(1), rd.GetString(2), rd.GetInt32(3));
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
            return cat;
        }
        public static categorie Rechercher_categorie_Id(int num)
        {
            categorie cat = null;
            SqlConnection con = null;
            SqlCommand cmd = null;
            SqlDataReader rd = null;
            try
            {
                con = new SqlConnection(Properties.Settings.Default.ValerioDB_Connect);
                string req = "select * from Categorie where (Id_categorie=@num) ";
                con.Open();
                cmd = new SqlCommand(req, con);
                cmd.Parameters.AddWithValue("@num", num);
                rd = cmd.ExecuteReader();
                while (rd.Read())
                {
                    cat = new categorie(rd.GetInt32(0), rd.GetString(1), rd.GetString(2), rd.GetInt32(3));
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
            return cat;
        }
        public static int Modifier_categorie(categorie cat,TraceSystem tr,int id)
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
                    cmd.CommandText = "update Categorie set Nom_categorie=@nom, Date_enregistrement=@date, Id_depot=@id_de where(Id_categorie=@id)";
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.Parameters.AddWithValue("@nom", cat.Nom_categorie);
                    cmd.Parameters.AddWithValue("@date", cat.Date_enregistrement);
                    cmd.Parameters.AddWithValue("@id_de", cat.Id_depot);
                    cmd.Parameters.AddWithValue("@active",1);
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
