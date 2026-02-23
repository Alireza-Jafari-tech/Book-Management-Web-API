using System.ComponentModel.DataAnnotations;

namespace apiApp.Models
{
    public class Book
    {
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
    }
}