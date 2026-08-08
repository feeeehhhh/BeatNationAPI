using src.Models;
namespace src.features.Interface.Beats.Query
{
    public interface IBeatQueryRepository
    {
        Task<Beat> GetByIdAsync(Guid id);
        Task<IEnumerable<Beat>> GetAllAsync();
    }
}