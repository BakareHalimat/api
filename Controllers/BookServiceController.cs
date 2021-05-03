using System;
using System.Data;
using Api.Interface;
using Api.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [ApiController]
    [Authorize]
    
    public class BookServicesController : ControllerBase
    {
         private IBookServices _repo;

        public BookServicesController(
            IBookServices repo
        )
        {
            _repo = repo;
        }
        [HttpGet("/book")]
        //[Authorize]
        public IActionResult Get()
        {
            var Book = _repo.GetAllBook();
            return Ok(Book);
        }
        [HttpPost("/book")]
        public IActionResult Post(Book model)
        {
            // if(Book.Title)
            
            try
            {
                var Book = _repo.AddBook(model);
                return new CreatedResult("/Book/", new {Id = Book.Id,DateAdded = DateTime.Now,message = "Book created succesfully"});
            }
            catch (Exception e)
            {
                return  BadRequest(new {message = e.Message});
            }
        }
        
        [HttpGet("/book/{authourId}")]
        public IActionResult Get(string authourId)
        {
            {
            var Book = _repo.GetAuthours(authourId);
            return Ok(Book);
        }
        }
        [HttpPatch("/Book/{id}")]
        public IActionResult Patch(string id, Book model)
        {
            try
            {
                var Book = _repo.UpdatePatchBook(id, model);
                return new OkObjectResult(new{ message =" Book updated successfully ", id});
            }
            catch (Exception e)
            {
                return  BadRequest(new {message = e.Message});
            }
        }
        [HttpPut("/Book/{id}")]
        public IActionResult Put(string id, Book model)
        {
            try
            {
                var Book = _repo.UpdatePutBook(id, model);
                return new OkObjectResult(new{message = "Book updated succesfully", id});
            }
            catch (Exception e)
            {
                return  BadRequest(new {message = e.Message});
            }

        }
        [HttpDelete("/Book/{id}")]
        public IActionResult Delete(string id)
        {
            try
            {
                var Book = _repo.DeleteBook(id);
                return new OkObjectResult(new{message = "Book deleted succesfully", id});
            }
            catch (Exception e)
            {
                return  BadRequest(new {message = e.Message});
            }

        }
        
        
    }
}