using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace oop04_04v3
{   // avem studenti inrolati la cursuri. avem profesori care tin cursurile la care sunt inscrisi studentii.
    // studentii primesc note iar sistemul nostru tre sa raspunda la cateva intrebari
    // 1. care sunt studentii inrolati la un anumit curs;
    // 2. Care e media notelor unui student la toate cursurile la care e inrolat && se calculeaza doar daca are toate notele >= 5;
    // 3. Care sunt cursurile nepromovate de catre un student;
    // Cap Ierarhii; Ordonam studentii descrescator dupa medii;
    // 4. Ordonam Studentii dupa nume alfabetic;
    // 5. Ordonam cursurile dupa nr de studenti inrolati;
    // CLASE : STUDENT, PROFESOR, CURS, nota?, SISTEM;
    // Repo pattern; mapeaza info;
    class Program
    {
        static void Main(string[] args)
        {
            // Create students
            Student student1 = new Student("John Doe", 20);
            Student student2 = new Student("Jane Smith", 22);
            Student student3 = new Student("Alice Johnson", 21);

            // Create professor
            Professor professor1 = new Professor("Dr. Smith", new Course("Matematici Speciale", 3));
            Professor professor2 = new Professor("Dr. Brown", new Course("OOP", 4));

            // Enroll students in courses
            Course mathCourse = new Course("Matematici Speciale", 3);
            Course historyCourse = new Course("OOP", 4);
            student1.EnrollInCourse(mathCourse);
            student2.EnrollInCourse(mathCourse);
            student3.EnrollInCourse(historyCourse);

            // Assign grades to students
            student1.AssignGrade(mathCourse, 8);
            student2.AssignGrade(mathCourse, 7);
            student3.AssignGrade(historyCourse, 6);

            // Get courses with failing grades for each student
            Console.WriteLine("Courses with failing grades for each student:");
            Console.WriteLine("=============================================");
            Console.WriteLine();

            List<Student> students = new List<Student> { student1, student2, student3 };
            foreach (var student in students)
            {
                List<Course> coursesWithFailingGrade = student.GetCoursesWithFailingGrade();
                Console.WriteLine($"{student.Name}:");
                foreach (var course in coursesWithFailingGrade)
                {
                    Console.WriteLine($"- {course.Name}");
                }
                Console.WriteLine();
            }

            // Sort students by grades descending
            Console.WriteLine("Students sorted by grades descending:");
            Console.WriteLine("====================================");
            Console.WriteLine();

            var sortedStudentsByGradesDescending = students.OrderByDescending(student => student.Courses.Sum(course => course.GetGrade(student)));
            foreach (var student in sortedStudentsByGradesDescending)
            {
                Console.WriteLine($"{student.Name}: Total Grade = {student.Courses.Sum(course => course.GetGrade(student))}");
            }

            // Sort courses by enrollment count ascending
            Console.WriteLine();
            Console.WriteLine("Courses sorted by enrollment count ascending:");
            Console.WriteLine("=============================================");
            Console.WriteLine();

            var sortedCoursesByEnrollmentCountAscending = professor1.Course.GetEnrollmentCount() < professor2.Course.GetEnrollmentCount() ?
                                                          new List<Course> { professor1.Course, professor2.Course } :
                                                          new List<Course> { professor2.Course, professor1.Course };

            foreach (var course in sortedCoursesByEnrollmentCountAscending)
            {
                Console.WriteLine($"{course.Name}: Enrollment Count = {course.GetEnrollmentCount()}");
            }

            // Calculate average grade for a course
            Console.WriteLine();
            Console.WriteLine($"Average grade for {mathCourse.Name}: {mathCourse.CalculateAverageGrade()}");

            Console.ReadLine();
        }
    }
}
