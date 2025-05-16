using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentPerformanceTracker
{
    internal class Student
    {
        // Id Property
        public int Id { get; set; }
        // Name property
        public string Name { get; set; }
        // Marks Property
        public List<int> Marks { get; set; }
        // Type of Student Property
        public StudentType Type { get; set; }
        // Average
        public double Average
        {
            get
            {
                if (Marks != null && Marks.Count > 0)
                    return Marks.Average();
                return 0;
            }
        }
        public string GetGrade
        {
            get
            {
                if (Type == StudentType.Regular)
                {
                    if (Average >= 90) return "A+";
                    else if (Average >= 80) return "A";
                    else if (Average >= 70) return "B";
                    else if (Average >= 60) return "C";
                    else if (Average >= 50) return "D";
                    else return "F";
                }
                else
                {
                    if (Average >= 60) return "Pass";
                    else return "Fail";
                }
            }
            set { }
        }

    }
}
