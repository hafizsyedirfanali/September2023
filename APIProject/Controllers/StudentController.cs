using APIProject.Interfaces;
using DbProjectAsync.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace APIProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        /// <summary>
        /// Api server accepts action verbs get, post, put, patch, delete
        /// CREATE - Post verb
        /// READ - Get verb
        /// UPDATE - Put Verb
        /// DELETE - Delete Verb
        /// Server Response Common Codes  - 200, 401,402,404, 500, 501, 502
        /// </summary>
        private readonly IStudentAPI student;

        public StudentController(IStudentAPI student)
        {
            this.student = student;
        }

        [HttpGet]
        [Route("GetStudentList")]
        public async Task<IActionResult> GetStudentList()
        {
            var result = await student.GetStudentListAsync().ConfigureAwait(false);
            if (result.IsSuccess) return StatusCode(StatusCodes.Status200OK, result); //Ok(result);
            else return StatusCode(StatusCodes.Status500InternalServerError, result);
        }


    }
}
