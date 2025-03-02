using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using Pedidos.Aplicacion.Comandos;
using Pedidos.Aplicacion.Consultas;
using Pedidos.Dominio.Puertos.Repositorios;
using Pedidos.Infraestructura.Adaptadores.Repositorios;
using Pedidos.Infraestructura.RepositorioGenerico;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Version = "V.1.0.1",
        Title = "Servicio Pedidos",
        Description = "Administración de pedidos"
    });
    options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        In = ParameterLocation.Header,
        Name = "Authorization",
        Type = SecuritySchemeType.Http,
        BearerFormat = "JWT",
        Scheme = "Bearer"
    });
    options.AddSecurityRequirement(new OpenApiSecurityRequirement
        {
            {
                new OpenApiSecurityScheme
                {
                    Reference = new OpenApiReference
                    {
                        Type=ReferenceType.SecurityScheme,
                        Id="Bearer"
                    }
                },
            Array.Empty<string>()
            }
        });

    var xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFilename));
});

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddDbContext<PedidosDbContext>(options =>
                options.UseSqlite(builder.Configuration.GetConnectionString("PedidosDbContext")), ServiceLifetime.Transient);
builder.Services.AddTransient(typeof(IRepositorioBase<>), typeof(RepositorioBase<>));
builder.Services.AddTransient<IPedidoRepositorio, PedidoRepositorio>();
builder.Services.AddScoped<IComandosProducto, ManejadorComandos>();
builder.Services.AddScoped<IConsultasProducto, ManejadorConsultas>();

SQLitePCL.Batteries.Init();

var app = builder.Build();
app.UseSwagger();
app.UseSwaggerUI();
app.UseAuthorization();
app.MapControllers();

await app.RunAsync();
