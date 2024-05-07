
using entities;
using entities.Models;

namespace Services
{
    public interface IUserServices
    {
        Task<User> addUser(User user);
        Task<IEnumerable<User>> getUsers();
        Task<int> updateUser(int id, User userToUpdate);
        Task<User> getUserByUserNameAndPassword(string UserName, string Password);
        Task<User> getUserById(int id);
        Task DeleteUser(int id);
    }
}