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
    public class FournisseurDal
    {
        public static int Enregistrer_Fournisseur(Fournisseur four, Adresse adrs, TraceSystem tr)
        {
            string con = Properties.Settings.Default.ValerioDB_Connect;
            int result = 0;
            using (SqlConnection connection = new SqlConnection(con))
            {
                connection.Open();
                SqlTransaction transaction = connection.BeginTransaction();
                SqlCommand cmd = connection.CreateCommand();
                cmd.Transaction = transaction;
                try
                {
                    #region commande Enregistrement fournisseur
                    cmd.CommandText = "Ajouter_Fournisseur";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@id_fournisseur", four.ID_fournisseur);
                    cmd.Parameters.AddWithValue("@representant", four.Representant);
                    cmd.Parameters.AddWithValue("@nom_fournisseur", four.Nom_fournisseur);
                    cmd.Parameters.AddWithValue("@telephone", four.Telephone);
                    cmd.Parameters.AddWithValue("@e_mail", four.E_mail);
                    cmd.Parameters.AddWithValue("@date_ajout", four.Date_ajout);
                    cmd.Parameters.AddWithValue("@active", four.Active);
                    cmd.Parameters.AddWithValue("@id_adresse", four.Id_adresse);
                    cmd.Parameters.AddWithValue("@pays", adrs.Pays);
                    cmd.Parameters.AddWithValue("@ville", adrs.Ville);
                    cmd.Parameters.AddWithValue("@region", adrs.Region);
                    cmd.Parameters.AddWithValue("@rue", adrs.Rue);
                    cmd.Parameters.AddWithValue("@numero", adrs.Numero);
                    cmd.Parameters.AddWithValue("@id_act", tr.Id_trace);
                    cmd.Parameters.AddWithValue("@descritpion", tr.Description);
                    cmd.Parameters.AddWithValue("@date_act", tr.Date_act);
                    cmd.Parameters.AddWithValue("@id_user", tr.Nom_user);
                    //
                    #endregion
                    cmd.ExecuteNonQuery();
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
        public static Fournisseur Rechercher_Fournisseur_Nom(string nom, TraceSystem trace)
        {
            SqlCommand cmd = null;
            SqlConnection con = null;
            SqlDataReader rd = null;
            Fournisseur four = null;
            try
                {
                con = new SqlConnection(Properties.Settings.Default.ValerioDB_Connect);
                con.Open();
                #region commande Enregistrement fournisseur
                    cmd = new SqlCommand( "Rechercher_Fournisseur",con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@nom_four", nom);
                    cmd.Parameters.AddWithValue("@id_act", trace.Id_trace);
                    cmd.Parameters.AddWithValue("@descritpion_act", trace.Description);
                    cmd.Parameters.AddWithValue("@date_act", trace.Date_act);
                    cmd.Parameters.AddWithValue("@id_user",trace.Nom_user);
                    rd = cmd.ExecuteReader();
                    if (rd.Read())
                    {
                        four = new Fournisseur(rd.GetInt32(0), rd.GetString(2), rd.GetString(1), rd.GetString(3), rd.GetString(4), rd.GetString(5), rd.GetString(12) + ", " + rd.GetString(11) + ", " + rd.GetString(10) + ", " + rd.GetString(9) + ", " + rd.GetString(8));
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

                return four;
            
        }
        public static Fournisseur Rechercher_Fournisseur(string nom)
        {
            SqlCommand cmd = null;
            SqlConnection con = null;
            SqlDataReader rd = null;
            Fournisseur four = null;
            try
            {
                con = new SqlConnection(Properties.Settings.Default.ValerioDB_Connect);
                con.Open();
                #region commande Enregistrement fournisseur
                cmd = new SqlCommand("Rechercher_Fournisseur_Nom", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@nom_four", nom);
               
                rd = cmd.ExecuteReader();
                while (rd.Read())
                {
                    four = new Fournisseur(rd.GetInt32(0),rd.GetString(2),rd.GetString(1));
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

            return four;

        }
        public static Fournisseur Rechercher_Fournisseur_Id(int id)
        {
            SqlCommand cmd = null;
            SqlConnection con = null;
            SqlDataReader rd = null;
            Fournisseur four = null;
            try
            {
                con = new SqlConnection(Properties.Settings.Default.ValerioDB_Connect);
                con.Open();
                #region commande Enregistrement fournisseur
                cmd = new SqlCommand("Rechercher_Fournisseur_Id", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@num_four", id);

                rd = cmd.ExecuteReader();
                if (rd.Read())
                {
                    four = new Fournisseur(rd.GetInt32(0), rd.GetString(1), rd.GetString(2));
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

            return four;

        }
        public static AdresseFournisseur Rechercher_Fournisseur_Adresse(string nom, TraceSystem trace)
        {
            SqlCommand cmd = null;
            SqlConnection con = null;
            SqlDataReader rd = null;
                AdresseFournisseur four = null;
                try
                {
                    con = new SqlConnection(Properties.Settings.Default.ValerioDB_Connect);
                    con.Open();
                    #region commande Enregistrement fournisseur
                    cmd = new SqlCommand("Rechercher_Fournisseur",con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@nom_four", nom);
                    cmd.Parameters.AddWithValue("@id_act", trace.Id_trace);
                    cmd.Parameters.AddWithValue("@descritpion_act", trace.Description);
                    cmd.Parameters.AddWithValue("@date_act", trace.Date_act);
                    cmd.Parameters.AddWithValue("@id_user", trace.Nom_user);
                    rd = cmd.ExecuteReader();
                    if (rd.Read())
                    {
                        four = new AdresseFournisseur(rd.GetInt32(7),rd.GetString(8),rd.GetString(9),rd.GetString(10),rd.GetString(11),rd.GetString(12),rd.GetInt32(0),rd.GetString(2),rd.GetString(1),rd.GetString(4),rd.GetString(3),rd.GetString(5));
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

                return four;
        }
        public static int Modifier_fournisseur(Fournisseur four, TraceSystem tr)
        {
            string con = Properties.Settings.Default.ValerioDB_Connect;
            int result = 0;
            using (SqlConnection connection = new SqlConnection(con))
            {
                connection.Open();
                SqlTransaction transaction = connection.BeginTransaction();
                SqlCommand cmd = connection.CreateCommand();
                cmd.Transaction = transaction;
                try
                {
                    #region commande Enregistrement fournisseur
                    cmd.CommandText = "Modifier_Fournisseur";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@id_fournisseur", four.ID_fournisseur);
                    cmd.Parameters.AddWithValue("@representant", four.Representant);
                    cmd.Parameters.AddWithValue("@nom_fournisseur", four.Nom_fournisseur);
                    cmd.Parameters.AddWithValue("@telephone", four.Telephone);
                    cmd.Parameters.AddWithValue("@e_mail", four.E_mail);
                    cmd.Parameters.AddWithValue("@date_ajout", four.Date_ajout);
                    cmd.Parameters.AddWithValue("@id_act", tr.Id_trace);
                    cmd.Parameters.AddWithValue("@descritpion", tr.Description);
                    cmd.Parameters.AddWithValue("@date_act", tr.Date_act);
                    cmd.Parameters.AddWithValue("@id_user", tr.Id_user);
                    //
                    #endregion
                    cmd.ExecuteNonQuery();
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
        public static int Modifier_fournisseur_Adresse(Fournisseur four,Adresse adrs, TraceSystem tr)
        {
            string con = Properties.Settings.Default.ValerioDB_Connect;
            int result = 0;
            using (SqlConnection connection = new SqlConnection(con))
            {
                connection.Open();
                SqlTransaction transaction = connection.BeginTransaction();
                SqlCommand cmd = connection.CreateCommand();
                cmd.Transaction = transaction;
                try
                {
                    #region commande Enregistrement fournisseur
                    cmd.CommandText = "Modifier_Fournisseur_Adresse";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@representant", four.Representant);
                    cmd.Parameters.AddWithValue("@nom_fournisseur", four.Nom_fournisseur);
                    cmd.Parameters.AddWithValue("@telephone", four.Telephone);
                    cmd.Parameters.AddWithValue("@e_mail", four.E_mail);
                    cmd.Parameters.AddWithValue("@date_ajout", four.Date_ajout);
                    cmd.Parameters.AddWithValue("@active", four.Active);
                    cmd.Parameters.AddWithValue("@id_act", tr.Id_trace);
                    cmd.Parameters.AddWithValue("@descritpion", tr.Description);
                    cmd.Parameters.AddWithValue("@date_act", tr.Date_act);
                    cmd.Parameters.AddWithValue("@id_user", tr.Nom_user);
                    cmd.Parameters.AddWithValue("@Id_Adresse",four.Id_adresse);
                    cmd.Parameters.AddWithValue("@pays", adrs.Pays);
                    cmd.Parameters.AddWithValue("@ville", adrs.Ville);
                    cmd.Parameters.AddWithValue("@region", adrs.Region);
                    cmd.Parameters.AddWithValue("@rue", adrs.Rue);
                    cmd.Parameters.AddWithValue("@numero", adrs.Numero);
                    //
                    #endregion
                    cmd.ExecuteNonQuery();
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
        public static int Supprimer_fournisseur(string nom_four, TraceSystem tr)
        {
            string con = Properties.Settings.Default.ValerioDB_Connect;
            int result = 0;
            using (SqlConnection connection = new SqlConnection(con))
            {
                connection.Open();
                SqlTransaction transaction = connection.BeginTransaction();
                SqlCommand cmd = connection.CreateCommand();
                cmd.Transaction = transaction;
                try
                {
                    #region commande Enregistrement fournisseur
                    cmd.CommandText = "Supprimer_Fournisseur";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@nom_fournisseur", nom_four);
                    cmd.Parameters.AddWithValue("@id_act", tr.Id_trace);
                    cmd.Parameters.AddWithValue("@descritpion", tr.Description);
                    cmd.Parameters.AddWithValue("@date_act", tr.Date_act);
                    cmd.Parameters.AddWithValue("@id_user", tr.Id_user);
                    //
                    #endregion
                    cmd.ExecuteNonQuery();
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
        public static BindingList<Fournisseur> List_Fournisseur( TraceSystem trace)
        {
                SqlCommand cmd = null;
                SqlConnection con = null;
                SqlDataReader rd = null;
                BindingList<Fournisseur> LstFournisseur = new BindingList<Fournisseur>();
                Fournisseur four = null;
                try
                {
                    #region commande Enregistrement fournisseur
                    con = new SqlConnection(Properties.Settings.Default.ValerioDB_Connect);
                    con.Open();
                    cmd = new SqlCommand("Liste_Fournisseur",con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@id_act", trace.Id_trace);
                    cmd.Parameters.AddWithValue("@descritpion_act", trace.Description);
                    cmd.Parameters.AddWithValue("@date_act", trace.Date_act);
                    cmd.Parameters.AddWithValue("@id_user", trace.Id_user);
                    rd = cmd.ExecuteReader();
                    if (rd.Read())
                    {
                        four = new Fournisseur(rd.GetInt32(0), rd.GetString(2), rd.GetString(1), rd.GetString(3), rd.GetString(4), rd.GetString(5), rd.GetString(12) + ", " + rd.GetString(11) + ", " + rd.GetString(10) + ", " + rd.GetString(9) + ", " + rd.GetString(8));
                        LstFournisseur.Add(four);
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
                return LstFournisseur;
         
        }
    }
}