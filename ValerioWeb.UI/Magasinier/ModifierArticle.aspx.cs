using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ValerioWeb.Controleur;
using ValerioWeb.Domaine;

namespace ValerioWeb.UI.Magasinier
{
    public partial class ModifierArticle : System.Web.UI.Page
    {
        string num;
        public string user;
        int id_cat;
        public image_article art = null;
        int id_four;
        decimal prix_achat; decimal prix_vente;
        public void Vider()
        {
            txtcode.Text = "";
            txtdescription.Text = "";
            txtnom.Text = "";
            txtpx_achat.Text = "";
            txtpx_vente.Text = "";
            txtqtealerte.Text = "";
            txtqtestock.Text = "";
            txtsearch.Text = "";
        }
        private void Verifier_Roles()
        {
            user = (string)(Session["Login"]);
            Utilisateur util = null;
            try
            {
                util = UtilisateurControleur.Verifier_Roles(user, "ModifierArticle.aspx");
                if (util != null)
                {
                    user = (string)Session["Login"];
                    TraceSystem tr = new TraceSystem(user, "Rechercher Article", DateTime.Now.ToString());
                    if (Request.QueryString["num"] != null)
                    {
                        num = Request.QueryString["num"].ToString().Trim();
                        Rechercher(num);
                        txtsearch.Text = num;
                    }
                    Master.ContentTextBoxOfMasterPage = user;
                }
                else
                {
                    Response.Redirect("../Erreur.aspx");
                }
            }
            catch (Exception ex)
            {
                lblsms.Text = ex.Message;
                lblsms.ForeColor = System.Drawing.Color.Red;
            }
        }
        public void Verifier_Session()
        {
            #region Verifier connexion
            ConnexionUser conse = null;
            try
            {
                conse = ConnexionUserControleur.Verifier_Session(user);
                if (conse == null)
                {
                    Server.Transfer("../Login.aspx");
                }
                else
                {
                    Verifier_Roles();
                }
            }
            catch (Exception)
            {

            }
            #endregion
        }
        protected void Link_Image_Button(object sender, EventArgs e)
        {
            Response.Clear();
            byte[] documents = (byte[])art.Contenu_image;
            Response.ContentType="image article";
            Response.AddHeader("Content disposition", string.Format("attachment; filename={0}", art.Nom_article));
            Response.BinaryWrite(documents);
            Response.Flush();
            Response.Close();
        }
        private void Rechercher(string num)
        {
            TraceSystem tra = new TraceSystem(user, "Recherche article", DateTime.Now.ToString());
            try
            {
                art = articleControleur.Rechercher_article_Code(num, tra);
                if(art!=null)
                {
                    txtcode.Text = art.Code_article;
                    txtdescription.Text = art.Description_article;
                    txtnom.Text = art.Nom_article;
                    txtpx_achat.Text = Convert.ToString(art.Px_achat);
                    txtpx_vente.Text = Convert.ToString(art.Px_vente);
                    txtqtealerte.Text = Convert.ToString(art.Qte_alerte);
                    txtqtestock.Text = Convert.ToString(art.Qte_enstock);
                    lblimage.Text = art.Nom_article;
                    Nom_Categorie(art.Id_categorie);
                    Nom_Fournisseur(art.Id_four);
                    prix_achat = art.Px_achat;
                    prix_vente = art.Px_vente;
                }
                else
                {
                    lblsms.Text = "Aucun resultat trouve";
                }
            }
            catch (Exception ex)
            {
                lblsms.Text = "Erreur! " + ex.Message;
                lblsms.ForeColor = System.Drawing.Color.Red;
            }
        }
        public void ID_Fournisseur()
        {
            Fournisseur four = null;
            try
            {
                four = FournisseurControleur.Rechercher_Fournisseur_Nom(ddlfournisseur.Text.Trim());
                if (four != null)
                {
                    id_four = four.ID_fournisseur;
                }
                else
                {
                    lblsms.Text = "ID fournisseur introuvable !";
                    lblsms.ForeColor = System.Drawing.Color.Orange;
                }
            }
            catch (Exception ex)
            {
                lblsms.Text = "Erreur! " + ex.Message;
                lblsms.ForeColor = System.Drawing.Color.Red;
            }
        }
        public void Nom_Fournisseur( int id)
        {
            Fournisseur four = null;
            try
            {
                four = FournisseurControleur.Rechercher_Fournisseur_Id(id);
                if (four != null)
                {
                    ddlfournisseur.SelectedValue = four.Representant;
                }
                else
                {
                    lblsms.Text = "Nom fournisseur introuvable !";
                    lblsms.ForeColor = System.Drawing.Color.Orange;
                }
            }
            catch (Exception ex)
            {
                lblsms.Text = "Erreur! " + ex.Message;
                lblsms.ForeColor = System.Drawing.Color.Red;
            }
        }
        public void ID_Categorie()
        {
            categorie cat = null;
            try
            {
                cat = categorieControleur.Rechercher_categorie(ddlcategorie.Text.Trim());
                if (cat != null)
                {
                    id_cat = cat.Id_categorie;
                }
                else
                {
                    lblsms.Text = "ID categorie introuvable !";
                    lblsms.ForeColor = System.Drawing.Color.Orange;
                }
            }
            catch (Exception ex)
            {
                lblsms.Text = "Erreur! " + ex.Message;
                lblsms.ForeColor = System.Drawing.Color.Red;
            }
        }
        public void Nom_Categorie(int id)
        {
            categorie cat = null;
            try
            {
                cat = categorieControleur.Rechercher_categorie_Id(id);
                if (cat != null)
                {
                    ddlcategorie.SelectedValue = cat.Nom_categorie;
                }
                else
                {
                    lblsms.Text = "Nom categorie introuvable !";
                    lblsms.ForeColor = System.Drawing.Color.Orange;
                }
            }
            catch (Exception ex)
            {
                lblsms.Text = "Erreur! " + ex.Message;
                lblsms.ForeColor = System.Drawing.Color.Red;
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            user = (string)Session["Login"];
            if (user != null)
            {
               Verifier_Session();
            }
            else
            {
                Response.Redirect("../Login.aspx");
             }
        }
        protected void btnanuler_Click(object sender, EventArgs e)
        {
            Vider();
        }
        public void Modifier_Article_image()
        {
            int result = 0;
            string filePath = FileUpload1.PostedFile.FileName;
            string nom_img = Path.GetFileName(filePath);
            string extn_img = Path.GetExtension(nom_img);
            byte[] document = FileUpload1.FileBytes;
            ID_Categorie();
            ID_Fournisseur();
            int qte_stock = Convert.ToInt32(txtqtestock.Text.Trim());
            int qte_alerte = Convert.ToInt32(txtqtealerte.Text.Trim());
            decimal px_achat = Convert.ToDecimal(txtpx_achat.Text.Trim());
            decimal px_vente = Convert.ToDecimal(txtpx_vente.Text.Trim());
            string date_en = DateTime.Now.ToString();
            rayon ray = new rayon(1, txtnom.Text.Trim(), DateTime.Now.ToString(), id_cat);
            TraceSystem tr = new TraceSystem(user, "Modification Article", DateTime.Now.ToString());
            art = new image_article(txtcode.Text.Trim(), txtnom.Text.Trim(), txtdescription.Text.Trim(), qte_stock, qte_alerte, id_cat, id_four, px_achat, px_vente, date_en, nom_img, extn_img, document);
            try
            {
                result = articleControleur.Modifier_article_tout(art, tr, ray);
                if (result > 0)
                {
                    lblsms.Text = "Succes! Modification effectuer";
                    lblsms.ForeColor = System.Drawing.Color.Green;
                    txtcode.Text = art.Code_article;
                    Vider();
                }
            }
            catch (Exception ex)
            {
                lblsms.Text = "Erreur! " + ex.Message;
                lblsms.ForeColor = System.Drawing.Color.Red;
            }
        }
        public void Modifier_Article_San_Article()
        {
            int result = 0;
            string filePath = FileUpload1.PostedFile.FileName;
            string nom_img = Path.GetFileName(filePath);
            string extn_img = Path.GetExtension(nom_img);
            byte[] document = FileUpload1.FileBytes;
            ID_Categorie();
            ID_Fournisseur();
            int qte_stock = Convert.ToInt32(txtqtestock.Text.Trim());
            int qte_alerte = Convert.ToInt32(txtqtealerte.Text.Trim());
            decimal px_achat = Convert.ToDecimal(txtpx_achat.Text.Trim());
            decimal px_vente = Convert.ToDecimal(txtpx_vente.Text.Trim());
            string date_en = DateTime.Now.ToString();
            rayon ray = new rayon(1, txtnom.Text.Trim(), DateTime.Now.ToString(), id_cat);
            TraceSystem tr = new TraceSystem(user, "Modification Article", DateTime.Now.ToString());
            art = new image_article(txtcode.Text.Trim(), txtnom.Text.Trim(), txtdescription.Text.Trim(), qte_stock, qte_alerte, id_cat, id_four, px_achat, px_vente, date_en, nom_img, extn_img, document);
            try
            {
                result = articleControleur.Modifier_article_San_Article_fournit(art, tr, ray);
                if (result > 0)
                {
                    lblsms.Text = "Succes! Modification effectuer";
                    lblsms.ForeColor = System.Drawing.Color.Green;
                    txtcode.Text = art.Code_article;
                    Vider();
                }
            }
            catch (Exception ex)
            {
                lblsms.Text = "Erreur! " + ex.Message;
                lblsms.ForeColor = System.Drawing.Color.Red;
            }
        }
        public void Modifier_Article()
        {
            int result = 0;
            string filePath = FileUpload1.PostedFile.FileName;
            string nom_img = Path.GetFileName(filePath);
            string extn_img = Path.GetExtension(nom_img);
            byte[] document = FileUpload1.FileBytes;
            ID_Categorie();
            ID_Fournisseur();
            int qte_stock = Convert.ToInt32(txtqtestock.Text.Trim());
            int qte_alerte = Convert.ToInt32(txtqtealerte.Text.Trim());
            decimal px_achat = Convert.ToDecimal(txtpx_achat.Text.Trim());
            decimal px_vente = Convert.ToDecimal(txtpx_vente.Text.Trim());
            string date_en = DateTime.Now.ToString();
            rayon ray = new rayon(1, txtnom.Text.Trim(), DateTime.Now.ToString(), id_cat);
            TraceSystem tr = new TraceSystem(user, "Modification Article", DateTime.Now.ToString());
            art = new image_article(txtcode.Text.Trim(), txtnom.Text.Trim(), txtdescription.Text.Trim(), qte_stock, qte_alerte, id_cat, id_four, px_achat, px_vente, date_en, nom_img, extn_img, document);
            try
            {
                result = articleControleur.Modifier_article_(art, tr, ray);
                if (result > 0)
                {
                    lblsms.Text = "Succes! Modification effectuer";
                    lblsms.ForeColor = System.Drawing.Color.Green;
                    txtcode.Text = art.Code_article;
                    Vider();
                }
            }
            catch (Exception ex)
            {
                lblsms.Text = "Erreur! " + ex.Message;
                lblsms.ForeColor = System.Drawing.Color.Red;
            }
        }
        protected void btnenregistrer_Click(object sender, EventArgs e)
        {
            if(FileUpload1.HasFiles)
            {
                if(prix_achat!=Convert.ToDecimal( txtpx_achat.Text.Trim() ) || prix_vente!=Convert.ToDecimal(txtpx_vente.Text.Trim()))
                {
                    Modifier_Article_San_Article();
                }
                else
                {
                    Modifier_Article_image();
                }
                
            }
            else
            {
                Modifier_Article();
            }
        }
        protected void BtnRechercher_Click(object sender, EventArgs e)
        {
            if(txtsearch.Text.Trim()!="")
            {
                Rechercher(txtsearch.Text.Trim());
            }
            else {
                lblsms.Text = "Attention! Vous devez siaisir l code de l'article";
                lblsms.ForeColor = System.Drawing.Color.Orange;
            }
        }
    }
}