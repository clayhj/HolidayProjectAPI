using HolidayProjectAPI.Models;
using HolidayProjectAPI.Repositories;

namespace HolidayProjectAPI.Services
{
    public interface IHolidayService : IBaseService<Holiday> { }
    public class HolidayService : BaseService<Holiday, IHolidayRepository>, IHolidayService
    {
        public HolidayService (IHolidayRepository repository) : base(repository) { }

        public override async Task<Holiday> Get(object[] keys)
        {
            Holiday result = await _repository.Get(keys);
            if (result == null)
            {
                result = new Holiday();
            } 
            return result;
        }

        public override async Task<IEnumerable<Holiday>> GetMany(object[] keys)
        {
            IEnumerable<Holiday> result = await _repository.GetMany(keys);
            return result;
        }

    }
}
