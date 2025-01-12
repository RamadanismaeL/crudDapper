using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using crudDapper.src.Dtos;
using crudDapper.src.Models;

namespace crudDapper.src.Helpers.Mappers.Profiles
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<UsuarioModel, UsuarioListarDto>();
        }
    }
}