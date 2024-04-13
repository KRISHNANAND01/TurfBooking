using System.Collections.Generic;
using TurfBooking.Model;

namespace TurfBooking.Services
{
    public interface IUserService
    {
        IEnumerable<User> GetUsers();
        User GetUser(int id);
        void AddUser(User user);
        void UpdateUser(User user);
        void DeleteUser(int id);
        string Login(string email, string password);
    }
}