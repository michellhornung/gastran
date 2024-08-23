using CheckList.Api.Models;
using CheckList.Api.Data;
using Microsoft.EntityFrameworkCore;

namespace CheckList.Api.Services
{
    public class ChecklistService
    {
        private readonly ApplicationDbContext _context;

        public ChecklistService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Checklist> CreateChecklistAsync(Checklist checklist)
        {
            _context.Checklists.Add(checklist);
            await _context.SaveChangesAsync();
            return checklist;
        }

        public async Task<Checklist> UpdateChecklistAsync(Checklist checklist)
        {
            if (checklist.Id <= 0)
            {
                throw new ArgumentException("Id inválido para atualização");
            }

            _context.Checklists.Update(checklist);
            await _context.SaveChangesAsync();
    
            return checklist;
        }

        public async Task<List<Checklist>> GetChecklistsAsync()
        {
            return await _context.Checklists
                .Include(c => c.Itens)
                .ToListAsync();
        }
        
        public async Task<bool> ApproveChecklistAsync(int id)
        {
            var checklist = await _context.Checklists.FindAsync(id);

            if (checklist == null)
            {
                return false;
            }

            checklist.Aprovado = true;
            _context.Checklists.Update(checklist);
            await _context.SaveChangesAsync();

            return true;
        }
    }

}