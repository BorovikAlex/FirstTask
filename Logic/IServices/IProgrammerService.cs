using Logic.DTOModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.IServices
{
    public interface IProgrammerService : IDisposable
    {
        Task<IEnumerable<ProgrammerDTO>> GetProgrammers();
        Task<ProgrammerDTO> GetProgrammerDetails(int id);
        Task<int> CreateProgrammer(ProgrammerDTO programmer);
        Task<ProgrammerDTO> FindById(int id);
        Task<int> EditProgrammer(ProgrammerDTO programmer);
        Task<bool> DeleteProgrammer(int id);
    }
}
