using Microsoft.Data.Sqlite;
using System.Data;

namespace HolidayProjectAPI.Repositories
{
    public abstract class BaseRepository<TModel> : IBaseRepository<TModel>
    {
        private string connectionString = @"Data Source={AppDir}Database\HolidayProject.db";
        public virtual string SelectSingleRecord { get { return ""; } }
        public virtual string SelectManyRecords { get { return ""; } }

        public abstract TModel CreateModel(SqliteDataReader reader);

        public virtual void InitializeGetCommand(SqliteCommand command, object[] keys)
        {
            command.CommandType = CommandType.Text;
            command.CommandText = SelectSingleRecord;
        }

        public virtual void InitializeGetManyCommand(SqliteCommand command, object[] keys)
        {
            command.CommandType = CommandType.Text;
            command.CommandText = SelectManyRecords;
        }

        public async Task<TModel> Get(object[] keys)
        {
            connectionString = connectionString.Replace("{AppDir}", AppDomain.CurrentDomain.BaseDirectory);
            using (SqliteConnection connection = new SqliteConnection(connectionString))
            {
                using (SqliteCommand command = connection.CreateCommand())
                {
                    InitializeGetCommand(command, keys);

                    await connection.OpenAsync();

                    using (SqliteDataReader reader = await command.ExecuteReaderAsync())
                    {
                        if (reader.Read())
                        {
                            return CreateModel(reader);
                        }
                        return default;
                    }
                }
            }
        }

        public async Task<IEnumerable<TModel>> GetMany(object[] keys)
        {
            connectionString = connectionString.Replace("{AppDir}", AppDomain.CurrentDomain.BaseDirectory);
            using (SqliteConnection connection = new SqliteConnection(connectionString))
            {
                using (SqliteCommand command = connection.CreateCommand())
                {
                    InitializeGetManyCommand(command, keys);

                    var returnValue = new List<TModel>();

                    await connection.OpenAsync();

                    using (SqliteDataReader reader = await command.ExecuteReaderAsync())
                    {
                        while (reader.Read())
                        {
                            returnValue.Add(CreateModel(reader));
                        }

                        return returnValue;
                    }
                }
            }
        }
    }
}
