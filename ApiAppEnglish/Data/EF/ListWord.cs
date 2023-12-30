using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiAppEnglish.Data.EF
{
    [Table("ListWord")]
    public class ListWord
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string word { get; set; }
        public string definition { get; set; }
        public int UserId { get; set; }
        public string phonetic { get; set; }
    }
}
