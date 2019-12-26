using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ValerioWeb.Domaine
{
    public class article_fournit : article
    {
        private int id_four_;
        private decimal px_achat;
        private decimal px_vente;
        private string date_enregistrement;

        public string Date_enregistrement
        {
            get { return date_enregistrement; }
            set { date_enregistrement = value; }
        }

        public decimal Px_vente
        {
            get { return px_vente; }
            set { px_vente = value; }
        }

        public int Id_four
        {
            get { return id_four_; }
            set { id_four_ = value; }
        }
        public decimal Px_achat
        {
            get { return px_achat; }
            set { px_achat = value; }
        }
        private string genCode()
        {
            Random ale = new Random();
            string n = Nom_article.Substring(0, 2);
            return string.Format("{0}-{1}{2}", n, ale.Next(0, 99), ale.Next(0, 999));
        }
        public article_fournit(string nom_art_, string descritpion_, int qtes_stock_, int qte_alerte_, int id_cate_, int id_four_,decimal px_achat_,decimal px_vente_,string date_enregistrement_) :base(nom_art_,descritpion_,qtes_stock_,qte_alerte_,id_cate_)
        {
            this.Code_article = genCode();
            this.Nom_article = nom_art_;
            this.Description_article = descritpion_;
            this.Qte_enstock = qtes_stock_;
            this.Qte_alerte = qte_alerte_;
            this.Id_categorie = id_cate_;
            this.Id_four = id_four_;
            this.Px_achat = px_achat_;
            this.Px_vente = px_vente_;
            this.Date_enregistrement = date_enregistrement_;
        }
    }
}
