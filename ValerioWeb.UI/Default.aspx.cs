using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ValerioWeb.Controleur;
using ValerioWeb.Domaine;

namespace ValerioWeb.UI
{
    public partial class Default : System.Web.UI.Page
    {
        string nom_;
        public void Verifier_Session()
        {
            #region Verifier connexion
            ConnexionUser conse = null;
            try
            {
                conse = ConnexionUserControleur.Verifier_Session(nom_);
                if (conse == null)
                {
                    Server.Transfer("Login.aspx");
                }
                else
                {
                    Master.ContentTextBoxOfMasterPage = nom_;
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
               Response.Redirect("Login.aspx");
            }
         
        }
    }
}