using AutoMapper;
using SetecCSharp.Data.Dto.Base;
using SetecCSharp.Data.DTO.Base;
using SetecCSharp.Data.VO.Base;
using SetecCSharp.Models.Base;
using SetecCSharp.Repositories.Generic;
using SetecCSharp.Services.Bases.Generic;

namespace SetecCSharp.Services.Generic
{
    public class GenericService<VO, M, DTO>(
      IRepository<M> _repository,
      IMapper _mapper
    ) : IService<VO, DTO> where M : BaseModel where DTO : BaseDTO where VO : BaseVO
    {
        //Crud Methods
        //getAll
        public async Task<IEnumerable<DTO>> FindAll()
        {
            var modelList = await _repository.FindAll();
            return _mapper.Map<IEnumerable<DTO>>(modelList);
        }


        //getAllPaged
        public async Task<CursorPagedDTO<DTO>> FindAllPaged(long? lastId, int size)
        {
            var modelList = await _repository.FindAllPaged(lastId, size);
            var dtos = _mapper.Map<IEnumerable<DTO>>(modelList);

            var last = modelList.LastOrDefault();

            return new CursorPagedDTO<DTO>
            {
                Data = dtos ?? [],
                LastIdReturned = last?.Id,
                PageSize = size
            };
        }

        //getById
        public virtual async Task<DTO?> FindById(long id)
        {
            var model = await _repository.FindById(id);
            return model == null ? null : _mapper.Map<DTO>(model);
        }

        //create
        public virtual async Task<DTO?> Create(VO obj)
        {
            ArgumentNullException.ThrowIfNull(obj);

            var model = await _repository.Create(_mapper.Map<M>(obj));
            return _mapper.Map<DTO>(model);
        }

        //update
        public virtual async Task<DTO?> Update(VO obj)
        {
            ArgumentNullException.ThrowIfNull(obj);

            var model = await _repository.Update(_mapper.Map<M>(obj)!);
            return _mapper.Map<DTO>(model!);
        }

        //delete
        public virtual async Task Delete(long id)
          => await _repository.Delete(id);
    }
}