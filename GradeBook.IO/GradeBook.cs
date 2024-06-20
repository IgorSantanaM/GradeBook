using System;

public class GradeBook
{
    private int[] grades;

    public string CourseName { get; set; }

    public GradeBook(string name, int[] gradesArray)
    {
        CourseName = name;
        grades = gradesArray;
    }

    public void DisplayMessage()
    {
        Console.WriteLine("Welcome to the grade book for\n{0}!\n", CourseName);
    }

    public void ProcessGrades()
    {
        OutputGrades();
        Console.WriteLine("\nClass average is {0:F}", GetAverage());
        Console.WriteLine("Lowest grade is {0}\nHighest grade is {1}\n", GetMinimum(), GetMaximum());
        OutputBarChart();
    }

    public int GetMinimum()
    {
        int lowGrade = grades[0];

        foreach (int grade in grades)
        {
            if (grade < lowGrade)
                lowGrade = grade;
        }

        return lowGrade;
    }

    public int GetMaximum()
    {
        int highGrade = grades[0];

        foreach (int grade in grades)
        {
            if (grade > highGrade)
                highGrade = grade;
        }

        return highGrade;
    }

    public double GetAverage()
    {
        int total = 0;

        foreach (int grade in grades)
            total += grade;

        return (double)total / grades.Length;
    }

    public void OutputBarChart()
    {
        Console.WriteLine("Grade distribution:");

        int[] frequency = new int[11];

        foreach (int grade in grades)
            ++frequency[grade / 10];

        for (int count = 0; count < frequency.Length; ++count)
        {
            if (count == 10)
                Console.Write("  100: ");
            else
                Console.Write("{0:D2}-{1:D2}: ", count * 10, count * 10 + 9);

            for (int stars = 0; stars < frequency[count]; ++stars)
                Console.Write("*");

            Console.WriteLine();
        }
    }

    public void OutputGrades()
    {
        Console.WriteLine("The grades are:\n");

        for (int student = 0; student < grades.Length; ++student)
            Console.WriteLine("Student {0}: {1}", student + 1, grades[student]);
    }
}
