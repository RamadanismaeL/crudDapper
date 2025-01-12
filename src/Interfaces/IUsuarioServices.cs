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
        Task<ResponseModel<UsuarioListarDto>> Update(UsuarioEditarDto usuarioEditarDto);
        Task<ResponseModel<UsuarioListarDto>> Delete(UsuarioDeleteDto usuarioDeleteDto);
        Task<ResponseModel<UsuarioListarDto>> FindById(UsuarioFindID usuarioFindID);
    }
}