using System;
using System.Net;

namespace Common.Domain.Model.Bases
{
    public abstract class BaseException : Exception
    {
        HttpStatusCode Code { get; }

        public BaseException(HttpStatusCode code)
        {
            this.Code = code;
        }


      
    }
}
