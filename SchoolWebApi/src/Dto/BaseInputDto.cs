using System.Runtime.InteropServices;

namespace SchoolWebApi.src.Dto
{
    public class BaseInputDto
    {
        public int? MaxResultCount { get; set; }
        public int? SkipCount { get; set; }
        public string? FilterText { get; set; }
    }
}
