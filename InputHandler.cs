using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace StudentPerformanceTracker
{
    internal class InputHandler
    {
        // check the valid name using Regex
        public string GetName()
        {
            string pattern = @"^[A-Za-z]+(?: [A-Za-z]+)*$";
            while (true)
            {
                try
                {
                    Console.WriteLine("Enter the Student Name");
                    string? input = Console.ReadLine();
                    if (input!=null)
                    {
                        if (Regex.IsMatch(input, pattern))
                        {
                            return input;
                        }
                        Console.WriteLine("Please enter the valid name");
                    }
                    else
                    {
                        Console.WriteLine("error");
                    }
                    
                }
                catch (Exception e)
                {
                    Console.WriteLine("Error : " + e.Message);
                }
            }
        }
        // get the valid input and 5 subject
        public List<int> GetMark()
        {
            List<int> marks = new List<int>();
                for (int i = 1; i <= 5; i++)
                {
                    int mark;
                    Console.WriteLine($"Enter the Mark Subject {i}");
                    if(int.TryParse(Console.ReadLine(), out mark) && mark >= 0 && mark <= 100)
                    {
                        marks.Add(mark);
                    }
                    else
                    {
                        Console.WriteLine("Please Enter the Valid Mark");
                        i--;
                    }
                }
                return marks;
        }

        // edit mark
        public List<int> EditMark(List<int> marks)
        {
            try
            {
                for (int i = 1; i <= 5; i++)
                {
                    if(YesOrNo($"subject {i} - {marks[i-1]}"))
                    {
                        bool isContinue = true;
                        while (isContinue)
                        {
                            int mark;
                            Console.WriteLine($"Enter the Mark of Subject {i}");
                            if (int.TryParse(Console.ReadLine(), out mark) && mark >= 0 && mark <= 100)
                            {
                                marks[i - 1] = mark;
                                isContinue = false;
                            }
                            else
                            {
                                Console.WriteLine("Please Enter the Valid Mark");
                            }
                        }
                    }
                }
            }
            catch(Exception e) { Console.WriteLine(e.Message); }
            return marks;
        }

        // calculate the yes or no
        public bool YesOrNo(string input)
        {
            bool isContinue = true;
            while (isContinue)
            {
                try
                {
                    Console.WriteLine($"You want to Change {input}? \nPress y : Yes\tPress n : No");
                    string? letter = Console.ReadLine();
                    if (letter.ToLower() == "y" || letter.ToLower() == "n")
                    {
                        if (letter.ToLower() == "n")
                        {
                            isContinue = false;
                            return false;
                        }
                        else
                        {
                            isContinue = false;
                            return true;
                        }
                    }
                    else
                    {
                        Console.WriteLine("Please Enter valid option");
                    }
                }
                catch (Exception e) { Console.WriteLine(e.Message); }
            }
            return false;
        }
    }
}
