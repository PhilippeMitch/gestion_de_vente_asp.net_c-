using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ValerioWeb.Domaine
{
    public class ConnexionUser
    {
        private int id_connexion;
        private string nom_user;
        private string password;
        private string ip_user;
        private string date_connexion;

        public string Date_connexion
        {
            get { return date_connexion; }
            set { date_connexion = value; }
        }
        public string Ip_user
        {
            get { return ip_user; }
            set { ip_user = value; }
        }
        public string Password
        {
            get { return password; }
            set { password = value; }
        }
        public string Nom_user
        {
            get { return  nom_user; }
            set {  nom_user = value; }
        }
        public int Id_connexion
        {
            get { return id_connexion; }
            set { id_connexion = value; }
        }
        private string genCode()
        {
            Random ale = new Random();
            return string.Format("{0}{1}{2}", ale.Next(0, 99), ale.Next(0, 999), ale.Next(0, 9999));
        }
        public ConnexionUser(int id_conect,string nom_us,string ip_us,string date_con)
        {
            this.Id_connexion = id_conect;
            this.Nom_user = nom_us;
            this.Ip_user = ip_us;
            this.Date_connexion = date_con;
        }
        public ConnexionUser(string nom_us, string ip_us, string date_con)
        {
            this.Id_connexion = Convert.ToInt32(genCode());
            this.Nom_user = nom_us;
            this.Ip_user = ip_us;
            this.Date_connexion = date_con;
        }
    }
}
