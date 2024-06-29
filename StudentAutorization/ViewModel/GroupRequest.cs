using StudentAutorization.Models.Main;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace StudentAutorization.ViewModel
{
    public class GroupRequest
    {

      
       

        public string Name { get; set; } = string.Empty;


        public int CourseId { get; set; }
       


        public int TeacherId { get; set; }
       
    }
}
