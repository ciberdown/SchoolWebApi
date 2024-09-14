using Microsoft.AspNetCore.Mvc;
using SchoolWebApi.src.Dto;
using SchoolWebApi.src.Dto.Course;
using SchoolWebApi.src.Service;

namespace SchoolWebApi.src.Controller
{
    [Route("api/course")]
    [ApiController]
    public class CourseController : ControllerBase
    {
        private ICourseAppService _service { get; set; }

        public CourseController(ICourseAppService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<PagedResultDto<CourseDto>>> Get([FromQuery] BaseInputDto input)
        {
            var res = await _service.Get(input);
            return Ok(res);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CourseDto>> GetById([FromRoute] int id)
        {
            var res = await _service.GetById(id);
            if (res == null)
                return NotFound();
            return Ok(res);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            var res = await _service.Delete(id);
            return res == true ? NoContent() : NotFound();
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<CourseDto>> Update([FromBody] CourseUpdateDto input, [FromRoute] int id)
        {
            var res = await _service.Update(input, id);
            if(res == null)
                return NotFound();
            return Ok(res);
        }

        [HttpPost]
        public async Task<ActionResult<CourseDto>> Create([FromBody] CourseCreateDto input)
        {
            var res = await _service.Create(input);
            return Ok(res);
        }
    }
}
