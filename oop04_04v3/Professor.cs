using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace oop04_04v3
{
    internal class Professor
    {
        public string Name { get; set; }
        public Course Course { get; set; }

        public Professor(string name, Course course)
        {
            Name = name;
            Course = course;
        }
    }
}
