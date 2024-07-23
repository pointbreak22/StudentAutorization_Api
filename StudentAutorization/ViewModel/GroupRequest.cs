namespace StudentAutorization.ViewModel
{
    public class GroupRequest
    {




        public string Name { get; set; } = string.Empty;

        public string Specialty { get; set; } = string.Empty;
        public string Year { get; set; }
        public int CourseId { get; set; }



        public int TeacherId { get; set; }

    }
}
