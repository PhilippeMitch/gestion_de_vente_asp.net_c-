using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ValerioWeb.Controleur;
using ValerioWeb.Domaine;

namespace ValerioWeb.UI
{
    public partial class Login : System.Web.UI.Page
    {
        string password;
        string ip_us;
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }
        private void Enregistrer_conexion()
        {
            string userHost = Dns.GetHostName();
            //Adresse IP
            ip_us = Dns.GetHostEntry(userHost).AddressList[0].ToString();
            ConnexionUser us = new ConnexionUser(txtnom.Text,ip_us,DateTime.Now.ToString());
            TraceSystem tr = new TraceSystem(txtnom.Text.Trim(),"Connexion",DateTime.Now.ToString());
            int result;
            try
            {
                result = ConnexionUserControleur.Enregistrer_Connexion_Utilisateur(us,tr);
                if(result>0)
                {
                    Response.Redirect("Default.aspx");
                }
            }
            catch (Exception ex)
            {
                lblsms.Text = ex.Message;
            }
        }
        private void CripterPassword(string pass)
        {
            HashAlgorithm algorithm = new SHA1Managed();
            string reslt = "";
            using (algorithm)
            {
                byte[] bytes = Encoding.UTF32.GetBytes(pass);
                reslt = BitConverter.ToString(algorithm.ComputeHash(bytes));
            }
            SHA1CryptoServiceProvider sha1 = new SHA1CryptoServiceProvider();
            byte[] b;
            byte[] r;
            b = System.Text.Encoding.UTF8.GetBytes(reslt);
            r = sha1.ComputeHash(b);
            sha1.Clear();
            password = Convert.ToBase64String(r);
        }
        public void Verifier_Session()
        {
            #region Verifier connexion
            ConnexionUser conse = null;
            try
            {
                conse = ConnexionUserControleur.Verifier_Session(txtnom.Text.Trim());
                if(conse==null)
                {
                    Session["Login"] = txtnom.Text;
                    Enregistrer_conexion();                   
                }
                else
                {
                    lblsms.Text = "Erreur Contacter l'administrateur !";
                    lblsms.ForeColor = System.Drawing.Color.Red;
                }
            }
            catch (Exception ex)
            {
               lblsms.ForeColor = System.Drawing.Color.Red;
               lblsms.Text = ex.Message;
            }
            #endregion
        }
        public void Connexion()
        {
            #region  connexion
            ConnexionUser cone = null;
            CripterPassword(txtpass.Text.Trim());
            try
            {
                cone = ConnexionUserControleur.Connexion(txtnom.Text.Trim(), password);
                if (cone != null)
                {
                    Verifier_Session();
                }
                else
                {
                    lblsms.Text = "Nom Urilisateur ou Mot de Passe incorrect !";
                    lblsms.ForeColor = System.Drawing.Color.Orange;
                }
            }
            catch (Exception ex)
            {
                lblsms.Text = ex.Message;
                lblsms.ForeColor = System.Drawing.Color.Red;
            }
            #endregion
        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            Connexion();    
        }
    }
}