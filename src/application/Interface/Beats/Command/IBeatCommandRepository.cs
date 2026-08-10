using src.domain.models;

namespace src.application.Interface.Beats.Command
{
    public interface IBeatRepository
    {
        Task<Beat> CreateAsync(Beat beat);
        Task UpdateAsync(Beat beat);
        Task DeleteAsync(Guid id);
    }
}