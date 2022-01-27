using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using Generic.Functions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Server.Kestrel.Core.Internal.Http;

namespace Generic.Models
{
    public class ReturnRequest<T> where T : class
    {
        private bool OperationResult { get; set; }

        public HttpStatusCode Status { get; }

        private HttpMethod Method { get; set; }

        public int Count => Records?.Count() ?? 0;

        public ObjectResult ObjectResult
        {
            get
            {
                if (Method is HttpMethod.Delete)
                    return ObjectResultHandler.ReturnData(OperationResult, Method);

                switch (Status)
                {
                    case HttpStatusCode.InternalServerError:
                        return new ObjectResult(new StatusCodeResult((int) Status));
                    case HttpStatusCode.NotFound:
                        return new NotFoundObjectResult(string.Empty);
                }

                if (Count > 0 && Records.Any())
                    return ObjectResultHandler.ReturnData(Records, Method);

                return ObjectResultHandler.ReturnData(Record, Method);
            }
        }

        public T Record { get; set; }

        public T FirstRecord => Records?.FirstOrDefault();

        public IEnumerable<T> Records { get; set; }

        public ReturnRequest()
        {
        }

        public ReturnRequest(HttpStatusCode statusCode) => Status = statusCode;
        
        public ReturnRequest( bool operationResult, HttpMethod method)
        {
            Method = method;
            OperationResult = operationResult;
        }

        public ReturnRequest(T model, HttpMethod method)
        {
            Record = model;
            Method = method;
        }

        public ReturnRequest(IEnumerable<T> models, HttpMethod method)
        {
            Records = models;
            Method = method;
        }
    }
}