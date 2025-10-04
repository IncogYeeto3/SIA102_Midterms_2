using SIA102_Midterms_2.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SIA102_Midterms_2.Repositories
{
    public class AuthorRepository : IAuthorRepository
    {
        private readonly pubsContext _context;

        // Custom event triggered when a new author is added
        public event Action<Author> AuthorAdded;

        public AuthorRepository(pubsContext context)
        {
            _context = context;
        }



        public async Task<List<Author>> GetAllAsync()
        {
            return await _context.Authors.ToListAsync();
        }

        public async Task<Author> GetByIdAsync(string id)
        {
            return await _context.Authors.FirstOrDefaultAsync(a => a.AuId == id);
        }

        public async Task AddAsync(Author author)
        {
            _context.Authors.Add(author);
            await _context.SaveChangesAsync();
            AuthorAdded?.Invoke(author);
        }

        public async Task UpdateAsync(Author author)
        {
            _context.Authors.Update(author);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(string id)
        {
            var author = await _context.Authors.FindAsync(id);
            if (author != null)
            {
                _context.Authors.Remove(author);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<bool> ExistsAsync(string id)
        {
            return await _context.Authors.AnyAsync(a => a.AuId == id);
        }
    }
}
