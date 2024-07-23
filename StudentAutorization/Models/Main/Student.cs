using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StudentAutorization.Models.Main
{
    public class Student
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        public string FIO { get; set; } = string.Empty;
        public string NumberPhone { get; set; } = string.Empty;

        public int GroupId { get; set; }

        [ForeignKey(nameof(GroupId))]
        public Group? Group { get; set; }

        public int PictureId { get; set; }

        public Picture? Picture { get; set; }



    }
}
