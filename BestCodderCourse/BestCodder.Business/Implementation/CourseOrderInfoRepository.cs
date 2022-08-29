using AutoMapper;
using BestCodder.Business.Contracts;
using BestCodder.Common;
using BestCodder.DataAccess.Data;
using BestCodder.Models;
using Microsoft.EntityFrameworkCore;

namespace BestCodder.Business.Implementation;

public class CourseOrderInfoRepository : ICourseOrderInfoRepository
{
    private readonly BestCodderCourseContext _ctx;
    private readonly IMapper _mapper;

    public CourseOrderInfoRepository(BestCodderCourseContext ctx, IMapper mapper)
    {
        _ctx = ctx;
        _mapper = mapper;
    }

    public async Task<Result<CourseOrderInfoDto>> Create(CourseOrderInfoDto details)
    {
        try
        {
            var courseOrder = _mapper.Map<CourseOrderInfoDto, CourseOrderInfo>(details);
            courseOrder.Status = ResultConstant.Status_Pending;
            var result = await _ctx.CourseOrderInfos.AddAsync(courseOrder);
            await _ctx.SaveChangesAsync();
            var returnData = _mapper.Map<CourseOrderInfo, CourseOrderInfoDto>(result.Entity);
            return new Result<CourseOrderInfoDto>(true, ResultConstant.RecordCreateSuccessfully, returnData);
        }
        catch (Exception e)
        {
            return new Result<CourseOrderInfoDto>(false, e.Message.ToString());
        }
    }

    public Task<Result<CourseOrderInfo>> PaymentSuccessful(CourseOrderInfoDto details)
    {
        throw new NotImplementedException();
    }

    public async Task<Result<CourseOrderInfoDto>> GetCourseOrderInfo(int courseId)
    {
        try
        {
            var data = await _ctx.CourseOrderInfos.Include(c => c.Course).FirstOrDefaultAsync(c=>c.Id==courseId);
            var info = _mapper.Map<CourseOrderInfo, CourseOrderInfoDto>(data);
            info.TotalCount = _ctx.Courses.Where(x => x.Id == courseId).ToList().Count;
            return new Result<CourseOrderInfoDto>(true, ResultConstant.RecordFound, info);
        }
        catch (Exception e)
        {
            return new Result<CourseOrderInfoDto>(false, e.Message.ToString());
        }
    }

    public Task<Result<bool>> UpdateCourseOrderStatus(int courseId, string status)
    {
        throw new NotImplementedException();
    }
}