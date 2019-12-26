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
    public class ClientDal
    {
        public static int Enregistrer_Client(AdresseClient cli,TraceSystem tr)
        {
            int result = 0;
            string con = Properties.Settings.Default.ValerioDB_Connect;
            using (SqlConnection connection = new SqlConnection(con))
            {
                connection.Open();
                SqlTransaction transaction = connection.BeginTransaction();
                SqlCommand cmd = connection.CreateCommand();
                SqlCommand cmd1 = connection.CreateCommand();
                SqlCommand cmd2 = connection.CreateCommand();
                cmd.Transaction = transaction;
                cmd1.Transaction = transaction;
                cmd2.Transaction = transaction;
                try
                {
                    #region  Commande enregistrer adresse
                    cmd1.CommandText = "Enregistrer_Adresse";
                    cmd1.CommandType = CommandType.StoredProcedure;
                    cmd1.Parameters.AddWithValue("@id_adresse", cli.ID_Adresse);
                    cmd1.Parameters.AddWithValue("@pays", cli.Pays);
                    cmd1.Parameters.AddWithValue("@ville", cli.Ville);
                    cmd1.Parameters.AddWithValue("@region", cli.Region);
                    cmd1.Parameters.AddWithValue("@rue", cli.Rue);
                    cmd1.Parameters.AddWithValue("@num", cli.Numero);
                    cmd1.ExecuteNonQuery();
                    #endregion

                    #region commande d'enregistrer du client
                    cmd.CommandText = "Enregistrer_Client";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@id_client", cli.Id_client);
                    cmd.Parameters.AddWithValue("@nom_client", cli.Nom_client);
                    cmd.Parameters.AddWithValue("@prenom_client", cli.Prenom_client);
                    cmd.Parameters.AddWithValue("@nif_cin", cli.Nif_Cin);
                    cmd.Parameters.AddWithValue("@tel_client", cli.Tel);
                    cmd.Parameters.AddWithValue("@mail_client", cli.Email);
                    cmd.Parameters.AddWithValue("@date_enregistrement", cli.Date_enregistrement);
                    cmd.Parameters.AddWithValue("@id_adresse", cli.ID_Adresse);
                    cmd.Parameters.AddWithValue("@active", 1);
                    cmd.ExecuteNonQuery();
                    #endregion

                    #region commande enregustrer trace systeme
                    cmd2.CommandText = "Enregistrer_trace";
                    cmd2.CommandType = CommandType.StoredProcedure;
                    cmd2.Parameters.AddWithValue("@id_trace", tr.Id_trace);
                    cmd2.Parameters.AddWithValue("@description", tr.Description);
                    cmd2.Parameters.AddWithValue("@date_act", tr.Date_act);
                    cmd2.Parameters.AddWithValue("@nom_user", tr.Nom_user);
                    cmd2.ExecuteNonQuery();
                    #endregion

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
        public static DataTable Rechercher_Client_Nom(string nom,TraceSystem trace)
        {
            //AdresseClient cli = null;
            DataTable lstClient = new DataTable();
            SqlCommand cmd = null;
            SqlConnection con = null;
            SqlDataAdapter rd = null;
            try
            {
                con = new SqlConnection(Properties.Settings.Default.ValerioDB_Connect);
                con.Open();
                #region commande Rechercher Client
                cmd = new SqlCommand("Rechercher_Client_Nom", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@nom_client", nom);
                cmd.Parameters.AddWithValue("@id_trace", trace.Id_trace);
                cmd.Parameters.AddWithValue("@description", trace.Description);
                cmd.Parameters.AddWithValue("@date_act", trace.Date_act);
                cmd.Parameters.AddWithValue("@nom_user", trace.Nom_user);
                rd = new SqlDataAdapter(cmd);
                //cli = new AdresseClient(rd.GetInt32(0), rd.GetInt32(1), rd.GetString(2), rd.GetString(3), rd.GetString(4), rd.GetString(5), rd.GetString(6), rd.GetString(7), rd.GetString(8), rd.GetString(9), rd.GetString(10), rd.GetString(11), rd.GetString(12));
                rd.Fill(lstClient);
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
            return lstClient;
        }
        public static AdresseClient Rechercher_Client_Num(int num, TraceSystem trace)
        {
            AdresseClient cli = null;
            SqlCommand cmd = null;
            SqlConnection con = null;
            SqlDataReader rd = null;
            try
            {
                con = new SqlConnection(Properties.Settings.Default.ValerioDB_Connect);
                con.Open();
                #region commande Rechercher Client
                cmd = new SqlCommand("Rechercher_Client_Num", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id_client", num);
                cmd.Parameters.AddWithValue("@id_trace", trace.Id_trace);
                cmd.Parameters.AddWithValue("@description", trace.Description);
                cmd.Parameters.AddWithValue("@date_act", trace.Date_act);
                cmd.Parameters.AddWithValue("@nom_user", trace.Nom_user);
                rd = cmd.ExecuteReader();
                if (rd.Read())
                { 
                cli = new AdresseClient(rd.GetInt32(0), rd.GetInt32(1), rd.GetString(8), rd.GetString(9), rd.GetString(10), rd.GetString(11), rd.GetString(12), rd.GetString(2), rd.GetString(3), rd.GetString(4), rd.GetString(5), rd.GetString(6), rd.GetString(7));
                #endregion
                }
            }
            catch (Exception Ex)
            {
                throw new Exception(Ex.Message);
            }
            finally
            {
                if (con != null) { con.Close(); }
            }
            return cli;
        }
        public static int Modifier_Client(AdresseClient cli_,TraceSystem tr)
        {
            int result = 0;
            string con = Properties.Settings.Default.ValerioDB_Connect;
            using (SqlConnection connection = new SqlConnection(con))
            {
                connection.Open();
                SqlTransaction transaction = connection.BeginTransaction();
                SqlCommand cmd = connection.CreateCommand();
                SqlCommand cmd1 = connection.CreateCommand();
                SqlCommand cmd2 = connection.CreateCommand();
                cmd.Transaction = transaction;
                cmd1.Transaction = transaction;
                cmd2.Transaction = transaction;
                try
                {
                    #region  Commande enregistrer adresse
                    cmd1.CommandText = "Modifier_Adresse";
                    cmd1.CommandType = CommandType.StoredProcedure;
                    cmd1.Parameters.AddWithValue("@id_adresse", cli_.ID_Adresse);
                    cmd1.Parameters.AddWithValue("@pays", cli_.Pays);
                    cmd1.Parameters.AddWithValue("@ville", cli_.Ville);
                    cmd1.Parameters.AddWithValue("@region", cli_.Region);
                    cmd1.Parameters.AddWithValue("@rue", cli_.Rue);
                    cmd1.Parameters.AddWithValue("@num", cli_.Numero);
                    cmd1.ExecuteNonQuery();
                    #endregion

                    #region commande d'enregistrer du client
                    cmd.CommandText = "Modifier_Client";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@id_client", cli_.Id_client);
                    cmd.Parameters.AddWithValue("@nom_client", cli_.Nom_client);
                    cmd.Parameters.AddWithValue("@prenom_client", cli_.Prenom_client);
                    cmd.Parameters.AddWithValue("@nif_cin", cli_.Nif_Cin);
                    cmd.Parameters.AddWithValue("@tel_client", cli_.Tel);
                    cmd.Parameters.AddWithValue("@mail_client", cli_.Email);
                    cmd.Parameters.AddWithValue("@date_enregistrement", cli_.Date_enregistrement);
                    cmd.ExecuteNonQuery();
                    #endregion

                    #region commande enregustrer trace systeme
                    cmd2.CommandText = "Enregistrer_trace";
                    cmd2.CommandType = CommandType.StoredProcedure;
                    cmd2.Parameters.AddWithValue("@id_trace", tr.Id_trace);
                    cmd2.Parameters.AddWithValue("@description", tr.Description);
                    cmd2.Parameters.AddWithValue("@date_act", tr.Date_act);
                    cmd2.Parameters.AddWithValue("@nom_user", tr.Nom_user);
                    cmd2.ExecuteNonQuery();
                    #endregion

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
