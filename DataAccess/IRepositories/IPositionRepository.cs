using DataAccess.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.IRepositories
{
    public interface IPositionRepository : IDisposable
    {
        Task<IEnumerable<PositionModel>> GetPositions();
        IEnumerable GetPositionsList();
        Task<PositionModel> GetPositionDetails(int id);
        Task<int> CreatePosition(PositionModel position);
        Task<PositionModel> FindById(int id);
        Task<int> EditPosition(PositionModel position);
        Task<bool> DeletePosition(int id);
        Task<bool> IsPositionAvailable(string positionName);
    }
}
