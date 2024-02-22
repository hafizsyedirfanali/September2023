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
        private readonly IStudent student;

        public StudentController(IStudent student)
        {
            this.student = student;
        }

        [HttpGet]
        [Route("GetStudentList")]
        public async Task<IActionResult> GetStudentList()
        {
            var result = await student.GetStudentListAsync().ConfigureAwait(false);
            return Ok(result);
        }


    }
}
