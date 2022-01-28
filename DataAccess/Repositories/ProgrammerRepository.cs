using DataAccess.IRepositories;
using DataAccess.Data;
using DataAccess.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories
{
    public class ProgrammerRepository : IProgrammerRepository
    {
        private readonly DBContext _context;

        public ProgrammerRepository(DBContext context) => _context = context;

        public async Task<IEnumerable<ProgrammerModel>> GetProgrammers()
        {
            return await _context.Programmers.Include(c => c.Position).ToListAsync().ConfigureAwait(false);
        }
        public async Task<ProgrammerModel> GetProgrammerDetails(int id)
        {
            return await _context.Programmers.Include(c => c.Position).FirstAsync(o => o.ProgrammerID == id).ConfigureAwait(false);
        }

        public async Task<int> CreateProgrammer(ProgrammerModel programmer)
        {
            _context.Programmers.Add(programmer);

            await _context.SaveChangesAsync().ConfigureAwait(false);

            return programmer.PositionID;
        }

        public async Task<ProgrammerModel> FindById(int id)
        {
            return await _context.Programmers.FirstAsync(o => o.ProgrammerID == id).ConfigureAwait(false);
        }

        public async Task<int> EditProgrammer(ProgrammerModel programmer)
        {
            var _programmer = await _context.Programmers.FirstOrDefaultAsync(p => p.ProgrammerID == programmer.ProgrammerID).ConfigureAwait(false);

            var entry = _context.Entry(_programmer);
            entry.CurrentValues.SetValues(programmer);

            return await _context.SaveChangesAsync().ConfigureAwait(false);
        }
        public async Task<bool> DeleteProgrammer(int id)
        {
            ProgrammerModel programmer = await _context.Programmers.FirstAsync(p => p.ProgrammerID == id).ConfigureAwait(false);

            var result = _context.Programmers.Remove(programmer);

            if (result == null)
            {
                return false;
            }

            await _context.SaveChangesAsync().ConfigureAwait(false);
            return true;

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