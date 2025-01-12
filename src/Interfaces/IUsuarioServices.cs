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
        Task<ResponseModel<UsuarioListarDto>> Create(UsuarioCriarDto usuarioCriarDto);
        Task<ResponseModel<List<UsuarioListarDto>>> ReadAll();
        Task<ResponseModel<UsuarioListarDto>> Update(int id, UsuarioEditarDto usuarioEditarDto);
        Task<ResponseModel<UsuarioListarDto>> Delete(int id);
        Task<ResponseModel<UsuarioListarDto>> FindById(int id);
    }
}