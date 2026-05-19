using Microsoft.EntityFrameworkCore;
using WebApplication1.Data;
using WebApplication1.DTOs;
using WebApplication1.Entities;
using WebApplication1.Exceptions;
namespace WebApplication1.Services;
public class DbService : IDbService
{
   private readonly AppDbContext _context;
   public DbService(AppDbContext context)
   {
       _context = context;
   }
   public async Task<IEnumerable<PcResponseDto>> GetAllPcsAsync()
   {
       return await _context.Pcs
           .Select(p => new PcResponseDto
           {
               Id = p.Id,
               Name = p.Name,
               Weight = p.Weight,
               Warranty = p.Warranty,
               CreatedAt = p.CreatedAt,
               Stock = p.Stock
           }).ToListAsync();
   }
   public async Task<IEnumerable<PcComponentResponseDto>> GetComponentsByPcIdAsync(int pcId)
   {
       var pcExists = await _context.Pcs.AnyAsync(p => p.Id == pcId);
       if (!pcExists)
       {
           throw new NotFoundException($"PC with ID {pcId} not found.");
       }
       return await _context.PcComponents
           .Where(pc => pc.PcId == pcId)
           .Select(pc => new PcComponentResponseDto
           {
               ComponentCode = pc.ComponentCode,
               Name = pc.Component.Name,
               Amount = pc.Amount
           }).ToListAsync();
   }
   public async Task<PcResponseDto> CreatePcAsync(CreateUpdatePcRequestDto dto)
   {
       var pc = new Pc
       {
           Name = dto.Name,
           Weight = dto.Weight,
           Warranty = dto.Warranty,
           CreatedAt = dto.CreatedAt,
           Stock = dto.Stock
       };
       _context.Pcs.Add(pc);
       await _context.SaveChangesAsync();
       return new PcResponseDto
       {
           Id = pc.Id,
           Name = pc.Name,
           Weight = pc.Weight,
           Warranty = pc.Warranty,
           CreatedAt = pc.CreatedAt,
           Stock = pc.Stock
       };
   }
   public async Task UpdatePcAsync(int id, CreateUpdatePcRequestDto dto)
   {
       var pc = await _context.Pcs.FindAsync(id);
       if (pc == null)
       {
           throw new NotFoundException($"PC with ID {id} not found.");
       }
       pc.Name = dto.Name;
       pc.Weight = dto.Weight;
       pc.Warranty = dto.Warranty;
       pc.CreatedAt = dto.CreatedAt;
       pc.Stock = dto.Stock;
       await _context.SaveChangesAsync();
   }
   public async Task DeletePcAsync(int id)
   {
       var pc = await _context.Pcs.FindAsync(id);
       if (pc == null)
       {
           throw new NotFoundException($"PC with ID {id} not found.");
       }
       _context.Pcs.Remove(pc);
       await _context.SaveChangesAsync();
   }
}