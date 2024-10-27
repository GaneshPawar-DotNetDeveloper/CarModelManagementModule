using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using CarModelManagement.Models;


namespace CarModelManagement.DataAccess
{
    public class SalesmanRepository
    {
        private readonly string _connectionString = ConfigurationManager.ConnectionStrings["YourDbConnection"].ConnectionString;

        public List<Salesman> GetSalesmen()
        {
            var salesmen = new List<Salesman>();
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                SqlCommand cmd = new SqlCommand("SELECT * FROM Salesman", conn);
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    salesmen.Add(new Salesman
                    {
                        Id = (int)reader["Id"],
                        Name = reader["Name"].ToString(),
                        LastYearSalesAmount = (decimal)reader["LastYearSalesAmount"]
                    });
                }
            }
            return salesmen;
        }

        public List<Sales> GetSalesBySalesman(int salesmanId)
        {
            var sales = new List<Sales>();
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                SqlCommand cmd = new SqlCommand("SELECT * FROM Sales WHERE SalesmanId = @SalesmanId", conn);
                cmd.Parameters.AddWithValue("@SalesmanId", salesmanId);
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    sales.Add(new Sales
                    {
                        Id = (int)reader["Id"],
                        SalesmanId = (int)reader["SalesmanId"],
                        Brand = reader["Brand"].ToString(),
                        Class = reader["Class"].ToString(),
                        NumberOfCarsSold = (int)reader["NumberOfCarsSold"]
                    });
                }
            }
            return sales;
        }

        public CommissionRate GetCommissionRate(string brand, string carClass)
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                SqlCommand cmd = new SqlCommand("SELECT * FROM CommissionRates WHERE Brand = @Brand AND Class = @Class", conn);
                cmd.Parameters.AddWithValue("@Brand", brand);
                cmd.Parameters.AddWithValue("@Class", carClass);
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    return new CommissionRate
                    {
                        Brand = reader["Brand"].ToString(),
                        FixedCommission = (decimal)reader["FixedCommission"],
                        Class = reader["Class"].ToString(),
                        PercentageRate = (decimal)reader["PercentageRate"]
                    };
                }
            }
            return null;
        }
    }
}
