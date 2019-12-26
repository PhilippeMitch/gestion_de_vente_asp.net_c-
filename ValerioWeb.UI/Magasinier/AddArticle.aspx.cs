using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ValerioWeb.Controleur;
using ValerioWeb.Domaine;

namespace ValerioWeb.UI.Responsable_des_Achats
{
    public partial class AddArticle : System.Web.UI.Page
    {
        string nom_user;
        int id_four;
        int id_cat;
        public void Verifier_Roles()
        {
            Utilisateur util = null;
            try
            {
                util = UtilisateurControleur.Verifier_Roles(nom_user, "AddArticle.aspx");
                if (util != null)
                {
                    Master.ContentTextBoxOfMasterPage = nom_user;
                }
                else
                {
                    Response.Redirect("../Erreur.aspx");
                }
            }
            catch (Exception ex)
            {
                lblsms.Text = "Erreur! "+ex.Message;
                lblsms.ForeColor = System.Drawing.Color.Red;
            }
        }
        public void Verifier_Session()
        {

            #region Verifier connexion
            ConnexionUser conse = null;
            try
            {
                conse = ConnexionUserControleur.Verifier_Session(nom_user);
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
        protected void Page_Load(object sender, EventArgs e)
        {
            nom_user = (string)Session["Login"];
            if (nom_user != null)
            {
               Verifier_Session();
            }
            else
            {
              Response.Redirect("../Login.aspx");
            }
        }     
        public void ID_Fournisseur()
        {
            Fournisseur four = null;
            try
            {
                four = FournisseurControleur.Rechercher_Fournisseur_Nom(ddlfournisseur.Text.Trim());
                if(four!=null)
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
        public void ID_Categorie()
        {
            categorie cat = null;
            try
            {
                cat = categorieControleur.Rechercher_categorie(ddlcategorie.Text.Trim());
                if(cat!=null)
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
        public void Voder()
        {
            txtcode.Text = "";
            txtdescription.Text = "";
            txtnom.Text = "";
            txtpx_achat.Text = "";
            txtpx_vente.Text = "";
            txtqtealerte.Text = "";
            txtqtealerte.Text = "";
        }  
        public void Enregistrer_Article()
        {
            int result = 0;
            string filePath = FileUpload1.PostedFile.FileName;
            string nom_img = Path.GetFileName(filePath);
            string extn_img = Path.GetExtension(nom_img);
            byte[] document = FileUpload1.FileBytes;

            int qte_stock = Convert.ToInt32(txtqtestock.Text);
            int qte_alerte = Convert.ToInt32(txtqtealerte.Text);
            decimal px_achat = Convert.ToDecimal(txtpx_achat.Text);
            decimal px_vente = Convert.ToDecimal(txtpx_vente.Text);
            string date_en = DateTime.Now.ToString();
            
            ID_Categorie();
            ID_Fournisseur();
            rayon ray = new rayon(txtnom.Text.Trim(), date_en, id_cat, 1);
            TraceSystem tr = new TraceSystem("Mitch", "Enregistrement Article", date_en);
            image_article art = new image_article(txtnom.Text.Trim(), txtdescription.Text.Trim(), qte_stock, qte_alerte, id_cat, id_four, px_achat, px_vente,date_en, nom_img, extn_img,document);
            try
            {
                result = articleControleur.Enregistre_article(art, tr, ray);
                if(result>0)
                {
                    lblsms.Text = "Succes! Enregistrement effectuer";
                    lblsms.ForeColor = System.Drawing.Color.Green;
                    txtcode.Text = art.Code_article;
                    Voder();
                }
            }
            catch (Exception ex)
            {
                lblsms.Text = "Erreur! " + ex.Message;
                lblsms.ForeColor = System.Drawing.Color.Red;
            }
        }
        public void Verifier_Article()
        {
            article art = null;
            try
            {
                art=articleControleur.Verifier_Article(txtnom.Text.Trim(),txtdescription.Text.Trim());
                if(art!=null)
                {
                    lblsms.Text = "Attention! ce produit existe deja";
                    lblsms.ForeColor = System.Drawing.Color.Orange;
                }
                else
                {
                    Enregistrer_Article();
                }
            }
            catch (Exception ex)
            {
               lblsms.Text = "Erreur! " + ex.Message;
               lblsms.ForeColor = System.Drawing.Color.Red;
            }
        }
        protected void BtnEnregistrer_Click(object sender, EventArgs e)
        {
            Verifier_Article(); 
        }
        protected void BtnAnnuler_Click(object sender, EventArgs e)
        {
            Voder();
        }
    }
}