using System.Collections.Generic;
using Api.Model;

namespace Api.Interface
{
    public interface IBookServices
    {
         
        List<Book> GetAllBook();
        Book GetOneBook(string id);
        Book AddBook(Book model);
        Book UpdatePutBook(string id, Book model);
        Book UpdatePatchBook(string id, Book model);
        Book DeleteBook(string id);
        Book GetAuthours(string authourId);
        
    }
}