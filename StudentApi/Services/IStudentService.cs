using StudentApi.Models;

namespace StudentApi.Services;

public interface IStudentService
{
    IEnumerable<Student> GetAll();

    Student? GetById(int id);
}