using Microsoft.AspNetCore.Components.Forms;

namespace BestCodderCourse.Service;

public interface IFileUpload
{
    Task<string> UploadFile(IBrowserFile file);
}