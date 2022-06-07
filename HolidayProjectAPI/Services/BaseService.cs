using HolidayProjectAPI.Repositories;

namespace HolidayProjectAPI.Services
{
    public abstract class BaseService <TModel, TRepositoryInterface> : IBaseService<TModel> where TRepositoryInterface : IBaseRepository<TModel>
    {
        protected readonly TRepositoryInterface _repository;

        protected BaseService(TRepositoryInterface repository)
        {
            _repository = repository;
        }

        public virtual async Task<TModel> Get(object[] keys)
        {
            var result = await _repository.Get(keys);
            return result;
        }

        //public virtual async Task<TModel> GetMany(object[] keys)
        //{
        //    var result = await _repository.Get(keys);
        //    return result;
        //}
    }
}
