using CleanArchitecture.Application.Contracts.DataAccess;
using CleanArchitecture.Application.Features.Users;
using CleanArchitecture.Application.Services.Users;
using CleanArchitecture.Infrastructure.DataAccess.Context;
using CleanArchitecture.Infrastructure.DataAccess.Repositories;
using CleanArchitecture.ResponseMappers;
using CleanArchitecture.Validators;
using FluentValidation;
using FluentValidation.AspNetCore;
using MediatR;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var services = builder.Services;

services.AddDbContext<CleanArchitectureDbContext>(options => options.UseInMemoryDatabase("DBMemory"));

services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

services.AddScoped<IResponseMapper, ResponseMapper>();

services.AddScoped(typeof(IRepository<>), typeof(EntityFrameworkBaseRepository<>));
services.AddScoped<IUserRepository, UserRepository>();

services.AddScoped<IUserService, UserService>();

services.AddControllers();

services.AddFluentValidationAutoValidation(); //Automatic fluent validation is not recommended anymore
services.AddValidatorsFromAssemblyContaining<GetUserDetailsQueryValidator>();

services.AddEndpointsApiExplorer();
services.AddSwaggerGen();

services.AddMediatR(typeof(GetUserDetailsQuery));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c => c.SwaggerEndpoint("v1/swagger.json", "Clean Architecture v1"));
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
