using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ValerioWeb.Domaine
{
    public class Personne
    {
        private int id_personne;
        private string nom_personne;
        private string prenom_personne;
        private string sexe_personne;
        private string cin_nif;
        private DateTime date_ajout;
        private byte active;
        private int id_adresse;
        public int ID_personne
        {
            get { return id_personne; }
            set { id_personne = value; }
        }       
        public string Nom_personne
        {
            get { return nom_personne; }
            set {
                if (Regex.IsMatch(value, "^[a-zA-Z][a-zA-Z' /-]+$"))
                {
                    nom_personne = value;
                }
                else
                {
                    throw new CanezException(1, "Le nom est incorrect !");
                }
            }
        }
        public string Prenom_personne
        {
            get { return prenom_personne; }
            set {
                if (Regex.IsMatch(value, "^[a-zA-Z][a-zA-Z' /-]+$"))
                {
                    prenom_personne = value;
                }
                else
                {
                    throw new CanezException(2, "Le prenom saisi est inccorect !");
                }
            }
        }
        public string Sexe_personne
        {
            get { return sexe_personne; }
            set {
                if (!string.IsNullOrEmpty(value))
                {
                    sexe_personne = value;
                }
                else
                {
                    throw new CanezException(3, "Sexe non valide !");
                }
            }
        }
        public string Cin_Nif
        {
            get { return cin_nif; }
            set
            {

                if (!string.IsNullOrEmpty(value))
                {
                    cin_nif = value;
                }
                else
                {
                    throw new CanezException(4, "Vous devez saisir le NIF ou le CIN !");
                }
            }
        }
        public DateTime Date_ajout
        {
            get { return date_ajout; }
            set { date_ajout = value; }
        }  
        public byte Active
        {
            get { return active; }
            set { active = value; }
        }
        public int Id_Adresse
        {
            get { return id_adresse; }
            set { id_adresse = value; }
        }
        private string genCode()
        {
            Random ale = new Random();
            return string.Format("{0}{1}{2}", ale.Next(0, 99), ale.Next(0, 999), ale.Next(0, 9999));
        }
        public Personne(string nom_pers,string prenom,string sexe_personne,string cin_nif,DateTime date_ajout,byte active,int id_adresse)
        {
            this.ID_personne = Convert.ToInt32(genCode());
            this.Nom_personne = Nom_personne;
            this.Prenom_personne = prenom;
            this.Sexe_personne = sexe_personne;
            this.Cin_Nif = cin_nif;
            this.Date_ajout = date_ajout;
            this.Active = active;
            this.Id_Adresse = id_adresse;
        }
        public Personne(int id_pers,string nom_pers, string prenom, string sexe_personne, string cin_nif,DateTime date_ajout)
        {
            this.ID_personne = id_pers;
            this.Nom_personne = Nom_personne;
            this.Prenom_personne = prenom;
            this.Sexe_personne = sexe_personne;
            this.Cin_Nif = cin_nif;
            this.Date_ajout = date_ajout;
        }
    }
}
