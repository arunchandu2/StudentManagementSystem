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
    internal class InAppMemoryEngine
    {
        public SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ename"].ConnectionString);

        public List<Student> studentlist = new List<Student>();
        public List<Course> courselist = new List<Course>();
        //public List<Course> courselist1 = new List<Course>();
        public List<Enroll> enrolllist = new List<Enroll>();
        static int count = 0;

        #region Student Details
        public void register(Student student)
        {
            con.Open();

            if (student.Id != " " && student.Name != " " && student.Date != null)
            {

                SqlCommand cmd = new SqlCommand("insertStudent", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id", student.Id);
                cmd.Parameters.AddWithValue("@name", student.Name);
                cmd.Parameters.AddWithValue("@date", student.Date);

                if (con.State == ConnectionState.Open)
                    con.Close();
                con.Open();
                try
                {
                    if (cmd.ExecuteNonQuery() > 0)
                    {
                        studentlist.Add(student);
                        Console.WriteLine($"Student name {student.Name} added successfully");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                finally
                {
                    con.Close();
                }
            }

        }

        public List<Student> Getstudentlist()
        {
            if (con.State == ConnectionState.Open)
                con.Close();
            con.Open();
            SqlCommand cmd = new SqlCommand("Select * from Student", con);
            SqlDataReader dr = cmd.ExecuteReader();
            studentlist.Clear();
            try
            {
                while (dr.Read())
                {
                    Student s = new Student((string)dr[0], (string)dr[1], (string)dr[2]);
                    studentlist.Add(s);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                con.Close();
            }

            if (studentlist.Count != 0)
            {
                return studentlist;
            }
            else
            {
                return null;
            }





        }

        #endregion


        #region  Course Details
        public void introduce(Course course)
        {
            if (course.Courseid != " " && course.Coursename != " " && course.Duration != 0 && course.Fee != 0)
            {
                SqlCommand cmd = new SqlCommand("insertCourse", con);

                if (course.GetType() == typeof(Degreecourse))
                {
                    Degreecourse d = (Degreecourse)course;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Did", d.Courseid);
                    cmd.Parameters.AddWithValue("@Dname", d.Coursename);
                    cmd.Parameters.AddWithValue("@Dduration", d.Duration);
                    cmd.Parameters.AddWithValue("@Course", "Degree");
                    cmd.Parameters.AddWithValue("@Dlevel", d.level);
                    cmd.Parameters.AddWithValue("@Dfees", d.Fee);
                    cmd.Parameters.AddWithValue("@DisPlacement", d.plac);
                    cmd.Parameters.AddWithValue("@Dtype", "Null");
                }
                else if (course.GetType() == typeof(Diplomacourse))
                {
                    Diplomacourse d1 = (Diplomacourse)course;

                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Did", d1.Courseid);
                    cmd.Parameters.AddWithValue("@Dname", d1.Coursename);
                    cmd.Parameters.AddWithValue("@Dduration", d1.Duration);
                    cmd.Parameters.AddWithValue("@Course", "Diploma");
                    cmd.Parameters.AddWithValue("@Dlevel", "Null");
                    cmd.Parameters.AddWithValue("@Dfees", d1.Fee);
                    cmd.Parameters.AddWithValue("@DisPlacement", 0);
                    cmd.Parameters.AddWithValue("@Dtype", d1.dtype);
                }
                else
                {
                    Console.WriteLine("Invalid Courses name ");
                }

                if (con.State == ConnectionState.Open)
                    con.Close();
                con.Open();
                try
                {
                    if (cmd.ExecuteNonQuery() > 0)
                    {
                        courselist.Add(course);
                        Console.WriteLine($"Course {course.Coursename} is added successfully");
                    }
                }
                catch (SqlException ex)
                {
                    Console.WriteLine(ex.Message);
                }
                finally { con.Close(); }

            }
            else
            {
                throw new Exception("Please enter all the details of the course");
            }


        }

        public List<Course> GetcourselistCourses()
        {
            if (con.State == ConnectionState.Open)
                con.Close();
            con.Open();
            Console.WriteLine("Asking");
            string a = Console.ReadLine();
            if (a == "degree")
            {
                SqlCommand cmd1 = new SqlCommand("Select * from Course1 where Course = 'Degree'", con);
                SqlDataReader dr = cmd1.ExecuteReader();
                courselist.Clear();
                try
                {
                    while (dr.Read())
                    {
                        Course c1 = new Degreecourse((string)dr[0], (string)dr[1], Int32.Parse(dr[2].ToString()), double.Parse(dr[5].ToString()), bool.Parse(dr[6].ToString()), (string)dr[4]);


                        courselist.Add(c1);

                        //   courseList.Add(c1);
                    }
                }
                catch (SqlException ex)
                {
                    Console.WriteLine(ex.Message);
                }
                finally { con.Close(); }
            }

            else if (a == "diploma")
            {
                SqlCommand cmd1 = new SqlCommand("Select * from Course1 where Course = 'Diploma'", con);
                SqlDataReader dr = cmd1.ExecuteReader();
                courselist.Clear();

                try
                {
                    while (dr.Read())
                    {

                        // Course c = new DegreeCourse(Int32.Parse(dr[0].ToString()), (string)dr[1], Int32.Parse(dr[2].ToString()), double.Parse(dr[5].ToString()), (string)dr[4],
                        //   bool.Parse(dr[6].ToString()));
                        Course c1 = new Diplomacourse(dr[0].ToString(), (string)dr[1], Int32.Parse(dr[2].ToString()), double.Parse(dr[5].ToString()),
                            (string)dr[7]);

                        courselist.Add(c1);
                        //   courseList.Add(c1);
                    }
                }
                catch (SqlException ex)
                {
                    Console.WriteLine(ex.Message);
                }
                finally { con.Close(); }

            }

            if (courselist.Count != 0)
                return courselist;
            else
                return null;

        }

        #endregion


        #region Enrollment Details

        public void enroll(Student student, Course course, DateTime endate)
        {
            //enrolllist.Add(new Enroll(student, course, endate));

            Enroll e = new Enroll(student, course, endate);
            con.Open();

            SqlCommand cmd = new SqlCommand("insertEnroll", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@sid", SqlDbType.NVarChar).Value = e.Student.Id;
            cmd.Parameters.AddWithValue("@cid", SqlDbType.NVarChar).Value = e.Course.Courseid;
            cmd.Parameters.AddWithValue("@enrollmentdate", SqlDbType.Date).Value = e.Endate;

            if (con.State == ConnectionState.Open)
                con.Close();
            con.Open();
            try
            {
                if (cmd.ExecuteNonQuery() > 0)
                {
                    Console.WriteLine("Successfully inserted");

                }

            }
            catch (SqlException e1)
            {
                Console.WriteLine(e1.Message);
            }
            catch (Exception e1)
            {
                Console.WriteLine(e1.Message);
            }
            finally
            {
                con.Close();
            }

            //foreach (Enroll en in e.listOfEnrollments())
            //{
            //    if (en.Student.Id == student.Id && en.Course.Id == course.Id)
            //        throw new NoRepeatEnrollmentException("you have already registered for the course");
            //}

            //foreach (Enroll en in e.GetlistEnrollments())
            //{
            //    if (en.Student.Id == student.Id)
            //        count++;
            //}
            //if (count > 4)
            //    Console.WriteLine("You had exceeded maximum number of registrations");
            enrolllist.Add(e);
        }




        public List<Enroll> GetlistEnrollments()
        {
            if (con.State == ConnectionState.Open)
                con.Close();
            con.Open();
            SqlCommand cmd = new SqlCommand("Select * from enrollcourse", con);
            SqlDataReader dr = cmd.ExecuteReader();
            enrolllist.Clear();
            try
            {
                while (dr.Read())
                {
                    Enroll e1 = new Enroll();
                    Student s1 = new Student();
                    string sid = (string)dr["sid"];
                    string cid = (string)dr["cid"];
                    e1.Endate = (DateTime)dr["enrolldate"];
                    e1.Student = getStudentByid(sid);
                    e1.Course = getCourseByid(cid);
                    int index = enrolllist.FindIndex(e => e.Student.Id == sid && e.Course.Courseid == cid);
                    if (index < 0)
                        enrolllist.Add(e1);
                    //enrolllist.Add(s);


                    //Console.WriteLine(sid + cid);
                    //enrolllist.Add(s);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                con.Close();
            }

            if (enrolllist.Count != 0)
            {
                return enrolllist;
            }
            else
            {
                return null;
            }






            //return enrolllist;
        }

        #endregion


        public Student getStudentByid(string id)
        {
            foreach (Student s in studentlist)
            {
                if (s.Id == id)
                    return s;
            }
            throw new Exception("student id not found");
        }
        public Course getCourseByid(string id)
        {
            foreach (Course c in courselist)
            {
                if (c.Courseid == id)
                    return c;
            }
            throw new Exception("course id not found");
        }


    }
}







 
