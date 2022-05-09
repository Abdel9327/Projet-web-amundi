using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Front_App_Amundi.Models
{
    public class RequestSettings
    {
        public int id { get; set; } 
        public string description { get; set; }
        public string[] columns { get; set; }       // a voir 
        public string[] row { get; set; }       // a voir 
        public string hourOfStart { get; set; }
        public string requete { get; set; }
        public string typeBDD { get; set; }
        public string serveur { get; set; }
        public string compte { get; set; }
        public string password { get; set; }
        public string typeRequete { get; set; }
        public string condition { get; set; }
        public bool conditionValider { get; set; }

    }
}
