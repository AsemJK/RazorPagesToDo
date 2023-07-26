using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorPagesToDo.Data;

namespace RazorPagesToDo.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly DataContext _dbContext;

        public IndexModel(ILogger<IndexModel> logger, DataContext dbContext)
        {
            _logger = logger;
            _dbContext = dbContext;
        }

        public void OnGet()
        {

        }
    }
}