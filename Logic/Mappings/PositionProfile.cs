using AutoMapper;
using DataAccess.Models;
using Logic.DTOModels;

namespace Logic.Mappings
{
    public class PositionProfile : Profile
    {
        public PositionProfile()
        {
            CreateMap<PositionDTO, PositionModel>().ReverseMap();
            CreateMap<PositionModel, PositionDTO>();
        }
    }
}
