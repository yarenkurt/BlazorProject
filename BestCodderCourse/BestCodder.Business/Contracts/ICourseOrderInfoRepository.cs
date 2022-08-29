using BestCodder.Common;
using BestCodder.DataAccess.Data;
using BestCodder.Models;

namespace BestCodder.Business.Contracts;

public interface ICourseOrderInfoRepository
{
    public Task<Result<CourseOrderInfoDto>> Create(CourseOrderInfoDto details);
    public Task<Result<CourseOrderInfo>> PaymentSuccessful(CourseOrderInfoDto details);
    public Task<Result<CourseOrderInfoDto>> GetCourseOrderInfo(int courseId);
    public Task<Result<bool>> UpdateCourseOrderStatus(int courseId,string status);
}