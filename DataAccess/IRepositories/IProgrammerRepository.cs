using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.IRepositories
{
    public interface IProgrammerRepository : IDisposable
    {
        Task<IEnumerable<ProgrammerModel>> GetProgrammers();
        Task<ProgrammerModel> GetProgrammerDetails(int id);
        Task<int> CreateProgrammer(ProgrammerModel programmer);
        Task<ProgrammerModel> FindById(int id);
        Task<int> EditProgrammer(ProgrammerModel programmer);
        Task<bool> DeleteProgrammer(int id);
    }
}
