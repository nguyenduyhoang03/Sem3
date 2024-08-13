using AutoMapper;
using Exam.Core.DTOs;
using Exam.src.Core.Entities;

public class AutoMapperProfile : Profile
{
    public AutoMapperProfile()
    {
        // Ánh xạ từ Employee entity sang EmployeeDto
        CreateMap<Employee, EmployeeDto>()
            .ForMember(dest => dest.DepartmentName, opt => opt.MapFrom(src => src.Department.DepartmentName));

        // Ánh xạ từ Department entity sang DepartmentDto (nếu cần)
        CreateMap<Department, DepartmentDto>();
    }
}
