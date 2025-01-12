using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
/**
** @author Ramadan Ismael
*/
namespace crudDapper.src.Models
{
    public class UsuarioModel
    {
        public int Id { get; set; }
        public string? NomeCompleto { get; set; }
        public string? Email { get; set; }
        public string? Cargo { get; set; }
        public double? Salario { get; set; }
        public string? CPF { get; set; }
        public bool Situacao { get; set; }
        public string? Senha { get; set; }
    }
}