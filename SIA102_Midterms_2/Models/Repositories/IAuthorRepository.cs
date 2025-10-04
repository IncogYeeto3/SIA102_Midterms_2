using SIA102_Midterms_2.Delegates;
using SIA102_Midterms_2.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SIA102_Midterms_2.Repositories
{
    public interface IAuthorRepository
    {
        Task<List<Author>> GetAllAsync();
        Task<Author> GetByIdAsync(string id);
        Task AddAsync(Author author);
        Task UpdateAsync(Author author);
        Task DeleteAsync(string id);
        Task<bool> ExistsAsync(string id);

        event Action<Author> AuthorAdded;
        Task<List<Author>> GetFilteredAuthorsAsync(AuthorFilter filter);
    }
}
