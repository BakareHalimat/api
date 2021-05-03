using System;
using System.Collections.Generic;
using System.Linq;
using Api.DatabaseContext;
using Api.Interface;
using Api.Model;

namespace Api.Services
{
    public class AuthourServices : IAuthourService
    {
        private ApplicationDbContext _context;

        public AuthourServices(
           ApplicationDbContext context
       )
       {
           _context = context;
       } 
       public List<Authour> GetAllAuthour()
       {
           return _context.Authour.ToList();
       }
       public Authour GetOneAuthour(string id)
       {
           return _context.Authour.FirstOrDefault(PID => PID.Id == id);
       }
       public Authour AddAuthour(Authour model)
       {
           if (model is null) throw new ArgumentNullException(message: "Authour cannot be null", null);

           var Authour = new Authour
           {
               Id = Guid.NewGuid().ToString(),
               FullName = model.FullName
           };
           _context.Authour.Add(Authour);
           _context.SaveChanges();
           return Authour;
       }

       public Authour UpdatePutAuthour(string id, Authour model)
       { 
            var Authour = GetOneAuthour(id);
            if (Authour is null) throw new ArgumentOutOfRangeException(message: "No Authour with this Id found", null);

            Authour.FullName = model.FullName;
                 
            _context.Authour.Update(Authour);
            _context.SaveChanges();
            return Authour;
       }
       
      
       
       public Authour UpdatePatchAuthour(string id, Authour model)
       {
           
            var Authour = GetOneAuthour(id);
            
            if (Authour is null) throw new ArgumentOutOfRangeException(message: "No Authour with this Id found", null);
            if (!string.IsNullOrWhiteSpace(model.FullName))
            {
                Authour.FullName = model.FullName;
            }
            
            _context.Authour.Update(Authour);
            _context.SaveChanges();
            return Authour;
       }

       
       public Authour DeleteAuthour(string id)
       {
           
            var Authour = GetOneAuthour(id);
            
            if (Authour is null) throw new ArgumentOutOfRangeException(message: "No Authour with this Id found", null);
            
            _context.Authour.Remove(Authour);
            _context.SaveChanges();
            return Authour;
       }
    }
}