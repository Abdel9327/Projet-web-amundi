using back_WebAPP_Amundi.DataBaseManager;
using Microsoft.Data.SqlClient;

namespace back_WebAPP_Amundi.JsonManager
{
    public class jsonManager
    {
        private IConfiguration _config;
        private readonly RequeteRepositorie _context;


        public jsonManager( IConfiguration _config, RequeteRepositorie _context)
        {
            this._config = _config;
            this._context= _context;
        }

        public String[] getAllRequetes()
        {
           int nbRequete= Int16.Parse( _config.GetValue<string>("_total"));
           String[] listeRequete = new string[nbRequete];

            for (int i = 0; i < nbRequete; i++)
                listeRequete[i]= _config.GetSection("Requetes:" + i).GetValue<String>("description");
            return listeRequete;
        }

        public int startRequest(int idRequete)
        {
            String connexion;
            connexion= "server=" + _config.GetSection("Requetes:" + idRequete).GetValue<String>("Serveur") + ";";
            connexion= connexion + "user=" + _config.GetSection("Requetes:" + idRequete).GetValue<String>("Compte") + ";";
            connexion = connexion + "password="+ _config.GetSection("Requetes:" + idRequete).GetValue<String>("Password") + ";";

            String sql = _config.GetSection("Requetes:" + idRequete).GetValue<String>("Requete");
           return _context.StartRequest(connexion,sql);

        }
    }
}
