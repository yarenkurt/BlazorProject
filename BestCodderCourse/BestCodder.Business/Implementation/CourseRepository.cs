﻿using AutoMapper;
using BestCodder.Business.Contracts;
using BestCodder.Common;
using BestCodder.DataAccess.Data;
using BestCodder.Models;
using Microsoft.EntityFrameworkCore;

namespace BestCodder.Business.Implementation;

public class CourseRepository : ICourseRepository
{
    private readonly BestCodderCourseContext _ctx;
    private readonly IMapper _mapper;

    public CourseRepository(BestCodderCourseContext ctx, IMapper mapper)
    {
        _ctx = ctx;
        _mapper = mapper;
    }

    public async Task<Result<CourseDto>> CreateCourse(CourseDto courseDto)
    {
        var course = _mapper.Map<CourseDto, Course>(courseDto);
        course.CreatedBy="Best Codder";
        var addedCourse = await _ctx.Courses.AddAsync(course);
        await _ctx.SaveChangesAsync();
        var returnData = _mapper.Map<Course, CourseDto>(addedCourse.Entity);
        return new Result<CourseDto>(true, ResultConstant.RecordCreateSuccessfully, returnData);
    }

    public async Task<Result<CourseDto>> UpdateCourse(int courseId, CourseDto courseDto)
    {
        try
        {
            if (courseId == courseDto.Id)
            {
                var courseDetails = await _ctx.Courses.FindAsync(courseId);
                var course = _mapper.Map<CourseDto, Course>(courseDto,courseDetails);
                course.UpdatedBy = "Best Codder";
                course.UpdatedDate = DateTime.Now;
                var updateCourse = _ctx.Courses.Update(course);
                await _ctx.SaveChangesAsync();
                var returnData = _mapper.Map<Course, CourseDto>(updateCourse.Entity);
                return new Result<CourseDto>(true, ResultConstant.RecordUpdatedSuccessfully, returnData);
            }
            else
            {
                return new Result<CourseDto>(false, ResultConstant.RecordUpdatedNotSuccessfully);
            }
        }
        catch (Exception e)
        {
           return new Result<CourseDto>(false, ResultConstant.RecordUpdatedNotSuccessfully);
        }
    }

    public async Task<Result<CourseDto>> UpdateCourseImage(int courseId, string imagePath)
    {
        try
        {
            if (courseId > 0)
            {
                var courseDetails = await _ctx.Courses.FindAsync(courseId);
               
                courseDetails.UpdatedBy = "Best Codder";
                courseDetails.UpdatedDate = DateTime.Now;
                courseDetails.ImageUrl = imagePath;
                var updateCourse = _ctx.Courses.Update(courseDetails);
                await _ctx.SaveChangesAsync();
                var returnData = _mapper.Map<Course, CourseDto>(updateCourse.Entity);
                return new Result<CourseDto>(true, ResultConstant.RecordUpdatedSuccessfully, returnData);
            }
            else
            {
                return new Result<CourseDto>(false, ResultConstant.RecordUpdatedNotSuccessfully);
            }
        }
        catch (Exception e)
        {
            return new Result<CourseDto>(false, ResultConstant.RecordUpdatedNotSuccessfully);
        }
    }

    public async Task<Result<CourseDto>> GetCourse(int courseId)
    {
        try
        {
            var data = await _ctx.Courses.FirstOrDefaultAsync(x => x.Id == courseId);
            var returnData = _mapper.Map<Course, CourseDto>(data);
            return new Result<CourseDto>(true, ResultConstant.RecordFound,returnData);
        }
        catch (Exception e)
        {
            return new Result<CourseDto>(false, ResultConstant.RecordNotFound);
        }
    }

    public async Task<Result<int>> DeleteCourse(int courseId)
    {
        var courseDetails = await _ctx.Courses.FindAsync(courseId);
        if (courseDetails != null)
        {
            _ctx.Courses.Remove(courseDetails);
            var result = await _ctx.SaveChangesAsync();
            return new Result<int>(true,ResultConstant.RecordRemoveSuccessfully,result);
        }
        return new Result<int>(true,ResultConstant.RecordRemoveNotSuccessfully);
    }

    public async Task<Result<IEnumerable<CourseDto>>> GetAllCourse()
    {
        try
        {
            var courseDtos = _mapper.Map<IEnumerable<Course>, IEnumerable<CourseDto>>(_ctx.Courses);
            return new Result<IEnumerable<CourseDto>>(true, ResultConstant.RecordFound, courseDtos,courseDtos.ToList().Count);
        }
        catch (Exception e)
        {
            return new Result<IEnumerable<CourseDto>>(false, ResultConstant.RecordNotFound);
        }
    }
}