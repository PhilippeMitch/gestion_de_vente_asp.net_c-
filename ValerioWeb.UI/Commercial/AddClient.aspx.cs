using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ValerioWeb.Controleur;
using ValerioWeb.Domaine;

namespace ValerioWeb.UI.Commercial
{
    public partial class AddClient : System.Web.UI.Page
    {
        string nom_user;
        public void Annuler()
        {
            txtcin.Text = "";
            txtmail.Text = "";
            txtnomclient.Text = "";
            txtnum.Text = "";
            txtpays.Text = "";
            txtprenomclient.Text = "";
            txtregion.Text = "";
            txtrue.Text = "";
            txttelf.Text = "";
            txtnif.Text = "";
            txtvile.Text = "";
        }
        protected void BtnAnnuler_Click(object sender, EventArgs e)
        {
            Annuler();
        }
        public void Verifier_Roles()
        {
            Utilisateur util = null;
            try
            {
                util = UtilisateurControleur.Verifier_Roles(nom_user, "AddClient.aspx");
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
        protected void Rdbcin_CkeckChange(object sender, EventArgs e)
        {
            if (rdbcin.Checked == true)
            {
                txtcin.Visible = true;
                txtnif.Visible = false;
                RequiredFieldValidatorCin.ValidationGroup = "valide";
                RegularExpressionCin.ValidationGroup = "valide";
            }
            else
            {
                txtcin.Visible = false;
                txtnif.Visible = true;
                RequiredFieldValidatorNif.ValidationGroup = "noValide";
                RegularExpressionNif.ValidationGroup = "noValide";
            }

        }
        protected void Rdbnif_CkeckChange(object sender, EventArgs e)
        {
            if (rdbnif.Checked == true)
            {
                RequiredFieldValidatorNif.ValidationGroup = "valide";
                RegularExpressionNif.ValidationGroup = "valide";
                txtcin.Visible = false;
                txtnif.Visible = true;
            }
            else
            {
                RequiredFieldValidatorCin.ValidationGroup = "novalide";
                RegularExpressionCin.ValidationGroup = "novalide";
                txtcin.Visible = true;
                txtnif.Visible = false;
            }
        }
        protected void btnenregistrer_Click(object sender, EventArgs e)
        {
            string identifiant;
            if (rdbcin.Checked == true)
            {
                identifiant = txtcin.Text.Trim();
            }
            else
            {
                identifiant = txtnif.Text.Trim();
            }
            AdresseClient cli = new AdresseClient(txtpays.Text.Trim(), txtvile.Text.Trim(), txtregion.Text.Trim(), txtrue.Text.Trim(), txtnum.Text.Trim(), txtnomclient.Text.Trim(), txtprenomclient.Text.Trim(), identifiant, txttelf.Text.Trim(), txtmail.Text.Trim(), DateTime.Now.ToString());
            TraceSystem tr = new TraceSystem(nom_user, "Enregistrement client", DateTime.Now.ToString());
            int res = 0;
            try
            {
                res = ClientControleur.Enregistrer_Client(cli, tr);
                if (res > 0)
                {
                    lblmessage.ForeColor = System.Drawing.Color.Green;
                    lblmessage.Text = "Succes !";
                    Annuler();
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
