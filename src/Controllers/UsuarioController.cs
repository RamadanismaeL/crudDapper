using crudDapper.src.Dtos;
using crudDapper.src.Interfaces;
using crudDapper.src.Services;
using Microsoft.AspNetCore.Mvc;

namespace crudDapper.src.Controllers
{
    [ApiController]
    public class UsuarioController(UsuarioService usuarioService) : ControllerBase, IUsuarioController
    {
        private readonly IUsuarioServices _usuarioServices = usuarioService;

        [HttpPost]
        [Route("/api/usuario/create")]
        public async Task<IActionResult> Create(UsuarioCriarDto usuarioCriarDto)
        {
            if(!ModelState.IsValid) return BadRequest(ModelState);
            var usuario = await _usuarioServices.Create(usuarioCriarDto);
            if(usuario.Status == false) return BadRequest(usuario);
            return Ok(usuario);
        }

        [HttpGet]
        [Route("/api/usuario/readAll")]
        public async Task<IActionResult> ReadAll()
        {
            var usuario = await _usuarioServices.ReadAll();
            if(usuario.Status == false) return NotFound(usuario);
            return Ok(usuario);
        }

        [HttpPut]
        [Route("/api/usuario/update")]
        public async Task<IActionResult> Update(int id, UsuarioEditarDto usuarioEditarDto)
        {
            if(!ModelState.IsValid) return BadRequest(ModelState);
            var usuario = await _usuarioServices.Update(id, usuarioEditarDto);
            if(usuario.Status == false) return BadRequest(usuario);
            return Ok(usuario);
        }

        [HttpDelete("{id}")]
        [Route("/api/usuario/delete/id{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            if(!ModelState.IsValid) return BadRequest(ModelState);
            var usuario = await _usuarioServices.Delete(id);
            if(usuario.Status == false) return BadRequest(usuario);
            return Ok(usuario);
        }

        [HttpGet("{id}")]
        [Route("/api/usuario/findById/{id}")]
        public async Task<IActionResult> FindById(int id)
        {
            if(!ModelState.IsValid) return BadRequest(ModelState);
            var usuario = await _usuarioServices.FindById(id);
            if(usuario.Status == false) return NotFound(usuario);
            return Ok(usuario);
        }
    }
}