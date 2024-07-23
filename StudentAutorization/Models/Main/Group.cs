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

        public string Year {  get; set; } = string.Empty;
        public string Specialty { get; set; } = string.Empty;

        public int CourseId { get; set; }

        [ForeignKey(nameof(CourseId))]
        public Course? Course { get; set; }

        [Column("teacher_id")]
        public int TeacherId { get; set; }

        [ForeignKey(nameof(TeacherId))]
        public Teacher? Teacher { get; set; }

        [System.Text.Json.Serialization.JsonIgnore]
        public List<Student> Students { get; } = new List<Student>();

    }
}
