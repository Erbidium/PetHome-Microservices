using AdvertService.BLL.MappingProfiles.AdvertProfiles;
using AdvertService.BLL.Services;
using AdvertService.BLL.Services.Interfaces;
using AdvertService.DAL.Data;
using AdvertService.DAL.Interfaces;
using AdvertService.DAL.Repositories;
using AdvertService.Middlewares;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(options =>
{
    options.AddPolicy("CORSPolicy",
        builder =>
        {
            builder
            .AllowAnyMethod()
            .AllowAnyHeader()
            .AllowCredentials()
            .SetIsOriginAllowed(origin => true);
        });
});

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddScoped<IAdvertService, AdvertsService>();
builder.Services.AddScoped<IAdvertsRepository, AdvertsRepository>();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<DataContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

builder.Services.AddAutoMapper(Assembly.GetAssembly(typeof(AdvertProfile)));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors("CORSPolicy");

app.UseAuthorization();

app.UseMiddleware<ExceptionHandlerMiddleware>();

app.MapControllers();

app.Run();
