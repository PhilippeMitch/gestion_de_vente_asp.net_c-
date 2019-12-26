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
    public partial class Model : System.Web.UI.MasterPage
    {
        
        protected void Page_Load(object sender, EventArgs e)
        {
           
        }
        public string ContentTextBoxOfMasterPage
        {
            get { return lbluser.Text; }
            set { lbluser.Text = value; }
        }
        public void Deconnect_Click(object sender, EventArgs e)
        {
            int result = 0;
            ConnexionUser co = new ConnexionUser(lbluser.Text.Trim(),"","");
            TraceSystem tr = new TraceSystem(lbluser.Text.Trim(), "Deconnexion", DateTime.Now.ToString());
            try
            {
                result = ConnexionUserControleur.Supprimer_Connexion_Utilisateur(co,tr);
                if(result>0)
                {
                    Session.Clear();
                    Session["Login"] = null;
                    Response.Redirect("Login.aspx");
                }
            }
            catch (Exception ex)
            {
                lbluser.Text = ex.Message;
            }
            
        }

    }
}