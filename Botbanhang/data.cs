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

            // Get the column names
            string columnQuery = $"SELECT COLUMN_NAME FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = '{tableName}'";
            using (SqlCommand columnCmd = new SqlCommand(columnQuery, cn))
            using (SqlDataReader columnReader = columnCmd.ExecuteReader())
            {
                // Read column names
                List<string> columnNames = new List<string>();
                while (columnReader.Read())
                {
                    string columnName = columnReader.GetString(0);
                    columnNames.Add(columnName);
                }

                columnReader.Close();

                // Get the data values
                string dataQuery = $"SELECT * FROM {tableName}";
                using (SqlCommand dataCmd = new SqlCommand(dataQuery, cn))
                using (SqlDataReader dataReader = dataCmd.ExecuteReader())
                {
                    // Read data values
                    while (dataReader.Read())
                    {
                        // Concatenate column names and data values
                        for (int i = 0; i < columnNames.Count; i++)
                        {
                            string columnName = columnNames[i];
                            string dataValue = dataReader.IsDBNull(i) ? "NULL" : dataReader.GetValue(i).ToString();
                            result += $"{columnName}:{dataValue}\n ";
                        }
                    }

                    dataReader.Close();
                }
            }
        }
    }
    catch (Exception ex)
    {
        result += $"Error: {ex.Message}";
    }

    return result;
}
        public string Doanhthu(string tableName)
        {
            string result = "";
            decimal tongDoanhThu = 0;
            try
            {
                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    cn.Open();

                    // Get the column names
                    string columnQuery = $"SELECT COLUMN_NAME FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = '{tableName}'";
                    using (SqlCommand columnCmd = new SqlCommand(columnQuery, cn))
                    using (SqlDataReader columnReader = columnCmd.ExecuteReader())
                    {
                        // Read column names
                        List<string> columnNames = new List<string>();
                        while (columnReader.Read())
                        {
                            string columnName = columnReader.GetString(0);
                            columnNames.Add(columnName);
                        }

                        columnReader.Close();

                        // Get the data values
                        string dataQuery = $"SELECT * FROM {tableName}";
                        using (SqlCommand dataCmd = new SqlCommand(dataQuery, cn))
                        using (SqlDataReader dataReader = dataCmd.ExecuteReader())
                        {
                            // Read data values
                            while (dataReader.Read())
                            {
                                // Concatenate column names and data values
                                for (int i = 0; i < columnNames.Count; i++)
                                {
                                    string columnName = columnNames[i];
                                    string dataValue = dataReader.IsDBNull(i) ? "NULL" : dataReader.GetValue(i).ToString();
                                    result += $"{columnName}:{dataValue}\n ";
                                }
                            }

                            dataReader.Close();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                result += $"Error: {ex.Message}";
            }

            return result;
        }
        public decimal Doanhthu()
        {
            decimal Doanhthu = 0;

            try
            {
                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    cn.Open();

                    string query = "SELECT SUM(chitietdathang.giaban*chitietdathang.soluong*(100-chitietdathang.mucgiamgia)/100 " +
                        "- mathang.gianhap*mathang.soluong) AS Doanhthu " +
                                   "FROM chitietdathang " +
                                   "JOIN mathang ON chitietdathang.mahang = mathang.mahang";


                    using (SqlCommand cmd = new SqlCommand(query, cn))
                    {
                        object result = cmd.ExecuteScalar();
                        if (result != DBNull.Value)
                        {
                            Doanhthu = Convert.ToDecimal(result);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // Xử lý lỗi nếu cần
                Console.WriteLine($"Error calculating Doanhthu: {ex.Message}");
                // Hoặc trả về giá trị mặc định
                // Doanhthu = 0;
            }

            return Doanhthu;
        }




    }
}
