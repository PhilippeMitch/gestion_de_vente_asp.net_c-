using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ValerioWeb.Controleur;
using ValerioWeb.Domaine;

namespace ValerioWeb.UI.Commercial
{
    public partial class ModifierClient : System.Web.UI.Page
    {
        string num1;
        public string user;
        int id_adresse;
        int id_client;
        public void Vider()
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
        private void Verifier_Roles()
        {
            user = (string)(Session["Login"]);
            Utilisateur util = null;
            try
            {
                util = UtilisateurControleur.Verifier_Roles(user, "ModifierClient.aspx");
                if (util != null)
                {
                    user = (string)Session["Login"];
                    if (IsPostBack)
                    {

                    }
                    else
                    {
                        TraceSystem tr = new TraceSystem("Mitch", "Rechercher Client", DateTime.Now.ToString());
                        if (Request.QueryString["num"] != null)
                        {
                            num1 = Request.QueryString["num"].ToString().Trim();
                            Rechercher_num(Convert.ToInt32(num1), tr);
                        }
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
        private void Rechercher_num(int num, TraceSystem tr)
        {
            string id;
            try
            {
                AdresseClient cli = ClientControleur.Rechercher_Client_Num(num, tr);
                if (cli != null)
                {
                    txtnomclient.Text = cli.Nom_client;
                    txtmail.Text = cli.Email;
                    txtnum.Text =cli.Numero;
                    txtprenomclient.Text = cli.Prenom_client;
                    txtpays.Text = cli.Pays;
                    txttelf.Text =cli.Tel;
                    txtregion.Text = cli.Region;
                    txtrue.Text = cli.Rue;
                    txtvile.Text = cli.Ville;
                    txtid.Text = Convert.ToString( num);
                    id = cli.Nif_Cin;
                    lblid.Text = cli.Id_client.ToString();
                    lbldat.Text = cli.Date_enregistrement;
                    id_client = cli.Id_client;
                    if(id.Length>13)
                    {
                        rdbcin.Checked = true;
                        rdbnif.Checked = false;
                        txtcin.Text = id;
                        txtcin.Visible = true;
                        txtnif.Visible = false;
                    }
                    else
                    {
                        rdbcin.Checked = false;
                        rdbnif.Checked = true;
                        txtnif.Text = id;
                        txtcin.Visible = false;
                        txtnif.Visible = true;
                    }
                }
                else
                {
                    lblmessage.Text = "Aucun client ne correspond a ce numero !";
                    lblmessage.ForeColor = System.Drawing.Color.Orange;
                }
            }
            catch (Exception ex)
            {
                lblmessage.Text = ex.Message;
                lblmessage.ForeColor = System.Drawing.Color.Red;
            }
        }
        private void Rechercher(string nom, TraceSystem tr)
        {
            try
            {
                DataTable dt = new DataTable();
                dt = ClientControleur.Rechercher_Client_Nom(nom, tr);
                if (dt != null)
                {
                    GridView1.DataSource = dt;
                    GridView1.DataBind();
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
        protected void BtnAnnuler_Click(object sender, EventArgs e)
        {
            Vider();
        }
        protected void BtnRechercher_Click(object sender, EventArgs e)
        {
            TraceSystem tr = new TraceSystem(user, "Rechercher Client", DateTime.Now.ToString());
            Rechercher(txtidrech.Text.Trim(), tr);
        }
        protected void BtnModifier_Click(object sender, EventArgs e)
        {
            string identifiant;
            num1 = null;
            if (txtcin.Text != "")
            {
                identifiant = txtcin.Text.Trim();
            }
            else
            {
                identifiant = txtnif.Text.Trim();
            }
            AdresseClient cli_ = new AdresseClient(id_adresse,Convert.ToInt32(lblid.Text), txtpays.Text.Trim(), txtvile.Text.Trim(), txtregion.Text.Trim(), txtrue.Text.Trim(), txtnum.Text.Trim(), txtnomclient.Text.Trim(), txtprenomclient.Text.Trim(), identifiant, txttelf.Text.Trim(), txtmail.Text.Trim(),lbldat.Text);
            TraceSystem tr = new TraceSystem(user, "Modification client", DateTime.Now.ToString());
            int res = 0;
            try
            {
                res = ClientControleur.Modifier_Client(cli_, tr);
                if (res > 0)
                {
                    lblmessage.ForeColor = System.Drawing.Color.Green;
                    lblmessage.Text = "Succes !";                  
                }
            }
            catch (Exception ex)
            {
                lblmessage.ForeColor = System.Drawing.Color.Red;
                lblmessage.Text = ex.Message;
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
    }
}