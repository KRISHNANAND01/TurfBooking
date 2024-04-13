using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System;
using TurfBooking.Model;
namespace TurfBooking.Services
{
    public class UserService : IUserService
    {
        private readonly TurfBookingContext _context;
        private readonly IConfiguration configuration;

        public UserService(TurfBookingContext context, IConfiguration configuration)
        {
            _context = context;
            this.configuration = configuration;
        }

        public IEnumerable<User> GetUsers()
        {
            return _context.Users.ToList();
        }

        public User GetUser(int id)
        {
            return _context.Users.Find(id);
        }

        public void AddUser(User user)
        {
            var newuser = new User
            {
                // Set other properties but do not set Id
                Name = user.Name,
                Email = user.Email,
                Password = user.Password
            };

            _context.Users.Add(newuser);
            _context.SaveChanges();
        }
        public string Login(string email, string password)
        {
            var userExist = _context.Users.FirstOrDefault(t => t.Email == email && EF.Functions.Collate(t.Password, "SQL_Latin1_General_CP1_CS_AS") == password);
            if (userExist != null)
            {
                var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["Jwt:Key"]));
                var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
                var claims = new[]
                {
            new Claim(ClaimTypes.Email,userExist.Email),
            new Claim("Id",userExist.Id.ToString()),
            new Claim(ClaimTypes.Role,userExist.Role)
        };
                var token = new JwtSecurityToken(configuration["Jwt:Issuer"], configuration["Jwt:Audience"], claims, expires: DateTime.Now.AddMinutes(30), signingCredentials: credentials);
                return new JwtSecurityTokenHandler().WriteToken(token);

            }
            return null;
        }



        public void UpdateUser(User user)
        {
            var updateuser = new User
            {
                // Set other properties but do not set Id
                Name = user.Name,
                Email = user.Email,
                Password = user.Password
            };
            _context.Entry(user).State = EntityState.Modified;
            //_context.Users.Update(updateuser);
            _context.SaveChanges();
        }

        public void DeleteUser(int id)
        {
            var user = _context.Users.Find(id);
            if (user != null)
            {
                _context.Users.Remove(user);
                _context.SaveChanges();
            }
        }
        private bool UserExist(User user)
        {
            return _context.Users.Any(t => t.Email == user.Email);
        }

    }
}