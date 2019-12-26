using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ValerioWeb.Domaine;
using ValerioWeb.DAL;
using System.Threading.Tasks;

namespace ValerioWeb.Controleur
{
    public class rayonControleur
    {
        public static int Enregistrer_Rayon(rayon ray,TraceSystem tr)
        {
            int resul = 0;
            try
            {
                resul = rayonDal.Enregistrer_Rayon(ray,tr);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return resul;
        }
        public static rayon Rechercher_Rayon(string nom)
        {
            rayon ray = null;
            try
            {
                ray = rayonDal.Rechercher_Rayon(nom);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return ray;
        }
        public static int Modifier_Rayon(rayon ray,TraceSystem tr)
        {
            int result = 0;
            try
            {
                result = rayonDal.Enregistrer_Rayon(ray, tr);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return result;
        }
    }
}
