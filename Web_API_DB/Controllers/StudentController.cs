using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query.Internal;

namespace Web_API_DB.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly StudentDbContext _context;

        public StudentController(StudentDbContext context)
        {
            _context = context;
        }
        [HttpGet]
        public async Task<ActionResult<List <Student>>> GetStudent()
        {
            var data= await _context.students.ToListAsync();
            return Ok(data);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<Student>> GetStudentbyId(int id)
        {
            var student= await _context.students.FindAsync(id);
            if(student == null)
            {
                return BadRequest();
            }
            return Ok(student);
        }
        [HttpPost]
        public async Task<ActionResult<Student>> CreateStudent(int id, Student student)
        {
            await _context.students.AddAsync(student);
            await _context.SaveChangesAsync();
            return Ok(student);
        }
        [HttpPut("{id}")]
        public async Task<ActionResult <Student>> UpdateStudent(int id, Student student)
        {
          if(student == null)
            {
                return BadRequest();
            }
            _context.Entry(student).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return Ok(student);

        }
        [HttpDelete("{id}")]
        public async Task<ActionResult <Student>> DeleteStudent(int id)
        {
            var std = await _context.students.FindAsync(id);
            if(std == null)
            {
                return BadRequest();
            }
            _context.students.Remove(std);
            await _context.SaveChangesAsync();
            return Ok(std);
        }


    }
}
