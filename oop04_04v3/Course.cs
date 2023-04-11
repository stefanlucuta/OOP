using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace oop04_04v3
{
    internal class Course
    {
        public string Name { get; set; }
        public int Credits { get; set; }
        public Dictionary<Student, int> Grades { get; set; } = new Dictionary<Student, int>();

        public Course(string name, int credits)
        {
            Name = name;
            Credits = credits;
        }

        public void EnrollStudent(Student student)
        {
            student.EnrollInCourse(this);
        }

        public void AssignGrade(Student student, int grade)
        {
            Grades[student] = grade;
        }

        public int GetGrade(Student student)
        {
            if (Grades.ContainsKey(student))
            {
                return Grades[student];
            }
            else
            {
                // If student not found, return -1 or handle the case as needed
                return -1;
            }
        }

        public int GetEnrollmentCount()
        {
            return Grades.Count;
        }

        public double CalculateAverageGrade()
        {
            if (Grades.Count == 0)
            {
                return 0;
            }

            int totalGrade = 0;
            foreach (var grade in Grades.Values)
            {
                totalGrade += grade;
            }

            return (double)totalGrade / Grades.Count;
        }
    }
}
