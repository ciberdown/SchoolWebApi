using SchoolWebApi.src.Model;
using System.Runtime.InteropServices;

namespace SchoolWebApi.src.Dto.School
{
    public class SchoolUpdateDto
    {


        public string? Name { get; set; }
        public string? Description { get; set; }

        public SchoolUpdateDto([Optional] string? name,[Optional] string? description)
        {
            Name = name;
            Description = description;
        }
    }
}
