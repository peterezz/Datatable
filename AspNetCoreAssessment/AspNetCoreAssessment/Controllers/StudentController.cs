using AspNetCoreAssessment.Manger;
using AspNetCoreAssessment.Models;
using Microsoft.AspNetCore.Mvc;

namespace AspNetCoreAssessment.Controllers
{
    public class StudentController : Controller    
    {
        private readonly StudentManger studentManger;


        public StudentController(StudentManger studentManger)
        {
            this.studentManger = studentManger;
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



    }
}
