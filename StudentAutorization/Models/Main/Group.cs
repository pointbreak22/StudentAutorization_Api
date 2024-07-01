using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StudentAutorization.Models.Main
{
    public class Group
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; } = string.Empty;

       
        public int CourseId { get; set; }

        public Course? Course { get; set; }

      
        public int TeacherId { get; set; }
   
        public Teacher? Teacher { get; set; }

        public List<Student> Students { get; } = new List<Student>();

    }
}
