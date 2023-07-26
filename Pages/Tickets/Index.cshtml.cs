using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorPagesToDo.Data;
using RazorPagesToDo.Models;

namespace RazorPagesToDo.Pages.Tickets
{
    public class IndexModel : PageModel
    {
        private readonly DataContext _dbContext;

        public IEnumerable<Ticket> TicketsList { get; set; }
        public IndexModel(DataContext dbContext)
        {
            _dbContext = dbContext;
        }
        public void OnGet()
        {
            TicketsList = _dbContext.Tickets.ToList();
        }
    }
}
