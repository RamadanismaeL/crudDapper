using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using crudDapper.src.Dtos;
using crudDapper.src.Models;

namespace crudDapper.src.Interfaces
{
    public interface IUsuarioServices
    {
        Task<ResponseModel<List<UsuarioListarDto>>> Create(UsuarioCriarDto usuarioCriarDto);
        Task<ResponseModel<UsuarioListarDto>> ReadAll();
        Task<ResponseModel<UsuarioListarDto>> Update(UsuarioEditarDto usuarioEditarDto);
        Task<ResponseModel<bool>> Delete(int id);
        Task<ResponseModel<UsuarioListarDto>> FindById(int id);
    }
}