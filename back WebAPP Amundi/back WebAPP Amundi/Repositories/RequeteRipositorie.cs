using back_WebAPP_Amundi.Models;
using Microsoft.Data.SqlClient;
using System.Data;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace back_WebAPP_Amundi.DataBaseManager
{
    public class RequeteRepositorie
    {
        public String StartRequest(RequeteSettings rs)
        {
            SqlDataReader reader;
            try
            {
                SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();

                builder.ConnectionString = rs.getStringConnexion();

                using (SqlConnection connection = new SqlConnection(builder.ConnectionString))
                {


                    connection.Open();

                    using (SqlCommand command = new SqlCommand(rs.Requete, connection))
                    {

                        using (reader = command.ExecuteReader())
                        {

                            return this.sqlDatoToJson(reader);

                        }
                    }
                }
            }
            catch (SqlException e)
            {
                return e.Message;
            }

        }

    

        public string[] testNewRequest(RequeteSettings newRequest)
        {
            List<string> etatRequete = new List<string>();
            SqlDataReader reader;
            try
            {
                SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();

                builder.ConnectionString = newRequest.getStringConnexion();

                using (SqlConnection connection = new SqlConnection(builder.ConnectionString))
                {

                    connection.Open();

                    using (SqlCommand command = new SqlCommand(newRequest.getRequete(), connection))
                    {

                        using (reader = command.ExecuteReader())
                        {

                            etatRequete.Add("requete execute sans probleme");
                            return etatRequete.ToArray();

                        }
                    }
                }

            }

            catch (SqlException e)
            {
                etatRequete.Add("Connexion impossible, veuillez transmetre des informations valides");
            }

            catch (InvalidOperationException e)
            {
                etatRequete.Add("Connexion a la base impossible");
            }

            catch (Exception e)
            {
                etatRequete.Add("Error");
            }

            return etatRequete.ToArray();
        }

        public RequeteSettings[] testConditions(RequeteSettings[] listeRequests)
        {
            SqlDataReader reader;
            String[] condition;
            try
            {
                SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();

                foreach (RequeteSettings request in listeRequests)
                {
                    if (request.Condition != null)
                    {
                        builder.ConnectionString = request.getStringConnexion();

                        using (SqlConnection connection = new SqlConnection(builder.ConnectionString))
                        {

                            connection.Open();

                            using (SqlCommand command = new SqlCommand(request.getRequete(), connection))
                            {

                                using (reader = command.ExecuteReader())
                                {

                                    condition = request.Condition.Split();
                                    request.ConditionValider = this.testConditionString(condition, JArray.Parse(sqlDatoToJson(reader)));


                                }

                            }
                        }
                    }
                }

            }
            catch (Exception e)
            {
            }

            return listeRequests;
        }
        public Boolean testConditionString(String[] condition, JArray reader)
        {
            switch (condition[0])
            {
                case "<":
                    
                    if (reader.Count() < Int16.Parse(condition[1]))
                        return true;
                    return false;
                case ">":

                    if (reader.Count() > Int16.Parse(condition[1]))
                        return true;

                    return false;

                case "=":

                    if (condition[1].All(char.IsNumber))
                    {

                        if (reader.Count() == Int16.Parse(condition[1]))
                            return true;

                    }

                    if(!condition[1].All(char.IsNumber))
                    {

                        if (reader.ElementAt(0).First.First.Value<string>()  == $"{condition[1]} {condition[2]}")
                                return true;
                        
                       
                    }
                    return false;
            }

            return false;
        }

        private String sqlDatoToJson(SqlDataReader dataReader)
        {

            var dataTable = new DataTable();
            dataTable.Load(dataReader);
            string JSONString = string.Empty;
            JSONString = JsonConvert.SerializeObject(dataTable);
            return JSONString;

        }

    }
}
   
