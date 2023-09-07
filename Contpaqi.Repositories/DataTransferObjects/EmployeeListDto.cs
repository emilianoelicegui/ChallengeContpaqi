namespace Contpaqi.Data.DataTransferObjects
{
    public class EmployeeListDto
    {
        public int Id { get; set; }
        public string FullName { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string Position { get; set; } = null!;
        public string Rfc { get; set; } = null!;
        public DateTime HireDate { get; set; }
    }
}
