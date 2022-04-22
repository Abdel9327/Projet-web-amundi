using back_WebAPP_Amundi.Models;
using Microsoft.Data.SqlClient;
using System.Data;
using Newtonsoft.Json;

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
                etatRequete.Add("Connexion impossible");
            }

            catch (Exception e)
            {
                etatRequete.Add("probleme");
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
                    builder.ConnectionString = request.getStringConnexion();

                    using (SqlConnection connection = new SqlConnection(builder.ConnectionString))
                    {

                        connection.Open();

                        using (SqlCommand command = new SqlCommand(request.getRequete(), connection))
                        {

                            using (reader = command.ExecuteReader())
                            {
                                if (request.Condition != null)
                                {
                                    condition = request.Condition.Split();
                                    request.ConditionValider = this.testConditionString(condition, reader);
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
        public Boolean testConditionString(String[] condition, SqlDataReader reader)
        {
            int countRow;
            switch (condition[0])
            {
                case "<":
                     countRow = 0;

                    while (reader.Read())
                    {
                        countRow = countRow + 1;
                    }
                    if (countRow < Int16.Parse(condition[1]))
                        return true;
                    return false;
                case ">":

                     countRow = 0;

                    while (reader.Read())
                    {
                        countRow = countRow + 1;
                    }

                    if (countRow > Int16.Parse(condition[1]))
                        return true;

                    return false;

                case "=":

                    if (condition[1].All(char.IsNumber))
                    {
                       countRow = 0;

                        while (reader.Read())
                        {
                            countRow = countRow + 1;
                        }

                        if (countRow == Int16.Parse(condition[1]))
                            return true;
                    }

                    if(!condition[1].All(char.IsNumber))
                    {
                        if (reader.HasRows)
                        {
                            reader.Read();

                            if (reader.GetString(0) == condition[1] + " " + condition[2])
                                return true;
                        }

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
   
