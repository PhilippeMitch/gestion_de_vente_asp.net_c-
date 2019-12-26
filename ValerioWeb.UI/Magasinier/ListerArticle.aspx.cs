using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ValerioWeb.Controleur;
using ValerioWeb.Domaine;

namespace ValerioWeb.UI.Magasinier
{
    public partial class ListerArticle : System.Web.UI.Page
    {
        string nom_;
        public void EnregistrerTrace()
        {
            #region Enregistrer trace
            TraceSystem tr = new TraceSystem(nom_, "Lister Article", DateTime.Now.ToString());
            int result = 0;
            try
            {
                result = TraceSystemControleur.Enregistrer_Trace(tr);
                if (result > 0)
                {
                    lblmessage.Text = "";
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
                util = UtilisateurControleur.Verifier_Roles(nom_, "ListerArticle.aspx");
                if (util != null)
                {
                    if (Page.IsPostBack == true)
                    {
                        Master.ContentTextBoxOfMasterPage = nom_;
                    }
                    else
                    {
                        EnregistrerTrace();
                        Master.ContentTextBoxOfMasterPage = nom_;
                    }
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
                conse = ConnexionUserControleur.Verifier_Session(nom_);
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
           nom_ = (string)Session["Login"];
           if (nom_ != null)
            {
                Verifier_Session();
            }
            else
            {
                Response.Redirect("../Login.aspx");
           }
        }
        public void HyperLink_Click(object sender, EventArgs e)
        {
            Response.Redirect("AddArticle.aspx");
        }
    }
}