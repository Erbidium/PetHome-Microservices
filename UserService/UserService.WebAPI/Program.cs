using System.Reflection;
using UserService.BLL.MappingProfiles;
using UserService.BLL.Services.Interfaces;
using UserService.DAL.Interfaces;
using UserService.DAL.Repositories;
using UserService.WebAPI.Middlewares;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(options =>
{
    options.AddPolicy("CORSPolicy",
        corsPolicyBuilder =>
        {
            corsPolicyBuilder
                .AllowAnyMethod()
                .AllowAnyHeader()
                .AllowCredentials()
                .SetIsOriginAllowed(_ => true);
        });
});

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddScoped<IUserService, UserService.BLL.Services.UserService>();
builder.Services.AddScoped<IUserRepository, MockUserRepository>();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddAutoMapper(Assembly.GetAssembly(typeof(UserProfile)));

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