
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StudentAutorization.Models.Main
{
    public class Teacher
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; } = string.Empty;
        public int PictureId { get; set; }

        [ForeignKey(nameof(PictureId))]
        public Picture? Picture { get; set; }


        [System.Text.Json.Serialization.JsonIgnore]

        public List<Group>? Groups { get; set; }



    }
}
