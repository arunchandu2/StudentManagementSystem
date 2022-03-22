using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagementSystem
{
    class Info
    {
        public void display(Student s)
        {
            Console.WriteLine($"{s.Id} \t {s.Name}\t{s.Date}");
        }

        public void display(Course c)
        {
            if (c.GetType() == typeof(Degreecourse))
            {
                Degreecourse d = (Degreecourse)c;
                Console.WriteLine($"ID: {d.Courseid} \tName: {d.Coursename} \tDuration: {d.Duration} \tFees:  {d.Fee} \tmonthlyfee: {d.calculateMonthlyfee()} ");
            }
            else
            {
                Diplomacourse diploma = (Diplomacourse)c;
                Console.WriteLine($"ID: {diploma.Courseid} \tName: {diploma.Coursename} \tDuration: {diploma.Duration} \t  " +
                    $"Fees: {diploma.Fee} \tmonthlyfee:{diploma.calculateMonthlyfee()}  ");
            }
        }

        public void display(Enroll e)
        { 
       
            Console.WriteLine(e.Student.Id + "\t" + e.Student.Name + "\t" + e.Course.Courseid + e.Course.Coursename + "\t" + e.Endate);
        }
        
    }
}
