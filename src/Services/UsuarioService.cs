using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using crudDapper.src.Dtos;
using crudDapper.src.Interfaces;
using crudDapper.src.Models;

namespace crudDapper.src.Services
{
    public class UsuarioService : IUsuarioServices
    {
        public Task<ResponseModel<UsuarioListarDto>> Create(UsuarioCriarDto usuarioCriarDto)
        {
            throw new NotImplementedException();
        }

        public Task<ResponseModel<List<UsuarioListarDto>>> ReadAll()
        {
            throw new NotImplementedException();
        }

        public Task<ResponseModel<UsuarioListarDto>> Update(UsuarioEditarDto usuarioEditarDto)
        {
            throw new NotImplementedException();
        }

        public Task<ResponseModel<bool>> Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Task<ResponseModel<UsuarioListarDto>> FindById(int id)
        {
            throw new NotImplementedException();
        }
    }
}