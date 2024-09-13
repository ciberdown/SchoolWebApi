using SchoolWebApi.src.Dto;
using SchoolWebApi.src.Dto.School;

namespace SchoolWebApi.src.Service
{
    public interface ISchoolAppService
    {
        public Task<PagedResultDto<SchoolDto>> GetAsync(BaseInputDto input);
        public Task<SchoolDto?> GetByIdAsync(int id);
        public Task<SchoolDto?> AddAsync(SchoolCreateDto input);
        public Task<bool>  DeleteAsync(int id);
        public Task<SchoolDto?> UpdateAsync(SchoolUpdateDto input, int id);
    }
}
