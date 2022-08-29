﻿using System.Text;
using BestCodder.Common;
using BestCodder.Models;
using BestCodderCourse.Client.Service.Contracts;
using Newtonsoft.Json;

namespace BestCodderCourse.Client.Service.Implements;

public class CourseOrderInfoService : ICourseOrderInfoService
{
    private readonly HttpClient _httpClient;

    public CourseOrderInfoService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<Result<CourseOrderInfoDto>> SaveCourseOrderInfo(CourseOrderInfoDto model)
    {
        var content = JsonConvert.SerializeObject(model);
        var bodyContent = new StringContent(content, Encoding.UTF8, "application/json");
        var response = await _httpClient.PostAsync("https://localhost:44353/api/courseOrder/create",bodyContent);
        string res = response.Content.ReadAsStringAsync().Result;
        if (response.IsSuccessStatusCode)
        {
            var data = response.Content.ReadAsStringAsync().Result;
            var result = JsonConvert.DeserializeObject<CourseOrderInfoDto>(data);
            return new Result<CourseOrderInfoDto>(true, ResultConstant.RecordFound, result);
        }
        else
        {
            var contentTemp = await response.Content.ReadAsStringAsync();
            return new Result<CourseOrderInfoDto>(true, ResultConstant.RecordNotFound);   
        }
    }

    public Task<Result<CourseOrderInfoDto>> PaymentSuccessful(int courseId)
    {
        throw new NotImplementedException();
    }
}