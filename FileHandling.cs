using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentPerformanceTracker
{
    internal class FileHandling
    {
        private readonly string path = "StudentReport.csv";
        // load the data
        public List<Student> Load()
        {
            List<Student> students = new List<Student>();
            try
            {
                if(!File.Exists(path))
                {
                    return students;
                }
                else
                {
                    string[] lines = File.ReadAllLines(path);
                    
                    foreach (string line in lines)
                    {
                        string[] element = line.Split(",");
                        try
                        {
                            if (element.Length == 5)
                            {
                                List<int> marks = element[2].Split("|").Select(a => int.Parse(a)).ToList();

                                StudentType type = Enum.Parse<StudentType>(element[4]);
                                students.Add(new Student
                                {
                                    Id = int.Parse(element[0]),
                                    Name = element[1],
                                    Marks = marks,
                                    Type = type
                                });
                            }
                            else
                            {
                                continue;
                            }
                        }
                        catch { 
                            // Header Line
                        }
                    }
                    return students;
                }
            }catch { Console.WriteLine("The file is open in another program. Please close it and try again.");Environment.Exit(1); return students; }
        }
        // save the data
        public void Save(List<Student> students)
        {
            try
            {
                using (StreamWriter sw = new StreamWriter(path))
                {
                    sw.WriteLine("Student Id,Student Name,Student Marks in all subject,Result,Type of Student");
                    foreach (Student student in students)
                    {
                        string marks = string.Join("|", student.Marks);
                        sw.WriteLine($"{student.Id},{student.Name},{marks},{student.GetGrade},{student.Type}");
                    }
                }
            }
            catch { Console.WriteLine("The file is open in another program. Please close it and try again.");Environment.Exit(1); }
        }
    }
}
//>	StudentPerformanceTracker.dll!StudentPerformanceTracker.FileHandling.Save(System.Collections.Generic.List<StudentPerformanceTracker.Student> students) Line 59	C#
