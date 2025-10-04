using SIA102_Midterms_2.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SIA102_Midterms_2.Repositories
{
    public interface ITitleRepository
    {
        Task<IEnumerable<Title>> GetAllAsync();
        Task<Title> GetByIdAsync(string id);
        Task AddAsync(Title title);
        Task UpdateAsync(Title title);
        Task DeleteAsync(string id);
        Task<bool> ExistsAsync(string id);
    }
}
