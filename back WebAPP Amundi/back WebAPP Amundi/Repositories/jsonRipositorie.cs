using back_WebAPP_Amundi.DataBaseManager;
using back_WebAPP_Amundi.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace back_WebAPP_Amundi.JsonManager
{
    public class jsonRipositorie
    {

        private readonly String jsonString = File.ReadAllText("appsettings.Requete.json");
        private readonly RequeteRepositorie _context;
        private JObject? _json;

        public jsonRipositorie( IConfiguration _config, RequeteRepositorie _context)
        {
            this._context= _context;
            this._json = JsonConvert.DeserializeObject(this.jsonString) as JObject;
        }

        public RequeteSettings[] getAllRequetes(String compte)
        {
            lock (this._json)
            {
                int nbRequete = Int32.Parse(this._json.SelectToken("_total").ToString());
                List<RequeteSettings> listeRequete = new List<RequeteSettings>();

                if (compte == "ADMIN")
                {
                    for (int i = 0; i < nbRequete; i++)
                    {
                        listeRequete.Add(JsonConvert.DeserializeObject<RequeteSettings>(_json.SelectToken($"Requetes[{i}]").ToString()));
                        listeRequete.ElementAt(i).id = i;
                    }

                }
                else
                    for (int i = 0; i < nbRequete; i++)
                    {
                        //tri des requete en fonction de l'utilisateur

                        if (compte == _json.SelectToken($"Requetes[{i}].Compte").ToString())
                        {
                            listeRequete.Add(JsonConvert.DeserializeObject<RequeteSettings>(_json.SelectToken($"Requetes[{i}]").ToString()));
                            listeRequete.ElementAt(listeRequete.Count() - 1).id = i;
                        }

                    }

                return listeRequete.ToArray();
            }
               

        }

        public String startRequest(int idRequete)
        {

            RequeteSettings? rs = JsonConvert.DeserializeObject<RequeteSettings>(_json.SelectToken($"Requetes[{idRequete}]").ToString());
            return _context.StartRequest(rs);

        }

        public String[] addRequest(RequeteSettings newRequest)
        {
            lock (this._json)
            {
                String[] etatRequete = _context.testNewRequest(newRequest);

                if (etatRequete[0] == "requete execute sans probleme")
                {
                    addRequestJson(newRequest);
                    etatRequete[0] = "Requete ajouté";
                }

                return etatRequete;
            }
        }

        public String[] modifyRequest(RequeteSettings newRequest, int index)
        {
            lock (this._json)
            {
                String[] etatRequete = _context.testNewRequest(newRequest);

                if (etatRequete[0] == "requete execute sans probleme")
                {
                    modifyRequestJson(newRequest, index);
                    etatRequete[0] = "Requete modifié";
                }

                return etatRequete;
            }
        }

        private void addRequestJson(RequeteSettings newRequest)
        {
            
                int index = Int32.Parse(_json.SelectToken("_total").ToString()) - 1;
                JToken? jToken = _json.SelectToken($"Requetes[ {index}]");

                var requestJon = JObject.Parse(JsonConvert.SerializeObject(newRequest));

                requestJon.Remove("id");
                requestJon.Remove("ConditionValider");

                if (newRequest.Condition == "")
                    requestJon.Remove("Condition");

                jToken.AddAfterSelf(requestJon);
                jToken = _json.SelectToken("_total");
                jToken.Replace(Int32.Parse(jToken.ToString()) + 1);

                string updatedJsonString = _json.ToString();
                File.WriteAllText("appsettings.Requete.json", updatedJsonString);
            
        }

        private void modifyRequestJson(RequeteSettings newRequest, int index)
        {
            lock (this._json)
            {
                JToken? jToken = _json.SelectToken($"Requetes[{index}]");
                var requestJon = JObject.Parse(JsonConvert.SerializeObject(newRequest));

                requestJon.Remove("id");
                requestJon.Remove("ConditionValider");

                if (newRequest.Condition == "")
                    requestJon.Remove("Condition");


                jToken.Replace(requestJon);

                string updatedJsonString = _json.ToString();
                File.WriteAllText("appsettings.Requete.json", updatedJsonString);
            }
        }

        public bool login(User user)
        {
            int nbCompte = Int32.Parse(_json.SelectToken("_nbCompte").ToString());

            for (int i = 0; i < nbCompte; i++)
            {
                if (_json.SelectToken($"Comptes[{i}].Compte").ToString() == user.compte 
                    && _json.SelectToken($"Comptes[{i}].Password").ToString() == user.password)

                    return true;
            }

            return false;
        }

        public RequeteSettings[] testConditions(String compte)
        {
            lock (this._json)
            {
                return _context.testConditions(getAllRequetes(compte));
            }
        }

    }

}
