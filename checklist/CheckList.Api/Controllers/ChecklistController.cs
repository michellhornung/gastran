using Microsoft.AspNetCore.Mvc;
using CheckList.Api.Models;
using CheckList.Api.Services;
// using Microsoft.AspNetCore.Authorization;


namespace CheckList.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ChecklistController : ControllerBase
    {
        private readonly ChecklistService _checklistService;

        public ChecklistController(ChecklistService checklistService)
        {
            _checklistService = checklistService;
        }

        [HttpGet]
        public async Task<IActionResult> GetChecklists()
        {
            var checklists = await _checklistService.GetChecklistsAsync();
            return Ok(checklists);
        }

        [HttpPost]
        // Validar autorização
        // [Authorize]
        public async Task<IActionResult> CreateChecklist([FromBody] Checklist checklist)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var createdChecklist = await _checklistService.CreateChecklistAsync(checklist);
            return CreatedAtAction(nameof(GetChecklists), new { id = createdChecklist.Id }, createdChecklist);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateChecklist([FromBody] Checklist checklist)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _checklistService.UpdateChecklistAsync(checklist);
            return NoContent();
        }
        
        [HttpPatch("{id}/approve")]
        public async Task<IActionResult> ApproveChecklist(int id)
        {
            var success = await _checklistService.ApproveChecklistAsync(id);

            if (!success)
            {
                return NotFound();
            }

            return NoContent(); // Indica que a operação foi bem-sucedida, mas não retorna conteúdo.
        }
    }
}