
using System.ComponentModel.DataAnnotations;

namespace MyFirstWebApi.Model
{
    public class Employee
    {
        public int Id { get; set; }

       
     
        public string Name { get; set; }

        public string Department { get; set; }
   
        public double Salary { get; set; }  
    }
}
