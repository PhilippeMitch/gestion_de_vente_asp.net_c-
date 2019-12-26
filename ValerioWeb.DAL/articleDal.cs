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
    public class articleDal
    {
        public static int Enregistrer_nouveau_(image_article im_art,TraceSystem tr,rayon ray)
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
                SqlCommand cmd4 = connection.CreateCommand();
                cmd3.Transaction = transaction;
                cmd4.Transaction = transaction;
                cmd.Transaction = transaction;
                cmd2.Transaction = transaction;
                cmd1.Transaction = transaction;
                try
                {
                    #region commande 2 enregistrer rayon
                    cmd1.CommandText = "Enregistrer_rayon";
                    cmd1.CommandType = CommandType.StoredProcedure;
                    cmd1.Parameters.AddWithValue("@id_rayon", ray.Id_rayon);
                    cmd1.Parameters.AddWithValue("@nom_rayon", ray.Nom_rayon);
                    cmd1.Parameters.AddWithValue("@date_enregistrement", ray.Date_enregistrement);
                    cmd1.Parameters.AddWithValue("@id_categorie", ray.Id_categorie);
                    cmd1.Parameters.AddWithValue("@active", ray.Active);
                    cmd1.ExecuteNonQuery();
                    #endregion

                    #region commande 3 Enregistrer image article
                    cmd2.CommandText = "Enregistrer_Image_Article";
                    cmd2.CommandType = CommandType.StoredProcedure;
                    cmd2.Parameters.AddWithValue("@id_img", im_art.Id_image);
                    cmd2.Parameters.AddWithValue("@nom_img", im_art.Nom_image);
                    cmd2.Parameters.AddWithValue("@contenu_img", im_art.Contenu_image);
                    cmd2.Parameters.AddWithValue("@extn_img", im_art.Extension_image);
                    cmd2.ExecuteNonQuery();
                    #endregion

                    #region commande 1 enregistrer Article
                    cmd.CommandText = "Enregistrer_article";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@code_art",im_art.Code_article);
                    cmd.Parameters.AddWithValue("@description_art",im_art.Description_article);
                    cmd.Parameters.AddWithValue("@id_img",im_art.Id_image);
                    cmd.Parameters.AddWithValue("@qte_stock",im_art.Qte_enstock);
                    cmd.Parameters.AddWithValue("@qte_alerte", im_art.Qte_alerte);
                    cmd.Parameters.AddWithValue("@date_enregistrement",im_art.Date_enregistrement);
                    cmd.Parameters.AddWithValue("@id_rayon", ray.Id_rayon);
                    cmd.Parameters.AddWithValue("@active", 1);
                    cmd.ExecuteNonQuery();
                    #endregion

                    #region comande 4 enregistrer article fournit
                    cmd4.CommandText = "Enregistrer_Article_fournit";
                    cmd4.CommandType = CommandType.StoredProcedure;
                    cmd4.Parameters.AddWithValue("@code_art", im_art.Code_article);
                    cmd4.Parameters.AddWithValue("@id_four", im_art.Id_four);
                    cmd4.Parameters.AddWithValue("@px_achat_art", im_art.Px_achat);
                    cmd4.Parameters.AddWithValue("@px_vente_art", im_art.Px_vente);
                    cmd4.Parameters.AddWithValue("@date_enregistrement", im_art.Date_enregistrement);
                    cmd4.Parameters.AddWithValue("@active",1);
                    cmd4.ExecuteNonQuery();
                    #endregion

                    #region commande 5 trace systeme
                    cmd3.CommandText = "Enregistrer_trace";
                    cmd3.CommandType = CommandType.StoredProcedure;
                    cmd3.Parameters.AddWithValue("@id_trace", tr.Id_trace);
                    cmd3.Parameters.AddWithValue("@description", tr.Description);
                    cmd3.Parameters.AddWithValue("@date_act", tr.Date_act);
                    cmd3.Parameters.AddWithValue("@nom_user", tr.Nom_user);
                    cmd3.ExecuteNonQuery();
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
        public static image_article Verifier_Prix_Quantite_Article(string code_art)
        {
            image_article art = null;
            SqlCommand cmd = null;
            SqlConnection con = null;
            SqlDataReader rd = null;
            try
            {
                con = new SqlConnection(Properties.Settings.Default.ValerioDB_Connect);
                con.Open();
                #region commande Enregistrement fournisseur
                cmd = new SqlCommand("Verifier_Prix_Quantite_Article", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@code_art", code_art);
                rd = cmd.ExecuteReader();
                while (rd.Read())
                {
                    art = new image_article(rd.GetString(0), rd.GetString(1), rd.GetString(2), rd.GetInt32(3), rd.GetInt32(4), rd.GetInt32(9), rd.GetInt32(5), rd.GetDecimal(6), rd.GetDecimal(7), rd.GetString(8), rd.GetSqlBytes(13).Value);
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
            return art;
        }
        public static image_article Rechercher_article_Nom(string nom,TraceSystem trace)
        {
            image_article art = null;
            SqlCommand cmd = null;
            SqlConnection con = null;
            SqlDataReader rd = null;
            try
            {
                con = new SqlConnection(Properties.Settings.Default.ValerioDB_Connect);
                con.Open();
                #region commande Enregistrement fournisseur
                cmd = new SqlCommand("Rechercher_article_Nom", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@nom_four", nom);
                cmd.Parameters.AddWithValue("@id_act", trace.Id_trace);
                cmd.Parameters.AddWithValue("@descritpion_act", trace.Description);
                cmd.Parameters.AddWithValue("@date_act", trace.Date_act);
                cmd.Parameters.AddWithValue("@id_user", trace.Nom_user);
                rd = cmd.ExecuteReader();
                while (rd.Read())
                {
                    art = new image_article(rd.GetString(2), rd.GetString(0), rd.GetString(3), rd.GetInt32(4), rd.GetInt32(5), rd.GetInt32(1), rd.GetInt32(7), rd.GetDecimal(8), rd.GetDecimal(9), rd.GetString(6), rd.GetSqlBytes(10).Value);
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
            return art;
        }
        public static image_article Rechercher_article_Code(string code, TraceSystem trace)
        {
            image_article art = null;
            SqlCommand cmd = null;
            SqlConnection con = null;
            SqlDataReader rd = null;
            try
            {
                con = new SqlConnection(Properties.Settings.Default.ValerioDB_Connect);
                con.Open();
                #region commande Enregistrement fournisseur
                cmd = new SqlCommand("Rechercher_article_Code", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@code_art", code);
                cmd.Parameters.AddWithValue("@id_trace", trace.Id_trace);
                cmd.Parameters.AddWithValue("@description", trace.Description);
                cmd.Parameters.AddWithValue("@date_act", trace.Date_act);
                cmd.Parameters.AddWithValue("@nom_user", trace.Nom_user);
                rd = cmd.ExecuteReader();
                while (rd.Read())
                {
                    art = new image_article(rd.GetString(0), rd.GetString(1), rd.GetString(2), rd.GetInt32(3), rd.GetInt32(4), rd.GetInt32(9), rd.GetInt32(5), rd.GetDecimal(6), rd.GetDecimal(7), rd.GetString(8), rd.GetSqlBytes(13).Value);
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
            return art;
        }
        public static int Modifier_article_tout(image_article im_art, TraceSystem tr, rayon ray)
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
                SqlCommand cmd4 = connection.CreateCommand();
                cmd4.Transaction = transaction;
                cmd3.Transaction = transaction;
                cmd.Transaction = transaction;
                cmd1.Transaction = transaction;
                try
                {
                    #region commande 1 enregistrer Article
                    cmd.CommandText = "Modifier_article";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@code_art", im_art.Code_article);
                    cmd.Parameters.AddWithValue("@description_art", im_art.Description_article);
                    cmd.Parameters.AddWithValue("@qte_stock", im_art.Qte_enstock);
                    cmd.Parameters.AddWithValue("@qte_alerte", im_art.Qte_alerte);
                    cmd.ExecuteNonQuery();
                    #endregion

                    #region commande 2 enregistrer rayon
                    cmd1.CommandText = "Modifier_rayon";
                    cmd1.CommandType = CommandType.StoredProcedure;
                    cmd1.Parameters.AddWithValue("@id_rayon", ray.Id_rayon);
                    cmd1.Parameters.AddWithValue("@nom_rayon", ray.Nom_rayon);
                    cmd1.Parameters.AddWithValue("@id_categorie", ray.Id_categorie);
                    cmd1.ExecuteNonQuery();
                    #endregion

                    #region commande 3 Enregistrer image article
                    cmd3.CommandText = "Modifier_image";
                    cmd3.CommandType = CommandType.StoredProcedure;
                    cmd3.Parameters.AddWithValue("@id_img", im_art.Id_image);
                    cmd3.Parameters.AddWithValue("@nom_img", im_art.Nom_image);
                    cmd3.Parameters.AddWithValue("@contenu_img", im_art.Contenu_image);
                    cmd3.Parameters.AddWithValue("@extn_img", im_art.Extension_image);
                    cmd3.ExecuteNonQuery();
                    #endregion

                    #region comande 4 enregistrer article fournit
                    cmd4.CommandText = "Modifier_Article_fournit";
                    cmd4.CommandType = CommandType.StoredProcedure;
                    cmd4.Parameters.AddWithValue("@code_art", im_art.Code_article);
                    cmd4.Parameters.AddWithValue("@id_four", im_art.Id_four);
                    cmd4.Parameters.AddWithValue("@px_achat_art", im_art.Px_achat);
                    cmd4.Parameters.AddWithValue("@px_vente_art", im_art.Px_vente);
                    cmd4.Parameters.AddWithValue("@date_enregistrement", im_art.Date_enregistrement);
                    cmd4.Parameters.AddWithValue("@active", 1);
                    cmd4.ExecuteNonQuery();
                    #endregion

                    #region commande 5 trace systeme
                    cmd3.CommandText = "Enregistrer_trace";
                    cmd3.CommandType = CommandType.StoredProcedure;
                    cmd3.Parameters.AddWithValue("@id_trace", tr.Id_trace);
                    cmd3.Parameters.AddWithValue("@description", tr.Description);
                    cmd3.Parameters.AddWithValue("@date_act", tr.Date_act);
                    cmd3.Parameters.AddWithValue("@nom_user", tr.Nom_user);
                    cmd3.ExecuteNonQuery();
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
        public static int Modifier_article_Tout_San_Article(image_article im_art, TraceSystem tr, rayon ray)
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
                cmd2.Transaction = transaction;
                cmd3.Transaction = transaction;
                cmd.Transaction = transaction;
                cmd1.Transaction = transaction;
                try
                {
                    #region commande 1 enregistrer Article
                    cmd.CommandText = "Modifier_article";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@code_art", im_art.Code_article);
                    cmd.Parameters.AddWithValue("@description_art", im_art.Description_article);
                    cmd.Parameters.AddWithValue("@qte_stock", im_art.Qte_enstock);
                    cmd.Parameters.AddWithValue("@qte_alerte", im_art.Qte_alerte);
                    cmd.ExecuteNonQuery();
                    #endregion

                    #region commande 2 enregistrer rayon
                    cmd1.CommandText = "Modifier_rayon";
                    cmd1.CommandType = CommandType.StoredProcedure;
                    cmd1.Parameters.AddWithValue("@id_rayon", ray.Id_rayon);
                    cmd1.Parameters.AddWithValue("@nom_rayon", ray.Nom_rayon);
                    cmd1.Parameters.AddWithValue("@id_categorie", ray.Id_categorie);
                    cmd1.ExecuteNonQuery();
                    #endregion

                    #region commande 3 Enregistrer image article
                    cmd3.CommandText = "Modifier_image";
                    cmd3.CommandType = CommandType.StoredProcedure;
                    cmd3.Parameters.AddWithValue("@id_img", im_art.Id_image);
                    cmd3.Parameters.AddWithValue("@nom_img", im_art.Nom_image);
                    cmd3.Parameters.AddWithValue("@contenu_img", im_art.Contenu_image);
                    cmd3.Parameters.AddWithValue("@extn_img", im_art.Extension_image);
                    cmd3.ExecuteNonQuery();
                    #endregion

                    #region commande 5 trace systeme
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

            }
            #endregion
        }
        public static int Modifier_article_(image_article im_art, TraceSystem tr, rayon ray)
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
                SqlCommand cmd3 = connection.CreateCommand();
                SqlCommand cmd4 = connection.CreateCommand();
                cmd4.Transaction = transaction;
                cmd.Transaction = transaction;
                cmd1.Transaction = transaction;
                try
                {
                    #region commande 1 enregistrer Article
                    cmd.CommandText = "Modifier_article";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@code_art", im_art.Code_article);
                    cmd.Parameters.AddWithValue("@description_art", im_art.Description_article);
                    cmd.Parameters.AddWithValue("@qte_stock", im_art.Qte_enstock);
                    cmd.Parameters.AddWithValue("@qte_alerte", im_art.Qte_alerte);
                    cmd.ExecuteNonQuery();
                    #endregion

                    #region commande 2 enregistrer rayon
                    cmd1.CommandText = "Modifier_rayon";
                    cmd1.CommandType = CommandType.StoredProcedure;
                    cmd1.Parameters.AddWithValue("@id_rayon", ray.Id_rayon);
                    cmd1.Parameters.AddWithValue("@nom_rayon", ray.Nom_rayon);
                    cmd1.Parameters.AddWithValue("@id_categorie", ray.Id_categorie);
                    cmd1.ExecuteNonQuery();
                    #endregion

                    #region comande 4 enregistrer article fournit
                    cmd4.CommandText = "Modifier_Article_fournit";
                    cmd4.CommandType = CommandType.StoredProcedure;
                    cmd4.Parameters.AddWithValue("@code_art", im_art.Code_article);
                    cmd4.Parameters.AddWithValue("@id_four", im_art.Id_four);
                    cmd4.Parameters.AddWithValue("@px_achat_art", im_art.Px_achat);
                    cmd4.Parameters.AddWithValue("@px_vente_art", im_art.Px_vente);
                    cmd4.Parameters.AddWithValue("@date_enregistrement", im_art.Date_enregistrement);
                    cmd4.Parameters.AddWithValue("@active", 1);
                    cmd4.ExecuteNonQuery();
                    #endregion

                    #region commande 5 trace systeme
                    cmd3.CommandText = "Enregistrer_trace";
                    cmd3.CommandType = CommandType.StoredProcedure;
                    cmd3.Parameters.AddWithValue("@id_trace", tr.Id_trace);
                    cmd3.Parameters.AddWithValue("@description", tr.Description);
                    cmd3.Parameters.AddWithValue("@date_act", tr.Date_act);
                    cmd3.Parameters.AddWithValue("@nom_user", tr.Nom_user);
                    cmd3.ExecuteNonQuery();
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
        public static article Verifier_Article(string nom,string description)
        {
            article art = null;
            SqlConnection con = null;
            SqlCommand cmd = null;
            SqlDataReader rd = null;
            try
            {
                con = new SqlConnection(Properties.Settings.Default.ValerioDB_Connect);
                string req = "SELECT Rayon.Nom_rayon, Article.Description_article, Article.Qte_stock, Article.Qte_alerte, Rayon.Id_categorie FROM Article INNER JOIN Rayon ON Article.Id_rayon = Rayon.Id_rayon WHERE (Rayon.Nom_rayon = @nom) AND (Article.Description_article = @description)";
                con.Open();
                cmd = new SqlCommand(req, con);
                cmd.Parameters.AddWithValue("@nom", nom);
                cmd.Parameters.AddWithValue("@description", description);
                rd = cmd.ExecuteReader();
                while (rd.Read())
                {
                    art = new article(rd.GetString(0), rd.GetString(1), rd.GetInt32(2), rd.GetInt32(3), rd.GetInt32(4));
                
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
            return art;
        }
        public static BindingList<image_article> Lister_Article(TraceSystem trace)
        {
            BindingList<image_article> lstarticle = new BindingList<image_article>();
            image_article art = null;
            SqlCommand cmd = null;
            SqlConnection con = null;
            SqlDataReader rd = null;
            try
            {
                con = new SqlConnection(Properties.Settings.Default.ValerioDB_Connect);
                con.Open();
                #region commande Enregistrement fournisseur
                cmd = new SqlCommand("Lister_article", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id_trace", trace.Id_trace);
                cmd.Parameters.AddWithValue("@description", trace.Description);
                cmd.Parameters.AddWithValue("@date_act", trace.Date_act);
                cmd.Parameters.AddWithValue("@nom_user", trace.Nom_user);
                rd = cmd.ExecuteReader();
                while (rd.Read())
                {
                    art = new image_article(rd.GetString(0), rd.GetString(1), rd.GetString(2), rd.GetInt32(3), rd.GetInt32(4), rd.GetInt32(9), rd.GetInt32(5), rd.GetDecimal(6), rd.GetDecimal(7), rd.GetString(8), rd.GetSqlBytes(13).Value);
                    lstarticle.Add(art);
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
            return lstarticle;
        }
    }
}
