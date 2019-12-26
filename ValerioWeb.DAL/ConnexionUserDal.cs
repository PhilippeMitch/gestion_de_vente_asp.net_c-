using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ValerioWeb.Domaine;

namespace ValerioWeb.DAL
{
    public class ConnexionUserDal
    {
        public static int Enregistrer_Connexion(ConnexionUser conect, TraceSystem tr)
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
                    #region commande Enregistrement fournisseur
                    cmd.CommandText = "Enregistrer_Connexion_Utilisateur";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@id_con", conect.Id_connexion);
                    cmd.Parameters.AddWithValue("@nom_us", conect.Nom_user);
                    cmd.Parameters.AddWithValue("@ip_us", conect.Ip_user);
                    cmd.Parameters.AddWithValue("@date_con", conect.Date_connexion);
                    cmd.ExecuteNonQuery();
                    //
                    cmd1.CommandText = "Enregistrer_trace";
                    cmd1.CommandType = CommandType.StoredProcedure;
                    cmd1.Parameters.AddWithValue("@id_trace", tr.Id_trace);
                    cmd1.Parameters.AddWithValue("@description", tr.Description);
                    cmd1.Parameters.AddWithValue("@date_act", tr.Date_act);
                    cmd1.Parameters.AddWithValue("@nom_user", tr.Nom_user);
                    //
                    #endregion
                    cmd1.ExecuteNonQuery();

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
        public static int Supprimer_Connexion(ConnexionUser conect, TraceSystem tr)
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
                    #region commande Enregistrement fournisseur
                    cmd.CommandText = "Supprimer_Connexion_Utilisateur";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@nom_us", conect.Nom_user);
                    cmd.ExecuteNonQuery();
                    //
                    cmd1.CommandText = "Enregistrer_trace";
                    cmd1.CommandType = CommandType.StoredProcedure;
                    cmd1.Parameters.AddWithValue("@id_trace", tr.Id_trace);
                    cmd1.Parameters.AddWithValue("@description", tr.Description);
                    cmd1.Parameters.AddWithValue("@date_act", tr.Date_act);
                    cmd1.Parameters.AddWithValue("@nom_user", tr.Nom_user);
                    //
                    #endregion
                    cmd1.ExecuteNonQuery();
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
        public static ConnexionUser Connexion(string nom,string pass)
        {         
            SqlDataReader rd = null;
            ConnexionUser conex = null;
            SqlCommand cmd = null;
            SqlConnection con = null;
            try
                {
                    con = new SqlConnection(Properties.Settings.Default.ValerioDB_Connect);
                    con.Open();
                    #region commande Enregistrement fournisseur
                    cmd =  new SqlCommand("Connection_Utilisateur",con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@nom", nom);
                    cmd.Parameters.AddWithValue("@pass",pass);
                    cmd.Parameters.AddWithValue("@active", true);
                    rd = cmd.ExecuteReader();
                    if (rd.Read())
                    {
                        conex = new ConnexionUser(rd.GetInt32(5), rd.GetString(1), rd.GetString(2), rd.GetString(3));
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
                return conex;
        }
        public static ConnexionUser Verifier_Session(string nom)
        {
            SqlDataReader rd = null;
            ConnexionUser conex = null;
            SqlCommand cmd = null;
            SqlConnection con = null;
                try
                {
                    con=new SqlConnection(Properties.Settings.Default.ValerioDB_Connect);
                    con.Open();
                    #region commande Enregistrement fournisseur
                    cmd= new SqlCommand("Verifier_Session",con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@nom_user", nom);
                    rd = cmd.ExecuteReader();
                    if (rd.Read())
                    {
                        conex = new ConnexionUser(rd.GetInt32(0), rd.GetString(1), rd.GetString(2), rd.GetString(3));
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
                return conex;

        }
        public static BindingList<ConnexionUser> List_Connexion(TraceSystem trace)
        {
            string con = Properties.Settings.Default.ValerioDB_Connect;
            using (SqlConnection connection = new SqlConnection(con))
            {
                connection.Open();
                SqlTransaction transaction = connection.BeginTransaction();
                SqlCommand cmd = connection.CreateCommand();
                cmd.Transaction = transaction;
                SqlDataReader rd = null;
                BindingList<ConnexionUser> LstConnexion = null;
                ConnexionUser conex = null;
                try
                {
                    #region commande Enregistrement fournisseur
                    cmd.CommandText = "Liste_Connexion";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@id_act", trace.Id_trace);
                    cmd.Parameters.AddWithValue("@descritpion_act", trace.Description);
                    cmd.Parameters.AddWithValue("@date_act", trace.Date_act);
                    cmd.Parameters.AddWithValue("@id_user", trace.Id_user);
                    rd = cmd.ExecuteReader();
                    if (rd.Read())
                    {
                        conex = new ConnexionUser(rd.GetInt32(0),rd.GetString(1),rd.GetString(2),rd.GetString(3));
                        LstConnexion.Add(conex);
                    }
                    #endregion
                    transaction.Commit();
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

                return LstConnexion;
            }
        }
    }
}
