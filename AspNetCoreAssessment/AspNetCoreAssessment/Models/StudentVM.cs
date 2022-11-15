using AspNetCoreAssessment.Entities;
using AspNetCoreAssessment.Manger;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace AspNetCoreAssessment.Models
{
    public class StudentVM
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Ssn field is requred")]
        [Display(Name ="Ssn")]
        public string? Ssn { get; set; }


        [Required(ErrorMessage = "First Name field is requred")]
        [Display(Name = "First Name")]
        public string? FirstName { get; set; }
        [Required(ErrorMessage = "Last Name field is requred")]
        [Display(Name = "Last Name")]
        public string? LastName { get; set; }
        [Required(ErrorMessage = "Gender field is requred")]
        [Display(Name = "Gender")]
        public int Gender { get; set; }
        [Required(ErrorMessage = "Phone Number field is requred")]
        [Display(Name = "PhoneNumber")]
        public string? PhoneNumber { get; set; }
        [Required(ErrorMessage = "Birthday field is requred")]
        [Display(Name = "Birthday")]
        public DateTime Birthday { get; set; }
        [Required(ErrorMessage = "Stage field is requred")]
        [Display(Name = "Stage")]
        public int Stage { get; set; }
        [Required(ErrorMessage = "Emailaddress field is requred")]
        [Display(Name = "Email Address")]
        public string? EmailAddress { get; set; }
        [Required(ErrorMessage = "Address field is requred")]
        [Display(Name = "Address")]
        public string? Address { get; set; }
        public StageVM? StageNavigation { get; set; }

        public GenderVM? GenderNavigation { get; set; }



        //Photo
        public string? Photo { get; set; }
        [Display(Name = "Student photo")]
        [Required(ErrorMessage ="Photo is required")]
        public List<IFormFile> PhotoFile { get; set; }
        public string PhotoPath { get { return "/UsersPhotos/Students/" + Photo; } }

    }
}
