using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Wipro.API.Entity;

namespace Wipro.API
{
    static public class Repository
    {
        static private readonly string server = "localhost";
        static private readonly string database = "wipro.database";
        static private readonly string user = "root";
        static private readonly string password = "123456";

        private static MySqlConnection GetConnection()
        {
            var connString = $"Server={server};Database={database};User={user};Password={password}";
            var connection = new MySqlConnection(connString);
            connection.Open();
            return connection;
        }

        public static T Select<T>(string id) where T : BaseEntity, new()
        {
            using (var connection = GetConnection())
            {
                var instance = new T() { Id = id };
                var table = instance.GetType().Name;

                var command = connection.CreateCommand();
                command.CommandText = $"SELECT * FROM {table} WHERE id = @id";
                command.Parameters.AddWithValue("@id", id);
                var reader = command.ExecuteReader();

                while (reader.Read())
                {
                    instance.GetType().GetProperties().ToList().ForEach(property =>
                    {
                        instance.GetType().GetProperty(property.Name).SetValue(instance, reader.GetString(property.Name));
                    });
                }

                return instance;
            }
        }

        public static List<T> Select<T>() where T : BaseEntity, new()
        {
            using (var connection = GetConnection())
            {
                var table = new T().GetType().Name;

                var command = connection.CreateCommand();
                command.CommandText = $"SELECT * FROM {table}";
                var reader = command.ExecuteReader();
                var list = new List<T>();

                while (reader.Read())
                {
                    var instance = new T();
                    instance.GetType().GetProperties().ToList().ForEach(property =>
                    {
                        instance.GetType().GetProperty(property.Name).SetValue(instance, reader.GetString(property.Name));
                    });
                    list.Add(instance);
                }

                return list;
            }
        }

        public static void Insert<T>(T entity) where T : BaseEntity, new()
        {
            using (var connection = GetConnection())
            {
                var command = connection.CreateCommand();
                
                var entityType = new T().GetType();
                var table = entityType.Name;

                var columns = entityType
                    .GetProperties()
                    .Select(property => property.Name)
                    .ToList();

                var set = columns
                    .Select(column => $"`{column}`")
                    .Aggregate((columnA, columnB) => columnA + ", " + columnB);

                var values = columns
                    .Select(column => $"@{column}")
                    .Aggregate((columnA, columnB) => columnA + ", " + columnB);

                command.CommandText = $"INSERT INTO {table} ({set}) VALUES({values})";

                columns
                    .ForEach(column => {
                        var name = $"{column}";
                        var value = entityType.GetProperty(column).GetValue(entity).ToString();
                        command.Parameters.AddWithValue(name, value);
                    });

                command.ExecuteNonQuery();
            }
        }

        public static void Update<T>(T entity) where T : BaseEntity, new()
        {
            using (var connection = GetConnection())
            {
                var command = connection.CreateCommand();

                var entityType = new T().GetType();
                var table = entityType.Name;

                var columns = entityType
                    .GetProperties()
                    .Select(property => property.Name)
                    .ToList();

                var set = columns
                    .Select(column => $"`{column}` = @{column}")
                    .Aggregate((columnA, columnB) => columnA + ", " + columnB);

                command.CommandText = $"UPDATE {table} SET {set} WHERE id = @id";

                columns
                    .ForEach(column => {
                        var name = $"{column}";
                        var value = entityType.GetProperty(column).GetValue(entity).ToString();
                        command.Parameters.AddWithValue(name, value);
                    });

                command.ExecuteNonQuery();
            }
        }


        public static void Delete<T>(string id) where T : BaseEntity, new()
        {
            using (var connection = GetConnection())
            {
                var command = connection.CreateCommand();

                var table = new T().GetType().Name;

                command.CommandText = $"UPDATE {table} SET Status = 'disabled' WHERE id = @id";
                command.Parameters.AddWithValue("@id", id);

                command.ExecuteNonQuery();
            }
        }
    }
}