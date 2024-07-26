using System;
using System.ComponentModel.DataAnnotations;

namespace applicationPool.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Username { get; set; }

        [Required]
        public string Password { get; set; }

      
        public string Email { get; set; }


        public string FirstName { get; set; }

      
        public string LastName { get; set; }
    }


}

