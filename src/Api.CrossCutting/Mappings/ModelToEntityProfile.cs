using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.Domain.Entities;
using Api.Domain.Models;
using AutoMapper;

namespace Api.CrossCutting.Mappings
{
    public class ModelToEntityProfile : Profile
    {
        public ModelToEntityProfile()
        {
            CreateMap<UserModel, UserEntity>()
                .ReverseMap();
            CreateMap<UfModel, UfEntity>()
                .ReverseMap();
            CreateMap<MunicipioModels, MunicipioEntity>()
                .ReverseMap();
            CreateMap<CepModel, CepEntity>()
                .ReverseMap();    
        }
    }
}