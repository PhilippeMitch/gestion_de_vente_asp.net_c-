using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ValerioWeb.Domaine
{
    public class article
    {
        private string code_article;
        private string nom_article;
        private string descritption_article;
        private int qte_en_stock;
        private int qte_alerte;
        private int id_categorie;
        private int id_img;

        public int Id_Img
        {
            get { return id_img; }
            set { id_img = value; }
        }
        public int Id_categorie
        {
            get { return id_categorie; }
            set { id_categorie = value; }
        }

        public int Qte_alerte
        {
            get { return qte_alerte; }
            set { qte_alerte = value; }
        }

        public int Qte_enstock
        {
            get { return qte_en_stock; }
            set { qte_en_stock = value; }
        }

        public string Description_article
        {
            get { return descritption_article; }
            set { descritption_article = value; }
        }

        public string Nom_article
        {
            get { return nom_article; }
            set { nom_article = value; }
        }

        public string Code_article
        {
            get { return code_article; }
            set { code_article = value; }
        }
        private string genCode()
        {
            Random ale = new Random();
            return string.Format("PDT-{0}{1}", ale.Next(0, 99), ale.Next(0, 999));
        }
        public override string ToString()
        {
            return nom_article.ToString();
        }

        public article (string nom_art_,string descritpion_,int qtes_stock_,int qte_alerte_,int id_cate_)
        {
            this.Code_article = genCode();
            this.Nom_article = nom_art_;
            this.Description_article = descritpion_;
            this.Qte_enstock = qtes_stock_;
            this.Qte_alerte = qte_alerte_;
            this.Id_categorie = id_cate_;
        }
    }
}
