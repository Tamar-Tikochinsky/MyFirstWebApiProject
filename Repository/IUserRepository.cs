
using entities;
using entities.Models;

namespace Repository
{
    public interface IUserRepository
    {
        Task<User> addUser(User user);
        Task<IEnumerable<User>> getUsers();
        Task<User> getUserByUserNameAndPassword(string UserName, string Password);
        Task<User> getUserById(int id);
        Task updateUser(int id, User userToUpdate);
        Task DeleteUser(int id);
    }
}