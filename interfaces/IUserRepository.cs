using apiwc.entities;

namespace apiwc.interfaces;

public interface IUserRepository
{
    Task<IEnumerable<User>> GetAll();

    Task<User> Detail(string id);

    Task<int> Create(User user);

    Task<int> Update(User user);

    Task<bool> Delete(int id);

}