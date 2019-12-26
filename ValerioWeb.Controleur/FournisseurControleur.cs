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
    public class FournisseurControleur
    {
        public static int Enregistrer_Fournisseur(Fournisseur four,Adresse adrs,TraceSystem tr)
        {
            int result = 0;
            try
            {
                result = FournisseurDal.Enregistrer_Fournisseur(four, adrs, tr);
            }
            catch (Exception ex)
            {
               throw new Exception(ex.Message);
            }
            return result;
        }
        public static Fournisseur Rechercher_Fournisseur(string nom_, TraceSystem tr)
        {
            Fournisseur four = null;
            try
            {
                four = FournisseurDal.Rechercher_Fournisseur_Nom(nom_, tr);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return four;
        }
        public static Fournisseur Rechercher_Fournisseur_Nom(string nom_)
        {
            Fournisseur four = null;
            try
            {
                four = FournisseurDal.Rechercher_Fournisseur(nom_);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return four;
        }
        public static Fournisseur Rechercher_Fournisseur_Id(int id)
        {
            Fournisseur four = null;
            try
            {
                four = FournisseurDal.Rechercher_Fournisseur_Id(id);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return four;
        }
        public static AdresseFournisseur Rechercher_Fournisseur_Adresse(string nom_, TraceSystem tr)
        {
            AdresseFournisseur  four = null;
            try
            {
                four = FournisseurDal.Rechercher_Fournisseur_Adresse(nom_, tr);
            }
            catch (Exception ex)
           {
               throw new Exception(ex.Message);
           }
            return four;
        }
        public static int Modifier_Fournisseur(Fournisseur four, TraceSystem tr)
        {
            int result = 0;
            try
            {
                result = FournisseurDal.Modifier_fournisseur(four, tr);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return result;
        }
        public static int Modifier_Fournisseur_Adresse(Fournisseur four, Adresse adrs, TraceSystem tr)
        {
            int result = 0;
            try
            {
                result = FournisseurDal.Modifier_fournisseur_Adresse(four, adrs, tr);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return result;
        }
        public static BindingList<Fournisseur> Liste_Fournisseur(TraceSystem tr)
        {
            BindingList<Fournisseur> LstFour = new BindingList<Fournisseur>();
            try
            {
                LstFour = FournisseurDal.List_Fournisseur(tr);
            }
           catch (Exception ex)
            {
               throw new Exception(ex.Message);
           }
            return LstFour;
        }

    }
}
