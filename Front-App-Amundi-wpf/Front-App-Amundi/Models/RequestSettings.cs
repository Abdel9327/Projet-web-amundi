using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Front_App_Amundi.Models
{
    public class RequestSettings
    {

    
        public RequestSettings(string description,string requete,string typeBDD,string serveur,string compte,string mdp,string typeRequete,string condition)
        {
            this.description = description;
            this.requete = requete;
            this.typeBDD = typeBDD;
            this.serveur = serveur;
            this.compte = compte;
            this.password = mdp;
            this.typeRequete = typeRequete;
            this.condition = condition;

        }


        public int id { get; set; } 
        public string description { get; set; }
        public List<Column> columns { get; set; }     
        public JArray row { get; set; }      
        public DateTime hourOfStart { get; set; }
        public string requete { get; set; }
        public string typeBDD { get; set; }
        public string serveur { get; set; }
        public string compte { get; set; }
        public string password { get; set; }
        public string typeRequete { get; set; }
        public string condition { get; set; }
        public bool conditionValider { get; set; }
        public List<RequestSettings> requestStarted { get; set; }




        public void initRequestStarted()
        {
            if (requestStarted == null)
            {
                requestStarted = new List<RequestSettings>();
            
            }
        }

        public void addRequestStarted(RequestSettings request)
        {
      
            requestStarted.Add(request);
        }


        public void deleteRequestStarted(RequestSettings request)
        {
            requestStarted.Remove(request);


        }
        public object Clone()
        {
            return this.MemberwiseClone();
        }
    }
}
