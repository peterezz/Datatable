using AspNetCoreAssessment.Manger;
using AspNetCoreAssessment.Models;
using Microsoft.AspNetCore.Mvc;

namespace AspNetCoreAssessment.Controllers
{
    public class StudentController : Controller    
    {
        private readonly StudentManger studentManger;
        private readonly StageManger stageManger;
        private readonly GenderManger genderManger;

        public StudentController(StudentManger studentManger,StageManger stageManger,GenderManger genderManger)
        {
            this.studentManger = studentManger;
            this.stageManger = stageManger;
            this.genderManger = genderManger;
        }
        [HttpGet]
        public IActionResult Index()
        {
           // var data = studentManger.SearchStudent(""); 
            return View();
        }
        [HttpGet]
        public IActionResult datatable_clientstide()
        {
           ViewBag.Students = studentManger.SearchStudent("All"); 
            return View(ViewBag.Students);
        }
        [HttpGet]
        public IActionResult RegisterStudent()
        {
            ViewBag.Gender = genderManger.GetGenders();
            ViewBag.Stage = stageManger.GetStages();
            return View();
        }



      


    }
}
