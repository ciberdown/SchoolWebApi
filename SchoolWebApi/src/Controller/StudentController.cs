using Microsoft.AspNetCore.Mvc;
using SchoolWebApi.src.Dto;
using SchoolWebApi.src.Dto.Student;
using SchoolWebApi.src.Interface.Student;

namespace SchoolWebApi.src.Controller
{
    [Route("api/student")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly IStudentAppService _service;

        public StudentController(IStudentAppService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<PagedResultDto<StudentDto>>> Get([FromQuery] BaseInputDto input)
        {
            var res = await _service.Get(input);
            return Ok(res);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<PagedResultDto<StudentDto>>> GetById([FromRoute] long id)
        {
            var res = await _service.GetById(id);
            return res == null ? NotFound() : Ok(res);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<PagedResultDto<StudentDto>>> Delete([FromRoute] long id)
        {
            var res = await _service.Delete(id);
            return res == false ? NotFound() : NoContent();
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<PagedResultDto<StudentDto>>> Update([FromRoute] long id, [FromBody] UpdateStudentDto input)
        {
            var res = await _service.Update(input, id);
            return res == null ? NotFound() : Ok(res);
        }

        [HttpPost]
        public async Task<ActionResult<PagedResultDto<StudentDto>>> Create( [FromBody] CreateStudentDto input)
        {
            var res = await _service.Create(input);
            return res == null ? BadRequest() : Ok(res);
        }
    }
}
