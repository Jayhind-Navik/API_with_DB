using API_with_DB.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API_with_DB.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly StudentDbContext dbContext;

        public StudentController(StudentDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        [HttpGet]
        public IActionResult GetAllStudent()
        {
           var std= dbContext.Students.ToList();
            if (std==null)
            {
                return NotFound();
            }
            return Ok(std);
        }
        [HttpGet("{RollNo}")]
        public ActionResult<Student> GetStudent(int RollNo)
        {
            var std=dbContext.Students.Find(RollNo);
            if (std == null)
            {
                return NotFound();
            }
            return Ok(std);
        }
        [HttpPost]
        public ActionResult<Student> AddStudent(Student student)
        {
            dbContext.Students.Add(student);
            dbContext.SaveChanges();
            return Ok();
        }
        [HttpPut("{RollNo}")]
        public ActionResult<Student> UpdateStudent(int RollNo, Student student)
        {
            if (RollNo != student.RollNo)
            {
                return BadRequest();
            }
          //  var std = dbContext.Students.Find(RollNo);
           
                dbContext.Students.Update(student);
               //dbContext.Entry(student).State=Microsoft.EntityFrameworkCore.EntityState.Modified;
                dbContext.SaveChanges();
            
            return Ok();
        }
        [HttpDelete("{RollNo}")]
        public ActionResult DeleteStudent(int RollNo)
        {
            var std = dbContext.Students.Find(RollNo);
            if (std != null)
            {
                dbContext.Students.Remove(std);
                dbContext.SaveChanges();
            }
            return Ok();
        }
    }
}
