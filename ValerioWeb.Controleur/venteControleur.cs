using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ValerioWeb.DAL;
using ValerioWeb.Domaine;

namespace ValerioWeb.Controleur
{
    public class venteControleur
    {
        public static int Enregistrer_vente(vente vt,StringCollection sc,Client cli, TraceSystem tr)
        {
            int result = 0;
            try
            {
                result = venteDal.Enregistrer_Vente(vt,sc, cli,tr);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return result;
        }
        public static DataTable Lister_Vente(TraceSystem trace)
        {
            DataTable lstvente = new DataTable();
            try
            {
                lstvente = venteDal.Lister_Vente(trace);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return lstvente;
        }
        public static DataTable Lister_Contenu_Vente(int num)
        {
            DataTable lstcontenu = new DataTable();
            try
            {
                lstcontenu = venteDal.Lister_Contenu_Vente(num);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return lstcontenu;
        }
    }
}
