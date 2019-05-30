using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using _2DChart.Data.Database;
using _2DChart.Data.Models;
using _2DChart.Helpers;

namespace _2DChart.Domain.Services
{
    public class UserService
    {
        private readonly ChartDbContext _context;

        public UserService(ChartDbContext context)
        {
            _context = context;
        }

        public async Task<User> Authenticate(string username, string password, CancellationToken cancellationToken)
        {
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
                return null;
            var user = await _context.User.SingleOrDefaultAsync(u => u.Name == username, cancellationToken);

            // check if username exists
            if (user == null)
                return null;
            // check if password is correct
            if (!VerifyPasswordHash(password,user.PasswordHash,user.PasswordSalt))
                return null;

            // authentication successful
            return user;
        }

        public async Task<User> Create(string username, string password, string email,
            CancellationToken cancellationToken)
        {
            // validation

            if (await _context.User.AnyAsync(x => x.Name == username, cancellationToken))
                throw new AppException("Username \"" + username + "\" is already taken");

            CreatePasswordHash(password, out byte[] passwordHash,out byte[] passwordSalt);

            var user = new User
            {
                Name = username,
                PasswordHash = passwordHash,
                PasswordSalt = passwordSalt,
                Mail = email
            };
            _context.User.Add(user);
            await _context.SaveChangesAsync(cancellationToken);
            return user;
        }

        private static void CreatePasswordHash(string password, out byte[] passwordHash,out byte[] passwordSalt)
        {
            if (password == null) throw new ArgumentNullException("password");
            if (string.IsNullOrWhiteSpace(password)) throw new ArgumentException("Value cannot be empty or whitespace only string.", "password");

            using (var hmac = new System.Security.Cryptography.HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }

        }
        private static bool VerifyPasswordHash(string password, byte[] storedHash, byte[] storedSalt)
        {
            if (password == null) throw new ArgumentNullException("password");
            if (string.IsNullOrWhiteSpace(password)) throw new ArgumentException("Value cannot be empty or whitespace only string.", "password");
            if (storedHash.Length != 64) throw new ArgumentException("Invalid length of password hash (64 bytes expected).", "passwordHash");


            using (var hmac = new System.Security.Cryptography.HMACSHA512(storedSalt))
            {
                var computedHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
                for (int i = 0; i < computedHash.Length; i++)
                {
                    if (computedHash[i] != storedHash[i]) return false;
                }
            }

            return true;
        }
    }
}
