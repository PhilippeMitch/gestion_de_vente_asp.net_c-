using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ValerioWeb.Domaine
{
    public class Adresse
    {
        private int id_adresse;
        private string code_personne;
        private string pays;
        private string ville;
        private string region;
        private string rue;
        private string numero;
        private DateTime date_debut;
        private DateTime date_fin;

        public int Id_adresse
        {
            get { return id_adresse; }
            set
            {
                if (!string.IsNullOrEmpty(Convert.ToString(value)))
                {
                    id_adresse = value;
                }
                else { throw new CanezException(1, "Id Adresse invalide !"); }
            }
        }
        public string Pays
        {
            get { return pays; }
            set
            {
                if (Regex.IsMatch(value, "^[a-zA-Z][a-zA-Z' /-]+$"))
                {
                    pays = value;
                }
                else
                {
                    throw new CanezException(2, "Pays non valide !");
                }
            }
        }
        public string Ville
        {
            get { return ville; }
            set
            {
                if (Regex.IsMatch(value, "^[a-zA-Z][a-zA-Z' /-]+$"))
                {
                    ville = value;
                }
                else
                {
                    throw new CanezException(3, "Ville non valide !");
                }
            }
        }
        public string Region
        {
            get { return region; }
            set
            {
                if (!string.IsNullOrEmpty(value))
                {
                    region = value;
                }
                else { throw new CanezException(4, "Region non valide !"); }
            }
        }
        public string Rue
        {
            get { return rue; }
            set
            {
                if (!string.IsNullOrEmpty(value))
                {
                    rue = value;
                }
                else { throw new CanezException(6, "Rue non valide !"); }
            }
        }
        public string Numero
        {
            get { return numero; }
            set
            {
                if (!string.IsNullOrEmpty(value))
                {
                    numero = value;
                }
                else { throw new CanezException(5, "Numero adresse non valide !"); }
            }
        }    
        public DateTime Date_fin
        {
            get { return date_fin; }
            set { date_fin = value; }
        }
        public DateTime Date_debut
        {
            get { return date_debut; }
            set { date_debut = value; }
        }
        public string Code_personne
        {
            get { return code_personne; }
            set {
                if (!string.IsNullOrEmpty(value))
                {
                    code_personne = value;
                }
                else { throw new CanezException(7, "Code personne non valide !"); }
                }
        }

        private string genCode()
        {
            Random ale = new Random();
            return string.Format("{0}{1}", ale.Next(0, 99), ale.Next(0, 999));
        }
        public Adresse(string pays, string ville, string region, string rue, string numero_ad, DateTime datedb, DateTime datefn,string code_personne)
        {
            this.Pays = pays;
            this.Ville = ville;
            this.Region = region;
            this.Rue = rue;
            this.Numero = numero_ad;
            this.Id_adresse = Convert.ToInt32(genCode());
            this.Date_debut = datedb;
            this.Date_fin = datefn;
            this.Code_personne = code_personne;
        }
        public Adresse(int id_adresse, string pays, string ville, string region, string rue, string numero_ad, DateTime datedb, DateTime datefn, string code_personne)
        {
            this.Id_adresse = id_adresse;
            this.Pays = pays;
            this.Ville = ville;
            this.Region = region;
            this.Rue = rue;
            this.Numero = numero_ad;
            this.Date_debut = datedb;
            this.Date_fin = datefn;
            this.Code_personne = code_personne;
        }

        public Adresse(string pays,string ville,string region,string rue,string numero)
        {
            this.Pays = pays;
            this.Ville = ville;
            this.Region = region;
            this.Rue = rue;
            this.Numero = numero;
            this.Id_adresse = Convert.ToInt32(genCode());
        }

    }
}
