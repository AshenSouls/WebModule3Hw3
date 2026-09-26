using StudentApi.Models;

namespace StudentApi.Services;

public class StudentService : IStudentService
{
    private readonly List<Student> _students =
    [
        new Student { Id = 1, Name = "Анна Иванова", Group = "ПИ-31" },
        new Student { Id = 2, Name = "Иван Петров", Group = "ПИ-31" },
        new Student { Id = 3, Name = "Мария Сидорова", Group = "ПИ-32" }
    ];

    public IEnumerable<Student> GetAll() => _students;

    public Student? GetById(int id) => _students.FirstOrDefault(student => student.Id == id);
}