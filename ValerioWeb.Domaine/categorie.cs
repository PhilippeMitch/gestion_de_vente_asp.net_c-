using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ValerioWeb.Domaine
{
    public class categorie
    {
        private int id_categorie;
        private string nom_categorie;
        private string date_enregistrement;
        private int id_depot;
        private Byte active;
        public int Id_categorie
        {
            get { return id_categorie; }
            set { id_categorie = value; }
        }
        public string Nom_categorie
        {
            get { return nom_categorie; }
            set { nom_categorie = value; }
        }
        public string Date_enregistrement
        {
            get { return date_enregistrement; }
            set { date_enregistrement = value; }
        }
        public int Id_depot
        {
            get { return id_depot; }
            set { id_depot = value; }
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
        public categorie(string nom_,string date_,int id_depot_,Byte active_)
        {
            this.Id_categorie = Convert.ToInt32(genCode());
            this.Nom_categorie = nom_;
            this.Date_enregistrement = date_;
            this.Id_depot = id_depot_;
            this.Active = active_;
        }
        public categorie(int id_cat,string nom_, string date_, int id_depot_)
        {
            this.Id_categorie = id_cat;
            this.Nom_categorie = nom_;
            this.Date_enregistrement = date_;
            this.Id_depot = id_depot_;
        }
    }
}
