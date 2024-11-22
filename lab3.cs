
using System;
using System.Collections.Generic;

class StudentRecord
{
    public string LastName { get; }
    public string FirstName { get; }
    public double Mark1 { get; }
    public double Mark2 { get; }
    public double AverageMark { get; }

    public StudentRecord(string lastName, string firstName, double mark1, double mark2)
    {
        LastName = lastName;
        FirstName = firstName;
        Mark1 = mark1;
        Mark2 = mark2;
        AverageMark = (mark1 + mark2) / 2;
    }
}

class RecordBook
{
    public static void Main()
    {
        List<StudentRecord> records = new List<StudentRecord>();

        Console.Write("Enter the number of records: ");
        int recordCount;
        
        while (!int.TryParse(Console.ReadLine(), out recordCount) || recordCount <= 0)
        {
            Console.WriteLine("Invalid input. Please enter a positive integer for the number of records.");
        }

        for (int i = 0; i < recordCount; i++)
        {
            Console.WriteLine($"\nRecord #{i + 1}");

            Console.Write("Enter last name: ");
            string lastName = Console.ReadLine();

            Console.Write("Enter first name: ");
            string firstName = Console.ReadLine();

            double mark1, mark2;

            Console.Write("Enter mark for the first subject: ");
            while (!double.TryParse(Console.ReadLine(), out mark1) || mark1 < 0 || mark1 > 100)
            {
                Console.WriteLine("Invalid input. Please enter a valid numeric value (0-100) for the first subject mark.");
            }

            Console.Write("Enter mark for the second subject: ");
            while (!double.TryParse(Console.ReadLine(), out mark2) || mark2 < 0 || mark2 > 100)
            {
                Console.WriteLine("Invalid input. Please enter a valid numeric value (0-100) for the second subject mark.");
            }

            records.Add(new StudentRecord(lastName, firstName, mark1, mark2));
        }

        Console.WriteLine("\nReport:");
        Console.WriteLine("------------------------------------------------------");
        Console.WriteLine("| Last Name | First Name | Subject 1 | Subject 2 | Average |");
        Console.WriteLine("------------------------------------------------------");

        double totalAverage = 0;
        foreach (var record in records)
        {
            Console.WriteLine($"| {record.LastName,-10} | {record.FirstName,-10} | {record.Mark1,9:F2} | {record.Mark2,9:F2} | {record.AverageMark,7:F2} |");
            totalAverage += record.AverageMark;
        }

        Console.WriteLine("------------------------------------------------------");
        Console.WriteLine($"Total Average for All Students: {totalAverage / records.Count:F2}");
    }
}
