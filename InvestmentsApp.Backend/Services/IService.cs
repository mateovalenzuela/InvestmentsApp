namespace InvestmentsApp.Backend.Services
{
    public interface IService<Dto, insertDto, updateDto>
    {
        Dictionary<string,string> Errors { get; }

        Task<IEnumerable<Dto>> GetAll();
        Task<Dto?> GetById(long id);

        Task<Dto> Add(insertDto dto);

        Task<Dto?> Update(long id, updateDto dto);

        Task<Dto?> Delete(long id);
    }
}
