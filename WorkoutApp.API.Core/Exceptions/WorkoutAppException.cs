using System;
using System.Collections.Generic;
using System.Text;

namespace WorkoutApp.API.Core.Exceptions
{
    public class WorkoutAppException : Exception
    {
        public WorkoutAppException() { }
        public WorkoutAppException(string message) : base(message) { }
        public WorkoutAppException(string message, Exception innerException) : base(message, innerException) { }
    }
}
