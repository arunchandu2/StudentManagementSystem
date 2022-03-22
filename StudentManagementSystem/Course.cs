using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagementSystem
{
    public abstract class Course
    {
        string courseid;
        string coursename;
        int duration;
        double fee;
      

        public Course()
        {
        }

        public Course(string courseid, string coursename, int duration, double fee)
        {
            this.Courseid = courseid;
            this.Coursename = coursename;
            this.Duration = duration;
            this.Fee = fee;
           
        }

     

        public string Courseid { get => courseid; set => courseid = value; }
        public string Coursename { get => coursename; set => coursename = value; }
        public int Duration { get => duration; set => duration = value; }
        public double Fee { get => fee; set => fee = value; }
    

        public abstract double calculateMonthlyfee();
        

        
    }
    
    
    public class Degreecourse:Course 
    {
        public bool plac { get; set; }
        public string level { get; set; }
        public Degreecourse(string courseid,string coursename,int duration,double fee,bool plac,string level) : base(courseid,coursename,duration,fee) 
        {
            this.plac = plac;
            this.level = level;
        }

        //public bool plac { get; set; }
        public Degreecourse()
        {
        }
        /*
        public enum Level
        {
            batchelor,master
        }
        */
        public override double calculateMonthlyfee()
        {
            if (plac == true)
            {

                return (Fee * 0.1);
                 
                //Console.WriteLine(Fee1);
            }
            else
            {
                return Fee;
            }
            
           
            
        }


    }
    public class Diplomacourse : Course
    {
        //Diplomacourse obj3 = new Diplomacourse();
        //obj3.calculateMonthlyfee();

        //public enum Type
        //{
        //    professional,
        //    academic,
        //};
        //public Type type;
        public string dtype { get; set; }
        public Diplomacourse(string courseid, string coursename, int duration, double fee, string dtype) : base(courseid, coursename, duration, fee)
        {
            //type = (Type)Enum.Parse(typeof(Type), dtype);
            this.dtype = dtype;

        }
     
        public Diplomacourse()
        {
            
        }

       

        public override double calculateMonthlyfee()
        {
            if (dtype == "professional")
            {
              
                return Fee + ((0.1 * Fee));
            }
            else if (dtype =="academic")
                return Fee + ((0.5 * Fee));
            else
                return Fee;


        }
    
    

    }
 
  

}
