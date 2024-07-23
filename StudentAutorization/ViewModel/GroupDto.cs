using StudentAutorization.Models.Main;
using System.ComponentModel.DataAnnotations.Schema;

namespace StudentAutorization.ViewModel
{
    public class GroupDto
    {
        public int Id { get; set; }

     
        public string Name { get; set; } = string.Empty;

        public string Year { get; set; } = string.Empty;
        public string Specialty { get; set; } = string.Empty;

       

        public string? CourseName { get; set; }

      
        public string? TeacherName { get; set; }

    }
}
