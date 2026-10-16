using System.ComponentModel.DataAnnotations;

namespace SRMSS.Models
{
    public class User
    {
        [Key]
        public int UserID { get; set; }

        [Required]
        [StringLength(50)]
        public string Username { get; set; } = string.Empty;

        [Required]
        [StringLength(255)]
        public string Password { get; set; } = string.Empty;

        [StringLength(100)]
        public string? FullName { get; set; }

        [Required]
        [StringLength(50)]
        public string Role { get; set; } = "User";
    }
}