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

    }
}
