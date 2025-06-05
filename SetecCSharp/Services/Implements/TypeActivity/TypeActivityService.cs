using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SetecCSharp.Data.DTO.Implementations.TypeActivity;
using SetecCSharp.Data.VO.Implementations.TypeActivity;
using SetecCSharp.db.Context;
using SetecCSharp.Models.Implementations.TypeActivity;
using SetecCSharp.Repositories.Implements.TypeActivity;
using SetecCSharp.Services.Generic;

namespace SetecCSharp.Services.Implements.TypeActivity
{
    public class TypeActivityService : GenericService<TypeActivityVO, TypeActivityModel,
            TypeActivityDTO>, ITypeActivityService
    {
        private readonly MySQLContext _context;

        public TypeActivityService(ITypeActivityRepository repository, IMapper mapper, MySQLContext context)
            : base(repository, mapper)
        {
            _context = context;
        }

        public override async Task<TypeActivityDTO?> FindById(long id)
        {
            if (id <= 0)
                throw new ArgumentException("Id inválido", nameof(id));

            var model = await _context.TypeActivities
                .FirstOrDefaultAsync(t => t.Id == id);

            ArgumentNullException.ThrowIfNull(model);

            return _mapper.Map<TypeActivityDTO>(model);
        }
    }
}