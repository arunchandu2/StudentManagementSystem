using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagementSystem
{
    class MainClass
    {
        public static void Main()
        {
         
            IAppEngine desc = new ScreenDescription();
		    do
		    {
            		desc.showFirstScreen();
		    }while(true);
     
        }
    }
}
