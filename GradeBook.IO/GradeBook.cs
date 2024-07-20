using System;

public class GradeBook
{
    private int[,] grades; // rectangular array of student grades

    // auto-implemented property CourseName
    public string CourseName { get; set; }

    // two-parameter constructor initializes CourseName and grades array
    public GradeBook(string name, int[,] gradesArray)
    {
        CourseName = name;
        grades = gradesArray; // initialize grades array
    }

    // display a welcome message to the GradeBook user
    public void DisplayMessage()
    {
        Console.WriteLine("Welcome to the grade book for\n{0}!\n", CourseName);
    }

    // perform various operations on the data
    public void ProcessGrades()
    {
        OutputGrades();

        Console.WriteLine("\n{0} {1}\n{2} {3}\n",
            "Lowest grade in the grade book is", GetMinimum(),
            "Highest grade in the grade book is", GetMaximum());

        OutputBarChart();
    }

    // find minimum grade
    public int GetMinimum()
    {
        int lowGrade = grades[0, 0]; // assume first element is smallest

        foreach (int grade in grades)
        {
            if (grade < lowGrade)
                lowGrade = grade; // new lowest grade
        }

        return lowGrade; // return lowest grade
    }

    // find maximum grade
    public int GetMaximum()
    {
        int highGrade = grades[0, 0]; // assume first element is largest

        foreach (int grade in grades)
        {
            if (grade > highGrade)
                highGrade = grade; // new highest grade
        }

        return highGrade; // return highest grade
    }

    // determine average grade for particular student
    public double GetAverage(int student)
    {
        int total = 0; // initialize total
        int amount = grades.GetLength(1); // get the number of grades per student

        for (int exam = 0; exam < amount; ++exam)
        {
            total += grades[student, exam]; // sum grades for one student
        }

        return (double)total / amount; // return average of grades
    }

    // output bar chart displaying overall grade distribution
    public void OutputBarChart()
    {
        Console.WriteLine("Overall grade distribution:");

        int[] frequency = new int[11]; // stores frequency of grades in each range of 10 grades

        foreach (int grade in grades)
        {
            ++frequency[grade / 10]; // increment the appropriate frequency
        }

        for (int count = 0; count < frequency.Length; ++count)
        {
            if (count == 10)
                Console.Write(" 100: ");
            else
                Console.Write("{0:D2}-{1:D2}: ", count * 10, count * 10 + 9);

            for (int stars = 0; stars < frequency[count]; ++stars)
                Console.Write("*");

            Console.WriteLine(); // start a new line of output
        }
    }

    // output the contents of the grades array
    public void OutputGrades()
    {
        Console.WriteLine("The grades are:\n");
        Console.Write(" "); // align column heads

        for (int test = 0; test < grades.GetLength(1); ++test)
            Console.Write("Test {0} ", test + 1);

        Console.WriteLine("Average"); // student average column heading

        for (int student = 0; student < grades.GetLength(0); ++student)
        {
            Console.Write("Student {0,2}", student + 1);

            for (int grade = 0; grade < grades.GetLength(1); ++grade)
                Console.Write("{0,8}", grades[student, grade]);

            Console.WriteLine("{0,9:F}", GetAverage(student)); // output student's average grade
        }
    }
}
