using apiwc.entities;
using apiwc.interfaces;
using Dapper;
using System.Diagnostics;
using MySql.Data.MySqlClient;

namespace apiwc.repositories;

public class UserRepository(MySqlConnection mySqlConnection) : IUserRepository
{
    private readonly MySqlConnection _mysqlConnection = mySqlConnection;

    private const string SelectAllUserSql = "SELECT * FROM users";

    private const string SelectUserById = @"SELECT * FROM users WHERE id = @Id";
    
    private const string UpdateUserById = @"UPDATE users SET names = @names, email = @email, status = @status WHERE id = @Id";
    
    private const string CreateUser = @"INSERT INTO users (id, names, email, password, status) VALUES (@Id, @Names, @Email, @Password, @Status)";

    protected MySqlConnection Conection
    {
        get => _mysqlConnection;
    }

    public async Task<IEnumerable<User>> GetAll()
    {
        return await Conection.QueryAsync<User>(SelectAllUserSql, new { });
    }
    
    public async Task<User> Detail(string id)
    {
        return await Conection.QueryFirstOrDefaultAsync<User>(SelectUserById, new { Id = id });
    }

    public async Task<int> Create(User user)
    {
        var myuuid = Guid.NewGuid();
        user.Id = myuuid.ToString();
        return await Conection.ExecuteAsync(CreateUser, user);
    }

    public async Task<int> Update(User user)
    {
        return await Conection.ExecuteAsync(UpdateUserById, user);
    }

    public Task<bool> Delete(int id)
    {
        throw new NotImplementedException();
    }
    
}