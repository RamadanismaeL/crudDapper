using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using crudDapper.src.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace crudDapper.src.Interfaces
{
    public interface IUsuarioController
    {
        Task<ActionResult> Create(UsuarioCriarDto usuarioCriarDto);
        Task<ActionResult> ReadAll();
        Task<ActionResult> Update(UsuarioEditarDto usuarioEditarDto);
        Task<ActionResult> Delete(UsuarioDeleteDto usuarioDeleteDto);
        Task<ActionResult> FindById(UsuarioFindID usuarioFindID);
    }
}