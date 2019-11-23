using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WorkoutApp.API.Presentation.Web.Models.Response
{
    public class ErrorResponse
    {
        public string Error { get; set; }
        public string Message { get; set; }
        public IList<string> SubErrors { get; set; }
            = new List<string>();
        public int AppErrorCode { get; set; }
    }
}
