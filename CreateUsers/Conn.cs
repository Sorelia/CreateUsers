using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreateUsers
{
    class Conn
    {

        public static string ConnectionString()
        {
            string cnn = "Data Source=zbc-e-b3-skp005;Initial Catalog=Brugere;Integrated Security=True";
            return cnn;
        }

        private static SqlConnection Connection()
        {
            string cnnString = ConnectionString();

            SqlConnection conn;

            conn = new SqlConnection(cnnString);
            conn.Open();
            return conn;
        }

        public static void InsertIntoDB(CUser user)
        {
            if (Connection().State == ConnectionState.Open)
            {
                string Query = "INSERT INTO Login (username, password, salt, key1, key2) VALUES (@username, @password, @salt, @key1, @key2)";

                SqlCommand command = new SqlCommand(Query, Connection());

                command.Parameters.Add("@username", SqlDbType.VarChar).Value = user.Username;
                command.Parameters.Add("@password", SqlDbType.VarChar).Value = user.Password;
                command.Parameters.Add("@salt", SqlDbType.VarChar).Value = user.SaltVal;
                command.Parameters.Add("@key1", SqlDbType.VarChar).Value = user.Key1;
                command.Parameters.Add("@key2", SqlDbType.VarChar).Value = user.Key2;

                command.ExecuteNonQuery();
                Connection().Close();
            }
        }
    }
}
