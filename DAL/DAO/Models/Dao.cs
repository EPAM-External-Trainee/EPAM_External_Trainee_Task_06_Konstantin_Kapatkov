using DAL.DAO.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Reflection;
using System.Threading.Tasks;

namespace DAL.DAO.Models
{
    /// <summary>Class describes CRUD functionality</summary>
    /// <typeparam name="T">ORM model</typeparam>
    public abstract class Dao<T> : IDao<T>
    {
        /// <summary>SQL Server connection string</summary>
        private readonly string _connectionString;

        /// <summary>Creating an instance of <see cref="Dao{T}"/> via connection string</summary>
        /// <param name="connectionString">SQL Server connection string</param>
        public Dao(string connectionString) => _connectionString = connectionString;

        /// <inheritdoc cref="IDao{T}.TryCreateAsync(T)"/>
        public async Task<bool> TryCreateAsync(T data)
        {
            try
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

                await connection.OpenAsync().ConfigureAwait(false);
                command.CommandText = $"INSERT INTO [dbo].[{tableName}] ({string.Join(",", tableColumns)}) VALUES ({string.Join(",", parameters)})";
                command.Connection = connection;
                await command.ExecuteNonQueryAsync().ConfigureAwait(false);
                return true;
            }
            catch
            {
                return false;
            }
        }

        /// <inheritdoc cref="IDao{T}.TryReadAsync(int)"/>
        public async Task<T> TryReadAsync(int id)
        {
            try
            {
                Type type = typeof(T);

                string tableName = $"{type.Name}s";
                string idValue = $"@{type.GetProperty("Id").Name}";

                using SqlConnection connection = new SqlConnection(_connectionString);
                using SqlCommand command = new SqlCommand($"SELECT * FROM [dbo].[{tableName}] WHERE ID = {idValue}", connection);
                command.Parameters.AddWithValue(idValue, id);
                await connection.OpenAsync().ConfigureAwait(false);

                using SqlDataReader dataReader = command.ExecuteReader();

                if (dataReader.HasRows && dataReader.FieldCount > 0)
                {
                    List<object> entityParams = new List<object>();

                    while (await dataReader.ReadAsync().ConfigureAwait(false))
                    {
                        for (int i = 0; i < dataReader.FieldCount; i++)
                        {
                            entityParams.Add(dataReader.GetValue(i));
                        }
                    }

                    return (T)Activator.CreateInstance(typeof(T), entityParams.ToArray());
                }

                return default;
            }
            catch
            {
                return default;
            }
        }

        /// <inheritdoc cref="IDao{T}.TryUpdateAsync(T)"/>
        public async Task<bool> TryUpdateAsync(T data)
        {
            try
            {
                Type dataType = GetTypeAndPropInfo(data).Item1;
                PropertyInfo[] propertyInfos = GetTypeAndPropInfo(data).Item2;

                string tableName = $"{dataType.Name}s";
                string idValue = $"@{dataType.GetProperty("Id").Name}";
                List<string> tableColumns = new List<string>();

                using SqlConnection connection = new SqlConnection(_connectionString);
                using SqlCommand command = new SqlCommand();
                command.Parameters.AddWithValue(idValue, dataType.GetProperty("Id").GetValue(data));

                foreach (var property in propertyInfos)
                {
                    if (string.Equals(property.Name, "id", StringComparison.OrdinalIgnoreCase))
                    {
                        continue;
                    }

                    tableColumns.Add($"{property.Name} = @{property.Name}");
                    command.Parameters.AddWithValue($"@{property.Name}", property.GetValue(data));
                }

                await connection.OpenAsync().ConfigureAwait(false);
                command.Connection = connection;
                command.CommandText = $"UPDATE [dbo].[{tableName}] SET {string.Join(",", tableColumns)} WHERE Id = {idValue}";
                await command.ExecuteNonQueryAsync().ConfigureAwait(false);

                return true;
            }
            catch
            {
                return false;
            }
        }

        /// <inheritdoc cref="IDao{T}.TryDeleteAsync(int)"/>
        public async Task<bool> TryDeleteAsync(int id)
        {
            try
            {
                Type type = typeof(T);

                string tableName = $"{type.Name}s";
                string idValue = $"@{type.GetProperty("Id").Name}";

                using SqlConnection connection = new SqlConnection(_connectionString);
                using SqlCommand command = new SqlCommand($"DELETE FROM [dbo].[{tableName}] WHERE ID = {idValue}", connection);
                command.Parameters.AddWithValue(idValue, id);

                await connection.OpenAsync().ConfigureAwait(false);
                await command.ExecuteNonQueryAsync().ConfigureAwait(false);

                return true;
            }
            catch
            {
                return false;
            }
        }

        /// <inheritdoc cref="IDao{T}.TryReadAllAsync"/>
        public async Task<IEnumerable<T>> TryReadAllAsync()
        {
            try
            {
                Type type = typeof(T);
                PropertyInfo[] propertyInfos = type.GetProperties();

                string tableName = $"{type.Name}s";

                using SqlConnection connection = new SqlConnection(_connectionString);
                using SqlCommand command = new SqlCommand($"SELECT * FROM [dbo].[{tableName}]", connection);

                await connection.OpenAsync().ConfigureAwait(false);
                using SqlDataReader dataReader = command.ExecuteReader();
                List<T> result = new List<T>();

                if (dataReader.HasRows && dataReader.FieldCount > 0)
                {
                    List<object> properties = new List<object>();

                    while (await dataReader.ReadAsync().ConfigureAwait(false))
                    {
                        for (int i = 0; i < dataReader.FieldCount; i++)
                        {
                            properties.Add(dataReader.GetValue(i));
                        }

                        result.Add((T)Activator.CreateInstance(typeof(T), properties.ToArray()));
                        properties.Clear();
                    }

                    return result;
                }

                return null;
            }
            catch
            {
                return null;
            }
        }

        /// <summary>Getting type and property info's</summary>
        /// <param name="data">Data</param>
        /// <returns>Type and property info's</returns>
        private (Type, PropertyInfo[]) GetTypeAndPropInfo(T data) => (data.GetType(), data.GetType().GetProperties());
    }
}