using SetecCSharp.Models.Implementations.Speaker;
using SetecCSharp.Repositories.Generic;

namespace SetecCSharp.Repositories.Implements.Speaker
{
    public interface ISpeakerRepository : IRepository<SpeakerModel>
    {
        Task<SpeakerModel> FindByIdWithUserAsync(long id);
    }
}