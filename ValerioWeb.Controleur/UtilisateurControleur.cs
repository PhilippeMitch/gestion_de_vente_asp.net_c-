using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ValerioWeb.DAL;
using ValerioWeb.Domaine;

namespace ValerioWeb.Controleur
{
    public class UtilisateurControleur
    {
        public static int Enregistrer_Utilisateur(Utilisateur util,TraceSystem tr)
        {
            int result = 0;
            try
            {
                result = UtilisateurDal.Enregistrer_User(util, tr);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return result;
        }
        public static int Modifier_Utilisateur(Utilisateur util, TraceSystem tr)
        {
            int result = 0;
            try
            {
                result = UtilisateurDal.Modifier_user(util, tr);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return result;
        }
        public static Utilisateur Rechercher_Utilisateur(string nom_user,TraceSystem tr)
        {
            Utilisateur util = null;
            try
            {
                util = UtilisateurDal.Rechercher_Utilisateur(nom_user, tr);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
                return util;
        }
        public static Utilisateur Verifier_Roles(string nom_user, string nom_page)
        {
            Utilisateur util = null;
            try
            {
                util = UtilisateurDal.Verifier_Roles_Utilisateur(nom_user, nom_page);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return util;
        }
    }
}
