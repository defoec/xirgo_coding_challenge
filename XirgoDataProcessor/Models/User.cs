using System;

namespace XirgoDataProcessor.Models
{
    public class User
    {
        public User(string userString){
            string[] user = userString.Split(',');
            UserType = Convert.ToInt32(user[0]);
            UserBirthYear = Convert.ToInt32(user[1]);
            UserGender = Convert.ToInt32(user[2]);
        }

        public int UserType { get; }
        public int UserBirthYear { get; }
        public int UserGender { get; }
    }
}