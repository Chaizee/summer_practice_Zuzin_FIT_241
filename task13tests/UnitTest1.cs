global using Xunit;
using task13;

namespace task13tests;

public class UnitTest1
{

    public Student student = new Student {
        FirstName = "Bumbl",
        LastName = "Coffe",
        BirthDate = new DateTime(2004, 04, 12),
        Grades = new List<Subject> {
            new Subject { Name = "Math", Grade = 5}
        }
    };

    [Fact]
    public void Serializer_ShouldReturnCorrectSerialized()
    {
        var serializedStud = JsonStudent.Serialize(student);
        Assert.Contains("Bumbl", serializedStud);
        Assert.Contains("Coffe", serializedStud);
        Assert.Contains("12-04-2004", serializedStud);
        Assert.Contains("Math", serializedStud);
        Assert.Contains("5", serializedStud);
    }

    [Fact]
    public void Deserializer_ShouldReturnCorrectDeserizlized() {
        var serializedStud = JsonStudent.Serialize(student);
        var deserializedstud = JsonStudent.Deserialize(serializedStud);

        Assert.Equal(student.BirthDate, deserializedstud.BirthDate);
        Assert.Equal("Bumbl", deserializedstud.FirstName);
        Assert.Equal("Coffe", deserializedstud.LastName);
        Assert.NotNull(deserializedstud.Grades);
        Assert.Equal("Math", deserializedstud.Grades[0].Name);
        Assert.Equal(5 , deserializedstud.Grades[0].Grade);
    }
}