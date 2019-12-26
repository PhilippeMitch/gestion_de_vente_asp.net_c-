using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ValerioWeb.Domaine
{
    public class TraceSystem
    {
        private int id_trace;
        private string description;
        private string nom_user;
        private string date_act;
        private string id_user;
        public int Id_trace
        {
            get { return id_trace; }
            set { id_trace = value; }
        }
        public string Description
        {
            get { return description; }
            set { description = value; }
        }    
        public string Date_act
        {
            get { return date_act; }
            set { date_act = value; }
        }
        public string Id_user
        {
            get { return id_user; }
            set { id_user = value; }
        }
        public string Nom_user
        {
            get { return nom_user; }
            set { nom_user = value; }
        }
        private string genCode()
        {
            Random ale = new Random();
            return string.Format("{0}{1}{2}", ale.Next(0, 99), ale.Next(0, 999), ale.Next(0, 9999));
        }
        public TraceSystem(int id_activite,string nom_us,string description,string date_act)
        {
            this.Id_trace = id_activite;
            this.Nom_user = nom_us;
            this.Description = description;
            this.Date_act = date_act;
        }
    
        public TraceSystem(string nom_user,string description, string date_act)
        {
            this.Id_trace = Convert.ToInt32(genCode());
            this.Nom_user = nom_user;
            this.Description = description;
            this.Date_act = date_act;
        }
    }
}
