using System.Runtime.InteropServices;

namespace SchoolWebApi.src.Dto
{
    public class PagedResultDto<T>
    {
        public int? TotalCount { get; set; }
        public IEnumerable<T> Items { get; set; }

        public PagedResultDto(IEnumerable<T> items, [Optional] BaseInputDto inputDto)
        {
            inputDto.MaxResultCount ??= 10;
            inputDto.SkipCount ??= 0;

            TotalCount = items.Count();
            Items = items.Skip((int)inputDto.SkipCount).Take((int)inputDto.MaxResultCount).ToList();

        }
    }
}
