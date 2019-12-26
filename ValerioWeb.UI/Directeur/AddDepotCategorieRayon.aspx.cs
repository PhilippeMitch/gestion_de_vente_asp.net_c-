using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ValerioWeb.Controleur;
using ValerioWeb.Domaine;

namespace ValerioWeb.UI.Directeur
{
    public partial class AddDepot : System.Web.UI.Page
    {
        string nom_user;
        string id_cat;
        string id_depot;
        protected void Lblenregistrer_Rayon_Click(object sender, EventArgs e)
        {
            ID_Categorie();
            int result = 0;
            rayon ray = new rayon(txtnomrayon.Text.Trim(), DateTime.Now.ToString(), Convert.ToInt32(id_cat), 1);
            TraceSystem tr = new TraceSystem(nom_user, "Enregistrement Rayon", DateTime.Now.ToString());
            try
            {
                result = rayonControleur.Enregistrer_Rayon(ray, tr);
                if(result>0)
                {
                    lblrayon.Text = "Insertion effectuee !";
                    lblrayon.ForeColor = System.Drawing.Color.Green;
                    txtnomrayon.Text = "";
                }
            }
            catch (Exception ex)
            {
                lblrayon.Text = ex.Message;
                lblrayon.ForeColor = System.Drawing.Color.Red;
            }
        }
        protected void LblenAnuler_Rayon_Click(object sender, EventArgs e)
        {
            txtidrayon.Text = "";
            txtnomrayon.Text = "";
        }
        protected void Lblenregistrer_Categorie_Click(object sender,EventArgs e)
        {           
            categorie cat = null;
            try
            {
                cat = categorieControleur.Rechercher_categorie(txtnomcategorie.Text.Trim());
                if(cat!=null)
                {
                    lblsmscategorie.Text = "Ce categorie saisi existe deja !";
                    lblsmscategorie.ForeColor = System.Drawing.Color.Orange;
                }
                else { Enregistrer_categories(); }
            }
            catch (Exception ex)
            {
                lblsmscategorie.Text = ex.Message;
                lblsmscategorie.ForeColor = System.Drawing.Color.Red;
            }
        }
        protected void LblanulerCategorie_Click(object sender,EventArgs e)
        {
            txtidcategorie.Text = "";
            txtnomcategorie.Text = "";
        }
        protected void LblanulerDepot_Click(object sender,EventArgs e)
        {
            txtidentrepot.Text = "";
            txtnondepot.Text = "";
        }
        public void Enregistrer_depot()
        {
            int result = 0;
            entrepot ent = new entrepot(txtnondepot.Text.Trim(), DateTime.Now.ToString(), 1);
            TraceSystem tr = new TraceSystem(nom_user, "Enregistrement entrepot", DateTime.Now.ToString());
            try
            {
                result = entrepotControleur.Enregistrer_entrepot(ent, tr);
                if(result>0)
                {
                    lblsmsentrepot.Text = "Insertion effectuee !";
                    lblsmsentrepot.ForeColor = System.Drawing.Color.Green;
                    txtnondepot.Text = "";
                }
            }
            catch (Exception ex)
            {
                lblsmsentrepot.Text = ex.Message;
                lblsmsentrepot.ForeColor = System.Drawing.Color.Red;
            }
        }
        public void Enregistrer_categories()
        {
            ID_Entrepot();
            int result = 0;
            categorie cat = new categorie(txtnomcategorie.Text.Trim(), DateTime.Now.ToString(), Convert.ToInt32(id_depot), 1);
            TraceSystem tr = new TraceSystem(nom_user, "Enregistrement categorie", DateTime.Now.ToString());
            try
            {
                result = categorieControleur.Enregistre_categorie(cat, tr);
                if (result > 0)
                {
                    txtidcategorie.Text = cat.Id_categorie.ToString();
                    lblsmscategorie.Text = "Insertion effectuee !";
                    lblsmscategorie.ForeColor = System.Drawing.Color.Green;
                    txtnomcategorie.Text = "";
                }
            }
            catch (Exception ex)
            {
                lblsmscategorie.Text = ex.Message;
                lblsmscategorie.ForeColor = System.Drawing.Color.Red;
            }
        }
        protected void LblenregistrerDepo_Click(object sender,EventArgs e)
        {
            entrepot ent = null;
            try
            {
                ent = entrepotControleur.Recrcher_entrepot(txtnondepot.Text.Trim());
                if(ent!=null)
                {
                    lblsmsentrepot.Text = "Ce nom existe deja !";
                    lblsmsentrepot.ForeColor = System.Drawing.Color.Orange;
                }
                else
                {
                    Enregistrer_depot();
                }
            }
            catch (Exception ex)
            {
                lblsmsentrepot.Text = ex.Message;
                lblsmsentrepot.ForeColor = System.Drawing.Color.Red;
            }
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
        public void Verifier_Roles()
        {
            Utilisateur util = null;
            try
            {
                util = UtilisateurControleur.Verifier_Roles(nom_user, "AddDepotCategorieRayon.aspx");
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
                lblsmscategorie.Text = ex.Message;
                lblsmscategorie.ForeColor = System.Drawing.Color.Red;
            }
        }
        public void ID_Entrepot()
        {
            entrepot ent = null;
            try
            {
                ent = entrepotControleur.Recrcher_entrepot(ddlentrepot.Text.Trim());
                if (ent != null)
                {
                    id_depot = ent.Id_entrepot.ToString();
                }

            }
            catch (Exception ex)
            {
                lblsmscategorie.Text = ex.Message;
                lblsmscategorie.ForeColor = System.Drawing.Color.Red;
            }
        }
        public void ID_Categorie()
        {
            categorie cat = null;
            try
            {
                cat = categorieControleur.Rechercher_categorie(ddlcategorie.SelectedItem.ToString());
                if (cat != null)
                {
                    id_cat = cat.Id_categorie.ToString();
                }
            }
            catch (Exception ex)
            {
                lblrayon.Text = ex.Message;
                lblrayon.ForeColor = System.Drawing.Color.Red;
            }
        }
      
    }
}