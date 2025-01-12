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
            Console.WriteLine($"NomeCompleto: {usuarioCriarDto.NomeCompleto}");
            Console.WriteLine($"Email: {usuarioCriarDto.Email}");
            Console.WriteLine($"Cargo: {usuarioCriarDto.Cargo}");
            Console.WriteLine($"Salario: {usuarioCriarDto.Salario}");
            Console.WriteLine($"CPF: {usuarioCriarDto.CPF}");
            Console.WriteLine($"Situacao: {usuarioCriarDto.Situacao}");
            Console.WriteLine($"Senha: {usuarioCriarDto.Senha}");

            try
            {
                if (_crudBapperdb == null)
                {
                    response.Mensagem = "Erro interno: serviço de banco de dados não está configurado.";
                    response.Status = false;
                    return response;
                }
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

        public async Task<ResponseModel<UsuarioListarDto>> Update(UsuarioEditarDto usuarioEditarDto)
        {
            Console.WriteLine($"ID User: {usuarioEditarDto.Id}");
            var response = new ResponseModel<UsuarioListarDto>();
            try
            {
                if(usuarioEditarDto.Id <= 0)
                {
                    response.Mensagem = "ID inválido.";
                    response.Status = false;
                    return response;
                }

                var usuarioExist = await _crudBapperdb.Usuarios.FindAsync(usuarioEditarDto.Id);
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

        public async Task<ResponseModel<UsuarioListarDto>> Delete(UsuarioDeleteDto usuarioDeleteDto)
        {
            var response = new ResponseModel<UsuarioListarDto>();
            try
            {
                if(usuarioDeleteDto.Id <= 0)
                {
                    response.Mensagem = "ID inválido.";
                    response.Status = false;
                    return response;
                }

                var usuarioExist = await _crudBapperdb.Usuarios.FindAsync(usuarioDeleteDto.Id);
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

        public async Task<ResponseModel<UsuarioListarDto>> FindById(UsuarioFindID usuarioFindID)
        {
            var response = new ResponseModel<UsuarioListarDto>();
            try
            {
                if(usuarioFindID.Id <= 0)
                {
                    response.Mensagem = "ID inválido.";
                    response.Status = false;
                    return response;
                }

                var usuarioExist = await _crudBapperdb.Usuarios.FindAsync(usuarioFindID.Id);
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