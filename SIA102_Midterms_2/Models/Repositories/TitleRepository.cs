using Microsoft.EntityFrameworkCore;
using SIA102_Midterms_2.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SIA102_Midterms_2.Repositories
{
    public class TitleRepository : ITitleRepository
    {
        private readonly pubsContext _context;

        public TitleRepository(pubsContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Title>> GetAllAsync()
        {
            return await _context.Titles.Include(t => t.Pub).ToListAsync();
        }

        public async Task<Title> GetByIdAsync(string id)
        {
            return await _context.Titles
                .Include(t => t.Pub)
                .FirstOrDefaultAsync(t => t.TitleId == id);
        }

        public async Task AddAsync(Title title)
        {
            _context.Titles.Add(title);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Title title)
        {
            _context.Titles.Update(title);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(string id)
        {
            var title = await _context.Titles.FindAsync(id);
            if (title != null)
            {
                _context.Titles.Remove(title);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<bool> ExistsAsync(string id)
        {
            return await _context.Titles.AnyAsync(t => t.TitleId == id);
        }
    }
}
