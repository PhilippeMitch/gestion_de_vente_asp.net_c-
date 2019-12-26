using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ValerioWeb.Domaine;
using ValerioWeb.DAL;

namespace ValerioWeb.Controleur
{
    public class categorieControleur
    {
        public static int Enregistre_categorie(categorie cat,TraceSystem tr)
        {
            int result = 0;
            try
            {
                result = categorieDal.Enrefistrer_categorie(cat, tr);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return result;
        }
        public static categorie Rechercher_categorie(string nom)
        {
            categorie cat = null;
            try
            {
                cat = categorieDal.Rechercher_categorie(nom);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return cat;
        }
        public static categorie Rechercher_categorie_Id(int num)
        {
            categorie cat = null;
            try
            {
                cat = categorieDal.Rechercher_categorie_Id(num);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return cat;
        }
        public static int Modifier_categorie(categorie cat,TraceSystem tr,int id)
        {
            int result = 0;
            try
            {
                result = categorieDal.Modifier_categorie(cat, tr, id);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return result;
        }
    }
}
