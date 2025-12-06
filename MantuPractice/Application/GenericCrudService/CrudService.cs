using AutoMapper;
using MantuPractice.Infrastructure;
using System.Net.Mail;

namespace MantuPractice.Application.GenericCrudService
{
    public class CrudService<T, TDto> : ICrudService<TDto>
     where T : class
    {
        private readonly ICrudRepository<T> _repo;
        private readonly IMapper _mapper;

        public CrudService(ICrudRepository<T> repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public async Task<IEnumerable<TDto>> GetAll()
        {
            var items = await _repo.GetAllAsync();
          //  var mapped = AutoMapper<AttachmentDTO, Attachment>().MapToObject(attachmentDetails)
            return _mapper.Map<IEnumerable<TDto>>(items);
        }

        public async Task<TDto> GetById(int id)
        {
            var item = await _repo.GetByIdAsync(id);
            return _mapper.Map<TDto>(item);
        }

        public async Task<TDto> Create(TDto dto)
        {
            var entity = _mapper.Map<T>(dto);
            var created = await _repo.CreateAsync(entity);
            return _mapper.Map<TDto>(created);
        }

        public async Task<TDto> Update(TDto dto)
        {
            var entity = _mapper.Map<T>(dto);
            var updated = await _repo.UpdateAsync(entity);
            return _mapper.Map<TDto>(updated);
        }

        public async Task Delete(int id)
        {
            await _repo.DeleteAsync(id);
        }
    }

}
