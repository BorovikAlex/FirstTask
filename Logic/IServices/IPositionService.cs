using Logic.DTOModels;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.IServices
{
    public interface IPositionService : IDisposable
    {
        Task<IEnumerable<PositionDTO>> GetPositions();
        IEnumerable GetPositionsList();
        Task<PositionDTO> GetPositionDetails(int id);
        Task<int> CreatePosition(PositionDTO position);
        Task<PositionDTO> FindById(int id);
        Task<int> EditPosition(PositionDTO position);
        Task<bool> DeletePosition(int id);
    }
}
