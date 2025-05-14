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

        public async Task<SpeakerModel> FindByIdWithUserAsync(long id)
            => await _context.Speakers
                .Include(s => s.User)
                .Include(s => s.AdminAproved)
                .FirstOrDefaultAsync(s => s.Id == id)
                    ?? throw new InvalidOperationException("Palestrante nao encontrado");

        public async Task<SpeakerModel> FindSpeakerByUserId(long userId)
        {
            return await _context.Speakers
                .AsNoTracking()
                .FirstOrDefaultAsync(s => s.UserId == userId)
                    ?? throw new InvalidOperationException("Speaker nao encontrado");
        }
    }
}