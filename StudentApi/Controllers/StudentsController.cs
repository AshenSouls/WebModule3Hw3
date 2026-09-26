using Microsoft.AspNetCore.Mvc;
using StudentApi.Models;
using StudentApi.Services;

namespace StudentApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class StudentsController : ControllerBase
{
    private readonly IStudentService _studentService;
    private readonly ILogger<StudentsController> _logger;

    public StudentsController(
        IStudentService studentService,
        ILogger<StudentsController> logger)
    {
        _studentService = studentService;
        _logger = logger;
    }

    [HttpGet]
    public ActionResult<IEnumerable<Student>> GetAll()
    {
        _logger.LogInformation("Getting all students");
        return Ok(_studentService.GetAll());
    }

    [HttpGet("{id:int}")]
    public ActionResult<Student> GetById(int id)
    {
        try
        {
            var student = _studentService.GetById(id);

            if (student is null)
            {
                _logger.LogWarning("Student with ID {StudentId} was not found", id);
                return NotFound();
            }

            _logger.LogInformation("Student with ID {StudentId} was found", id);
            return Ok(student);
        }
        catch (Exception exception)
        {
            _logger.LogError(exception, "Error while getting student with ID {StudentId}", id);
            return StatusCode(StatusCodes.Status500InternalServerError);
        }
    }
}