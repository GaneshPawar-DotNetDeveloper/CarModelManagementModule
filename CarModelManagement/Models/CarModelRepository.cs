using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using CarModels.Models;

namespace CarModels.DataAccess
{
    public class CarModelRepository
    {
        private readonly string _connectionString = ConfigurationManager.ConnectionStrings["YourDbConnection"].ConnectionString;

        public List<CarModel> GetCarModels()
        {
            List<CarModel> carModels = new List<CarModel>();
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                SqlCommand cmd = new SqlCommand("SELECT * FROM CarModel", conn);
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    CarModel carModel = new CarModel
                    {
                        Id = (int)reader["Id"],
                        Brand = reader["Brand"].ToString(),
                        Class = reader["Class"].ToString(),
                        ModelName = reader["ModelName"].ToString(),
                        ModelCode = reader["ModelCode"].ToString(),
                        Description = reader["Description"].ToString(),
                        Features = reader["Features"].ToString(),
                        Price = (decimal)reader["Price"],
                        DateOfManufacturing = (DateTime)reader["DateOfManufacturing"],
                        Active = (bool)reader["Active"],
                        SortOrder = (int)reader["SortOrder"]
                    };
                    carModels.Add(carModel);
                }
            }
            return carModels;
        }

        public void AddCarModel(CarModel carModel)
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                SqlCommand cmd = new SqlCommand("INSERT INTO CarModel (Brand, Class, ModelName, ModelCode, Description, Features, Price, DateOfManufacturing, Active, SortOrder) VALUES (@Brand, @Class, @ModelName, @ModelCode, @Description, @Features, @Price, @DateOfManufacturing, @Active, @SortOrder)", conn);
                cmd.Parameters.AddWithValue("@Brand", carModel.Brand);
                cmd.Parameters.AddWithValue("@Class", carModel.Class);
                cmd.Parameters.AddWithValue("@ModelName", carModel.ModelName);
                cmd.Parameters.AddWithValue("@ModelCode", carModel.ModelCode);
                cmd.Parameters.AddWithValue("@Description", carModel.Description);
                cmd.Parameters.AddWithValue("@Features", carModel.Features);
                cmd.Parameters.AddWithValue("@Price", carModel.Price);
                cmd.Parameters.AddWithValue("@DateOfManufacturing", carModel.DateOfManufacturing);
                cmd.Parameters.AddWithValue("@Active", carModel.Active);
                cmd.Parameters.AddWithValue("@SortOrder", carModel.SortOrder);

                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        // Additional methods for update, delete, etc. would go here
    }
}
