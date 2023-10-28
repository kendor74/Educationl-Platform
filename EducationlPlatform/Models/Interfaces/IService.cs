﻿namespace EducationlPlatform.Models.Interfaces
{
    public interface IService<T>
    {
        Task<T> Add(T entity);
        Task<T> Update(T entity, int id);
        Task<bool> Delete(int entityId);
        Task<IEnumerable<T>> GetAll();
        Task<T>? GetById(int entityId);

        Task<int> Count();
        Task<T> FindById(int id);
        Task<bool> IsExist(int id);
    }
}
