using System;
using System.Text;
using static System.Console;

namespace ProjectHome2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            OutputEncoding = Encoding.UTF8;

            string[] subjects =
            {
                "Математика",
                "Програмування",
                "Бази даних"
            };

            StudentGrades[] students =
            {
                new StudentGrades("Іван Петренко",subjects,new int[] { 10, 12, 11 }),
                new StudentGrades("Олена Коваленко",subjects,new int[] { 12, 11, 12 }),
                new StudentGrades("Андрій Мельник",subjects,new int[] { 8, 9, 10 })
            };
            WriteLine(" ОЦІНКИ СТУДЕНТІВ \n");

            foreach (StudentGrades student in students)
            {
                WriteLine($"Студент: {student.Name}");
                for (int i = 0; i < student.Grades.Length; i++)
                {
                    WriteLine($"{student.Subjects[i]}: {student.Grades[i]}");
                }
                WriteLine($"Середня оцінка: {StudentGradesHelper.Average(student):F2}\n");
            }
            StudentGrades bestStudent = StudentGradesHelper.MaxAverageStudent(students);
            WriteLine(" НАЙКРАЩИЙ СТУДЕНТ ");
            WriteLine($"Ім'я: {bestStudent.Name}");
            WriteLine($"Середня оцінка: {StudentGradesHelper.Average(bestStudent):F2}");
            WriteLine("\n ЗАГАЛЬНА СЕРЕДНЯ ОЦІНКА ");
            WriteLine($"{StudentGradesHelper.OverallAverage(students):F2}");
            ReadKey();
        }
    }
}
