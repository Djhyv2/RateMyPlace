using System;
namespace RateMyPlace.Classes
{
    public class User
    {
        private string username;
        private string firstName;

        public User(string username, string password)
        {
            
        }

        public User(string username, string password, string firstName) {
            this.username = username;
            this.firstName = firstName;
        }

        public bool LoggedIn { get; set; }
        public string Username { get; }
        public string FirstName { get; }

        public bool CheckPassword(string password) {
            bool valid = false;
            ///make a call to the database to ensure password is valid
            return valid;
        }
    }
}
