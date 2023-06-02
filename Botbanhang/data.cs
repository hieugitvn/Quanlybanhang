using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;


namespace Botbanhang
{
    public class data
    {
        string connectionString = @"Data Source=aff;Initial Catalog=Quanlybanhang;Integrated Security=True;";


        public string Hienthi(string tableName)
        {
            string result = "";
            try
            {
                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    cn.Open();
                    using (SqlCommand cmd = cn.CreateCommand())
                    {
                        cmd.CommandText = $"SELECT * FROM {tableName}";

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                for (int i = 0; i < reader.FieldCount; i++)
                                {
                                    result += reader[i].ToString() + " ";
                                }
                                result += "\n";
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                result = $"Error: {ex.Message}";
            }
            return result;
        }

    }
}
