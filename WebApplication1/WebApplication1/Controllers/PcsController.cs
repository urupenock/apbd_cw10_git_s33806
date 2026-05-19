using Microsoft.AspNetCore.Mvc;
using WebApplication1.DTOs;
using WebApplication1.Exceptions;
using WebApplication1.Services;
namespace WebApplication1.Controllers;
[ApiController]
[Route("api/pcs")] 
public class PcsController : ControllerBase
{
   private readonly IDbService _dbService;
   public PcsController(IDbService dbService)
   {
       _dbService = dbService;
   }
  
   [HttpGet]
   public async Task<IActionResult> GetAll()
   {
       var pcs = await _dbService.GetAllPcsAsync();
       return Ok(pcs);
   }
   
   [HttpGet("{id}/components")]
   public async Task<IActionResult> GetComponents(int id)
   {
       try
       {
           var components = await _dbService.GetComponentsByPcIdAsync(id);
           return Ok(components);
       }
       catch (NotFoundException ex)
       {
           return NotFound(new { message = ex.Message });
       }
   }
   [HttpPost]
   public async Task<IActionResult> Create([FromBody] CreateUpdatePcRequestDto dto)
   {
       var createdPc = await _dbService.CreatePcAsync(dto);
       return CreatedAtAction(nameof(GetAll), new { id = createdPc.Id }, createdPc);
   }
   [HttpPut("{id}")]
   public async Task<IActionResult> Update(int id, [FromBody] CreateUpdatePcRequestDto dto)
   {
       try
       {
           await _dbService.UpdatePcAsync(id, dto);
           return NoContent(); 
       }
       catch (NotFoundException ex)
       {
           return NotFound(new { message = ex.Message });
       }
   }
   [HttpDelete("{id}")]
   public async Task<IActionResult> Delete(int id)
   {
       try
       {
           await _dbService.DeletePcAsync(id);
           return NoContent(); 
       }
       catch (NotFoundException ex)
       {
           return NotFound(new { message = ex.Message });
       }
   }
}