using AutoMapper;
using DataAccess.IRepositories;
using DataAccess.Models;
using Logic.DTOModels;
using Logic.IServices;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Services
{
    public class ProgrammerService : IProgrammerService
    {
        private IMapper _mapper;
        private IProgrammerRepository _repo;

        public ProgrammerService(IProgrammerRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }


        public async Task<IEnumerable<ProgrammerDTO>> GetProgrammers()
        {
            return await _repo.GetProgrammers()
                 .ContinueWith(t => _mapper.Map<IEnumerable<ProgrammerDTO>>(t.Result));
        }   
        public async Task<ProgrammerDTO> GetProgrammerDetails(int id)
        {
            return await _repo.GetProgrammerDetails(id)
                 .ContinueWith(t => _mapper.Map<ProgrammerDTO>(t.Result));
        }

        public async Task<int> CreateProgrammer(ProgrammerDTO programmer)
        {
            try
            {
                var id = await _repo.CreateProgrammer(_mapper.Map<ProgrammerModel>(programmer)).ContinueWith(t => t.Result);

                return id;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<ProgrammerDTO> FindById(int id)
        {
            return await _repo.FindById(id)
                .ContinueWith(t => _mapper.Map<ProgrammerDTO>(t.Result));
        }

        public async Task<int> EditProgrammer(ProgrammerDTO position)
        {
            return await _repo.EditProgrammer(_mapper.Map<ProgrammerModel>(position)).ContinueWith(t => t.Result);
        }


        public async Task<bool> DeleteProgrammer(int id)
        {
            return await _repo.DeleteProgrammer(id);
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
