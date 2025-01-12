using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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