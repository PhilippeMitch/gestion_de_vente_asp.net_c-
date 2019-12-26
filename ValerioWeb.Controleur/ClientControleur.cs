using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ValerioWeb.Domaine;
using ValerioWeb.DAL;
using System.Data;

namespace ValerioWeb.Controleur
{
    public class ClientControleur
    {
        public static int Enregistrer_Client(AdresseClient cli,TraceSystem tr)
        {
            int result = 0;
            try
            {
                result = ClientDal.Enregistrer_Client(cli, tr);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return result;
        }
        public static DataTable Rechercher_Client_Nom(string nom,TraceSystem tr)
        {
            DataTable lstclient = new DataTable();
            try
            {
                lstclient = ClientDal.Rechercher_Client_Nom(nom, tr);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return lstclient;
        }
        public static AdresseClient Rechercher_Client_Num(int num, TraceSystem tr)
        {
            AdresseClient cli = null;
            try
            {
                cli = ClientDal.Rechercher_Client_Num(num, tr);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return cli;
        }
        public static int Modifier_Client(AdresseClient cli, TraceSystem tr)
        {
            int result = 0;
            try
            {
                result = ClientDal.Modifier_Client(cli, tr);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return result;
        }
    }
}
