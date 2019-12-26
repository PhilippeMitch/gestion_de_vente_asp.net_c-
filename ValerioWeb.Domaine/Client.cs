using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ValerioWeb.Domaine
{
    public class Client
    {
        private int id_client;
        private string nom_client;
        private string prenom_client;
        private string nif_cin;

        private string tel;
        private string email;
        private string date_enregistrement;
        private int id_adresse;
        public int Id_client
        {
            get { return id_client; }
            set { id_client = value; }
        }        
        public string Nom_client
        {
            get { return nom_client; }
            set { nom_client = value; }
        }
        public string Prenom_client
        {
            get { return prenom_client; }
            set { prenom_client = value; }
        }
        public string Nif_Cin
        {
            get { return nif_cin; }
            set { nif_cin = value; }
        }
        public string Tel
        {
            get { return tel; }
            set { tel = value; }
        }
        public string Email
        {
            get { return email; }
            set { email = value; }
        }
        public string Date_enregistrement
        {
            get { return date_enregistrement; }
            set { date_enregistrement = value; }
        }

        public int Id_adresse
        {
            get { return id_adresse; }
            set { id_adresse = value; }
        }

        private string genCode()
        {
            Random ale = new Random();
            return string.Format("{0}{1}{2}", ale.Next(0, 99), ale.Next(0, 999),ale.Next(0,9999));
        }

        public Client(int id_client, string nom_client, string prenom_client, string nif_cin_ ,string tel, string email, string date_enregistrement)
        {
            this.Id_client = id_client;
            this.Nom_client = nom_client;
            this.Prenom_client = prenom_client;
            this.Nif_Cin = nif_cin_;
            this.Tel = tel;
            this.Email = email;
            this.Date_enregistrement = date_enregistrement;
        }

        public Client(string nom_client, string prenom_client, string nif_Cin, string tel, string email, string date_enregistrement)
        {
            this.Id_client = Convert.ToInt32(genCode());
            this.Nom_client = nom_client;
            this.Prenom_client = prenom_client;
            this.Nif_Cin = nif_Cin;
            this.Tel = tel;
            this.Email = email;
            this.Date_enregistrement = date_enregistrement;
        }
    }
}
