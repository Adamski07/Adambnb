//Adam Abdelbakey
//s1178952
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Adambnb.Data;
using Adambnb.Mapping;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;
using System.Reflection;
using System.Text.Json.Serialization;
using Asp.Versioning;
using Adambnb;
using Adambnb.Services;


var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<AdambnbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("AdambnbContext") ?? throw new InvalidOperationException("Connection string 'AdambnbContext' not found.")));

// Add services to the container.
builder.Services.AddAutoMapper(typeof(MappingProfile));
builder.Services.AddControllers();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<ILocationService, LocationService>();


builder.Services.AddApiVersioning(options =>
{
    options.AssumeDefaultVersionWhenUnspecified = true;
    options.DefaultApiVersion = new ApiVersion(1, 0);
    options.ReportApiVersions = true;
    options.ApiVersionReader = new QueryStringApiVersionReader("api-version");
}).AddMvc();

builder.Services.AddControllers()
    .AddJsonOptions(opt =>
    {
        opt.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
    });

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("1.0", new OpenApiInfo { Title = "V1", Version = "1.0" });
    options.SwaggerDoc("2.0", new OpenApiInfo { Title = "V2", Version = "2.0" });
    options.DocInclusionPredicate((docName, apiDesc) =>
    {
        if (!apiDesc.TryGetMethodInfo(out MethodInfo method))
            return false;

        var versions = method.DeclaringType
                        .GetCustomAttributes(true)
                        .OfType<ApiVersionAttribute>()
                        .SelectMany(attr => attr.Versions);

        return versions.Any(v => $"{v}" == docName);
    });

    options.OperationFilter<AddApiVersionQueryParamOperationFilter>();
});

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowSpecificOrigin",
               builder =>
               {
                   builder.WithOrigins("https://cloudbnb-df3c1.web.app")
                   .AllowAnyMethod()
                   .AllowAnyHeader();
               });
});


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(config =>
    {
        config.SwaggerEndpoint("/swagger/1.0/swagger.json", "API v1");
        config.SwaggerEndpoint("/swagger/2.0/swagger.json", "API v2");
    });
}

app.UseCors("AllowSpecificOrigin");

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();