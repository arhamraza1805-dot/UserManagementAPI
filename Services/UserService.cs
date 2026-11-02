using UserManagementAPI.Models;

namespace UserManagementAPI.Services;

public class UserService
{
    private readonly List<User> _users = new();
    private int _nextId = 1;

    public UserService()
    {
        // Seed data
        _users.Add(new User { Id = _nextId++, Name = "Alice Johnson", Email = "alice@example.com", Age = 28 });
        _users.Add(new User { Id = _nextId++, Name = "Bob Smith", Email = "bob@example.com", Age = 34 });
    }

    public IEnumerable<User> GetAll() => _users;

    public User? GetById(int id) => _users.FirstOrDefault(u => u.Id == id);

    public User Create(User user)
    {
        user.Id = _nextId++;
        _users.Add(user);
        return user;
    }

    public bool Update(int id, User updated)
    {
        var existing = GetById(id);
        if (existing == null) return false;

        existing.Name = updated.Name;
        existing.Email = updated.Email;
        existing.Age = updated.Age;
        return true;
    }

    public bool Delete(int id)
    {
        var user = GetById(id);
        if (user == null) return false;
        _users.Remove(user);
        return true;
    }
}