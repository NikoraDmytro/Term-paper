namespace Api.DataTransferObjects
{
    public class DoctorDto
    {
        public int Age { get; set; }
        public int Experience { get; set; }
        public string FullName { get; set; } = string.Empty;
        public string Profession { get; set; } = string.Empty;
    }
}