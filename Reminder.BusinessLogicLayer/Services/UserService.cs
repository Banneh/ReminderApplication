using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Extensions.Logging.Abstractions;
using Reminder.DataAccessLayer.DataModels;
using Reminder.DataAccessLayer.DAL;

namespace Reminder.BusinessLogicLayer.Services
{
    public class UserService : IUserService
    {
        public IUnitOfWork UnitOfWork { get; }

        public UserService(IUnitOfWork unitOfWork)
        {
            UnitOfWork = unitOfWork;
        }

        public User Authenticate(string username, string password)
        {
            if(string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
                return null;

            User user = UnitOfWork.Users.Find(x => x.Username == username).SingleOrDefault();

            if (user == null)
                return null;

            if (!VerifyPasswordHash(password, user.PasswordHash, user.PasswordSalt))
                return null;

            return user;
        }

        public User GetById(long id)
        {
            User toReturn = UnitOfWork.Users
                .Get(id);

            return toReturn;
        }

        public User Add(User entity, string password)
        {
            CreatePasswordHash(password, out byte[] passwordHash, out byte[] passwordSalt);

            entity.PasswordHash = passwordHash;

            entity.PasswordSalt = passwordSalt;

            UnitOfWork.Users
                .Add(entity);

            UnitOfWork.Complete();

            return entity;
        }

        public void Update(long id, User entity, string password)
        {
            User userToUpdate = UnitOfWork.Users.Get(id);

            if (userToUpdate == null)
                throw new Exception("");

            if (entity.Username != userToUpdate.Username)
            {
                throw new Exception("");
            }

            userToUpdate.FirstName = entity.FirstName;
            userToUpdate.LastName = userToUpdate.LastName;

            if (!string.IsNullOrWhiteSpace(password))
            {
                CreatePasswordHash(password, out byte[] passwordHash, out byte[] passwordSalt);

                userToUpdate.PasswordHash = passwordHash;
                userToUpdate.PasswordSalt = passwordSalt;
            }

            UnitOfWork.Users.Update(userToUpdate);
            UnitOfWork.Complete();
        }


        public void Delete(long id)
        {
            User userToDelete = UnitOfWork.Users.Get(id);

            if (userToDelete != null)
            {
                UnitOfWork.Users.Remove(userToDelete);
                UnitOfWork.Complete();
            }
        }

        private static void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
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
            if (storedSalt.Length != 128) throw new ArgumentException("Invalid length of password salt (128 bytes expected).", "passwordHash");

            using (var hmac = new System.Security.Cryptography.HMACSHA512(storedSalt))
            {
                var computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
                for (int i = 0; i < computedHash.Length; i++)
                {
                    if (computedHash[i] != storedHash[i]) return false;
                }
            }

            return true;
        }
    }
}
