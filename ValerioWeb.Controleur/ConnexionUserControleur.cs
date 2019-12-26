using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ValerioWeb.DAL;
using ValerioWeb.Domaine;

namespace ValerioWeb.Controleur
{
    public class ConnexionUserControleur
    {
        public static int Enregistrer_Connexion_Utilisateur(ConnexionUser conect,TraceSystem tr)
        {
            int result = 0;
            try
            {
                result = ConnexionUserDal.Enregistrer_Connexion(conect, tr);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return result;
        }
        public static int Supprimer_Connexion_Utilisateur(ConnexionUser conect, TraceSystem tr)
        {
            int result = 0;
            try
            {
                result = ConnexionUserDal.Supprimer_Connexion(conect, tr);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return result;
        }
        public static BindingList<ConnexionUser> ListeConnexion(TraceSystem tr)
        {
            BindingList<ConnexionUser> Lstconnexion = null;
            try
            {
                Lstconnexion = ConnexionUserDal.List_Connexion(tr);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return Lstconnexion;
        }
        public static ConnexionUser Connexion(string nom,string pass)
        {
            ConnexionUser connex = null;
            try
            {
                connex = ConnexionUserDal.Connexion(nom,pass);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
           }
            return connex;
        }
        public static ConnexionUser Verifier_Session(string nom)
        {
            ConnexionUser connex = null;
            try
            {
                connex = ConnexionUserDal.Verifier_Session(nom);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return connex;
        }
    }
}
