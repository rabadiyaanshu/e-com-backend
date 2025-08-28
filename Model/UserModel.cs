using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebLoginRegisterApi.Model
{
    [Table("Users")] 
    public class UserModel
    {
        public int Id { get; set; }

        [Required]
        public string? Username { get; set; }

        [Required]
        public string? Email { get; set; }

        [Required]
        public string? Password { get; set; }

        public bool IsLoggedIn { get; set; } = false;
        public DateTime? LastLoginDate { get; set; }
    }
}
