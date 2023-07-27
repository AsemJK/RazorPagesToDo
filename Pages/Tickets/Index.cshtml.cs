using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorPagesToDo.Data;
using RazorPagesToDo.Models;
using RazorPagesToDo.Services;

namespace RazorPagesToDo.Pages.Tickets
{
    public class IndexModel : PageModel
    {
        private readonly DataContext _dbContext;
        private readonly IUserService _userService;

        public IEnumerable<Ticket> TicketsList { get; set; }
        public IndexModel(DataContext dbContext, IUserService userService)
        {
            _dbContext = dbContext;
            _userService = userService;
        }
        public async Task<IActionResult> OnGet()
        {
            User cuser = _userService.GetLoginUser();
            if (cuser.Id > 0)
            {
                TicketsList = _dbContext.Tickets.Where(b => b.CompanyId == (cuser.CompanyId == 0 ? b.CompanyId : cuser.CompanyId)).ToList();
                return Page();
            }
            else
            {
                TicketsList = new List<Ticket>();
                return Redirect("/Login");
            }


        }
    }
}
