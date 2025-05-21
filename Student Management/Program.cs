using System;
using System.Collections.Generic;

class Student
{
    public string Name { get; set; }
    public int Age { get; set; }
    public float Marks { get; set; }

    public void Display()
    {
        Console.WriteLine($"Name: {Name}, Age: {Age}, Marks: {Marks}");
    }
}

class Program
{
    static void Main()
    {
        List<Student> students = new List<Student>();
        int choice;

        do
        {
            Console.WriteLine("\n--- Student Management System ---");
            Console.WriteLine("1. Add Student");
            Console.WriteLine("2. View All Students");
            Console.WriteLine("3. Show Average Marks");
            Console.WriteLine("4. Exit");
            Console.Write("Enter your choice: ");

            bool isValid = int.TryParse(Console.ReadLine(), out choice);
            if (!isValid)
            {
                Console.WriteLine("Invalid input. Please enter a number.");
                continue;
            }

            switch (choice)
            {
                case 1:
                    Student s = new Student();
                    Console.Write("Enter name: ");
                    s.Name = Console.ReadLine();

                    Console.Write("Enter age: ");
                    s.Age = int.Parse(Console.ReadLine());

                    Console.Write("Enter marks: ");
                    s.Marks = float.Parse(Console.ReadLine());

                    students.Add(s);
                    Console.WriteLine("Student added successfully!");
                    break;

                case 2:
                    Console.WriteLine("\n--- Student List ---");
                    if (students.Count == 0)
                        Console.WriteLine("No students added yet.");
                    else
                        foreach (var student in students)
                            student.Display();
                    break;

                case 3:
                    if (students.Count == 0)
                        Console.WriteLine("No students to calculate average.");
                    else
                    {
                        float total = 0;
                        foreach (var student in students)
                            total += student.Marks;

                        float average = total / students.Count;
                        Console.WriteLine($"Average Marks: {average:F2}");
                    }
                    break;

                case 4:
                    Console.WriteLine("Exiting...");
                    break;

                default:
                    Console.WriteLine("Invalid choice.");
                    break;
            }

        } while (choice != 4);
    }
}
