using AdvertService.BLL.MappingProfiles.AdvertProfiles;
using AdvertService.BLL.Services;
using AdvertService.BLL.Services.Interfaces;
using AdvertService.DAL.Data;
using AdvertService.DAL.Interfaces;
using AdvertService.DAL.Repositories;
using AdvertService.Middlewares;
using AdvertService.Sync;
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
builder.Services.AddScoped<HttpSyncClient>();
builder.Services.AddSingleton<UnhealthySerivce>();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<DataContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"), options =>
    options.EnableRetryOnFailure());
    
});

builder.Services.AddAutoMapper(Assembly.GetAssembly(typeof(AdvertProfile)));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

using var scope = app.Services.GetService<IServiceScopeFactory>()?.CreateScope();
using var context = scope?.ServiceProvider.GetRequiredService<DataContext>();
if (context != null && context.Database.GetPendingMigrations().Any())
{
    context.Database.Migrate();
}

app.UseHttpsRedirection();

app.UseCors("CORSPolicy");

app.UseAuthorization();

app.UseMiddleware<ExceptionHandlerMiddleware>();

app.MapControllers();

app.Run();
