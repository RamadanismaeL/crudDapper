using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using crudDapper.src.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace crudDapper.src.Data.Maps
{
    public class UsuarioMap : IEntityTypeConfiguration<UsuarioModel>
    {
        public void Configure(EntityTypeBuilder<UsuarioModel> builder)
        {
            try
            {
                builder.ToTable("tbUsuario");

                builder.Property(u => u.Id)
                .HasColumnName("id")
                .HasColumnType("bigint unsigned")
                .ValueGeneratedOnAdd()
                .IsRequired();
                builder.HasKey(u => u.Id);

                builder.Property(u => u.NomeCompleto)
                .HasColumnName("name")
                .HasColumnType("varchar(45)")
                .HasMaxLength(75)
                .IsRequired();

                builder.Property(u => u.Email)
                .HasColumnName("email")
                .HasColumnType("varchar(75)")
                .HasMaxLength(75);

                builder.Property(u => u.Cargo)
                .HasColumnName("position")
                .HasColumnType("varchar(75)")
                .HasMaxLength(75);

                builder.Property(u => u.Salario)
                .HasColumnName("salary")
                .HasColumnType("decimal(10,2)");

                builder.Property(u => u.CPF)
                .HasColumnName("cpf")
                .HasColumnType("varchar(75)")
                .HasMaxLength(75);

                builder.Property(u => u.Situacao)
                .HasColumnName("status");

                builder.Property(u => u.Senha)
                .HasColumnName("passwordUser")
                .HasColumnType("varchar(45)")
                .HasMaxLength(45)
                .IsRequired();
            }
            catch (Exception error)
            {
                throw new Exception($"Error: {error.Message}");
            }
        }
    }
}