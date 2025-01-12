﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using crudDapper.src.Data;

#nullable disable

namespace crudDapper.Migrations
{
    [DbContext(typeof(CrudBapperdb))]
    partial class CrudBapperdbModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            MySqlModelBuilderExtensions.AutoIncrementColumns(modelBuilder);

            modelBuilder.Entity("crudDapper.src.Models.UsuarioModel", b =>
                {
                    b.Property<ulong>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint unsigned")
                        .HasColumnName("id");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<ulong>("Id"));

                    b.Property<string>("CPF")
                        .HasMaxLength(75)
                        .HasColumnType("varchar(75)")
                        .HasColumnName("cpf");

                    b.Property<string>("Cargo")
                        .HasMaxLength(75)
                        .HasColumnType("varchar(75)")
                        .HasColumnName("position");

                    b.Property<string>("Email")
                        .HasMaxLength(75)
                        .HasColumnType("varchar(75)")
                        .HasColumnName("email");

                    b.Property<string>("NomeCompleto")
                        .IsRequired()
                        .HasMaxLength(75)
                        .HasColumnType("varchar(45)")
                        .HasColumnName("name");

                    b.Property<decimal?>("Salario")
                        .HasColumnType("decimal(10,2)")
                        .HasColumnName("salary");

                    b.Property<string>("Senha")
                        .IsRequired()
                        .HasMaxLength(45)
                        .HasColumnType("varchar(45)")
                        .HasColumnName("passwordUser");

                    b.Property<bool>("Situacao")
                        .HasColumnType("tinyint(1)")
                        .HasColumnName("status");

                    b.HasKey("Id");

                    b.ToTable("tbUsuario", (string)null);
                });
#pragma warning restore 612, 618
        }
    }
}
