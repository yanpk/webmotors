using System;
using System.Collections.Generic;
using System.Text;

namespace WebMotors.ViewModel
{
    public interface IPagedResultBase
    {
        int TotalResults { get; set; }
        int PageSize { get; set; }
        int PageNumber { get; set; }
        int TotalPages { get; }
        int StartAt { get; }
        int EndAt { get; }
        bool EnableNext { get; }
        bool EnablePrevious { get; }
    }
}
