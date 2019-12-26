using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ValerioWeb.Domaine
{
     public class AdresseFournisseur : Fournisseur
    {      
        private string pays;
        private string ville;
        private string region;
        private string rue;
        private string numero;      
        public string Pays
        {
            get { return pays; }
            set
            {
                    pays = value;
            }
        }
        public string Ville
        {
            get { return ville; }
            set
            {
                    ville = value;
            }
        }
        public string Region
        {
            get { return region; }
            set
            {
                    region = value;
            }
        }
        public string Rue
        {
            get { return rue; }
            set
            {
                    rue = value;
            }
        }
        public string Numero
        {
            get { return numero; }
            set
            {
               numero = value;                           
            }
        }
        public AdresseFournisseur(int id_adresse, string pays, string ville, string region, string rue, string numero_ad, int id_fournisseur, string nom_four, string representant, string mail_four, string phone, string date_ajout):base(id_fournisseur,nom_four,representant,mail_four,phone,date_ajout)
        {
            this.ID_fournisseur = id_fournisseur;
            this.Nom_fournisseur = nom_four;
            this.Representant = representant;
            this.Telephone = phone;
            this.Date_ajout = date_ajout;
            this.E_mail = mail_four;
            this.Id_adresse = id_adresse;
            this.Pays = pays;
            this.Ville = ville;
            this.Region = region;
            this.Rue = rue;
            this.Numero = numero_ad;
        }
    }
}
