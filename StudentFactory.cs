using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentPerformanceTracker
{
    internal class StudentFactory : IStudentFactory
    {
        private readonly InputHandler input;
        public StudentFactory(InputHandler input)
        {
            this.input = input;
        }
        // Add the instance of student
        public Student CreateStudent(int id, StudentType typeOfStudent)
        {
            string name = input.GetName();
            List<int> mark = input.GetMark();
            double average = mark.Sum() / mark.Count();
            return (new Student
            {
                Id = id,
                Name = name,
                Marks = mark,
                Type = typeOfStudent
            });
        }
    }

}

