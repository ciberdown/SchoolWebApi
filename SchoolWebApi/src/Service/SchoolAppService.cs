using Microsoft.EntityFrameworkCore;
using SchoolWebApi.src.Dto;
using SchoolWebApi.src.Dto.School;
using SchoolWebApi.src.Repository;

namespace SchoolWebApi.src.Service
{
    public class SchoolAppService : ISchoolAppService
    {
        private ISchoolRepo _repo { get; set; }

        public SchoolAppService(ISchoolRepo repo)
        {
            _repo = repo;
        }

        public async Task<PagedResultDto<SchoolDto>> GetAsync(BaseInputDto input)
        {
            var res = _repo.Get();
            var schools = await res.ToListAsync();
            var schoolDtos = schools.Select(s => new SchoolDto(s));
            var pagedResultDto = new PagedResultDto<SchoolDto>(schoolDtos, input);
            return pagedResultDto;
        }

        public async Task<SchoolDto?> GetByIdAsync(int id)
        {
            var res = await _repo.GetById(id);
            if (res == null)
                return null;
            var schoolDto = new SchoolDto(res);
            return schoolDto;
        }

        public async Task<SchoolDto?> AddAsync(SchoolCreateDto input)
        {
            var res = await _repo.Create(input);
            var schoolDto = new SchoolDto(res);
            return schoolDto;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var res = await _repo.Delete(id);
            return res;
        }
    }
}
