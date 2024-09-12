﻿using Microsoft.EntityFrameworkCore;
using SchoolWebApi.src.Data;
using SchoolWebApi.src.Dto;
using SchoolWebApi.src.Dto.School;
using SchoolWebApi.src.Model;

namespace SchoolWebApi.src.Repository
{
    public class SchoolRepo : ISchoolRepo
    {
        private SchoolDb _context { get; set; }

        public SchoolRepo(SchoolDb context)
        {
            _context = context;
        }
        public IQueryable<School> Get()
        {
            var res = _context.Schools
                .Include(s => s.Students)
                .Include(s => s.Courses)
                //.ThenInclude(c => c.School)
                .AsQueryable();
            return res;
        }

        public async Task<School?> GetById(int id)
        {
            var res = await _context.Schools
                .Include(s => s.Students)
                .Include(s => s.Courses)
                //.ThenInclude(c => c.School)
                .FirstOrDefaultAsync(s => s.Id == id);
            return res;
        }

        public async Task<School?> Create(SchoolCreateDto input)
        {
            var school = new School(input.Name, input.Description);
            var founded = await _context.Schools.FirstOrDefaultAsync(s => s.Name == input.Name);
            if (founded != null)
                throw new Exception("school with this name exists!");
            var res = await _context.AddAsync(school);
            await _context.SaveChangesAsync();
            return school;
        }

        public async Task<bool> Delete(int id)
        {
            var res = await _context.Schools.FindAsync(id);
            if(res == null)
                return false;
            _context.Schools.Remove(res);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
