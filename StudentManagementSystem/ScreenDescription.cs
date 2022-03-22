using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagementSystem
{
    public class ScreenDescription : IAppEngine
    {
        //Enroll obj = new Enroll();
        Course an = new Diplomacourse();
        Course an1 = new Degreecourse();
        Info obj2 = new Info();
        InAppMemoryEngine obj = new InAppMemoryEngine();


        public void showAdminScreen()
        {
            Console.WriteLine("Welcome to  admin screen");
            Console.WriteLine("1.ADD Course \n2.List of students \n3.List of Enrollements \n4.List of courses");
            Console.WriteLine("Enter Your choice:");
            int showAdmin = int.Parse(Console.ReadLine());
            switch(showAdmin)
            {
                case 1:
                    introduceNewCourseScreen();
                    break;
                case 2:
                    showAllStudentsScreen();
                    break;
                case 3:
                    showAllEnrollments();
                    break;
                case 4:
                    showAllCoursesScreen();
                    break;





            }

        }

        public void showStudentScreen()
        {
            Console.WriteLine("You are in student screen");
            Console.WriteLine("1.Register  \n2.Show all Student Enrollments \n3.Show all student Details \n 4.Enroll for  a course");
            Console.WriteLine("Enter Your choice:");
            //Console.WriteLine();
            int stusc = Convert.ToInt32(Console.ReadLine());
            switch (stusc)
            {
                case 1:
                    showRegistrationScreen();
                    break;
                case 2:
                    showAllEnrollments();
                    break;
                case 3:
                    showAllStudentsScreen();
                    break;
               case 4:
                    showEnrollementScreen();
                    break;





            }
        }

        public void showAllStudentsScreen()
        {
            Console.WriteLine("You are in all students screen");
            //obj.Getstudentlist();
            foreach (Student i in obj.Getstudentlist())
            {
                obj2.display(i);
            }



        }
        public void showRegistrationScreen()
        {
            Console.WriteLine("You are in student registration screen");
            Console.WriteLine("Enter student id:");
            string id = Console.ReadLine();
            Console.WriteLine("Enter Student name:");
            string name = Console.ReadLine();
            Console.WriteLine("Enter Date of birth");
            string date = Console.ReadLine();
            obj.register(new Student(id, name, date));
            






        }

        public void showAllCoursesScreen()
        {
            Console.WriteLine("You are in all courses screen");

            foreach (Course j in obj.GetcourselistCourses())
            {
                obj2.display(j);

            }
        }

        public void introduceNewCourseScreen()
        {
            Console.WriteLine("You are in introduce new course screen");
            Console.WriteLine("1.Degree\n2.Diploma");
            int ch = int.Parse(Console.ReadLine());
           // an.calculateMonthlyfee();
            Console.WriteLine("Enter course id");
            string courseid = Console.ReadLine();
            Console.WriteLine("Enter course name");
            string coursename = Console.ReadLine();
            Console.WriteLine("Enter course duration");
            int duration = int.Parse(Console.ReadLine());
          
            
            Console.WriteLine("Enter course Fee");
            //double fee = int.Parse(Console.ReadLine());

          
            double fee = double.Parse(Console.ReadLine());
            if (ch == 1)
            {
                Console.WriteLine("Enter Course level(Bachelor/Master)");
                string level = Console.ReadLine();
                Console.WriteLine("Placement available(True/False)");
                bool plac = Convert.ToBoolean(Console.ReadLine());
                obj.introduce(new Degreecourse(courseid, coursename, duration, fee, plac,level));
            }
            else
            {
                Console.WriteLine("Enter type(Professional/Academic)");
                string dtype = Console.ReadLine();
                obj.introduce(new Diplomacourse(courseid, coursename, duration, fee, dtype));


                
            }
            //an.calculateMonthlyfee();


        }
        public void showEnrollementScreen()
        {
            Student std1 = new Student();
            Console.WriteLine("You are in course enrollement screen");
          
            Console.WriteLine("Enter student id:");
            string id1 = Console.ReadLine();
            bool found = false;
            foreach (Student s in obj.studentlist)
            {
                if (id1 == s.Id)
                {
                    std1.Id = s.Id;
                    std1.Name = s.Name;
                    std1.Date = s.Date;
                    found = true;
                    break;
                }
            }
                if(!found)
               {
                    Console.WriteLine("No student found enter details again");
                    showFirstScreen();

                }
            Console.WriteLine("select type of course 1.degree\n2.diploma");
            int ts1 = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter Course ID");
            string cs1 = Console.ReadLine();
            DateTime endate = DateTime.Now;
            Course cor1 = new Degreecourse();
            Course cor2 = new Diplomacourse();
            foreach (Course c in obj.courselist)
            {
                if (cs1 == c.Courseid)
                {
                    if (c.GetType() == typeof(Degreecourse))
                    {
                        cor1.Courseid = c.Courseid;
                        cor1.Coursename = c.Coursename;
                        cor1.Duration = c.Duration;
                        cor1.Fee = cor1.Fee;
                    }
                    else
                    {
                        cor1.Courseid = c.Courseid;
                        cor1.Coursename = c.Coursename;
                        cor1.Duration = c.Duration;
                        cor1.Fee = cor1.Fee;

                    }
                }

            }
            obj.enroll(std1, cor1, endate);




        }


        public void showFirstScreen()
        {
            
            Console.WriteLine("Welcome to SMS(Student Mgmt. System) v1.0");
            Console.WriteLine("Tell us who you are : \n1. Student\n2. Admin");
            Console.WriteLine("Enter your choice ( 1 or 2 ) : ");

            int op = Convert.ToInt32(Console.ReadLine());
            switch (op)
            {
                case 1:
                    showStudentScreen();
                    break;
                case 2:
                    showAdminScreen();
                    break;
                default:
                    Console.WriteLine("You had choosen incorrect choice");
                    showFirstScreen();
                    break;
            }
        }
        public void showAllEnrollments()

        {
            List<Enroll> e = new List<Enroll>();
            e = obj.GetlistEnrollments();

            //if (e.Count() != 0)
            //{
             

                foreach (Enroll enr in e)
                {
                    obj2.display(enr);
                }
            //}
            //else
            //{
            //    System.Console.WriteLine("no enrollments found. please add records");
            //}



        }
    
    }
}
