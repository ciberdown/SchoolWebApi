using Microsoft.AspNetCore.Mvc;
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



    }
}
