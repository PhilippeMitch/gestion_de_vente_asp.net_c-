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
    public partial class ListerVente : System.Web.UI.Page
    {
        string num1;
        protected void Page_Load(object sender, EventArgs e)
        {
            ListeVente();
            if (Request.QueryString["num"] != null)
            {
                num1 = Request.QueryString["num"].ToString().Trim();
                Rechercher(Convert.ToInt32(num1));
            }
        }
        private void Rechercher(int num_v)
        {
            try
            {
                DataTable dt = new DataTable();
                dt = venteControleur.Lister_Contenu_Vente(num_v);
                if (dt != null)
                {
                    GridView2.DataSource = dt;
                    GridView2.DataBind();
                }
                else
                {
                    lblmessage.Text = "Aucun fournisseur ne correspond au nom saisi!";
                    lblmessage.ForeColor = System.Drawing.Color.Orange;
                }
            }
            catch (Exception ex)
            {
                lblmessage.Text = ex.Message;
                lblmessage.ForeColor = System.Drawing.Color.Red;
            }
        }
        public void ListeVente()
        {
            TraceSystem tr = new TraceSystem("Mitch", "Lister Vente", DateTime.Now.ToString());
            try
            {
                DataTable dt = new DataTable();
                dt = venteControleur.Lister_Vente(tr);
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
    }
}