using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ValerioWeb.Domaine
{
    public class Utilisateur
    {
        private string nom_user;
        private string pass;
        private string e_mail;
        private string date_add;
        private Byte active;
        private int id_group;
        private string nom_group;
        public string Nom_group
        {
            get { return nom_group; }
            set { nom_group = value; }
        }
        public string Nom_user
        {
            get { return nom_user; }
            set { nom_user = value; }
        }
        public string Pass
        {
            get { return pass; }
            set { pass = value; }
        }
        public string E_mail
        {
            get { return e_mail; }
            set { e_mail = value; }
        }
        public string Date_add
        {
            get { return date_add; }
            set { date_add = value; }
        }
        public Byte Active
        {
            get { return active; }
            set { active = value; }
        }   
        public int Id_group
        {
            get { return id_group; }
            set { id_group = value; }
        }
        public Utilisateur(string nom_user,string pass_user,string mail_user,string date_user,Byte active_user,int group_user,string nom_group)
        {
            this.Nom_user = nom_user;
            this.Pass = pass_user;
            this.E_mail = mail_user;
            this.Date_add = date_user;
            this.Active = active_user;
            this.Id_group = group_user;
        }
        public Utilisateur(string nom_user, string mail_user, string date_user, Byte active_user,string nom_group)
        {
            this.Nom_user = nom_user;
            this.E_mail = mail_user;
            this.Date_add = date_user;
            this.Active = active_user;
        }
        public Utilisateur(string nom_user, string mail_user,string nom_group, string date_user)
        {
            this.Nom_user = nom_user;
            this.E_mail = mail_user;
            this.Nom_group = nom_group;
            this.Date_add = date_user;
        }
    }
}
