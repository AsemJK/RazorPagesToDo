using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorPagesToDo.Data;
using RazorPagesToDo.Models;
using RazorPagesToDo.Services;

namespace RazorPagesToDo.Pages.Tickets
{
    public class NewModel : PageModel
    {
        private readonly DataContext _dbContext;
        private readonly IHostEnvironment _host;
        private readonly IUserService _userService;

        public NewModel(DataContext dbContext, IHostEnvironment host, IUserService userService)
        {
            _dbContext = dbContext;
            _host = host;
            _userService = userService;
        }
        public void OnGet()
        {

        }

        [BindProperty]
        public List<IFormFile> Upload { get; set; }

        [BindProperty]
        public string Message { get; set; }

        public async Task OnPost()
        {
            if (ModelState.IsValid)
            {
                var random = Guid.NewGuid().ToString("N");
                User currentUser = _userService.GetLoginUser();
                if (Request.Form["title"].ToString() != string.Empty)
                {
                    var addedTicket = _dbContext.Tickets.Add(new Models.Ticket { Title = Request.Form["title"].ToString(), UserId = currentUser.Id, CompanyId = currentUser.CompanyId });
                    _dbContext.SaveChanges();
                    string newFullFileName = "";
                    foreach (var file in Upload)
                    {
                        random = Guid.NewGuid().ToString("N");
                        newFullFileName = random + "_" + file.FileName.Replace(" ", "");
                        var fileUploaded = Path.Combine(_host.ContentRootPath, "wwwroot", "files", newFullFileName);
                        using (var fileStream = new FileStream(fileUploaded, FileMode.Create))
                        {
                            await file.CopyToAsync(fileStream);
                            _dbContext.TicketFiles.Add(new Models.TicketFile
                            {
                                FileName = newFullFileName,
                                TicketId = addedTicket.Entity.Id
                            });
                        }
                    }
                    _dbContext.SaveChanges();
                }
                else
                    return;

            }
            else
                return;
        }
    }
}
