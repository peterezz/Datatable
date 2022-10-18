using AspNetCoreAssessment.Entities;
using AspNetCoreAssessment.Models;
using AspNetCoreAssessment.Reposatory;
using AutoMapper;
using Korzh.EasyQuery.Linq;
using Microsoft.Extensions.Primitives;

namespace AspNetCoreAssessment.Manger
{
    public class StudentManger
    {
        private readonly IMapper mapper;
        private readonly BaseRepo<Student> StudentRepo;

        public StudentManger(AspnetcoreassessmentContext context,IMapper mapper)
        {
            StudentRepo = new BaseRepo<Student>(context);
            
            this.mapper = mapper;
        }
        public List<StudentVM> SearchStudent(string SearchVal)
        {
            if(string.IsNullOrEmpty(SearchVal) || SearchVal.Equals("All"))
            {
             
                var Allstudents = mapper.Map<List<StudentVM>>(StudentRepo.GetMany(null,student=> student.GenderNavigation, student=> student.StageNavigation).ToList());
                return Allstudents;

            }
            var Filteredstudents = StudentRepo.GetMany(student => student.FirstName.Contains(SearchVal) ||
            student.LastName.Contains(SearchVal) ||
            student.Ssn.Contains(SearchVal) ||
            student.PhoneNumber.Contains(SearchVal) ||
            student.Birthday.ToString().Contains(SearchVal) ||
            student.EmailAddress.ToString().Contains(SearchVal)||
            student.Address.Contains(SearchVal) 
            
            ).ToList();
            return mapper.Map<List<StudentVM>>(Filteredstudents);
        }

    }
}
