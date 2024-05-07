using entities;
using entities.Models;
using Repository;
using Microsoft.AspNetCore.Mvc;

namespace Services
{
    public class UserServices : IUserServices
    {
        IUserRepository _UserRepository;
        public UserServices(IUserRepository userRepository)
        {
            _UserRepository = userRepository;
        }
        
        public async Task<User> addUser(User user)
        {
            //check strength of password
            var result = Zxcvbn.Core.EvaluatePassword(user.Password);
            if (result.Score <= 2) return null;
            return await _UserRepository.addUser(user);
        }

        public async Task<User> getUserById(int id)
        {
            return await _UserRepository.getUserById(id);
        }

        public async Task<IEnumerable<User>> getUsers()
        {
            return await _UserRepository.getUsers();
        }

        public async Task<User> getUserByUserNameAndPassword(string UserName, string Password)
        {
            return await _UserRepository.getUserByUserNameAndPassword(UserName, Password);
        }

        public async Task<int> updateUser(int id, User userToUpdate)
        {
            //check strength of password
            var result = Zxcvbn.Core.EvaluatePassword(userToUpdate.Password);
            if (result.Score <= 2) return result.Score;
            await _UserRepository.updateUser(id, userToUpdate);
            return result.Score;
        }

        public async Task DeleteUser(int id)
        { 
            await _UserRepository.DeleteUser(id);
        }
    }
}