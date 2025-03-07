
using Microsoft.OpenApi.Models;
//using NLog;
//using NLog.Web;
using System.Reflection;

//var logger = LogManager.Setup().LoadConfigurationFromAppSettings().GetCurrentClassLogger();

//try
//{
    var builder = WebApplication.CreateBuilder(args);

    builder.Services.AddControllers();
    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddSwaggerGen(options =>
    {

        options.SwaggerDoc("v1", new OpenApiInfo
        {
            Version = "V.1.0.1",
            Title = "Gateway Api",
            Description = "Descripci�n",
        });

        var xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
        options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFilename));

    });

    builder.Logging.ClearProviders();
    //builder.Host.UseNLog();

    var config = builder.Configuration.GetSection("ReverseProxy");
    builder.Services
        .AddReverseProxy()
        .LoadFromConfig(config);

    builder.Services.AddRequestTimeouts();
    builder.Services.AddCors(options =>
    {
        options.AddPolicy("AllowSpecificMethods",
            builder => builder.AllowAnyOrigin()
                              .WithMethods("GET", "POST", "OPTIONS")
                              .AllowAnyHeader());
    });

    var app = builder.Build();

    app.Use((context, next) =>
    {
        context.Response.Headers["Access-Control-Allow-Origin"] = "*";
        return next.Invoke();
    });
    app.UseCors("AllowSpecificMethods");

    app.UseSwagger();
    app.UseSwaggerUI();
    app.UseAuthorization();
    app.MapControllers();
    app.UseRequestTimeouts();
    app.MapReverseProxy();
    await app.RunAsync();
//}
//catch (Exception ex)
//{
    //logger.Error(ex, "Error inicializando program.cs");
//}
//finally
//{
//    LogManager.Shutdown();
//}

