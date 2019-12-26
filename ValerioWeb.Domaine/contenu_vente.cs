using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ValerioWeb.Domaine
{
    public class contenu_vente
    {
        private int code_article;
        private int id_vente;
        private int quantite;
        private decimal prix_negocier;
        private decimal estimation;
        private decimal rabais;
        private decimal montant;
        public int Code_article
        {
            get { return code_article; }
            set { code_article = value; }
        }
        public int Id_vente
        {
            get { return id_vente; }
            set { id_vente = value; }
        }
        public int Quantite
        {
            get { return quantite; }
            set { quantite = value; }
        }
        public decimal Estimation
        {
            get { return estimation; }
            set { estimation = value; }
        }
        public decimal Rabais
        {
            get { return rabais; }
            set { rabais = value; }
        }
        public decimal Prix_negocier
        {
            get { return prix_negocier; }
            set { prix_negocier = value; }
        }    
        public decimal Montant
        {
            get { return montant; }
            set { montant = value; }
        }
        private string genCode()
        {
            Random ale = new Random();
            return string.Format("{0}{1}{2}", ale.Next(0, 99), ale.Next(0, 999), ale.Next(0, 9999));
        }
        public contenu_vente(int code_article, int id_vente, int quantite, decimal prix_negocier,decimal estimation_,decimal rabais_, decimal montant)
        {
            this.Code_article = code_article;
            this.Id_vente = id_vente;
            this.Quantite = quantite;
            this.Prix_negocier = prix_negocier;
            this.Estimation = estimation_;
            this.Rabais = rabais_;
            this.Montant = montant;
        }
        public contenu_vente(int quantite, decimal prix_negocier, decimal montant)
        {
            this.Id_vente = id_vente;
            this.Quantite = quantite;
            this.Prix_negocier = prix_negocier;
            this.Montant = montant;
        }
    }
}
