using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace hireAPI.Models
{
    public class User:IdentityUser
    {
        [Required,MaxLength(50)]
        public string Arabic_Name { get; set; }
        [Required, MaxLength(50)]

        public string English_Name { get; set; }

        public string Email { get; set; }
        public string Password { get; set; }
        public string Mobile { get; set; }


        public IEnumerable<Products>? ProductUser { get; set; }
        
        public User(string arabic_Name, string english_Name, string email, string password, string mobile, IEnumerable<Products>? productUser)
        {
            Arabic_Name = arabic_Name;
            English_Name = english_Name;
            Email = email;
            Password = password;
            Mobile = mobile;
            ProductUser = productUser;
        }
        public User()
        {
                
        }

    }
}
