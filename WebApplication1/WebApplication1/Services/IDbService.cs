using WebApplication1.DTOs;
namespace WebApplication1.Services;
public interface IDbService
{
    Task<IEnumerable<PcResponseDto>> GetAllPcsAsync();
    Task<IEnumerable<PcComponentResponseDto>> GetComponentsByPcIdAsync(int pcId);
    Task<PcResponseDto> CreatePcAsync(CreateUpdatePcRequestDto dto);
    Task UpdatePcAsync(int id, CreateUpdatePcRequestDto dto);
    Task DeletePcAsync(int id);
}