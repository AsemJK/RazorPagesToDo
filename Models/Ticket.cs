using System.ComponentModel.DataAnnotations;

namespace RazorPagesToDo.Models
{
    public class Ticket
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        public int UserId { get; set; } = 0;
        public int CompanyId { get; set; } = 0;
        public string LastStatus { get; set; } = "";
        public DateTime LastUpdateDateTime { get; set; } = DateTime.Now;
        public string ImageUrl { get; set; } = "";
    }
}
