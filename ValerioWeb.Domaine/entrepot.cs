using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ValerioWeb.Domaine
{
    public class entrepot
    {
        private int id_entrepot;
        private string nom_entrepot;
        private string date_enregistrement;
         private Byte active;
        public int Id_entrepot
        {
            get { return id_entrepot; }
            set { id_entrepot = value; }
        }
        public string Nom_entrepot
        {
            get { return nom_entrepot; }
            set { nom_entrepot = value; }
        }
        public string Date_enregistrement
        {
            get { return date_enregistrement; }
            set { date_enregistrement = value; }
        }
        public Byte Active
        {
            get { return active; }
            set { active = value; }
        }
        private string genCode()
        {
            Random ale = new Random();
            return string.Format("{0}{1}", ale.Next(0, 99), ale.Next(0, 999));
        }
        public entrepot(string nom_,string date_,Byte active_)
        {
            this.Id_entrepot = Convert.ToInt32(genCode());
            this.Nom_entrepot = nom_;
            this.Date_enregistrement = date_;
            this.Active = active;
        }
        public entrepot(int id, string nom_, string date_)
        {
            this.Id_entrepot = id;
            this.Nom_entrepot = nom_;
            this.Date_enregistrement = date_;
        }
    }
}
