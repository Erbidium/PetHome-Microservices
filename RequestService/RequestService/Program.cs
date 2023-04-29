using System.Reflection;
using AdvertService.Sync;
using RequestService.DAL.Data;
using RequestService.Middlewares;
using RequestService.BLL.Services;
using Microsoft.EntityFrameworkCore;
using RequestService.BLL.Interfaces;
using RequestService.DAL.Interfaces;
using RequestService.DAL.Repositories;
using RequestService.BLL.MappingProfile;

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
builder.Services.AddScoped<IRequestsService, RequestsService>();
builder.Services.AddScoped<IRequestsRepository, RequestsRepository>();
builder.Services.AddScoped<HttpSyncClient>();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<DataContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"), options =>
    options.EnableRetryOnFailure());
});

builder.Services.AddAutoMapper(Assembly.GetAssembly(typeof(RequestsProfile)));

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
