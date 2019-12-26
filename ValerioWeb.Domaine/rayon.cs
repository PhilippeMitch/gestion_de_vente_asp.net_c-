using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ValerioWeb.Domaine
{
    public class rayon
    {
        private int id_rayon;
        private string nom_rayon;
        private string date_enregistrement;
        private int id_categorie;
        private string nom_categorie;

        public string Nom_categorie
        {
            get { return nom_categorie; }
            set { nom_categorie = value; }
        }

        public int Id_rayon
        {
            get { return id_rayon; }
            set { id_rayon = value; }
        }  
        public string Nom_rayon
        {
            get { return  nom_rayon; }
            set {  nom_rayon = value; }
        }
        public string Date_enregistrement
        {
            get { return date_enregistrement; }
            set { date_enregistrement = value; }
        }      
        public int Id_categorie
        {
            get { return id_categorie; }
            set { id_categorie = value; }
        }
        private Byte active;
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
        public rayon(string nom_,string date_,int id_ca,Byte active_)
        {
            this.Id_rayon = Convert.ToInt32(genCode());
            this.Nom_rayon = nom_;
            this.Date_enregistrement = date_;
            this.Id_categorie = id_ca;
            this.Active = active;
        }
        public rayon( int id_rayon_,string nom_, string date_,int categorie_ca)
        {
            this.Id_rayon = id_rayon_ ;
            this.Nom_rayon = nom_;
            this.Date_enregistrement = date_;
            this.Id_categorie = categorie_ca;
        }
    }
}
