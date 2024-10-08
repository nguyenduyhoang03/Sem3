using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ExamAzure.Dto
{
    // Dùng để trả về thông tin Project
    public class ProjectDto
    {
        public int ProjectId { get; set; }

        public string ProjectName { get; set; }

        public DateTime ProjectStartDate { get; set; }

        public DateTime? ProjectEndDate { get; set; }

        public List<int> EmployeeIds { get; set; }
    }

    // Dùng để thêm mới Project
    public class CreateProjectDto
    {
        [Required]
        [StringLength(150, MinimumLength = 2)]
        public string ProjectName { get; set; }

        [Required]
        public DateTime ProjectStartDate { get; set; }

        public DateTime? ProjectEndDate { get; set; }

        // Danh sách các EmployeeId cho Project này
        public List<int> EmployeeIds { get; set; }
    }

    // Dùng để cập nhật Project
    public class UpdateProjectDto
    {
        [Required]
        public int ProjectId { get; set; }

        [Required]
        [StringLength(150, MinimumLength = 2)]
        public string ProjectName { get; set; }

        [Required]
        public DateTime ProjectStartDate { get; set; }

        public DateTime? ProjectEndDate { get; set; }

        // Danh sách các EmployeeId cập nhật cho Project này
        public List<int> EmployeeIds { get; set; }
    }
}
