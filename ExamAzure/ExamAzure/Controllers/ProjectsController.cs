using ExamAzure.Dto;
using ExamAzure.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExamAzure.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectsController : ControllerBase
    {
        private readonly ProjectManagementContext _context;

        public ProjectsController(ProjectManagementContext context)
        {
            _context = context;
        }

        // GET: api/projects
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProjectDto>>> GetProjects()
        {
            return await _context.Projects
                .Include(p => p.ProjectEmployees)
                .ThenInclude(pe => pe.Employees)
                .Select(p => new ProjectDto
                {
                    ProjectId = p.ProjectId,
                    ProjectName = p.ProjectName,
                    ProjectStartDate = p.ProjectStartDate,
                    ProjectEndDate = p.ProjectEndDate,
                    EmployeeIds = p.ProjectEmployees.Select(pe => pe.EmployeeId).ToList()
                })
                .ToListAsync();
        }

        // GET: api/projects/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<ProjectDto>> GetProject(int id)
        {
            var project = await _context.Projects
                .Include(p => p.ProjectEmployees)
                .ThenInclude(pe => pe.Employees)
                .FirstOrDefaultAsync(p => p.ProjectId == id);

            if (project == null)
            {
                return NotFound();
            }

            var projectDto = new ProjectDto
            {
                ProjectId = project.ProjectId,
                ProjectName = project.ProjectName,
                ProjectStartDate = project.ProjectStartDate,
                ProjectEndDate = project.ProjectEndDate,
                EmployeeIds = project.ProjectEmployees.Select(pe => pe.EmployeeId).ToList()
            };

            return projectDto;
        }

        // POST: api/projects
        [HttpPost]
        public async Task<ActionResult<ProjectDto>> PostProject(CreateProjectDto dto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var project = new Project
            {
                ProjectName = dto.ProjectName,
                ProjectStartDate = dto.ProjectStartDate,
                ProjectEndDate = dto.ProjectEndDate
            };

            _context.Projects.Add(project);
            await _context.SaveChangesAsync();

            // Thêm các Employee vào Project
            if (dto.EmployeeIds != null && dto.EmployeeIds.Count > 0)
            {
                foreach (var employeeId in dto.EmployeeIds)
                {
                    _context.ProjectEmployees.Add(new ProjectEmployee
                    {
                        ProjectId = project.ProjectId,
                        EmployeeId = employeeId
                    });
                }
                await _context.SaveChangesAsync();
            }

            var projectDto = new ProjectDto
            {
                ProjectId = project.ProjectId,
                ProjectName = project.ProjectName,
                ProjectStartDate = project.ProjectStartDate,
                ProjectEndDate = project.ProjectEndDate,
                EmployeeIds = dto.EmployeeIds
            };

            return CreatedAtAction(nameof(GetProject), new { id = project.ProjectId }, projectDto);
        }

        // PUT: api/projects/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateProject(int id, UpdateProjectDto dto)
        {
            if (id != dto.ProjectId)
            {
                return BadRequest("Project ID mismatch");
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var project = await _context.Projects
                .Include(p => p.ProjectEmployees)
                .FirstOrDefaultAsync(p => p.ProjectId == id);

            if (project == null)
            {
                return NotFound();
            }

            // Cập nhật thông tin project
            project.ProjectName = dto.ProjectName;
            project.ProjectStartDate = dto.ProjectStartDate;
            project.ProjectEndDate = dto.ProjectEndDate;

            // Cập nhật các Employee liên quan
            project.ProjectEmployees.Clear();
            if (dto.EmployeeIds != null && dto.EmployeeIds.Count > 0)
            {
                foreach (var employeeId in dto.EmployeeIds)
                {
                    project.ProjectEmployees.Add(new ProjectEmployee
                    {
                        ProjectId = project.ProjectId,
                        EmployeeId = employeeId
                    });
                }
            }

            await _context.SaveChangesAsync();

            return NoContent();
        }

        // DELETE: api/projects/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProject(int id)
        {
            var project = await _context.Projects.FindAsync(id);
            if (project == null)
            {
                return NotFound();
            }

            _context.Projects.Remove(project);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ProjectExists(int id)
        {
            return _context.Projects.Any(p => p.ProjectId == id);
        }
    }
}
