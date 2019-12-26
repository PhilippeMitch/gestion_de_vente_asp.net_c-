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
    public class UtilisateurDal
    {
        public static int Enregistrer_User(Utilisateur user, TraceSystem tr)
        {
            #region
            string con = Properties.Settings.Default.ValerioDB_Connect;
            int result = 0;
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
                    #region commande 1 enregistrement Utilisateur
                    cmd.CommandText = "Enregistrer_Utilisateur";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@nom_user", user.Nom_user);
                    cmd.Parameters.AddWithValue("@pass_user", user.Pass);
                    cmd.Parameters.AddWithValue("@mail_user", user.E_mail);
                    cmd.Parameters.AddWithValue("@date_add", user.Date_add);
                    cmd.Parameters.AddWithValue("@active", user.Active);
                    cmd.Parameters.AddWithValue("@id_group", user.Id_group);
                    cmd.ExecuteNonQuery();
                    #endregion

                    #region commande 2 enregistrement transaction
                    cmd1.CommandText = "Enregistrer_trace";
                    cmd1.CommandType = CommandType.StoredProcedure;
                    cmd1.Parameters.AddWithValue("@id_trace", tr.Id_trace);
                    cmd1.Parameters.AddWithValue("@description", tr.Description);
                    cmd1.Parameters.AddWithValue("@date_act", tr.Date_act);
                    cmd1.Parameters.AddWithValue("@nom_user", tr.Nom_user);
                    cmd1.ExecuteNonQuery();
                    #endregion

                    transaction.Commit();
                    result = 1;
                }
                catch (Exception Ex)
                {
                    transaction.Rollback();
                    throw new Exception(Ex.Message);
                }
                finally
                {
                    connection.Close();
                }
                return result;
            }
            #endregion
        }       
        public static int Modifier_user(Utilisateur user,TraceSystem tr)
        {
            string con = Properties.Settings.Default.ValerioDB_Connect;
            int result = 0;
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
                    #region commande 1 enregistrement Utilisateur
                    cmd.CommandText = "Modifier_Utilisateur";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@nom_user", user.Nom_user);
                    cmd.Parameters.AddWithValue("@pass_user", user.Pass);
                    cmd.Parameters.AddWithValue("@mail_user", user.E_mail);
                    cmd.Parameters.AddWithValue("@date_add", user.Date_add);
                    cmd.Parameters.AddWithValue("@active", user.Active);
                    cmd.Parameters.AddWithValue("@id_group", user.Id_group);
                    cmd.ExecuteNonQuery();
                    #endregion

                    #region commande 2 enregistrement transaction
                    cmd1.CommandText = "Enregistrer_trace";
                    cmd1.CommandType = CommandType.StoredProcedure;
                    cmd1.Parameters.AddWithValue("@id_trace", tr.Id_trace);
                    cmd1.Parameters.AddWithValue("@description", tr.Description);
                    cmd1.Parameters.AddWithValue("@date_act", tr.Date_act);
                    cmd1.Parameters.AddWithValue("@nom_user", tr.Nom_user);
                    cmd1.ExecuteNonQuery();
                    #endregion

                    transaction.Commit();
                    result = 1;
                }
                catch (Exception Ex)
                {
                    transaction.Rollback();
                    throw new Exception(Ex.Message);
                }
                finally
                {
                    connection.Close();
                }
                return result;
            }
            }
        public static Utilisateur Rechercher_Utilisateur(string nom_user, TraceSystem tr)
        {
            SqlCommand cmd = null;
            SqlConnection con = null;
            SqlDataReader rd = null;
            Utilisateur util = null;
            try
            {
                con = new SqlConnection(Properties.Settings.Default.ValerioDB_Connect);
                con.Open();
                #region commande Enregistrement fournisseur
                cmd = new SqlCommand("Rechercher_Utilisateur", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@nom_user", nom_user);
                cmd.Parameters.AddWithValue("@id_act", tr.Id_trace);
                cmd.Parameters.AddWithValue("@descritpion_act", tr.Description);
                cmd.Parameters.AddWithValue("@date_act", tr.Date_act);
                cmd.Parameters.AddWithValue("@id_user", tr.Id_user);
                rd = cmd.ExecuteReader();
                if (rd.Read())
                {
                    util = new Utilisateur(rd.GetString(0), rd.GetString(1), rd.GetString(2), rd.GetString(3));
                }
                #endregion

            }
            catch (Exception Ex)
            {
                throw new Exception(Ex.Message);
            }
            finally
            {
                if (con != null) { con.Close(); }
            }

            return util;
        }
        public static Utilisateur Verifier_Roles_Utilisateur(string nom_user, string nom_pages)
        {
            SqlCommand cmd = null;
            SqlConnection con = null;
            SqlDataReader rd = null;
            Utilisateur util = null;
            try
            {
                con = new SqlConnection(Properties.Settings.Default.ValerioDB_Connect);
                con.Open();
                #region commande Enregistrement fournisseur
                cmd = new SqlCommand("Verifier_Roles_Utilisateur", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@nom_user", nom_user);
                cmd.Parameters.AddWithValue("@nom_pages", nom_pages);
                rd = cmd.ExecuteReader();
                if (rd.Read())
                {
                    util = new Utilisateur(rd.GetString(0), rd.GetString(1), rd.GetString(2), rd.GetString(3));
                }
                #endregion

            }
            catch (Exception Ex)
            {
                throw new Exception(Ex.Message);
            }
            finally
            {
                if (con != null) { con.Close(); }
            }

            return util;
        }
    }
}
