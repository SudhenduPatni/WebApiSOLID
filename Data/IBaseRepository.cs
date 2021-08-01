using Core.Entity;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Data
{
    public interface IBaseRepository<T> where T : class
    {
        Task<T> GetByIdAsync(Guid globalId);
        Task<List<T>> GetAllAsync();
        Task<int> AddClientAsync(T entity);
        Task<List<Files>> GetAllFilesAsync();
        Task<List<Files>> GetAllFilesByIdAsync(Guid globalId);
        Task SaveFileAsync(Files entity);
        Task<Files> GetFileAsync(Guid globalId);
        Task<int> AddSubscriptionAsync(Subscription entity);
        Task<List<Subscription>> GetAllSubscriptionAsync();
        Task<Subscription> GetSubscriptionByIdAsync(Guid globalId);
    }
}
