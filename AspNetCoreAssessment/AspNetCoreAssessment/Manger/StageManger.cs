using AspNetCoreAssessment.Entities;
using AspNetCoreAssessment.Models;
using AspNetCoreAssessment.Reposatory;
using AutoMapper;

namespace AspNetCoreAssessment.Manger
{
    public class StageManger
    {
        private  readonly BaseRepo<Stage> StageRepo;
        private readonly IMapper mapper;

        public StageManger(AspnetcoreassessmentContext context,IMapper mapper)
        {
            StageRepo = new BaseRepo<Stage>(context);
            this.mapper = mapper;
        }
        public StageVM GetStudentStage(int stageId)
        {
            var data= StageRepo.Get(stageId);
            return mapper.Map<StageVM>(data);

        }
        public List<StageVM> GetStages()
        {
            var Stages = StageRepo.GetAll().ToList();
            return mapper.Map<List<StageVM>>(Stages);
        }
    }
}
