using Demo2.Models;

namespace Demo2.Services
{
    public class UserService
    {
        private readonly List<User> _users = new();
        private int _nextId = 1;

        public IEnumerable<User> GetUsers() => _users;

        public void AddUser(User user)
        {
            user.Id = _nextId++;
            _users.Add(user);
        }

        public void UpdateUser(User user)
        {
            var existing = _users.FirstOrDefault(u => u.Id == user.Id);
            if (existing != null)
            {
                existing.Name = user.Name;
                existing.Email = user.Email;
            }
        }

        public void DeleteUser(int id)
        {
            var existing = _users.FirstOrDefault(u => u.Id == id);
            if (existing != null)
            {
                _users.Remove(existing);
            }
        }
    }
}
