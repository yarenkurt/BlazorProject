﻿using AutoMapper;
using BestCodder.Business.Contracts;
using BestCodder.DataAccess.Data;
using BestCodder.Models;

namespace BestCodder.Business.Mapper;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<CourseDto, Course>().ReverseMap().ForMember(c=>c.ImageUrl,o=>o.MapFrom<CourseItemUrlResolver>());
        CreateMap<CourseOrderInfoDto,CourseOrderInfo>().ReverseMap();
    }
}