using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ValerioWeb.DAL;
using ValerioWeb.Domaine;

namespace ValerioWeb.Controleur
{
    public class articleControleur
    {
        public static int Enregistre_article(image_article im_art, TraceSystem tr, rayon ray)
        {
            int result = 0;
            try
            {
                result = articleDal.Enregistrer_nouveau_(im_art, tr, ray);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return result;
        }
        public static int Modifier_article_tout(image_article im_art, TraceSystem tr, rayon ray)
        {
            int result = 0;
            try
            {
                result = articleDal.Modifier_article_tout(im_art, tr, ray);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return result;
        }
        public static int Modifier_article_San_Article_fournit(image_article im_art, TraceSystem tr, rayon ray)
        {
            int result = 0;
            try
            {
                result = articleDal.Modifier_article_Tout_San_Article(im_art, tr, ray);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return result;
        }
        public static int Modifier_article_(image_article im_art, TraceSystem tr, rayon ray)
        {
            int result = 0;
            try
            {
                result = articleDal.Modifier_article_(im_art, tr, ray);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return result;
        }
        public static image_article Verifier_Prix_Quantite_Article(string code_art)
        {
            image_article art = null;
            try
            {
                art = articleDal.Verifier_Prix_Quantite_Article(code_art);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return art;
        }
        public static image_article Rechercher_article_Nom(string nom,TraceSystem tr)
        {
            image_article art = null;
            try
            {
                art = articleControleur.Rechercher_article_Nom(nom, tr);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return art;
        }
        public static image_article Rechercher_article_Code(string code, TraceSystem trace)
        {
            image_article art = null;
            try
            {
                art = articleDal.Rechercher_article_Code(code, trace);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return art;
        }
        public static BindingList<image_article> Lister_Article(TraceSystem trace)
        {
            BindingList<image_article> lstarticle = new BindingList<image_article>();
            try
            {
                lstarticle = articleDal.Lister_Article(trace);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return lstarticle;
        }
        public static article Verifier_Article(string nom, string description)
        {
            article art = null;
            try
            {
                art = articleDal.Verifier_Article(nom, description);
            }
            catch (Exception ex)
            {
               throw new Exception(ex.Message);
            }
            return art;
        }
    }
}
