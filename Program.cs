using apiwc.db;
using apiwc.interfaces;
using apiwc.repositories;
using MySql.Data.MySqlClient;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers();

Dapper.DefaultTypeMap.MatchNamesWithUnderscores = true;

var strDbConnection = builder.Configuration.GetConnectionString("DefaultConnection");

if (strDbConnection == null || strDbConnection == "") {
   Console.WriteLine("Database configuration not found!");
   Environment.Exit(0);
}

var dbMysqlConfiguration = new MysqlConfiguration(strDbConnection);

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

