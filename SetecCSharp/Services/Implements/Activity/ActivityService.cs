using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SetecCSharp.Data.DTO.Implementations.Activity;
using SetecCSharp.Data.VO.Implementations.Activity;
using SetecCSharp.db.Context;
using SetecCSharp.Models.Implementations.Activity;
using SetecCSharp.Repositories.Implements.Activity;
using SetecCSharp.Services.Generic;

namespace SetecCSharp.Services.Implements.Activity
{
    public class ActivityService : GenericService<ActivityVO, ActivityModel,
            ActivityDTO>, IActivityService
    {

        private readonly MySQLContext _context;
        private readonly IMapper _mapper;

        public ActivityService(IActivityRepository repository, IMapper mapper, MySQLContext context)
            : base(repository, mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public override async Task<ActivityDTO?> FindById(long id)
        {
            var model = await _context.Activities
                .Include(a => a.TypeActivity)
                .Include(a => a.Event)
                .FirstOrDefaultAsync(a => a.Id == id);

            ArgumentNullException.ThrowIfNull(model);

            return _mapper.Map<ActivityDTO>(model);
        }

        public override async Task<ActivityDTO?> Create(ActivityVO obj)
        {
            ArgumentNullException.ThrowIfNull(obj.TypeActivityId);
            ArgumentNullException.ThrowIfNull(obj.EventId);

            // Mapeia VO para model
            var model = _mapper.Map<ActivityModel>(obj);

            // Busca os relacionamentos
            var typeActivity = await _context.TypeActivities.FindAsync(obj.TypeActivityId);
            var evento = await _context.Events.FindAsync(obj.EventId);

            if (typeActivity == null || evento == null)
                throw new ArgumentException("Tipo de atividade ou evento inválido");

            model.TypeActivity = typeActivity;
            model.TypeActivityId = typeActivity.Id;

            model.Event = evento;
            model.EventId = evento.Id;

            // Salva
            await _context.Activities.AddAsync(model);
            await _context.SaveChangesAsync();

            // Carrega relacionamentos para retornar DTO completo
            await _context.Entry(model).Reference(a => a.TypeActivity).LoadAsync();
            await _context.Entry(model).Reference(a => a.Event).LoadAsync();

            return _mapper.Map<ActivityDTO>(model);
        }
    }
}