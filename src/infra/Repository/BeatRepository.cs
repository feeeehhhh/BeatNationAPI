using src.infra.data;
using src.features.Interface.Beats.Command;
using src.Models;
using Microsoft.EntityFrameworkCore;

namespace src.infra.Repository
{

    public class BeatRepository : IBeatRepository
    {
        private readonly AppDbContext _context;

        public BeatRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Beat> CreateAsync(Beat beat)
        {
            await _context.Beats.AddAsync(beat);
            await _context.SaveChangesAsync();
            return beat;
        }

        public async Task<Beat> GetByIdAsync(Guid id)
        {
            return await _context.Beats.FindAsync(id);
        }

        public async Task<IEnumerable<Beat>> GetAllAsync()
        {
            return await _context.Beats.ToListAsync();
        }

        public async Task UpdateAsync(Beat beat)
        {
            _context.Beats.Update(beat);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Guid id)
        {
            var beat = await _context.Beats.FindAsync(id);
            if (beat != null)
            {
                _context.Beats.Remove(beat);
                await _context.SaveChangesAsync();
            }
        }
    }
}