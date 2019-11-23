using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using WorkoutApp.API.Core.Exceptions;

namespace WorkoutApp.API.Presentation.Web.Exceptions
{
    public class WorkoutAppHttpException : WorkoutAppException
    {
        public int Code { get; set; }

        public WorkoutAppHttpException(int code)
        {
            Code = code;
        }

        public WorkoutAppHttpException(HttpStatusCode code)
        {
            Code = (int) code;
        }

        public WorkoutAppHttpException(int code, string message) : base(message)
        {
            Code = code;
        }

        public WorkoutAppHttpException(int code, string message, Exception innerException) : base(message,
            innerException)
        {
            Code = code;
        }

        public WorkoutAppHttpException(HttpStatusCode code, string message) : base(message)
        {
            Code = (int)code;
        }

        public WorkoutAppHttpException(HttpStatusCode code, string message, Exception innerException) : base(message,
            innerException)
        {
            Code = (int)code;
        }
    }
}
