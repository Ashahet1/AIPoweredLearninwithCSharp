using Userservice.Models;

namespace Userservice.Services
{

    public class InMemoryUserStore
    {
        private readonly List<User> _users = new();

        public bool EmailExists(string email) =>
            _users.Any(u => u.Email.Equals(email, StringComparison.OrdinalIgnoreCase));

        public void Add(User user) => _users.Add(user);

        public User? GetByEmail(string email) =>
        _users.FirstOrDefault(u => string.Equals(u.Email, email, StringComparison.OrdinalIgnoreCase));
    }
}