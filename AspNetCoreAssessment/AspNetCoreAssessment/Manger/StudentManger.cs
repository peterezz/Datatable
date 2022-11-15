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
        private readonly StageManger stageManger;
        private readonly GenderManger genderManger;
        private readonly BaseRepo<Student> StudentRepo;

        public StudentManger(AspnetcoreassessmentContext context,IMapper mapper,StageManger stageManger,GenderManger genderManger)
        {
            StudentRepo = new BaseRepo<Student>(context);
            
            this.mapper = mapper;
            this.stageManger = stageManger;
            this.genderManger = genderManger;
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
        public void AddStudent(StudentVM studentVM)
        {

            studentVM.Photo = FileManger.UploadPhoto(studentVM.PhotoFile[0], "/wwwroot/UsersPhotos/Students/", 150, 150);
            studentVM.StageNavigation = stageManger.GetStudentStage(studentVM.Stage);
            studentVM.GenderNavigation = genderManger.GetStudentGender(studentVM.Gender);
            var student = mapper.Map<Student>(studentVM);
            StudentRepo.Add(student);
        }
        public void DeleteStudent(int studentId)
        {
            var student = SearchStudentById(studentId);
            FileManger.DeleteFile(student.PhotoPath);
            StudentRepo.Delete(studentId);
        }
        public StudentVM SearchStudentById(int Id)
        {
            var student = StudentRepo.Get(Id);  
            return mapper.Map<StudentVM>(student);
        }
        public StudentVM SearchStudentBySsn(string Ssn)
        {
            var student = StudentRepo.GetOne(student=>student.Ssn.Equals(Ssn));
            var studentVM = mapper.Map<StudentVM>(student);
            studentVM.StageNavigation = stageManger.GetStudentStage(studentVM.Stage);
            studentVM.GenderNavigation = genderManger.GetStudentGender(studentVM.Gender);
            return studentVM;

        }
      
    }
}
