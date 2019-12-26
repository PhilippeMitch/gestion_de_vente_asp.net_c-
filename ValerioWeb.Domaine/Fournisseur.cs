using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ValerioWeb.Domaine
{
    public class Fournisseur
    {
        private int id_adresse;
        private string representant;
        private string nom_founisseur;
        private string e_mail;
        private string date_ajout;
        private Byte active;
        private int id_fournisseur;
        private string telephone;
        private string adresse;
        public string Telephone
        {
            get { return telephone; }
            set {
                if (!string.IsNullOrEmpty(value))
                {
                    telephone = value;
                }
                else { throw new CanezException(8, "Numero de telephone Invalide"); }
                }
        }
        public int ID_fournisseur
        {
            get { return id_fournisseur; }
            set { id_fournisseur = value; }
        }
        public int Id_adresse
        {
            get { return id_adresse; }
            set { id_adresse = value; }
        }
        public string Nom_fournisseur
        {
            get { return nom_founisseur; }
            set
            {
                if (!string.IsNullOrEmpty(value))
                {
                    nom_founisseur = value;
                }
                else { throw new CanezException(1, "Vous devez saisir le nom du fournisseur"); }
            }
        }
        public string Representant
        {
            get { return representant; }
            set
            {
                if (!string.IsNullOrEmpty(value))
                {
                    representant = value;
                }
                else { throw new CanezException(2, "Vous saisir le reprensentant"); }
            }
        }
        public string E_mail
        {
            get { return e_mail; }
            set
            {
                if (!string.IsNullOrEmpty(value))
                {
                    e_mail = value;
                }
                else { throw new CanezException(3, "Vous devez saisir l'adresse e-mail"); }
            }
        }
        public string Date_ajout
        {
            get { return date_ajout; }
            set
            {
                if (!string.IsNullOrEmpty(value))
                {
                    date_ajout = value;
                }
                else { throw new CanezException(4, "Vous devez saisir la date d'insertion"); }
            }
        }
        public Byte Active
        {
            get { return active; }
            set
            {
                if (!string.IsNullOrEmpty(Convert.ToString(value)))
                {
                    active = value;
                }
                else { throw new CanezException(5, "Etat non trouve!"); }
            }
        }
        public string Adresse
        {
            get { return adresse; }
            set { adresse = value; }
        }
        private string genCode()
        {
            Random ale = new Random();
            return string.Format("{0}{1}{2}", ale.Next(0, 99), ale.Next(0, 999), ale.Next(0, 9999));
        }
        public Fournisseur(int id_fournisseur,string nom_four, string representant, string mail_four, string phone,string date_ajout,string adresse)
        {
            this.ID_fournisseur = id_fournisseur;
            this.Nom_fournisseur = nom_four;
            this.Representant = representant;
            this.Telephone = phone;
            this.Date_ajout = date_ajout;
            this.E_mail = mail_four;
            this.Adresse = adresse;
        }
        public Fournisseur(string nom_four, string representant, string mail_four, string telephone, string date_ajout_, int id_adresse, Byte active_)
        {
            this.ID_fournisseur = Convert.ToInt32(genCode());
            this.ID_fournisseur = id_fournisseur;
            this.Nom_fournisseur = nom_four;
            this.Date_ajout = date_ajout_;
            this.Representant = representant;
            this.Telephone = telephone;
            this.E_mail = mail_four;
            this.Id_adresse = id_adresse;
            this.Active = active_;
        }
        public Fournisseur(int id_fournisseur, string nom_four, string representant, string mail_four, string phone, string date_ajout)
        {
            this.ID_fournisseur = id_fournisseur;
            this.Nom_fournisseur = nom_four;
            this.Representant = representant;
            this.Telephone = phone;
            this.Date_ajout = date_ajout;
            this.E_mail = mail_four;
        }
        public Fournisseur(int id_four_,string nom_four_,string representant_)
        {
            this.ID_fournisseur = id_four_;
            this.Nom_fournisseur = nom_four_;
            this.Representant = representant_;
        }
    }
}
