using Microsoft.Data.SqlClient;

namespace back_WebAPP_Amundi.DataBaseManager
{
    public class RequeteRepositorie
    {
        public int StartRequest(String connexion,String sql)
        {
            SqlDataReader reader;
            try
            {
                SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();

                builder.ConnectionString = connexion;

                using (SqlConnection connection = new SqlConnection(builder.ConnectionString))
                {


                    connection.Open();


                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        using (reader = command.ExecuteReader())
                        {
                           /////// return les valeurs en format json
                            return 1;


                        }
                    }
                }

            }


            catch (SqlException e)
            {
                return 0; ////////////////return exception
            }

        }
    }
    }
