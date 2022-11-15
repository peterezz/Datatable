using AspNetCoreAssessment.Entities;
using AspNetCoreAssessment.Models;
using AspNetCoreAssessment.Reposatory;
using AutoMapper;

namespace AspNetCoreAssessment.Manger
{
    public class GenderManger
    {
        private readonly BaseRepo<Gender> GenderRepo;
        private readonly IMapper mapper;

        public GenderManger(AspnetcoreassessmentContext context,IMapper mapper)
        {
            GenderRepo = new BaseRepo<Gender>(context);
            this.mapper = mapper;
        }
        public GenderVM GetStudentGender(int GenderId)
        {
            var data= GenderRepo.Get(GenderId);
            return mapper.Map<GenderVM>(data);  
        }
        public List<GenderVM> GetGenders()
        {
            var Genders = GenderRepo.GetAll().ToList();
            return mapper.Map<List<GenderVM>>(Genders);
        }
    }
}
