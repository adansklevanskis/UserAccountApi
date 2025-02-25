using Microsoft.Data.SqlClient;
using System.Data;
using UserAccountApi.Domain.Repository;
using UserAccountApi.Domain.Services;
using UserAccountApi.Infra;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddTransient<IUserRepository, UserRepository>();
builder.Services.AddTransient<IUserService, UserService>();

builder.Services.AddScoped<IDbConnection, SqlConnection>(provider =>
{
    //initialize sql server configuration

    return null;
});

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

//app.UseAuthorization(); not used yet

app.MapControllers();

app.Run();
