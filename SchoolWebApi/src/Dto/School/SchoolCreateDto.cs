﻿namespace SchoolWebApi.src.Dto.School
{
    public class SchoolCreateDto
    {
        public string Name {  get; set; }
        public string? Description { get; set; }

        public SchoolCreateDto(string name, string? description)
        {
            Name = name;
            Description = description;
        }
    }
}
