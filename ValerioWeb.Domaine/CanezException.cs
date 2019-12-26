using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ValerioWeb.Domaine
{
    public class CanezException : Exception
    {
        private int numero;

        public int Numero
        {
            get { return numero; }
            set { numero = value; }
        }

        public CanezException(int numero,string sms):base(sms)
        {
            Numero = numero;
        }
    }
}
