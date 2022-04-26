namespace back_WebAPP_Amundi.Models
{
    public class RequeteSettings
    {

        public RequeteSettings()
        {

        }

        public bool ConditionValider { get; set; }
        public string Condition { get; set; }
        public string Description { get; set; }
        public string Requete { get; set; }
        public string TypeBdd { get; set; }
        public string Serveur { get; set; }
        public string Base { get; set;}
        public string Compte { get; set; }
        public string Password { get; set; }
        public string TypeRequete { get; set; }
        public int id { get; set; }


        public String getStringConnexion()
        {
            return $"server={Serveur} ; user={Compte} ; password= {Password} ;" ;
        }

        public String getRequete()
        {
            return Requete;
        }
    }
}
