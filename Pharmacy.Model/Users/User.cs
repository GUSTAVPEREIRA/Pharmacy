using Pharmacy.Cryptographic;
using System;

namespace Pharmacy.Model.Users
{
    public class User
    {
        public User()
        {
            CreatedAt = DateTime.UtcNow;
            Updated();
        }

        public User(string username, string password, string name)
        {
            Username = username;
            SetPassword(password);
            Name = name;
            Updated();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Password { get; private set; }
        public string Username { get; set; }
        public DateTime CreatedAt { get; private set; }

        public DateTime? DeletedAt { get; private set; }
        public DateTime UpdatedAt { get; private set; }


        public void SetPassword(string password)
        {
            Password = new PBKDF2().Encrypt(password);
        }

        public void DisableUser()
        {
            DeletedAt = DateTime.UtcNow;
            Updated();
        }

        public void EnableUser()
        {
            DeletedAt = null;
            Updated();
        }

        public void Updated()
        {
            UpdatedAt = DateTime.UtcNow;
        }
    }
}