using HolidayProjectAPI.Models;
using Microsoft.Data.Sqlite;
using System.Data;

namespace HolidayProjectAPI.Repositories
{

    public interface IHolidayRepository : IBaseRepository<Holiday> { }
    public class HolidayRepository : BaseRepository<Holiday>, IHolidayRepository
    {
        private enum Columns
        {
            Name = 0,
            Description,
            Date,
            IsFloatingDate
        }

        public override string SelectSingleRecord =>
            @"SELECT Name, IFNULL(Description, ''), Date, IsFloatingDate 
                FROM USFederalHolidays WHERE Date = Date(@Date)";

        public override string SelectManyRecords =>
            @"SELECT Name, IFNULL(Description, ''), Date, IsFloatingDate
                FROM USFederalHolidays WHERE strftime('%Y', Date) = @Year";

        public override void InitializeGetCommand(SqliteCommand command, object[] keys)
        {
            command.CommandType = CommandType.Text;
            command.CommandText = SelectSingleRecord;

            command.Parameters.AddWithValue("@Date", keys[0]);
        }

        public override void InitializeGetManyCommand(SqliteCommand command, object[] keys)
        {
            command.CommandType = CommandType.Text;
            command.CommandText = SelectManyRecords;

            command.Parameters.AddWithValue("@Year", keys[0]);
        }

        public override Holiday CreateModel(SqliteDataReader reader)
        {
            return new Holiday
            {
                Name = reader.GetString((int)Columns.Name),
                Description = reader.GetString((int)Columns.Description),
                Date = reader.GetDateTime((int)Columns.Date),
                IsFloatingDate = reader.GetBoolean((int)Columns.IsFloatingDate)
            };
        }
    }
}
