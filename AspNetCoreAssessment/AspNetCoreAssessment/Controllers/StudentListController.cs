using AspNetCoreAssessment.Manger;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq.Dynamic.Core;

namespace AspNetCoreAssessment.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentListController : ControllerBase
    {
        private readonly StudentManger studentManger;

        public StudentListController(StudentManger studentManger)
        {
            this.studentManger = studentManger;
        }
        [HttpPost]
        public IActionResult ListStudents()
        {
            var pageSize = int.Parse(Request.Form["length"]);
            var skip = int.Parse(Request.Form["start"]);

            var searchValue = Request.Form["search[value]"];

            var sortColumn = Request.Form[string.Concat("columns[", Request.Form["order[0][column]"], "][name]")];
            var sortColumnDirection = Request.Form["order[0][dir]"];

            var data = studentManger.SearchStudent(searchValue).AsQueryable();

            if (!(string.IsNullOrEmpty(sortColumn) && string.IsNullOrEmpty(sortColumnDirection)))
                data = data.OrderBy(string.Concat(sortColumn, " ", sortColumnDirection));

            var ProccessedData = data.Skip(skip).Take(pageSize).ToList();

            var recordsTotal = data.Count();

            var jsonData = new { recordsFiltered = recordsTotal, recordsTotal, ProccessedData };

            return Ok(jsonData);
        }
    }
}
