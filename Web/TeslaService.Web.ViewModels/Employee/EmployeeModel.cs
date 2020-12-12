namespace TeslaService.Web.ViewModels.Employee
{
    using System.ComponentModel.DataAnnotations;

    public class EmployeeModel
    {
        public int Id { get; set; }

        [Required]
        [MinLength(2)]
        [MaxLength(30)]
        public string FirstName { get; set; }

        [Required]
        [MinLength(2)]
        [MaxLength(30)]
        public string LastName { get; set; }

        [Required]
        [MinLength(2)]
        [MaxLength(30)]
        public string Position { get; set; }

        [Required]
        public string ImageURL { get; set; }

        [Required]
        public string DateOfJoin { get; set; }

        public int ServiceId { get; set; }
    }
}
