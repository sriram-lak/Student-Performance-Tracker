using System;
using System.Net.Http.Headers;

namespace StudentPerformanceTracker
{
    class Program
    {
        static void Main(string[] args)
        {
            // object of input handler 
            InputHandler input = new InputHandler();
            // object of File Handling
            FileHandling fileHandling = new FileHandling();
            // object of student factory is do the creation of student detail
            IStudentFactory studentFactory = new StudentFactory(input);
            // object of student services is do the add, delete, edit and display
            IStudentService studentService = new StudentService(studentFactory,input,fileHandling);
            // object of the sutdentoperation is contain the UI of console
            StudentOperation studentOperation = new StudentOperation(studentService);
            // initially call the Start() method
            studentOperation.Start();
        }
    }
}