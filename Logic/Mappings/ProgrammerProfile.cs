using AutoMapper;
using DataAccess.Models;
using Logic.DTOModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Mappings
{
    public class ProgrammerProfile : Profile
    {
        public ProgrammerProfile()
        {
            CreateMap<ProgrammerDTO, ProgrammerModel>().ReverseMap();
            CreateMap<ProgrammerModel, ProgrammerDTO>();
        }
    }
}
