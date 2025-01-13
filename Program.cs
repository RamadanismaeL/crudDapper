using crudDapper.src.Data;
using crudDapper.src.Helpers.Mappers.Profiles;
using crudDapper.src.Interfaces;
using crudDapper.src.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
builder.Services.AddControllers();

var username = Environment.GetEnvironmentVariable("DB_USER") ?? throw new InvalidOperationException("DB_USER is not set");
var password = Environment.GetEnvironmentVariable("DB_PASSWORD") ?? throw new InvalidOperationException("DB_PASSWORD is not set");
var port = Environment.GetEnvironmentVariable("DB_PORT") ?? throw new InvalidOperationException("DB_PORT is not set");
var server = Environment.GetEnvironmentVariable("DB_SERVER") ?? throw new InvalidOperationException("DB_SERVER is not set");
Console.WriteLine($"user: {username}\npassword: {password}\nport: {port}\nserver: {server}");
string? connect = $"server={server}; port={port}; database=dbCrudBapper; user={username}; password={password}; Persist Security Info=false; Connect Timeout=300";

builder.Services.AddDbContextPool<CrudBapperdb>(ram => ram.UseMySql(connect, ServerVersion.AutoDetect(connect)));

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddScoped<IUsuarioServices, UsuarioService>();
builder.Services.AddAutoMapper(typeof(AutoMapperProfile));

builder.Services.AddCors(options => {
    options.AddPolicy("usuariosApp", builder => {
        builder.AllowAnyOrigin()
        .AllowAnyHeader()
        .AllowAnyMethod();
    });
});

var app = builder.Build();
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseCors("usuariosApp");
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();