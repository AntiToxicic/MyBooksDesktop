using MyBooksDesktop.Core.Models;
using MyBooksDesktop.Core.Requests;

namespace MyBooksDesktop.Core.Interfaces;

public interface IBookService
{
    public Task<bool> Create(uint userId, CreateOrUpdateBookRequest request);
    public Task<IEnumerable<Book>?> GetAllBooks(uint userId);
    public Task<bool> Update(uint bookId, CreateOrUpdateBookRequest request);
    public Task<bool> Delete(uint bookId);
}