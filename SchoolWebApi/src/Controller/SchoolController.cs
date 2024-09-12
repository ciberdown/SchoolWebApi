using Microsoft.AspNetCore.Mvc;
using SchoolWebApi.src.Dto;
using SchoolWebApi.src.Dto.School;
using SchoolWebApi.src.Service;

namespace SchoolWebApi.src.Controller
{
    [Route("api/school")]
    [ApiController]
    public class SchoolController : ControllerBase
    {
        private ISchoolAppService _service { get; set; }

        public SchoolController(ISchoolAppService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<PagedResultDto<SchoolDto>>> Get([FromQuery] BaseInputDto input)
        {
            var res = await _service.GetAsync(input);
            return Ok(res);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<StudentDto?>> GetByIdAsync([FromRoute] int id)
        {
            var res = await _service.GetByIdAsync(id);
            if (res == null)
                return NotFound();
            return Ok(res);

        }

        [HttpPost]
        public async Task<ActionResult<StudentDto>> CreateAsync([FromBody] SchoolCreateDto input)
        {
            var res = await _service.AddAsync(input);
            return Ok(res);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync([FromRoute] int id)
        {
            var res = await _service.DeleteAsync(id);
            return res? NoContent() : NotFound();
        }
    }
}
