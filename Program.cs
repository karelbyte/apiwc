using apiwc.db;
using apiwc.interfaces;
using apiwc.repositories;
using MySql.Data.MySqlClient;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers();

Dapper.DefaultTypeMap.MatchNamesWithUnderscores = true;

var dbMysqlConfiguration = new MysqlConfiguration(builder.Configuration.GetConnectionString("DefaultConnection"));

var mysqlConnection = new MySqlConnection(dbMysqlConfiguration.ConnectionString);

builder.Services.AddSingleton(mysqlConnection);

builder.Services.AddScoped<IUserRepository, UserRepository>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapControllers();

app.Run();

