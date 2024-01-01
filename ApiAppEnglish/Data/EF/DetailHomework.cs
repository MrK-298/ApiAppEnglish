using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace ApiAppEnglish.Data.EF
{
    [Table("DetailHomeWork")]
    public class DetailHomework
    {
        [Key]
        public int id { get; set; }

        public int homeworkId { get; set; }
        public virtual Homework homework { get; set; }
        public int userId { get; set; }
        public virtual User user { get; set; }
        public int score { get; set; }
        public bool isDone { get; set; }
    }
}
