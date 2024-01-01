using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiAppEnglish.Data.EF
{
    [Table("Homework")]
    public class Homework
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string title { get; set; }     
        public int topicId { get; set; }

    }
}
