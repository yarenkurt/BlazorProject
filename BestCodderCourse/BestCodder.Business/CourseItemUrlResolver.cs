using AutoMapper;
using BestCodder.Common;
using BestCodder.DataAccess.Data;
using BestCodder.Models;

namespace BestCodder.Business;

public class CourseItemUrlResolver : IValueResolver<Course,CourseDto,string>
{
    public string Resolve(Course source, CourseDto destination, string destMember, ResolutionContext context)
    {
        if (!string.IsNullOrEmpty(source.ImageUrl))
            return ResultConstant.ImageServerUrl + source.ImageUrl;
        return null;
    }
}