using MyBooksDesktop.Core.Models;
using MyBooksDesktop.Core.Requests;

namespace MyBooksDesktop.Core.Interfaces;

public interface IUserService
{
    public Task<bool> Register(uint userId, RegisterRequest registerRequest);
    
    public Task<bool> UpdatePassword(uint userId, UpdateUserPasswordRequest updateUserPasswordRequest);
    
    public Task<bool> Login(uint userId, LoginRequest loginRequest);
    
    public Task<bool> UpdateUser(uint userId, UpdateUserRequest updateUserRequest);

    public Task<User?> Get(uint userId);
    
    public Task<bool> Delete(uint userId);
}