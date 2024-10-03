using catedra1.src.Interfaces;
using catedra1.Src.Data;
using catedra1.Src.DTOs;
using catedra1.Src.Filters;
using catedra1.Src.Models;

namespace catedra1.Src.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly AppDbContext _context;
        public UserRepository(AppDbContext context)
        {
            _context = context;
        }
        public User? Delete(int id)
        {
            var userToDelete = _context.Users.FirstOrDefault(u => u.Id == id);
            if (userToDelete == null)
            {
                return null;
            }

            _context.Users.Remove(userToDelete);
            _context.SaveChanges();
            return userToDelete;
        }

        public bool ExistsByRut(string rut)
        {
            return _context.Users.Any(u => u.Rut == rut);
        }

        public List<User> GetAll(UserFilter userFilter)
        {
            var query = _context.Users
                .Where(u => string.IsNullOrEmpty(userFilter.Gender) || u.Gender == userFilter.Gender);

            // Aplicar el ordenamiento solo si se proporcionó un valor para Sort
            if (!string.IsNullOrEmpty(userFilter.Sort))
            {
                if (userFilter.Sort.Equals("asc", StringComparison.OrdinalIgnoreCase))
                {
                    query = query.OrderBy(u => u.Name);
                }
                else if (userFilter.Sort.Equals("desc", StringComparison.OrdinalIgnoreCase))
                {
                    query = query.OrderByDescending(u => u.Name);
                }
            }

            return query.ToList();
        }

        public User? GetById(int id)
        {
            return _context.Users.FirstOrDefault(u => u.Id == id);
        }

        public User Post(User user)
        {
            _context.Users.Add(user);
            _context.SaveChanges();
            return user;
        }

        public User? Put(int id, UserDto userDto)
        {
            var userToUpdate = _context.Users.FirstOrDefault(u => u.Id == id);
            if (userToUpdate == null)
            {
                return null;
            }
            userToUpdate.Rut = userDto.Rut;
            userToUpdate.Name = userDto.Name;
            userToUpdate.Email = userDto.Email;
            userToUpdate.Gender = userDto.Gender;
            userToUpdate.Birthday = userDto.Birthday;

            _context.SaveChanges();
            return userToUpdate;
        }
    }
}