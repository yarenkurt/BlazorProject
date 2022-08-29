using BestCodder.Common;
using BestCodder.Models;

namespace BestCodderCourse.Client.Service.Contracts;

public interface ICourseService
{
    public Task<Result<IEnumerable<CourseDto>>> GetAllCourse();
    public Task<Result<CourseDto>> GetCourse(int courseId);
}