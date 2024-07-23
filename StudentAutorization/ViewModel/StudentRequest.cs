namespace StudentAutorization.ViewModel
{
    public class StudentRequest
    {
        public string FIO { get; set; } = string.Empty;

        public int GroupId { get; set; }

        public string NumberPhone { get; set; } = string.Empty;
        public int PictureId { get; set; }
    }
}
