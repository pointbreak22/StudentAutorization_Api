namespace StudentAutorization.ViewModel
{
    public class StudentDto
    {
        public int Id { get; set; }


        public string FIO { get; set; } = string.Empty;


        public string NumberPhone { get; set; } = string.Empty;


        public int GroupId { get; set; }
        public string GroupName { get; set; } = string.Empty;
        public int PictureId { get; set; }
        public string PictureName { get; set; } = string.Empty;

    }
}
