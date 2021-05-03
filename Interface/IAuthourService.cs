using System.Collections.Generic;
using Api.Model;

namespace Api.Interface
{
    public interface IAuthourService
    {
         
        List<Authour> GetAllAuthour();
        Authour GetOneAuthour(string id);
        Authour AddAuthour(Authour model);
        Authour UpdatePutAuthour(string id, Authour model);
        Authour UpdatePatchAuthour(string id, Authour model);
        Authour DeleteAuthour(string id);
    }
}