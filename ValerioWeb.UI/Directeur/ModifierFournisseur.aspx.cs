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
    public partial class ModifierFournisseur : System.Web.UI.Page
    {
        string num;
        public string user;
        public void Vider()
        {
            txtnomfour.Text = "";
            txtmail.Text = "";
            txtnumero.Text = "";
            txtpaysfour.Text = "";
            txtphone.Text = "";
            txtregionfour.Text = "";
            txtrepresentant.Text = "";
            txtruefour.Text = "";
            txtvilefour.Text = "";
            txtidrech.Text = "";
            txtidrech.Text = "";
        }
        private void Verifier_Roles()
        {
            user = (string)(Session["Login"]);
            Utilisateur util = null;
            try
            {
                util = UtilisateurControleur.Verifier_Roles(user, "ModifierFournisseur.aspx");
                if (util != null)
                {
                    user = (string)Session["Login"];
                    lbluser.Text = user;
                    TraceSystem tr = new TraceSystem(user, "Rechercher Fournisseur", DateTime.Now.ToString());
                    if (Request.QueryString["num"] != null)
                    {
                        num = Request.QueryString["num"].ToString().Trim();
                        Rechercher(num, tr);
                    }
                    Master.ContentTextBoxOfMasterPage = user;
                }
                else
                {
                    Response.Redirect("Erreur.aspx");
                }
            }
            catch (Exception ex)
            {
                lblmessage.Text = ex.Message;
                lblmessage.ForeColor = System.Drawing.Color.Red;
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
        private void Rechercher(string num,TraceSystem tr)
        {           
            try
            {
                AdresseFournisseur fr = FournisseurControleur.Rechercher_Fournisseur_Adresse(num, tr);
                if (fr != null)
                {
                    lblmessage.Text = " Fournisseur retrouve !";
                    lblmessage.ForeColor = System.Drawing.Color.Green;
                    txtnomfour.Text = fr.Nom_fournisseur;
                    txtmail.Text = fr.E_mail;
                    txtnumero.Text = fr.Numero;
                    txtpaysfour.Text = fr.Pays;
                    txtphone.Text = fr.Telephone;
                    txtregionfour.Text = fr.Region;
                    txtrepresentant.Text = fr.Representant;
                    txtruefour.Text = fr.Rue;
                    txtvilefour.Text = fr.Ville;
                    txtidrech.Text = num;
                    lbldat.Text = fr.Date_ajout;
                    lblidAd.Text = Convert.ToString( fr.Id_adresse);
                }
                else
                {
                    lblmessage.Text = "Aucun fournisseur ne correspond au nom saisi !";
                    lblmessage.ForeColor = System.Drawing.Color.Orange;
                }
            }
            catch (Exception ex)
            {
                lblmessage.Text = ex.Message;
                lblmessage.ForeColor = System.Drawing.Color.Red;
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
        protected void btnReh_Click(object sender, EventArgs e)
        {
            if(txtidrech.Text.Trim()!=null)
            {
                TraceSystem tr = new TraceSystem("Mitch", "Rechercher Fournisseur", DateTime.Now.ToString());
                Rechercher(txtidrech.Text.Trim(), tr);
            }
        }
        protected void btnanuler_Click(object sender, EventArgs e)
        {
            Vider();
        }
        protected void btnenregistrer_Click(object sender, EventArgs e)
        {
            int result = 0;
           Fournisseur four = new Fournisseur(txtnomfour.Text.Trim(),txtrepresentant.Text.Trim(),txtmail.Text.Trim(),txtphone.Text.Trim(),lbldat.Text.Trim(),Convert.ToInt32(lblidAd.Text.Trim()),1);
           TraceSystem tra = new TraceSystem(lbluser.Text.Trim(), "Modification Fournisseur", DateTime.Now.ToString());
            Adresse ad = new Adresse(txtpaysfour.Text.Trim(), txtvilefour.Text.Trim(), txtregionfour.Text.Trim(), txtruefour.Text.Trim(), txtnumero.Text.Trim());
            try
            {
               result = FournisseurControleur.Modifier_Fournisseur_Adresse(four,ad, tra);
                if(result>0)
                {
                    lblmessage.Text = "Modification effectuee !";
                    lblmessage.ForeColor = System.Drawing.Color.Green;
                    Vider();
                }
            }
            catch (Exception ex)
            {
                lblmessage.Text = ex.Message;
                lblmessage.ForeColor = System.Drawing.Color.Red;
            }
        }
    }
}