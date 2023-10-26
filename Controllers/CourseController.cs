using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using symphony2.Utils;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using symphony2.Models;

namespace symphony2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CourseController : Controller
    {
        private readonly SymphonyContext _context;

        public CourseController(SymphonyContext context)
        {
            _context = context;
        }

        // GET: api/Course
        [HttpGet]
        [Authorize]
        public async Task<ActionResult<IEnumerable<Course>>> GetCourses()
        {
            var courses = await _context.Course.Where(u => u.DeletedAt == null).ToListAsync();

            if (courses == null || courses.Count == 0)
            {
                return NotFound();
            }

            return courses;
        }

        // GET: api/courses/{id}
        [HttpGet("{id}")]
        [Authorize]
        public async Task<ActionResult<Course>> GetCourseById(int id)
        {
                var course = await _context.Course
                            .Where(u => u.Id == id && u.DeletedAt == null)
                            .FirstOrDefaultAsync();

            if (course == null)
            {
                return NotFound();
            }

            return course;
        }

        // POST: api/course
        [HttpPost("course")]
        [Authorize]
        public ActionResult<string> CreateBuilder([FromBody] Course course)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            // Set CreatedAt and UpdatedAt timestamps to the current time
            course.CreatedAt = DateTime.Now;
            course.UpdatedAt = DateTime.Now;

            // Add the user to the database
            _context.Course.Add(course);
            _context.SaveChanges();

            return Ok("Create successfully.");
        }

        // PUT: api/courses/{id}
        [HttpPut("{id}")]
        [Authorize]
        public async Task<IActionResult> UpdateCourse(int id, [FromBody] Course updatedCourse)
        {
            var course = await _context.Course.Where(u => u.Id == id && u.DeletedAt == null)
                                            .FirstOrDefaultAsync();

            if (course == null)
            {
                return NotFound();
            }

            course.CourseName = updatedCourse.CourseName;
            course.Major = updatedCourse.Major;
            course.Description = updatedCourse.Description;

            course.UpdatedAt = DateTime.Now;

            _context.Entry(course).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CourseExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Ok("Update success!");
        }

        // DELETE: api/courses/{id}
        [HttpDelete("{id}")]
        [Authorize]
        public async Task<IActionResult> SoftDeleteCourse(int id)
        {
            var course = await _context.Course.FindAsync(id);

            if (course == null)
            {
                return NotFound();
            }

            // Set the DeletedAt timestamp to the current time
            course.DeletedAt = DateTime.Now;

            await _context.SaveChangesAsync();

            return Ok("Delete success!");
        }

        private bool CourseExists(int id)
        {
            return _context.Course.Any(e => e.Id == id);
        }
    }
}