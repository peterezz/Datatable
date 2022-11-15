using AspNetCoreAssessment.Entities;
using AspNetCoreAssessment.Models;
using AutoMapper;
using Microsoft.CodeAnalysis;

namespace AspNetCoreAssessment.AutoMapper
{
    public class DomainProfile :Profile
    {
        public DomainProfile()
        {
            CreateMap<Student, StudentVM>().ReverseMap();
         
            CreateMap<Stage, StageVM>().ReverseMap();
            CreateMap<Gender, GenderVM>().ReverseMap();


        }
    }
}
