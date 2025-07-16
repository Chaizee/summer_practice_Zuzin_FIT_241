﻿using System.Text.Json;
using System.Text.Json.Serialization;

namespace task13;

public class Subject
{
  public string? Name {get; set; }
  public int Grade {get; set; }
}

public class Student
{
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public DateTime BirthDate { get; set; }
    public List<Subject>? Grades { get; set; }
}

public class JsonStudent

{
    public class CustomDateConverter : JsonConverter<DateTime> {
        private const string format = "dd-MM-yyyy";

        public override DateTime Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options) {
            string datestr = reader.GetString();
            return DateTime.ParseExact(datestr, format, null);
        }

        public override void Write(Utf8JsonWriter writer, DateTime value, JsonSerializerOptions options)
        {
            writer.WriteStringValue(value.ToString(format));
        }
    }
        public static string Serialize(Student student) {
            var opt = new JsonSerializerOptions { IgnoreNullValues = true, Converters = { new CustomDateConverter()}, WriteIndented = true};

            return JsonSerializer.Serialize(student, opt);
        }

        public static Student Deserialize(string student)
        {
            var opt = new JsonSerializerOptions { Converters = { new CustomDateConverter() }, WriteIndented = true };

            return JsonSerializer.Deserialize<Student>(student, opt)!;
        }
    
}