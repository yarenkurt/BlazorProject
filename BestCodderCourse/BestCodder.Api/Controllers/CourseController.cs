﻿using BestCodder.Business.Contracts;
using BestCodder.Common;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BestCodder.Api.Controllers;

[Route("api/[controller]")]
[Authorize]
public class CourseController : Controller
{
    private readonly ICourseRepository _courseRepository;

    public CourseController(ICourseRepository courseRepository)
    {
        _courseRepository = courseRepository;
    }

    [HttpGet]
    public async Task<IActionResult> GetCourses()
    {
        var allCourse = await _courseRepository.GetAllCourse();
        var data = allCourse;
        return Ok(data.Data);
    }

    [HttpGet("{courseId}")]
    public async Task<IActionResult> GetCourse(int? courseId)
    {
        if (courseId is null)
            return BadRequest(new Result<IActionResult>(false, ResultConstant.IdNotNull));
        var courseData = await _courseRepository.GetCourse((int)courseId);
        if (courseData != null)
            return Ok(courseData.Data);
        return BadRequest(new Result<IActionResult>(false, ResultConstant.RecordNotFound));
    }
}