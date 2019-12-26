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
    public partial class AddFournisseur : System.Web.UI.Page
    {
        string nom_user;
        protected void BtnAnnuler_Click(object sender, EventArgs e)
        {
            txtid.Text = "";
            txtmail.Text = "";
            txtnomfour.Text = "";
            txtnomfour.Text = "";
            txtnumero.Text = "";
            txtpaysfour.Text = "";
            txtphone.Text = "";
            txtregionfour.Text = "";
            txtrepresentant.Text = "";
            txtruefour.Text = "";
            txtvilefour.Text = "";
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
        public void Verifier_Roles()
        {
            Utilisateur util = null;
            try
            {
                util = UtilisateurControleur.Verifier_Roles(nom_user, "AddFournisseur.aspx");
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
        protected void btnenregistrer_Click(object sender, EventArgs e)
        {
            Adresse adr = new Adresse(txtpaysfour.Text, txtvilefour.Text, txtregionfour.Text, txtruefour.Text,txtnumero.Text);
            Fournisseur four = new Fournisseur(txtnomfour.Text, txtrepresentant.Text, txtmail.Text, txtphone.Text, DateTime.Now.ToString(), adr.Id_adresse,1);
            TraceSystem tr = new TraceSystem(nom_user, "Isertion Fournisseur", DateTime.Now.ToString());
            int res = 0;
            try
           {
                res = FournisseurControleur.Enregistrer_Fournisseur(four, adr, tr);
                if(res>0)
                {
                    lblmessage.ForeColor = System.Drawing.Color.Green;
                    lblmessage.Text = "Enregistrement Effectuee !";
                }
            }
            catch (Exception ex)
            {
                lblmessage.ForeColor = System.Drawing.Color.Red;
                lblmessage.Text = ex.Message;
           }
        }
    }
}