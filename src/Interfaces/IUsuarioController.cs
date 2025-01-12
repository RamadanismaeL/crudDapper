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
        Task<IActionResult> Create(UsuarioCriarDto usuarioCriarDto);
        Task<IActionResult> ReadAll();
        Task<IActionResult> Update(int id, UsuarioEditarDto usuarioEditarDto);
        Task<IActionResult> Delete(int id);
        Task<IActionResult> FindById(int id);
    }
}