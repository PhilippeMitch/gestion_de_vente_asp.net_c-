using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ValerioWeb.Domaine
{
    public class AdresseClient :Client
    {
        private int id_adresse;

        public int ID_Adresse
        {
            get { return id_adresse; }
            set { id_adresse = value; }
        }

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
        private string genID()
        {
            Random ale = new Random();
            return string.Format("{0}{1}{2}", ale.Next(0, 99), ale.Next(0, 999), ale.Next(0, 9999));
        }
        private string genCode()
        {
            Random ale = new Random();
            return string.Format("{0}{1}", ale.Next(0, 99), ale.Next(0, 999));
        }

        public AdresseClient(string pays, string ville, string region, string rue, string numero_ad, string nom_client_, string prenom_client_, string nif_cin, string tel_Client, string email_cli_, string date_enregistrement_client_):base(nom_client_,prenom_client_, nif_cin,tel_Client, email_cli_, date_enregistrement_client_)
        {
            this.ID_Adresse = Convert.ToInt32(genCode());
            this.Id_client = Convert.ToInt32(genID());
            this.Nom_client = nom_client_;
            this.Prenom_client = prenom_client_;
            this.Nif_Cin = nif_cin;
            this.Tel = tel_Client;
            this.Email = email_cli_;
            this.Date_enregistrement = date_enregistrement_client_;
            this.Pays = pays;
            this.Ville = ville;
            this.Region = region;
            this.Rue = rue;
            this.Numero = numero_ad;
        }
        public AdresseClient(int id_adresse_,int id_client_,string pays, string ville, string region, string rue, string numero_ad, string nom_client_, string prenom_client_, string nif_cin, string tel_Client, string email_cli_, string date_enregistrement_client_):base(nom_client_, prenom_client_, nif_cin, tel_Client, email_cli_, date_enregistrement_client_)
        {
            this.ID_Adresse = id_adresse_;
            this.Id_client = id_client_;
            this.Nom_client = nom_client_;
            this.Prenom_client = prenom_client_;
            this.Nif_Cin = nif_cin;
            this.Tel = tel_Client;
            this.Email = email_cli_;
            this.Date_enregistrement = date_enregistrement_client_;
            this.Pays = pays;
            this.Ville = ville;
            this.Region = region;
            this.Rue = rue;
            this.Numero = numero_ad;
        }
    }
}
