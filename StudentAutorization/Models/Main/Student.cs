using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Drawing;

namespace StudentAutorization.Models.Main
{
    public class Student
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }=string.Empty;
        [ForeignKey("Group")]
        public int GroupId { get; set; }
      
        public Group? Group { get; set; }

        public byte[]? Photo { get; set; }


        
    }
}
