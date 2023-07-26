using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorPagesToDo.Data;
using RazorPagesToDo.Models;

namespace RazorPagesToDo.Pages.Tickets
{
    public class DetailsModel : PageModel
    {
        private readonly DataContext _dbContext;

        public DetailsModel(DataContext dbContext)
        {
            _dbContext = dbContext;
        }
        [BindProperty]
        public int TicketId { get; set; }
        public Ticket TicketData { get; set; }
        public List<TicketFile> TicketFilesList { get; set; }
        public void OnGet(int id)
        {
            TicketId = id;
            TicketData = _dbContext.Tickets.FirstOrDefault(t => t.Id == TicketId);
            if (TicketData.Id > 0)
            {
                TicketFilesList = _dbContext.TicketFiles.Where(tc => tc.TicketId == TicketId).ToList();
            }
        }
    }
}
