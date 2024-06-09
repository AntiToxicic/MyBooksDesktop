using System.Net.Http;
using System.Text;
using MyBooksDesktop.Core.Interfaces;
using MyBooksDesktop.Core.Models;
using MyBooksDesktop.Core.Requests;
using Newtonsoft.Json;

namespace MyBooksDesktop.Infrastructure.Services;

public class BookService : IBookService
{
    private const string BaseUrl = "http://localhost:5211/api";


    public async Task<bool> Create(uint userId, CreateOrUpdateBookRequest request)
    {
        using (var client = new HttpClient())
        {
           
            var jsonContent = new StringContent(JsonConvert.SerializeObject(request), Encoding.UTF8, "application/json");

            try
            {
                var response = await client.PostAsync($"{BaseUrl}/books/{userId}", jsonContent);

                return response.IsSuccessStatusCode;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка при отправке запроса: {ex.Message}");
            }
        }

        return false;
    }

    public async Task<IEnumerable<Book>?> GetAllBooks(uint userId)
    {
        using (var client = new HttpClient())
        {
            try
            {
                var response = await client.GetAsync($"{BaseUrl}/books/{userId}/allBooks");

                if (response.IsSuccessStatusCode)
                {
                    var jsonResponse = await response.Content.ReadAsStringAsync();
                    var books = JsonConvert.DeserializeObject<IEnumerable<Book>>(jsonResponse);

                    return books;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка при отправке запроса: {ex.Message}");
            }
        }

        return null;
    }

    public async Task<bool> Update(uint bookId, CreateOrUpdateBookRequest request)
    {
        using (var client = new HttpClient())
        {
            try
            {
                var jsonContent = new StringContent(JsonConvert.SerializeObject(request), Encoding.UTF8, "application/json");

                
                var response = await client.PutAsync($"{BaseUrl}/books/{bookId}", jsonContent);

              
                return response.IsSuccessStatusCode;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка при отправке запроса: {ex.Message}");
            }
        }

        return false;
    }

    public async Task<bool> Delete(uint bookId)
    {
        using (var client = new HttpClient())
        {
            try
            {
                var response = await client.DeleteAsync($"{BaseUrl}/books/{bookId}");
                
                return response.IsSuccessStatusCode;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка при отправке запроса: {ex.Message}");
            }

            return false;
        }
    }
}

   
