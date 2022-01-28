using DataAccess.IRepositories;
using DataAccess.Data;
using DataAccess.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace DataAccess.Repositories
{
    public class PositionRepository : IPositionRepository
    {
        private readonly DBContext _context;

        public PositionRepository(DBContext context) => _context = context;

        public async Task<IEnumerable<PositionModel>> GetPositions()
        {
            return await _context.Positions.ToListAsync().ConfigureAwait(false);
        }   
        public  IEnumerable GetPositionsList()
        {
            return  _context.Positions.ToList();
        }
        public async Task<PositionModel> GetPositionDetails(int id)
        {
            return await _context.Positions.FirstAsync(o => o.PositionID == id).ConfigureAwait(false);
        }

        public async Task<int> CreatePosition(PositionModel position)
        {
            _context.Positions.Add(position);

            await _context.SaveChangesAsync().ConfigureAwait(false);

            return position.PositionID;
        }

        public async Task<PositionModel> FindById(int id)
        {
            return await _context.Positions.FirstAsync(o => o.PositionID == id).ConfigureAwait(false);
        }

        public async Task<int> EditPosition(PositionModel position)
        {
            var _position = await _context.Positions.FirstOrDefaultAsync(p => p.PositionID == position.PositionID).ConfigureAwait(false);

            var entry = _context.Entry(_position);
            entry.CurrentValues.SetValues(position);

            return await _context.SaveChangesAsync().ConfigureAwait(false);
        }
        public async Task<bool> DeletePosition(int id)
        {
            PositionModel position = await _context.Positions.FirstAsync(p => p.PositionID == id).ConfigureAwait(false);

            var result = _context.Positions.Remove(position);

            if (result == null)
            {
                return false;
            }

            await _context.SaveChangesAsync().ConfigureAwait(false);
            return true;

        }
        public async Task<bool> IsPositionAvailable(string positionName)
        {
            return !(await _context.Positions.AnyAsync(u => u.PositionName == positionName).ConfigureAwait(false));
        }

        #region IDisposable Support
        private bool disposedValue = false; // Для определения избыточных вызовов

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                }

                disposedValue = true;
            }
        }

        void IDisposable.Dispose()
        {

            Dispose(true);

        }




        #endregion

    }
}
