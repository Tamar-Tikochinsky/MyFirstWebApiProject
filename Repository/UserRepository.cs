using entities;
using System.Text.Json;
using entities.Models;
using Microsoft.EntityFrameworkCore;

namespace Repository;

public class UserRepository : IUserRepository
{
    private readonly CookwareShopContext _CookwareShopContext;
    public UserRepository(CookwareShopContext cookwareShopContext)
    {
        _CookwareShopContext = cookwareShopContext;
    }
    public async Task<User> addUser(User user)
    {
        await _CookwareShopContext.Users.AddAsync(user);
        await _CookwareShopContext.SaveChangesAsync();
        return user;
    }

    public async Task<User> getUserById(int id)
    {
        return await _CookwareShopContext.Users.FindAsync(id);
    }

    public async Task<User> getUserByUserNameAndPassword(string UserName, string Password)
    {
        return await _CookwareShopContext.Users.Where(i => i.UserName == UserName &&
        i.Password == Password).FirstOrDefaultAsync();
    }

    public async Task<IEnumerable<User>> getUsers()
    {
        return await _CookwareShopContext.Users.ToListAsync();
    }

    public async Task updateUser(int id, User userToUpdate)
    {
        //var userToUpdate1 = await _CookwareShopContext.Users.FindAsync(id);
        _CookwareShopContext.Update(userToUpdate);
        await _CookwareShopContext.SaveChangesAsync();

    }

    public async Task DeleteUser(int id)
    {
        var user = await _CookwareShopContext.Users.FindAsync(id);
        _CookwareShopContext.Users.Remove(user);
        await _CookwareShopContext.SaveChangesAsync(true);
    }
}