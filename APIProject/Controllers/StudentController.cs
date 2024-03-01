using APIProject.Interfaces;
using APIProject.Models;
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
        [Route("GetToken")]
        public async Task<IActionResult> GetToken()
        {
            var token = await student.GetToken();
            await student.SaveToken(token);
            return Ok(token);
        }

        [HttpGet]
        [Route("GetStudentList")]
        public async Task<IActionResult> GetStudentList()
        {
            var result = await student.GetStudentListAsync().ConfigureAwait(false);
            if (result.IsSuccess) return StatusCode(StatusCodes.Status200OK, result); //Ok(result);
            else return StatusCode(StatusCodes.Status500InternalServerError, result);
        }
        [HttpPost]
        [Route("AddRecord")]
        public async Task<IActionResult> AddRecord([FromForm] StudentModel model)
        {
            if (ModelState.IsValid)
            {
                var result = await student.AddStudentAsync(model);
                if (result.IsSuccess)
                {
                    return Ok(result);
                }
                return StatusCode(StatusCodes.Status500InternalServerError, result);
            }
            string errors = string.Empty;
            foreach (var item in ModelState.Values.SelectMany(s=>s.Errors).ToList())
            {
                errors += item.ErrorMessage + "; ";
            }
            return BadRequest(new { ErrorMessage = errors });
        }

    }
}
