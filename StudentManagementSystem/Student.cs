using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagementSystem
{
    class Student

    {
        string id;
        string name;
        string date;
        public Student()
        {
        }

        public Student(string id, string name, string date)
        {
            this.Id = id;
            this.Name = name;
            this.Date = date;
        }

        public string Id { get => id; set => id = value; }
        public string Name { get => name; set => name = value; }
        public string Date { get => date; set => date = value; }
        //public override string ToString()
        //{
        //    return  this.id + " " + this.name + " " + this.date;
        //}
    }
}
