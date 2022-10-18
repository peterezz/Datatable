using AspNetCoreAssessment.Entities;
using AspNetCoreAssessment.Reposatory;

namespace AspNetCoreAssessment.Manger
{
    public class StageManger
    {
        private  static BaseRepo<Stage>? StageRepo;
        public StageManger(AspnetcoreassessmentContext context)
        {
            StageRepo = new BaseRepo<Stage>(context);
        }
        public static Stage GetStudentStage(int stageId)
        {
            return StageRepo.Get(stageId);
        }
    }
}
