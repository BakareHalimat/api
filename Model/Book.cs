using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Api.Model
{
    public class Book
    {
        
        
        public string Id {get; set;}
        [Key]
        public string Title { get; set; }
        public string Descripition { get; set; }
        public string Genre { get; set; }
        public string Authour { get; set; }
        [ForeignKey(nameof(Authour))]
        public DateTime DateAdded { get; set; }
        [ForeignKey(nameof(AuthourId))]
        public string AuthourId { get; set; }
        
        //public Publisher Publisher{ get; set;}
    


    }
}