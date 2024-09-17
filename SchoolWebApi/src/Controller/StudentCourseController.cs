using Microsoft.AspNetCore.Mvc;
using SchoolWebApi.src.Dto;
using SchoolWebApi.src.Dto.StudentCourse;
using SchoolWebApi.src.Service;

namespace SchoolWebApi.src.Controller
{
    [Route("api/studentCourse")]
    [ApiController]
    public class StudentCourseController : ControllerBase
    {
        private IStudentCourseAppService _service { get; set; }

        public StudentCourseController(IStudentCourseAppService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<PagedResultDto<StudentCourseDto>>> Get([FromQuery] BaseInputDto input)
        {
            var res = await _service.Get(input);
            return Ok(res);
        }

        [HttpGet("{studentId}/{courseId}")]
        public async Task<ActionResult<StudentCourseDto>> GetById([FromRoute] int studentId, [FromRoute] int courseId)
        {
            var res = await _service.GetById(studentId, courseId);
            if (res == null)
                return NotFound();
            return Ok(res);
        }

        [HttpPost]
        public async Task<ActionResult<StudentCourseDto>> Create([FromBody] StudentCourseCreateDto input)
        {
            var res = await _service.Create(input);
            if (res == null)
                return BadRequest();
            return Ok(res);
        }

        [HttpPut("{studentId}/{courseId}")]
        public async Task<ActionResult<StudentCourseDto>> Update([FromBody] StudentCourseUpdateDto input, [FromRoute] int studentId, [FromRoute] int courseId)
        {
            var res = await _service.Update(input, studentId, courseId);
            if(res == null)
                return NotFound();
            return Ok(res);
        }

        [HttpDelete("{studentId}/{courseId}")]
        public async Task<IActionResult> Delete([FromRoute] int studentId, [FromRoute] int courseId)
        {
            var isDeleted = await _service.Delete(studentId,courseId);
            return isDeleted == true ? NoContent() : NotFound();
        }
    }
}
