using apiwc.entities;
using apiwc.interfaces;
using Dapper;
using MySql.Data.MySqlClient;

namespace apiwc.repositories;

public class UserRepository: IUserRepository
{
    private  MySqlConnection _mysqlConnection;
    
    private const string SelectAllUserSql = "select * from users";

    protected MySqlConnection Conection
    {
        get => _mysqlConnection;
    } 
    
    public UserRepository(MySqlConnection mySqlConnection)
    {
        _mysqlConnection = mySqlConnection;
    }

    public async Task<IEnumerable<User>> GetAll()
    {
        return await Conection.QueryAsync<User>(SelectAllUserSql, new { });
    }

    public Task<User> Detail(int id)
    {
        throw new NotImplementedException();
    }

    public Task<User> Create(User user)
    {
        throw new NotImplementedException();
    }

    public Task<User> Update(User user)
    {
        throw new NotImplementedException();
    }

    public Task<bool> Delete(int id)
    {
        throw new NotImplementedException();
    }
}