using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using crudDapper.src.Models;
using crudDapper.src.Repositories.Data.Maps;
using Microsoft.EntityFrameworkCore;

namespace crudDapper.src.Repositories.Data
{
    public class CrudBapperdb : DbContext
    {
        public CrudBapperdb(DbContextOptions<CrudBapperdb> options) : base(options)
        {}

        public required DbSet<UsuarioModel> Usuarios { get; set; }

        protected override void OnModelCreating(ModelBuilder model)
        {
            try
            {
                model.ApplyConfiguration(new UsuarioMap());
                base.OnModelCreating(model);
            }
            catch (Exception error)
            {
                throw new Exception($"Error: {error.Message}");
            }
        }
    }
}