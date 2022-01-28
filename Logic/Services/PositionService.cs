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
    public class PositionService : IPositionService
    {
        private IMapper _mapper;
        private IPositionRepository _repo;

        public PositionService(IPositionRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }


        public async Task<IEnumerable<PositionDTO>> GetPositions()
        {
            return await _repo.GetPositions()
                 .ContinueWith(t => _mapper.Map<IEnumerable<PositionDTO>>(t.Result));
        }   
        public  IEnumerable GetPositionsList()
        {
            return  _repo.GetPositionsList();
        }
        public async Task<PositionDTO> GetPositionDetails(int id)
        {
            return await _repo.GetPositionDetails(id)
                 .ContinueWith(t => _mapper.Map<PositionDTO>(t.Result));
        }

        public async Task<int> CreatePosition(PositionDTO position)
        {
            if (!await _repo.IsPositionAvailable(position.PositionName))
            {
                // throws 409 conflict
                return 0;
            }
            try
            {
                var id = await _repo.CreatePosition(_mapper.Map<PositionModel>(position)).ContinueWith(t => t.Result);

                return id;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<PositionDTO> FindById(int id)
        {
            return await _repo.FindById(id)
                .ContinueWith(t => _mapper.Map<PositionDTO>(t.Result));
        }

        public async Task<int> EditPosition(PositionDTO position)
        {
            return await _repo.EditPosition(_mapper.Map<PositionModel>(position)).ContinueWith(t => t.Result);
        }


        public async Task<bool> DeletePosition(int id)
        {
            return await _repo.DeletePosition(id);
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
