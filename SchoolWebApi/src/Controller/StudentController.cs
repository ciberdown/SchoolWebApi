using Microsoft.AspNetCore.Mvc;
using SchoolWebApi.src.Dto;
using SchoolWebApi.src.Dto.Student;
using SchoolWebApi.src.Service;

namespace SchoolWebApi.src.Controller
{
    [Route("api/student")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private IStudentAppService _service {  get; set; }
        public StudentController(IStudentAppService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<PagedResultDto<StudentDto>>> Get([FromQuery] BaseInputDto input)
        {
            var res = await _service.GetAllAsync(input);
            return Ok(res);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<StudentDto>> GetById([FromRoute] int id)
        {
            var res = await _service.GetByIdAsync(id);
            if (res == null)
                return NotFound();
            return Ok(res);
        }

        [HttpPost]
        public async Task<ActionResult<StudentDto>> Create([FromBody] StudentCreateDto input)
        {
            var res = await _service.CreateAsync(input);
            return Ok(res);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            var res = await _service.DeleteAsync(id);
            return res == true ? NoContent() : NotFound();
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<StudentDto>> Update([FromBody] StudentUpdateDto input, [FromRoute] int id)
        {
            var res = await _service.UpdateAsync(input, id);
            return res == null ? NotFound() : Ok(res);
        }

    }
}
