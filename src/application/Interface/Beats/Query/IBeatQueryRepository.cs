using src.domain.models;
namespace src.application.Interface.Beats.Query
{
    public interface IBeatQueryRepository
    {
        Task<Beat> GetByIdAsync(Guid id);
        Task<IEnumerable<Beat>> GetAllAsync();
    }
}