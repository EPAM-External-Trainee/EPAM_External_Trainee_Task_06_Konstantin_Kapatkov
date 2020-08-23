using ResultsOfTheSession.DAO.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Reflection;

namespace ResultsOfTheSession.DAO.Models
{
    public class Dao<T> : IDao<T>
    {
        private string _connectionString;

        public Dao(string connectionString) => _connectionString = connectionString;

        public void Create(T data)
        {
            Type dataType = GetTypeAndPropInfo(data).Item1;
            PropertyInfo[] propertyInfos = GetTypeAndPropInfo(data).Item2;

            string tableName = $"{dataType.Name}s";
            List<string> tableColumns = new List<string>();
            List<string> parameters = new List<string>();

            using SqlConnection connection = new SqlConnection(_connectionString);
            using SqlCommand command = new SqlCommand();

            foreach (var property in propertyInfos)
            {
                if (string.Equals(property.Name, "id", StringComparison.OrdinalIgnoreCase))
                {
                    continue;
                }

                tableColumns.Add(property.Name);
                parameters.Add($"@{property.Name}");
                command.Parameters.AddWithValue($"@{property.Name}", property.GetValue(data));
            }

            connection.Open();
            command.CommandText = $"INSERT INTO [dbo].[{tableName}] ({string.Join(",", tableColumns)}) VALUES ({string.Join(",", parameters)})";
            command.Connection = connection;
            command.ExecuteNonQuery();
        }

        public T Read(int id)
        {
            Type type = typeof(T);
            PropertyInfo[] propertyInfos = type.GetProperties();

            string tableName = $"{type.Name}s";
            string idValue = $"@{type.GetProperty("Id").Name}";

            using SqlConnection connection = new SqlConnection(_connectionString);
            using SqlCommand command = new SqlCommand($"SELECT * FROM {tableName} WHERE ID = {idValue}", connection);
            command.Parameters.AddWithValue(idValue, id);
            connection.Open();

            using SqlDataReader dataReader = command.ExecuteReader();
         
            if (dataReader.HasRows)
            {
                List<object> entityParams = new List<object>();

                while (dataReader.Read())
                {
                    for (int i = 0; i < dataReader.FieldCount; i++)
                    {
                        entityParams.Add(dataReader.GetValue(i));
                    }
                }

                return (T)Activator.CreateInstance(typeof(T), entityParams.ToArray());
            }

            throw new ArgumentException($"Entity with id = {id} wasn't found.");
        }

        public void Update(T data)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<T> ReadAll()
        {
            throw new NotImplementedException();
        }

        private (Type, PropertyInfo[]) GetTypeAndPropInfo(T data) => (data.GetType(), data.GetType().GetProperties());
    }
}