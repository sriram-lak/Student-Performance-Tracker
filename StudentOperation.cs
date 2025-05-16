using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentPerformanceTracker
{
    internal class StudentOperation
    {
        
        private readonly IStudentService studentService;
        public StudentOperation(IStudentService studentService) {
            this.studentService = studentService;
        }
        public void Start()
        {
            bool isContinue = true;
            while (isContinue)
            {
                Console.WriteLine("\nPress 1 : Add Regular Student\nPress 2 : Add Exchange Student\nPress 3 : Edit\nPress 4 : Delete\nPress 5 : Display Result\nPress 6 : Display Catagery\nPress 7 : Exit");
                string input = Console.ReadLine();
                switch (input)
                {
                    // add the regular student
                    case "1":
                        studentService.AddStudent(studentService.GetId(),StudentType.Regular);
                        break;
                    // add the exchange student
                    case "2":
                        studentService.AddStudent(studentService.GetId(),StudentType.Exchange);
                        break;
                    // Edit the student detail
                    case "3":
                        int editId;
                        Console.WriteLine("Enter the Id to Edit");
                        if(int.TryParse(Console.ReadLine(), out editId))
                        {
                            studentService.EditStudent(editId);
                        }
                        else
                        {
                            Console.WriteLine("Id must be number format");
                        }
                        break;
                    // Delete the student detail
                    case "4":
                        int deleteId;
                        Console.WriteLine("Enter the Id to Delete"); 
                        if (int.TryParse(Console.ReadLine(), out deleteId))
                        {
                            studentService.DeleteStudent(deleteId);
                        }
                        else
                        {
                            Console.WriteLine("Id must be number format");
                        }
                        break;
                    //Display the Student name and result
                    case "5":
                        studentService.DisplayResult();
                        break;
                    // Display the Result Count
                    case "6":
                        studentService.DisplayCatagery();
                        break;
                    // Close the app
                    case "7":
                        studentService.SaveInFile();
                        return;
                    default:
                        Console.WriteLine("Please enter the valid option");
                        break;
                }

            }
        }
    }
}
