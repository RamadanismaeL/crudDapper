using AutoMapper;
using crudDapper.src.Dtos;
using crudDapper.src.Interfaces;
using crudDapper.src.Models;
using crudDapper.src.Data;
using Microsoft.EntityFrameworkCore;

namespace crudDapper.src.Services
{
    public class UsuarioService(CrudBapperdb crudBapperdb, IMapper mapper) : IUsuarioServices
    {
        private readonly CrudBapperdb _crudBapperdb = crudBapperdb;
        private readonly IMapper _mapper = mapper;

        public async Task<ResponseModel<UsuarioListarDto>> Create(UsuarioCriarDto usuarioCriarDto)
        {
            var response = new ResponseModel<UsuarioListarDto>();

            try
            {
                var usuarioMapeado = _mapper.Map<UsuarioModel>(usuarioCriarDto);
                await _crudBapperdb.Usuarios.AddAsync(usuarioMapeado);
                await _crudBapperdb.SaveChangesAsync();

                var usuarioDto = _mapper.Map<UsuarioListarDto>(usuarioMapeado);
                response.Dados = usuarioDto;
                response.Mensagem = "Usuário registrado com sucesso!";
                response.Status = true;
            }
            catch (Exception error)
            {
                response.Mensagem = $"Ocorreu um erro ao registrar o usuário: {error.Message}";
                response.Status = false;
            }

            return response;
        }

        public async Task<ResponseModel<List<UsuarioListarDto>>> ReadAll()
        {
            var response = new ResponseModel<List<UsuarioListarDto>>();
            try
            {
                var usuariosList = await _crudBapperdb.Usuarios.ToListAsync();
                if(usuariosList == null)
                {
                    response.Mensagem = "Nenhum usuário encontrado.";
                    response.Status = false;
                    return response;
                }

                var usuarioDto = _mapper.Map<List<UsuarioListarDto>>(usuariosList);
                response.Dados = usuarioDto;
                response.Mensagem = "Usuários localizados com sucesso!";
                response.Status = true;
            }
            catch (Exception error)
            {
                response.Mensagem = $"Ocorreu um erro ao localizar os usuários: {error.Message}";
                response.Status = false;
            }

            return response;
        }

        public async Task<ResponseModel<UsuarioListarDto>> Update(int id, UsuarioEditarDto usuarioEditarDto)
        {
            var response = new ResponseModel<UsuarioListarDto>();
            try
            {
                if(id <= 0)
                {
                    response.Mensagem = "ID inválido.";
                    response.Status = false;
                    return response;
                }

                var usuarioExist = await _crudBapperdb.Usuarios.FindAsync(id);
                if(usuarioExist == null)
                {
                    response.Mensagem = "Usuário não encontrado.";
                    response.Status = false;
                    return response;
                }

                var usuarioMapeado = _mapper.Map(usuarioEditarDto, usuarioExist);
                _crudBapperdb.Usuarios.Update(usuarioMapeado);
                await _crudBapperdb.SaveChangesAsync();

                var usuarioDto = _mapper.Map<UsuarioListarDto>(usuarioMapeado);
                response.Dados = usuarioDto;
                response.Mensagem = "Usuário atualizado com sucesso!";
                response.Status = true;
            }
            catch (Exception error)
            {
                response.Mensagem = $"Ocorreu um erro ao atualizar o usuário: {error.Message}";
                response.Status = false;
            }
            return response;
        }

        public async Task<ResponseModel<UsuarioListarDto>> Delete(int id)
        {
            var response = new ResponseModel<UsuarioListarDto>();
            try
            {
                if(id <= 0)
                {
                    response.Mensagem = "ID inválido.";
                    response.Status = false;
                    return response;
                }

                var usuarioExist = await _crudBapperdb.Usuarios.FindAsync(id);
                if(usuarioExist == null)
                {
                    response.Mensagem = "Usuário não encontrado.";
                    response.Status = false;
                    return response;
                }

                _crudBapperdb.Usuarios.Remove(usuarioExist);
                await _crudBapperdb.SaveChangesAsync();

                response.Mensagem = "Usuário deletado com sucesso!";
                response.Status = true;
            }
            catch (Exception error)
            {
                response.Mensagem = $"Ocorreu um erro ao deletar o usuário: {error.Message}";
                response.Status = false;
            }
            return response;
        }

        public async Task<ResponseModel<UsuarioListarDto>> FindById(int id)
        {
            var response = new ResponseModel<UsuarioListarDto>();
            try
            {
                if(id <= 0)
                {
                    response.Mensagem = "ID inválido.";
                    response.Status = false;
                    return response;
                }

                var usuarioExist = await _crudBapperdb.Usuarios.FindAsync(id);
                if(usuarioExist == null)
                {
                    response.Mensagem = "Usuário não encontrado.";
                    response.Status = false;
                    return response;
                }

                var usuarioDto = _mapper.Map<UsuarioListarDto>(usuarioExist);
                response.Dados = usuarioDto;
                response.Mensagem = "Usuário localizado com sucesso!";
                response.Status = true;
            }
            catch (Exception error)
            {
                response.Mensagem = $"Ocorreu um erro ao localizar o usuário por ID: {error.Message}";
                response.Status = false;
            }
            return response;
        }
    }
}