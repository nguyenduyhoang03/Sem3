namespace Exam.Core.DTOs
{
    public class EmployeeDto
    {
        public int EmployeeId { get; set; }          // Mã nhân viên
        public string EmployeeName { get; set; }     // Tên nhân viên
        public string DepartmentName { get; set; }   // Tên phòng ban
        public string Rank { get; set; }             // Cấp bậc nhân viên

        // Bạn có thể thêm các thuộc tính khác nếu cần thiết
    }
}
