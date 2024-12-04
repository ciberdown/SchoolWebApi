using System.Runtime.InteropServices;

namespace SchoolWebApi.src.Dto
{
    public class BaseInputDto
    {
        public int? Start { get; private set; }
        public int? Length { get; private set; }
        public string? FilterText { get; private set; } = null;
    }
}
