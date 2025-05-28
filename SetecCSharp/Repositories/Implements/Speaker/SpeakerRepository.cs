using Microsoft.EntityFrameworkCore;
using SetecCSharp.db.Context;
using SetecCSharp.Models.Implementations.Speaker;
using SetecCSharp.Repositories.Generic;

namespace SetecCSharp.Repositories.Implements.Speaker
{
    public class SpeakerRepository
        : GenericRepository<SpeakerModel>, ISpeakerRepository
    {
        private readonly MySQLContext _context;
        public SpeakerRepository(MySQLContext context) : base(context) => _context = context;


        public override async Task<IEnumerable<SpeakerModel>> FindAll()
        {
            return await _context.Speakers
                .Include(s => s.User)
                .ToListAsync();
        }

        public async Task<SpeakerModel> FindByIdWithUserAsync(long id)
            => await _context.Speakers
                .Include(s => s.User)
                .FirstOrDefaultAsync(s => s.Id == id)
                    ?? throw new InvalidOperationException("Palestrante nao encontrado");

        public async Task<SpeakerModel> FindSpeakerByUserId(long userId)
        {
            return await _context.Speakers
                .Include(s => s.User)
                .AsNoTracking()
                .FirstOrDefaultAsync(s => s.UserId == userId)
                    ?? throw new InvalidOperationException("Speaker nao encontrado");
        }

        
    }
}