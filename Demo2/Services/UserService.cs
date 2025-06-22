using Demo2.Data;
using Demo2.Models;
using Microsoft.EntityFrameworkCore;

namespace Demo2.Services
{
    public class UserService
    {
        private readonly AppDbContext _context;

        public UserService(AppDbContext context)
        {
            _context = context;
        }

        public IEnumerable<User> GetUsers() => _context.Users.AsNoTracking().ToList();

        public void AddUser(User user)
        {
            _context.Users.Add(user);
            _context.SaveChanges();
        }

        public void UpdateUser(User user)
        {
            _context.Users.Update(user);
            _context.SaveChanges();
        }

        public void DeleteUser(int id)
        {
            var existing = _context.Users.Find(id);
            if (existing != null)
            {
                _context.Users.Remove(existing);
                _context.SaveChanges();
            }
        }
    }
}
