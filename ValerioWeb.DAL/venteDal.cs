using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ValerioWeb.Domaine;

namespace ValerioWeb.DAL
{
    public class venteDal
    {
        public static int Enregistrer_Vente(vente ven, StringCollection sc,Client cli, TraceSystem tr)
        {
            int result = 0;
            #region
            string con = Properties.Settings.Default.ValerioDB_Connect;
            using (SqlConnection connection = new SqlConnection(con))
            {
                connection.Open();
                SqlTransaction transaction = connection.BeginTransaction();
                SqlCommand cmd = connection.CreateCommand();
                SqlCommand cmd1 = connection.CreateCommand();
                SqlCommand cmd2 = connection.CreateCommand();
                SqlCommand cmd3 = connection.CreateCommand();
                cmd.Transaction = transaction;
                cmd1.Transaction = transaction;
                cmd2.Transaction = transaction;
                cmd3.Transaction = transaction;
                StringBuilder sb = new StringBuilder(string.Empty);
                string[] splitItems = null;
                try
                {
                    #region enregistrement client
                    cmd3.CommandText = "insert into Acheteur values(@id_acheteur,@nom,@prenom)";
                    cmd3.Parameters.AddWithValue("@id_acheteur", cli.Id_client);
                    cmd3.Parameters.AddWithValue("@nom", cli.Nom_client);
                    cmd3.Parameters.AddWithValue("@prenom", cli.Prenom_client);
                    cmd3.ExecuteNonQuery();
                    #endregion

                    #region commande 1 enregistrer vente
                    cmd1.CommandText = "Enregistrer_Vente";
                    //cmd1.CommandText = "insert into EssaiVente Values(@id_vente,@montant,@date_vente,@id_acheteur,@active)";
                    cmd1.CommandType = CommandType.StoredProcedure;
                    cmd1.Parameters.AddWithValue("@id_vente", ven.Id_vente);
                    cmd1.Parameters.AddWithValue("@montant", ven.Montant);
                    cmd1.Parameters.AddWithValue("@date_vente", ven.Date_Vente);
                    cmd1.Parameters.AddWithValue("@id_acheteur", ven.Id_acheteur);
                    cmd1.Parameters.AddWithValue("@active", ven.Active);
                    cmd1.ExecuteNonQuery();
                    #endregion

                    #region commande 1 contenu vente Article
                   const string req = "INSERT INTO Essai_Contenu_Vente (Id_vente,Code_article,Qte_article,Px_unitaire,Estimation,Rabais,Montant_) VALUES";
                    foreach (string item in sc)
                    {
                        if (item.Contains(","))
                       {
                            splitItems = item.Split(",".ToCharArray());
                            sb.AppendFormat("{0}('{1}','{2}','{3}','{4}','{5}','{6}','{7}'); ", req,splitItems[0], splitItems[1], splitItems[2], splitItems[3],splitItems[4],splitItems[5],splitItems[6]);
                       }
                    }
                       using (SqlCommand cmdd = new SqlCommand(sb.ToString(), connection))
                        {
                            cmdd.Transaction = transaction;
                            cmdd.CommandType = CommandType.Text;
                            //cmdd.ExecuteNonQuery();
                        }
                    #endregion

                    #region commande 3 trace systeme
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
                #endregion
            }
        }
        public static DataTable Lister_Vente(TraceSystem trace)
        {
            DataTable lstVente = new DataTable();
            SqlCommand cmd = null;
            SqlConnection con = null;
            SqlDataAdapter rd = null;
            try
            {
                con = new SqlConnection(Properties.Settings.Default.ValerioDB_Connect);
                con.Open();
                #region commande Rechercher Client
                cmd = new SqlCommand("Lister_Vente", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id_trace", trace.Id_trace);
                cmd.Parameters.AddWithValue("@description", trace.Description);
                cmd.Parameters.AddWithValue("@date_act", trace.Date_act);
                cmd.Parameters.AddWithValue("@nom_user", trace.Nom_user);
                rd = new SqlDataAdapter(cmd);
                rd.Fill(lstVente);
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
            return lstVente;
        }
        public static DataTable Lister_Contenu_Vente(int num)
        {
            DataTable lstVente = new DataTable();
            SqlCommand cmd = null;
            SqlConnection con = null;
            SqlDataAdapter rd = null;
            try
            {
                con = new SqlConnection(Properties.Settings.Default.ValerioDB_Connect);
                con.Open();
                #region commande Rechercher Client
                cmd = new SqlCommand("Lister_Contenu_Vente", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id_vente", num);
                rd = new SqlDataAdapter(cmd);
                rd.Fill(lstVente);
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
            return lstVente;
        }
    }
}
