using Microsoft.JSInterop;

namespace BestCodderCourse.Helper;

public static class IJSRuntimeExtention
{
    public static async ValueTask ToastrSuccess(this IJSRuntime jsRuntime, string? message)
    {
        await jsRuntime.InvokeVoidAsync("DisplayToastr","success",message);
    }
    public static async ValueTask ToastrError(this IJSRuntime jsRuntime, string? message)
    {
        await jsRuntime.InvokeVoidAsync("DisplayToastr","error",message);
    }
}