using iHelpU.MODEL.Models;

public interface IAnuncioServico_Service
{
    Task<IEnumerable<AnuncioServico>> GetAllAsync();
    Task<AnuncioServico> GetByIdAsync(int id);
    Task<AnuncioServico> CreateAsync(AnuncioServico anuncioServico);
    Task UpdateAsync(AnuncioServico anuncioServico);
    Task DeleteAsync(int id);
}
