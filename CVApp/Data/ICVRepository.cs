using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CVApp.Data
{
    public interface ICVRepository
    {
        Task<IList<CV>> GetAllCVs();
        Task CreateCV(CV cv);
        Task<CV> GetCvByID(int id);
        Task<List<Skill>> GetSkillsByID(int id);
        Task DeleteCv(int id);
        Task<bool> UpdateCv(CV cv);
    }
}
