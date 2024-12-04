using Microsoft.AspNetCore.Mvc;
using SchoolWebApi.src.Dto;
using SchoolWebApi.src.Interface.Teacher;
using SchoolWebApi.src.Dto.Teacher;

namespace SchoolWebApi.src.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeacherController : ControllerBase
    {
        private readonly ITeacherAppService _service;
        public TeacherController(ITeacherAppService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<PagedResultDto<TeacherDto>>> Get([FromQuery] BaseInputDto input)
        {
            var res = await _service.Get(input);
            return Ok(res);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<PagedResultDto<TeacherDto>>> GetById([FromRoute] long id)
        {
            var res = await _service.GetById(id);
            return res == null ? NotFound() : Ok(res);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<PagedResultDto<TeacherDto>>> Delete([FromRoute] long id)
        {
            var res = await _service.Delete(id);
            return res == false ? NotFound() : NoContent();
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<PagedResultDto<TeacherDto>>> Update([FromRoute] long id, [FromBody] UpdateTeacherDto input)
        {
            var res = await _service.Update(input, id);
            return res == null ? NotFound() : Ok(res);
        }

        [HttpPost]
        public async Task<ActionResult<PagedResultDto<TeacherDto>>> Create([FromBody] CreateTeacherDto input)
        {
            var res = await _service.Create(input);
            return res == null ? BadRequest() : Ok(res);
        }
    }
}
