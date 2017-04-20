using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KeyRegister.DAO
{
   public  class Designations
   {
       private int designationId;
       private  string designation;
       private int departmentId;

       public int DesignationId
       {
           get { return designationId; }
           set { designationId = value; }
       }

       public string Designation
       {
           get { return designation; }
           set { designation = value; }
       }

       public int DepartmentId
       {
           get { return departmentId; }
           set { departmentId = value; }
       }
   }
}
