using Microsoft.EntityFrameworkCore;
using SetecCSharp.db.Context;
using SetecCSharp.Models.Implementations.Speaker;
using SetecCSharp.Repositories.Generic;
using SetecCSharp.Repositories.Implements.Users;

namespace SetecCSharp.Repositories.Implements.Speaker
{
    public class SpeakerRepository
        : GenericRepository<SpeakerModel>, ISpeakerRepository
    {
        private readonly MySQLContext _context;
        private readonly IUserRepository _userRepo;

        public SpeakerRepository(MySQLContext context,
            IUserRepository userRepo) : base(context)
        {
            _context = context;
            _userRepo = userRepo;
        }


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
                .FirstOrDefaultAsync(s => s.Id == userId)
                    ?? throw new InvalidOperationException("Speaker nao encontrado");
        }

        public override async Task<SpeakerModel?> Create(SpeakerModel obj)
        {
            var user = await _userRepo.Create(obj.User!)
                ?? throw new InvalidOperationException("Falha ao criar usuario");

            obj.Id = user.Id;

            try
            {
                await DataSet.AddAsync(obj);
                await _context.SaveChangesAsync();
                
                return obj;
            }
            catch (Exception) { throw; }
        }
    }
}