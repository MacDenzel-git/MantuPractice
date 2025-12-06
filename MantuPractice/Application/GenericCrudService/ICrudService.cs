namespace MantuPractice.Application.GenericCrudService
{
    public interface ICrudService<TDto>
    {
        Task<IEnumerable<TDto>> GetAll();
        Task<TDto> GetById(int id);
        Task<TDto> Create(TDto dto);
        Task<TDto> Update(TDto dto);
        Task Delete(int id);
    }
}
