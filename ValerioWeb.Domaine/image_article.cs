using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ValerioWeb.Domaine
{
    public class image_article : article_fournit
    {
        private int id_image;
        private string nom_image;
        private string extension_image;
        private byte[] contenu_image;
        public byte[] Contenu_image
        {
            get { return contenu_image; }
            set { contenu_image = value; }
        }
        public string Extension_image
        {
            get { return extension_image; }
            set { extension_image = value; }
        }
        public string Nom_image
        {
            get { return nom_image; }
            set { nom_image = value; }
        }
        public int Id_image
        {
            get { return id_image; }
            set { id_image = value; }
        }
        private string genCode()
        {
            Random ale = new Random();
            string n = Nom_article.Substring(0, 2);
            return string.Format("{0}-{1}{2}", n, ale.Next(0, 99), ale.Next(0, 999));
        }
        private string genID()
        {
            Random ale = new Random();
            return string.Format("{0}{1}", ale.Next(0, 99), ale.Next(0, 999));
        }
        public image_article(string nom_art_, string descritpion_, int qtes_stock_, int qte_alerte_, int id_cate_, int id_four_, decimal px_achat_, decimal px_vente_, string date_enregistrement_,string nom_img,string ext_img,byte[] contenu_img) :base( nom_art_, descritpion_, qtes_stock_, qte_alerte_, id_cate_, id_four_, px_achat_, px_vente_,date_enregistrement_)
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
            this.Id_image = Convert.ToInt32(genID());
            this.Nom_image = nom_img;
            this.Extension_image = ext_img;
            this.Contenu_image = contenu_img;
        }
        public image_article(string code_art_, string nom_art_, string descritpion_, int qtes_stock_, int qte_alerte_, int id_cate_, int id_four_, decimal px_achat_, decimal px_vente_, string date_enregistrement_, string nom_img, string ext_img, byte[] contenu_img) : base(nom_art_, descritpion_, qtes_stock_, qte_alerte_, id_cate_, id_four_, px_achat_, px_vente_, date_enregistrement_)
        {
            this.Code_article =code_art_;
            this.Nom_article = nom_art_;
            this.Description_article = descritpion_;
            this.Qte_enstock = qtes_stock_;
            this.Qte_alerte = qte_alerte_;
            this.Id_categorie = id_cate_;
            this.Id_four = id_four_;
            this.Px_achat = px_achat_;
            this.Px_vente = px_vente_;
            this.Date_enregistrement = date_enregistrement_;
            this.Id_image = Convert.ToInt32(genID());
            this.Nom_image = nom_img;
            this.Extension_image = ext_img;
            this.Contenu_image = contenu_img;
        }
        public image_article(string code_art_, string nom_art_, string descritpion_, int qtes_stock_, int qte_alerte_, int id_cate_, int id_four_, decimal px_achat_, decimal px_vente_, string date_enregistrement_,byte[] contenu_img) : base(nom_art_, descritpion_, qtes_stock_, qte_alerte_, id_cate_, id_four_, px_achat_, px_vente_, date_enregistrement_)
        {
            this.Code_article = code_art_;
            this.Nom_article = nom_art_;
            this.Description_article = descritpion_;
            this.Qte_enstock = qtes_stock_;
            this.Qte_alerte = qte_alerte_;
            this.Id_categorie = id_cate_;
            this.Id_four = id_four_;
            this.Px_achat = px_achat_;
            this.Px_vente = px_vente_;
            this.Date_enregistrement = date_enregistrement_;
            this.Contenu_image = contenu_img;
        }
    }
}
