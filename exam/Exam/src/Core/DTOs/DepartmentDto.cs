namespace Exam.Core.DTOs
{
    public class DepartmentDto
    {
        public int DepartmentId { get; set; }        // Mã phòng ban
        public string DepartmentName { get; set; }   // Tên phòng ban
        public string Location { get; set; }         // Địa điểm của phòng ban
        public int NumberOfPersonals { get; set; }   // Số lượng nhân sự trong phòng ban

        // Các thuộc tính khác nếu cần thiết
    }
}
