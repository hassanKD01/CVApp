using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CVApp.Data;
using CVApp.Services;
using Microsoft.EntityFrameworkCore;

namespace CVApp.Data
{
    public class CVSqlRepository : ICVRepository
    {
        private readonly CVsDbContext _context;

        public CVSqlRepository(CVsDbContext context)
        {
            _context = context;
        }

        public async Task<IList<CV>> GetAllCVs()
        {
            return await _context.CVs.ToListAsync();
        }

        public async Task CreateCV(CV cv)
        {
            _context.CVs.Add(cv);
            await _context.SaveChangesAsync();
        }

        public async Task<CV> GetCvByID(int id)
        {
            return await _context.CVs.Include(cv => cv.Skills).FirstOrDefaultAsync(m => m.ID == id);
        }

        public async Task<List<Skill>> GetSkillsByID(int id)
        {
            return await _context.Skills.Where(s => s.CVId == id).ToListAsync();
        }

        public async Task DeleteCv(int id)
        {
            CV cv= await _context.CVs.FindAsync(id);
            _context.CVs.Remove(cv);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> UpdateCv(CV cv)
        {
            await DeleteSkills(cv.ID);
            _context.Attach(cv).State = EntityState.Modified;
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (GetCvByID(cv.ID) == null)
                {
                    return false;
                }
                else
                {
                    throw;
                }
            }
            return true;
        }
        
        public async Task DeleteSkills(int id)
        {
            List<Skill> skills = await GetSkillsByID(id);
            _context.RemoveRange(skills);
            await _context.SaveChangesAsync();
        }
    }
}
