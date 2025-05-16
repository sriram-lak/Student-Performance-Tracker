using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentPerformanceTracker
{
    internal interface IStudentService
    {
        // add, edit, delete, display and id generater function 
        void AddStudent(int id,StudentType typeOfStudent);
        void EditStudent(int id);
        void DeleteStudent(int id);
        void DisplayResult();
        void DisplayCatagery();
        int GetId();
        void SaveInFile();
    }
}
