using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ValerioWeb.DAL;
using ValerioWeb.Domaine;

namespace ValerioWeb.Controleur
{
    public class TraceSystemControleur
    {
        public static int Enregistrer_Trace(TraceSystem tr)
        {
            int result = 0;
            try
            {
                result = TraceSystemDal.Enregistrer_Trace(tr);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return result;
        }
    }
}
