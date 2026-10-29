using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectHome2
{
    public static class StudentGradesHelper
    {
        public static double Average(StudentGrades student)
        {
            int sum = 0;
            foreach (int grade in student.Grades)
            {
                sum += grade;
            }
            return (double)sum / student.Grades.Length;
        }
        public static StudentGrades MaxAverageStudent(StudentGrades[] students)
        {
            StudentGrades bestStudent = students[0];
            double maxAverage = Average(bestStudent);
            for (int i = 1; i < students.Length; i++)
            {
                double average = Average(students[i]);
                bool isBetter = average > maxAverage;
                bestStudent = isBetter ? students[i] : bestStudent;
                maxAverage = isBetter ? average : maxAverage;
            }
            return bestStudent;
        }
        public static double OverallAverage(StudentGrades[] students)
        {
            int sum = 0;
            int count = 0;
            foreach (StudentGrades student in students)
            {
                foreach (int grade in student.Grades)
                {
                    sum += grade;
                    count++;
                }
            }
            return (double)sum / count;
        }
    }
}
