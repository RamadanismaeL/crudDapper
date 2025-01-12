using crudDapper.src.Dtos;
using crudDapper.src.Interfaces;
using crudDapper.src.Services;
using Microsoft.AspNetCore.Mvc;

namespace crudDapper.src.Controllers
{
    [ApiController]
    public class UsuarioController(IUsuarioServices usuarioService) : ControllerBase, IUsuarioController
    {
        private readonly IUsuarioServices _usuarioServices = usuarioService;

        [HttpPost]
        [Route("/api/usuario/create")]
        public async Task<ActionResult> Create(UsuarioCriarDto usuarioCriarDto)
        {
            if(!ModelState.IsValid) return BadRequest(ModelState);
            var usuario = await _usuarioServices.Create(usuarioCriarDto);
            if(usuario.Status == false) return BadRequest(usuario);
            return Ok(usuario);
        }

        [HttpGet]
        [Route("/api/usuario/readAll")]
        public async Task<ActionResult> ReadAll()
        {
            var usuario = await _usuarioServices.ReadAll();
            if(usuario.Status == false) return NotFound(usuario);
            return Ok(usuario);
        }

        [HttpPut]
        [Route("/api/usuario/update")]
        public async Task<ActionResult> Update(UsuarioEditarDto usuarioEditarDto)
        {
            if(!ModelState.IsValid) return BadRequest(ModelState);
            var usuario = await _usuarioServices.Update(usuarioEditarDto);
            if(usuario.Status == false) return BadRequest(usuario);
            return Ok(usuario);
        }

        [HttpDelete]
        [Route("/api/usuario/delete")]
        public async Task<ActionResult> Delete(UsuarioDeleteDto usuarioDeleteDto)
        {
            if(!ModelState.IsValid) return BadRequest(ModelState);
            var usuario = await _usuarioServices.Delete(usuarioDeleteDto);
            if(usuario.Status == false) return BadRequest(usuario);
            return Ok(usuario);
        }

        [HttpGet]
        [Route("/api/usuario/findById")]
        public async Task<ActionResult> FindById(UsuarioFindID usuarioFindID)
        {
            if(!ModelState.IsValid) return BadRequest(ModelState);
            var usuario = await _usuarioServices.FindById(usuarioFindID);
            if(usuario.Status == false) return NotFound(usuario);
            return Ok(usuario);
        }
    }
}