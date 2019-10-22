using System;
namespace SaveTheWorld
{
    class User
    {
        public string Name { get; set; }
        private string Password { get; set; }
        public string TypeOfUser { get; set; }

        public User()
        {
        }

        public User(string name, string password, string typeOfUser)
        {
            this.Name = name;
            this.Password = password;
            this.TypeOfUser = typeOfUser; 
        }
    }
}
