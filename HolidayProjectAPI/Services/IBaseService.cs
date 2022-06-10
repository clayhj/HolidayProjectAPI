namespace HolidayProjectAPI.Services
{
    public interface IBaseService<TModel>
    {
        Task<TModel> Get(object[] keys);
        Task<IEnumerable<TModel>> GetMany(object[] keys);
    }
}
