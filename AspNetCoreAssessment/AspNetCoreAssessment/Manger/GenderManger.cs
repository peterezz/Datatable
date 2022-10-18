using AspNetCoreAssessment.Entities;
using AspNetCoreAssessment.Reposatory;

namespace AspNetCoreAssessment.Manger
{
    public class GenderManger
    {
        private static BaseRepo<Gender> GenderRepo;
        public GenderManger(AspnetcoreassessmentContext context)
        {
            GenderRepo = new BaseRepo<Gender>(context);

        }
        public static Gender GetStudentGender(int GenderId)
        {
            return GenderRepo.Get(GenderId);
        }
    }
}
