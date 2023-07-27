using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using RazorPagesToDo.Data;
using RazorPagesToDo.Models;

namespace RazorPagesToDo.Pages
{
    public class LoginModel : PageModel
    {
        private readonly DataContext _dbContext;

        [BindProperty]
        public string UserName { get; set; }
        [BindProperty]
        public string Password { get; set; }

        public LoginModel(DataContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<IActionResult> OnGet()
        {
            var userfromsession = HttpContext.Session.GetString("user");
            if (userfromsession != null)
                return Redirect("/");
            else
                return Page();
        }
        public async Task<IActionResult> OnPost()
        {
            User user = await _dbContext.Users.Where(u => u.Name == UserName && u.Password == Password).FirstOrDefaultAsync();
            if (user?.Id > 0)
            {
                HttpContext.Session.SetString("user", JsonConvert.SerializeObject(user));
                return Redirect("/");
            }
            else
            {
                return Page();
            }
        }
    }
}
