using Microsoft.EntityFrameworkCore;
using System.Runtime.InteropServices;

namespace SchoolWebApi.src.Dto
{
    public class PagedResultDto<T>
    {
        public int TotalRecords { get; private set; }
        public int Start { get; private set; }
        public int Length { get; private set; }
        public List<T> Data { get; private set; }

        private PagedResultDto() { }

        public PagedResultDto(IEnumerable<T> source, [Optional] BaseInputDto? input)
        {
            // Validate input
            if (input.Start < 0) throw new ArgumentException("Start must be non-negative", nameof(input.Start));
            if (input.Length <= 0) throw new ArgumentException("Length must be greater than zero", nameof(input.Length));


            var data = source.ToList().Skip(Start).Take(Length);


            // Apply pagination
            TotalRecords = data.Count();
            Start = input.Start ?? 0;
            Length = input.Length ?? 10;
            Data = data.ToList();
        }

        public static async Task<PagedResultDto<T>> CreateAsync(IQueryable<T> source, [Optional] BaseInputDto? input)
        {
            // Validate input
            if (input.Start < 0) throw new ArgumentException("Start must be non-negative", nameof(input.Start));
            if (input.Length <= 0) throw new ArgumentException("Length must be greater than zero", nameof(input.Length));

            var start = input.Start ?? 0;
            var length = input.Length ?? 10;


            var data = source.Skip(start)
                .Take(length);


            var response = new PagedResultDto<T>
            {
                Start = start,
                Length = length,
                Data = await data.ToListAsync(),
                TotalRecords = await data.CountAsync(),
            };
            return response;
        }
    }
}
