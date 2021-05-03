using System;
using Api.Interface;
using Api.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [ApiController]
    [Authorize]
    
    public class AuthourController : ControllerBase
    {
        
        private IAuthourService _repo;

        public AuthourController(
            IAuthourService repo
        )
        {
            _repo = repo;
        }
        [HttpGet("/Authour")]
        
        public IActionResult Get()
        {
            var Authour = _repo.GetAllAuthour();
            return Ok(Authour);
        }
        
        [HttpPost("/Authour")]
        public IActionResult Post(Authour model)
        {
            try
            {
                var Authour = _repo.AddAuthour(model);
                return new CreatedResult("/Authour/", new {Id = Authour.Id, message = "Authour created succesfully"});
            }
            catch (Exception e)
            {
                return  BadRequest(new {message = e.Message});
            }
        }
        [HttpPatch("/Authour/{id}")]
        public IActionResult Patch(string id, Authour model)
        {
            try
            {
                var Authour = _repo.UpdatePatchAuthour(id, model);
                return new OkObjectResult(new{ message =" Authour updated successfully ", id});
            }
            catch (Exception e)
            {
                return  BadRequest(new {message = e.Message});
            }
        }
        [HttpPut("/Authour/{id}")]
        public IActionResult Put(string id, Authour model)
        {
            try
            {
                var Authour = _repo.UpdatePutAuthour(id, model);
                return new OkObjectResult(new{message = "Authour updated succesfully", id});
            }
            catch (Exception e)
            {
                return  BadRequest(new {message = e.Message});
            }

        }
        [HttpDelete("/Authour/{id}")]
        public IActionResult Delete(string id)
        {
            try
            {
                var Authour = _repo.DeleteAuthour(id);
                return new OkObjectResult(new{message = "Authour deleted succesfully", id});
            }
            catch (Exception e)
            {
                return  BadRequest(new {message = e.Message});
            }

        }
      
    }
}