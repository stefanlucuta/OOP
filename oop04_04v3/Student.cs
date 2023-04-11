using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace oop04_04v3
{
    internal class Student
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public List<Course> Courses { get; set; } = new List<Course>();

        public Student(string name, int age)
        {
            Name = name;
            Age = age;
        }

        public void EnrollInCourse(Course course)
        {
            Courses.Add(course);
        }

        public void AssignGrade(Course course, int grade)
        {
            course.AssignGrade(this, grade);
        }

        public List<Course> GetCoursesWithFailingGrade()
        {
            List<Course> coursesWithFailingGrade = new List<Course>();
            foreach (var course in Courses)
            {
                int grade = course.GetGrade(this);
                if (grade < 5)
                {
                    coursesWithFailingGrade.Add(course);
                }
            }
            return coursesWithFailingGrade;
        }
    }

}
