using SIA102_Midterms_2.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SIA102_Midterms_2.Repositories
{
    public interface IPublisherRepository
    {
        Task<List<Publisher>> GetAllAsync();
        Task<Publisher> GetByIdAsync(string id);
        Task AddAsync(Publisher publisher);
        Task UpdateAsync(Publisher publisher);
        Task DeleteAsync(string id);

        // Optional: Event when publisher added
        event Action<Publisher> PublisherAdded;
    }
}
