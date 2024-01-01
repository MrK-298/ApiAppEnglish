using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiAppEnglish.Data.EF
{
    [Table("Topic")]
    public class Topic
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string title { get; set; }
        public string content { get; set; }
        public ICollection<Homework> homeworks { get; set; }

    }
}
