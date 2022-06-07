using Microsoft.Data.Sqlite;

namespace HolidayProjectAPI.Repositories
{
    public interface IBaseRepository<TModel>
    {
        TModel CreateModel(SqliteDataReader reader);
        void InitializeGetCommand(SqliteCommand command, object[] keys);
        //void InitializeGetManyCommand(SqliteCommand command, object[] keys);
        Task<TModel> Get(object[] keys);
        //Task<IEnumerable<TModel>> GetMany(object[] keys);
    }
}
