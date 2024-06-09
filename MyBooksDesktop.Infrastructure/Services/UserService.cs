using System.Net.Http;
using System.Text;
using MyBooksDesktop.Core.Interfaces;
using MyBooksDesktop.Core.Models;
using MyBooksDesktop.Core.Requests;
using Newtonsoft.Json;

namespace MyBooksDesktop.Infrastructure.Services;

public class UserService : IUserService
{
    private const string BaseUrl = "http://localhost:5211/api";
    
    public async Task<bool> UpdatePassword(uint userId, UpdateUserPasswordRequest updateUserPasswordRequest)
    {
        using (var client = new HttpClient())
        {
           
            var jsonContent = new StringContent(JsonConvert.SerializeObject(updateUserPasswordRequest), Encoding.UTF8, "application/json");

            try
            {
                var response = await client.PutAsync($"{BaseUrl}/users/{userId}/password", jsonContent);

                if (response.IsSuccessStatusCode)
                {
                    return true;

                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка при отправке запроса: {ex.Message}");
            }
        }

        return false;
    }

    public async Task<bool> Login(uint userId, LoginRequest loginRequest)
    {
        using (var client = new HttpClient())
        {
            var jsonContent = new StringContent(JsonConvert.SerializeObject(loginRequest), Encoding.UTF8,
                "application/json");
            
            try
            {
                var response = await client.PostAsync($"{BaseUrl}/users/login", jsonContent);
     

                if (response.IsSuccessStatusCode)
                {
                    var jsonResponse = await response.Content.ReadAsStringAsync();
                    var user = JsonConvert.DeserializeObject<User>(jsonResponse);
                    UserIdToken.Id = user.Id;
                    
                    return true;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка при отправке запроса: {ex.Message}");
            }

            return false;
        }
    }

    public async Task<bool> UpdateUser(uint userId, UpdateUserRequest updateUserRequest)
    {
        using (var client = new HttpClient())
        {
           
            var jsonContent = new StringContent(JsonConvert.SerializeObject(updateUserRequest), Encoding.UTF8, "application/json");

            try
            {
                var response = await client.PutAsync($"{BaseUrl}/users/{userId}", jsonContent);

                if (response.IsSuccessStatusCode)
                {
                    return true;

                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка при отправке запроса: {ex.Message}");
            }
        }

        return false;
    }

    public async Task<User?> Get(uint userId)
    {
        using (var client = new HttpClient())
        {
            try
            {
                var response = await client.GetAsync($"{BaseUrl}/users/{userId}");
                
                if (response.IsSuccessStatusCode)
                {
                    var jsonResponse = await response.Content.ReadAsStringAsync();
                    var user = JsonConvert.DeserializeObject<User>(jsonResponse);

                    return user;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка при отправке запроса: {ex.Message}");
            }

            return null;
        }
    }

    public async Task<bool> Delete(uint userId)
    {
        using (var client = new HttpClient())
        {
            try
            {
                var response = await client.DeleteAsync($"{BaseUrl}/users/{userId}");
                
                return response.IsSuccessStatusCode;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка при отправке запроса: {ex.Message}");
            }

            return false;
        }
    }

    public async Task<bool> Register(uint userId, RegisterRequest registerRequest)
    {
        using (var client = new HttpClient())
        {
           
            var jsonContent = new StringContent(JsonConvert.SerializeObject(registerRequest), Encoding.UTF8, "application/json");

            try
            {
                var response = await client.PostAsync($"{BaseUrl}/users/register", jsonContent);

                if (response.IsSuccessStatusCode)
                {
                    return true;

                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка при отправке запроса: {ex.Message}");
            }
        }

        return false;
    }
}