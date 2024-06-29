namespace StudentAutorization.ViewModel
{
    public class StudentRequest
    {
        public string Name { get; set; } = string.Empty;

        public int GroupId { get; set; }     

        public byte[] Photo { get; set; }
    }
}
