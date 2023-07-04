using System.ComponentModel.DataAnnotations;

namespace hireAPI.Models
{
    public class RegisterModel
    {
        [Required,StringLength(50)]
        public string Arabic_Name { get; set; }

        [Required, StringLength(50)]

        public string English_Name { get; set; }
        [Required, StringLength(128)]

        public string Email { get; set; }



        [Required, StringLength(256)]

        public string Password { get; set; }




        [Required, StringLength(11)]

        public string Mobile { get; set; }
    }
}
