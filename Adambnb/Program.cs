//Adam Abdelbakey
//s1178952
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Adambnb.Data;
using Adambnb.Mapping;
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<AdambnbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("AdambnbContext") ?? throw new InvalidOperationException("Connection string 'AdambnbContext' not found.")));

// Add services to the container.
builder.Services.AddAutoMapper(typeof(MappingProfile));
builder.Services.AddControllers();
builder.Services.AddSwaggerGen();



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
    app.UseSwaggerUI();
}

app.UseCors("AllowSpecificOrigin");

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
