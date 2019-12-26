using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ValerioWeb.Domaine
{
    public class vente
    {
        private int id_vente;
        private decimal montant;
        private string date_vente;
        private int id_acheteur;
        private byte active;
        public int Id_vente
        {
            get { return id_vente; }
            set { id_vente = value; }
        }
        public string Date_Vente
        {
            get { return date_vente; }
            set { date_vente = value; }
        }
        public int Id_acheteur
        {
            get { return id_acheteur; }
            set { id_acheteur = value; }
        }
        public decimal Montant
        {
            get { return montant; }
            set { montant = value; }
        }
        public byte Active
        {
            get { return active; }
            set { active = value; }
        }
        private string genCode()
        {
            Random ale = new Random();
            return string.Format("{0}{1}{2}", ale.Next(0, 99), ale.Next(0, 999), ale.Next(0, 9999));
        }
        public vente(decimal montant_,int id_acheteur_,string date_vente_,byte active_)
        {
            this.Id_vente = Convert.ToInt32(genCode());
            this.Montant = montant_;
            this.Id_acheteur = id_acheteur_;
            this.Date_Vente = date_vente_;
            this.Active = active_;
        }
        public vente(int id_vente_, decimal montant, string date_vente_, int id_acheteur_,byte active_)
        {
            this.Id_vente = id_vente_;
            this.Montant = montant;
            this.Date_Vente = date_vente_;          
            this.Id_acheteur = id_acheteur_;
            this.Active = active_;
        }

    }
}

