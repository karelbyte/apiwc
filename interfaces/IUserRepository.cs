using apiwc.entities;

namespace apiwc.interfaces;

public interface IUserRepository
{
    Task<IEnumerable<User>> GetAll();

    Task<User> Detail(int id);

    Task<User> Create(User user);

    Task<User> Update(User user);

    Task<bool> Delete(int id);

}