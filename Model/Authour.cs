using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Api.Model
{
    public class Authour
    {

        [Key]
        public string Id { get; set; }
        
        [Required(ErrorMessage="Please Insert your full name....")]
        
        public string FullName { get; set; }
        
         
        
    }
}