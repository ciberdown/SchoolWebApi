using Microsoft.AspNetCore.Mvc;
using SchoolWebApi.src.Dto;
using SchoolWebApi.src.Dto.Course;
using SchoolWebApi.src.Interface.Course;

namespace SchoolWebApi.src.Controller
{
    [Route("api/course")]
    [ApiController]
    public class CourseController : ControllerBase
    {
        private readonly ICourseAppService _service;

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
        public async Task<ActionResult<CourseDto>> GetById([FromRoute] long id)
        {
            var res = await _service.GetById(id);
            return res == null ? NotFound() : Ok(res);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] long id)
        {
            var res = await _service.Delete(id);
            return res == true ? NoContent() : NotFound();
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<CourseDto>> Update([FromRoute] long id, [FromBody] UpdateCourseDto input)
        {
            var res = await _service.Update(input, id);
            return res == null ? NotFound() : Ok(res);
        }

        [HttpPost]
        public async Task<ActionResult<CourseDto>> Create([FromBody] CreateCourseDto input)
        {
            var res = await _service.Create(input);
            return Ok(res);
        }
    }
}
