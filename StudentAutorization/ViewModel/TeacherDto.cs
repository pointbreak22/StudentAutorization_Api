namespace StudentAutorization.ViewModel
{
    public class TeacherDto
    {

        public int Id { get; set; }
        public string FIO { get; set; } = string.Empty;

        public int PictureId { get; set; }
        public string PictureName { get; set; } = string.Empty;
    }
}
