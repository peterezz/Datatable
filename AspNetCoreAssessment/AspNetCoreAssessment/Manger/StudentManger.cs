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
        public List<StudentVM> SearchStudent(string searchValue)
        {
            if(string.IsNullOrEmpty(searchValue) || searchValue.Equals("All"))
            {
             
                var Allstudents = mapper.Map<List<StudentVM>>(StudentRepo.GetMany(null,student=> student.GenderNavigation, student=> student.StageNavigation).ToList());
                return Allstudents;

            }
            var Filteredstudents = StudentRepo.GetAll().FullTextSearchQuery(searchValue).ToList();
            return mapper.Map<List<StudentVM>>(Filteredstudents);
        }
    }
}
