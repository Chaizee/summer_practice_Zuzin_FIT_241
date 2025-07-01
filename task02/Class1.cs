namespace task02;

public class Student
{
    public required string Name { get; set; }
    public required string Faculty { get; set; }
    public required List<int> Grades { get; set; }
}

public class StudentService {
    private readonly List<Student> _students;
    
    public StudentService(List<Student> students) => _students = students;

    public IEnumerable<Student> GetStudentsByFaculty(string faculty)
        =>  _students.Where(c => c.Faculty == faculty);

    public IEnumerable<Student> GetStudentsWithMinAverageGrade(double minAverageGrade) 
        => _students.Where(c => c.Grades.Any() && c.Grades.Average() >= minAverageGrade);

    public IEnumerable<Student> GetStudentsOrderedByName()
        => _students.OrderBy(c => c.Name);

    public ILookup<string, Student> GroupStudentsByFaculty()
        => _students.ToLookup(c => c.Faculty);

    public string GetFacultyWithHighestAverageGrade()
        => _students.Where(c => c.Grades.Any())
        .GroupBy(c => c.Faculty)
        .OrderByDescending(s => s.Average(v => v.Grades.Average()))
        .Select(v => v.Key)
        .FirstOrDefault();
}
