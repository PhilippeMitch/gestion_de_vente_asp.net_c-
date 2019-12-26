using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ValerioWeb.Domaine;
using ValerioWeb.DAL;

namespace ValerioWeb.Controleur
{
    public class entrepotControleur
    {
        public static int Enregistrer_entrepot(entrepot ent,TraceSystem tr)
        {
            int result = 0;
            try
            {
                result = entrepotDal.Enregistrer_Depot(ent, tr);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return result;
        }
        public static entrepot Recrcher_entrepot(string nom)
        {
            entrepot ent = null;
            try
            {
                ent = entrepotDal.Rechercher_entrepot(nom);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return ent;
        }
        public static int Modifier_entrepot(entrepot ent,TraceSystem tr,int id)
        {
            int result = 0;
            try
            {
                result = entrepotDal.Modifier_entrepot(ent, tr,id);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return result;
        }
    }
}
