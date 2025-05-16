using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentPerformanceTracker
{
    internal class StudentService : IStudentService
    {
        private readonly IStudentFactory studentFactory;
        private readonly InputHandler input;
        private readonly FileHandling fileHandling;
        private List<Student> students = new List<Student>();
        // Constructor
        public StudentService(IStudentFactory studentFactory, InputHandler input,FileHandling fileHandling)
        {
            this.studentFactory = studentFactory;
            this.input = input;
            this.fileHandling = fileHandling;
            students =fileHandling.Load();
        }
        // List add the Student detail
        public void AddStudent(int id,StudentType typeOfStudent)
        {
            var student = studentFactory.CreateStudent(id,typeOfStudent);
            students.Add(student);
            Console.WriteLine("Add Successfully");
        }
        // Edit Student detail both regular and exchange
        public void EditStudent(int id)
        {
            var student = students.FirstOrDefault(x => x.Id == id);
            if(student != null)
            {
                if (input.YesOrNo($"Name - {student.Name}"))
                {
                    string name = input.GetName();
                    student.Name = name;
                }
                if (input.YesOrNo("Mark"))
                {
                    List<int> mark = input.EditMark(student.Marks);
                    student.Marks = mark;
                }
                Console.WriteLine("Update Successfully");
            }
            else
            {
                Console.WriteLine("Student Id Not Found, Try Again");
            }
        }
        // Delete the student detail
        public void DeleteStudent(int id)
        {
            var student = students.FirstOrDefault(y => y.Id == id);
            if(student != null)
            {
                students.Remove(student);
                Console.WriteLine("Delete Successfully");
            }
            else
            {
                Console.WriteLine("Student Id Not Found, Try Again");
            }
        }
        // this function is display the all student name and result
        public void DisplayResult()
        {
            if(students.Count == 0)
            {
                Console.WriteLine("No Data is Found");
            }
            else
            {   
                Console.WriteLine("Student Name and Your Result");
                foreach(var student in students)
                {
                    Console.WriteLine($"Student Name - {student.Name}\tResult - {student.GetGrade}");
                }
            }
        }
        // Display the number of catagery
        public void DisplayCatagery()
        {
            Dictionary<String, int> regularStudentGrade = new Dictionary<String, int>();

            if (students.Count == 0)
            {
                Console.WriteLine("No Data is Found");
            }
            else
            {

                foreach (var student in students)
                {
                    if (regularStudentGrade.ContainsKey(student.GetGrade))
                    {
                        regularStudentGrade[student.GetGrade]++;
                    }
                    else
                    {
                        regularStudentGrade[student.GetGrade] = 1;
                    }
                }
                Console.WriteLine("Grade Catagery of Student");
                foreach(var grade in regularStudentGrade)
                {
                    Console.WriteLine($"Number of Grade {grade.Key} is {grade.Value}");
                }
            }
        }
        // Auto id generator
        public int GetId()
        {
            return students.Count == 0 ? 1 : students.Max(a => a.Id) + 1;
        }

        // save the file
        public void SaveInFile()
        {
            fileHandling.Save(students);
        }
    }
}
