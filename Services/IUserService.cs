using RazorPagesToDo.Models;

namespace RazorPagesToDo.Services
{
    public interface IUserService
    {
        User GetById(int id);
        User GetLoginUser();
    }
}
