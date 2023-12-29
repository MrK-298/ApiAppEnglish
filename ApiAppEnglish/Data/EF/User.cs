using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiAppEnglish.Data.EF
{
    public class User
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        [MaxLength(100)]
        public string userName { get; set; }
        [Required]
        [MaxLength(100)]
        public string passWord { get; set; }
        [EmailAddress]
        public string Email { get; set; }
        public bool? emailConfirmed { get; set; }
        public string? fullName { get; set; }
        public string? VerificationCode { get; set; }
        public ICollection<ListWord> List { get; set; }
    }
}
