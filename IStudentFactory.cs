using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentPerformanceTracker
{
    internal interface IStudentFactory
    {
        // regular and exchange student instance creation
        Student CreateStudent(int id, StudentType typeOfStudent);
    }
}
