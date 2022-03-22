using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;

namespace StudentManagementSystem
{
    internal class Enroll
    {



        Student student;
        Course course;
        DateTime endate;



        public Student Student { get => student; set => student = value; }
        public Course Course { get => course; set => course = value; }
        public DateTime Endate { get => endate; set => endate = value; }

        public Enroll()
        {
        }

        public Enroll(Student student, Course course, DateTime endate)
        {
            this.Student = student;
            this.Course = course;
            this.Endate = endate;

        }


    }
}
