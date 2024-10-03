using catedra1.Src.DTOs;
using catedra1.Src.Filters;
using catedra1.Src.Models;

namespace catedra1.src.Interfaces
{
    public interface IUserRepository
    {
        bool ExistsByRut(string rut);
        List<User> GetAll(UserFilter userFilter);
        User? GetById(int id);
        User Post(User user);
        User? Put(int id, UserDto userDto);
        User? Delete(int id);
    }
}