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
        public List<StudentVM> SearchStudent(StringValues SearchVal)
        {
            if(string.IsNullOrEmpty(SearchVal) || SearchVal.Equals("All"))
            {
             
                var Allstudents = mapper.Map<List<StudentVM>>(StudentRepo.GetMany(null,student=> student.GenderNavigation, student=> student.StageNavigation).ToList());
                return Allstudents;

            }
            string searchValue = SearchVal.ToString();
            var Filteredstudents = StudentRepo.GetMany(student => student.FirstName.Contains(searchValue) ||
            student.LastName.Contains(searchValue)||
            student.EmailAddress.Contains(searchValue)||
            student.Address.Contains(searchValue) ||
            student.PhoneNumber.Contains(searchValue) ||
            student.Birthday.ToString().Contains(searchValue) ||
            student.StageNavigation.Name.Contains(searchValue) ||
            student.Ssn.Contains(searchValue) ,
            student => student.GenderNavigation, 
            student => student.StageNavigation

            ).ToList();
            return mapper.Map<List<StudentVM>>(Filteredstudents);
        }

    }
}
