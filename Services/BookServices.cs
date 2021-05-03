using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using Api.DatabaseContext;
using Api.Interface;
using Api.Model;
using Microsoft.AspNetCore.Identity;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace Api.Services
{
    public class BookServices : IBookServices
    {
        private ApplicationDbContext _context;

        public BookServices(
           ApplicationDbContext context
       )
       {
           _context = context;
       } 
       public List<Book> GetAllBook()
       {
           return _context.Book.ToList();
       }
       public Book GetOneBook(string id)
       {
           return _context.Book.FirstOrDefault(PID => PID.Id == id);
       }
       public Book AddBook(Book model)
       {
           /*SqlConnection con = new SqlConnection("Server=DESKTOP-R00G17Q\\SQLEXPRESS;Database=BookManagementDatabase;Trusted_Connection=True;MultipleActiveResultSets=true");
           SqlDataAdapter da = new SqlDataAdapter("Select title from dbo.Book where Title ="+model.Title+"",con);
           DataTable dt = new DataTable();
           da.Fill(dt);
           if(dt.Rows.Count >= 1)
           {
               MessageBox.Show("Book exist already");
           }
           else
           {
               con.Open();
               SqlCommand cmd = new SqlCommand("Insert into dbo.Book(Title) VALUES("+model.Title+")",con);
               cmd.ExecuteNonQuery();
               con.Close();
               model.Title = "";
               MessageBox.Show("Book Saved")
           }*/
           
           if (model is null) throw new ArgumentNullException(message: "Book cannot be null", null);

           var Book = new Book
           {
                Id = Guid.NewGuid().ToString(),
               Title = model.Title,
               Descripition = model.Descripition,
               Genre = model.Genre,
               Authour = model.Authour,
               DateAdded = DateTime.Now,
               AuthourId = model.AuthourId.ToString()
           };
           _context.Book.Add(Book);
           _context.SaveChanges();
           return Book;
       }

       public Book UpdatePutBook(string id, Book model)
       { 
            var Book = GetOneBook(id);
            if (Book is null) throw new ArgumentOutOfRangeException(message: "No Book with this Id found", null);

           if (!string.IsNullOrWhiteSpace(model.Title))
            {
               Book.Title = model.Title;
               Book.Descripition = model.Descripition;
               Book.Genre = model.Genre;
               Book.Authour = model.Authour;
               Book.DateAdded = DateTime.Now;
            }
                 
            _context.Book.Update(Book);
            _context.SaveChanges();
            return Book;
       }
       
      
       
       public Book UpdatePatchBook(string id, Book model)
       {
           
            var Book = GetOneBook(id);
            
            if (Book is null) throw new ArgumentOutOfRangeException(message: "No Book with this Id found", null);
            if (!string.IsNullOrWhiteSpace(model.Title))
            {
               Book.Title = model.Title;
               Book.Descripition = model.Descripition;
               Book.Genre = model.Genre;
               Book.Authour = model.Authour;
               Book.DateAdded = DateTime.Now;
            }
            
            _context.Book.Update(Book);
            _context.SaveChanges();
            return Book;
       }

       public Book GetAuthours(string authourId)
       {
           return _context.Book.FirstOrDefault(PID => PID.AuthourId == authourId);
       }      
       public Book DeleteBook(string id)
       {
           
            var Book = GetOneBook(id);
            
            if (Book is null) throw new ArgumentOutOfRangeException(message: "No Book with this Id found", null);
            
            _context.Book.Remove(Book);
            _context.SaveChanges();
            return Book;
       }
    }
}