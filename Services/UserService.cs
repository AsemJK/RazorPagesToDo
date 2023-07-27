using Newtonsoft.Json;
using RazorPagesToDo.Data;
using RazorPagesToDo.Models;

namespace RazorPagesToDo.Services
{
    public class UserService : IUserService
    {
        private readonly DataContext _dbContext;
        private readonly IHttpContextAccessor _contextAccessor;

        public UserService(DataContext dbContext, IHttpContextAccessor contextAccessor)
        {
            _dbContext = dbContext;
            _contextAccessor = contextAccessor;
        }
        public User GetById(int id)
        {
            return _dbContext.Users.FirstOrDefault(x => x.Id == id);
        }

        public User GetLoginUser()
        {
            if (_contextAccessor.HttpContext.Session.GetString("user") != null)
            {
                User userfromsession = JsonConvert.DeserializeObject<User>(_contextAccessor.HttpContext.Session.GetString("user"));
                if (userfromsession.Id > 0)
                    return userfromsession;
                else
                    return new User();
            }
            else
            { return new User(); }
        }
    }
}
