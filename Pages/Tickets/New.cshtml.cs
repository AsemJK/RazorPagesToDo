using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorPagesToDo.Data;

namespace RazorPagesToDo.Pages.Tickets
{
    public class NewModel : PageModel
    {
        private readonly DataContext _dbContext;
        private readonly IHostEnvironment _host;

        public NewModel(DataContext dbContext, IHostEnvironment host)
        {
            _dbContext = dbContext;
            _host = host;
        }
        public void OnGet()
        {
        }

        [BindProperty]
        public List<IFormFile> Upload { get; set; }
        public async Task OnPost()
        {
            if (ModelState.IsValid)
            {
                var random = Guid.NewGuid().ToString("N");
                var addedTicket = _dbContext.Tickets.Add(new Models.Ticket { Title = Request.Form["title"].ToString(), UserId = 1 });
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
        }
    }
}
