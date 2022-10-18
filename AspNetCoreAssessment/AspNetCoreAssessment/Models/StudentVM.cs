using AspNetCoreAssessment.Entities;
using AspNetCoreAssessment.Manger;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace AspNetCoreAssessment.Models
{
    public class StudentVM
    {
        public int Id { get; set; }
        public string? Ssn { get; set; }
        public string? Photo { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public int Gender { get; set; }
        public string? PhoneNumber { get; set; }
        public DateTime Birthday { get; set; }
        public int Stage { get; set; }
        public string? EmailAddress { get; set; }
        public string? Address { get; set; }

        [NotMapped]
        public string? StageName { get { return StageNavigation.Name; } }
        public  StageVM? StageNavigation { get; set; }
        [NotMapped]
        public string? GenderName { get { return GenderNavigation.Name; } }
        public  GenderVM? GenderNavigation { get; set; }

    }
}
