using System.ComponentModel.DataAnnotations;

namespace MyFirstWebApi.Model
{
    public class EmployeeDTO
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Name field is required")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Name should be  3 to 50 characters only")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Department is required")]
        public string Department { get; set; }
    }
}
