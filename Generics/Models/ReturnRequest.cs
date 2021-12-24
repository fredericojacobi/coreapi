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
        private bool OperationResult
        {
            get => false;
            set{}
        }

        public HttpStatusCode Status { get; }

        private HttpMethod Method { get; set; }

        public int Count => Records.Count;

        public ObjectResult ObjectResult
        {
            get
            {
                if (OperationResult)
                    return new OkObjectResult(new { });

                switch (Status)
                {
                    case HttpStatusCode.InternalServerError:
                        return new ObjectResult(new StatusCodeResult((int) Status));
                    case HttpStatusCode.NotFound:
                        return new NotFoundObjectResult(new { });
                }

                if (Record is not null)
                    return ObjectResultHandler.ReturnData(Record, Method);
                if (Records.Any())
                    return ObjectResultHandler.ReturnData(Records, Method);
                return new BadRequestObjectResult(new { });
            }
            set { }
        }

        public T Record { get; set; }

        public T FirstRecord => Records.FirstOrDefault();

        public IList<T> Records { get; set; }

        public ReturnRequest()
        {
        }

        public ReturnRequest(bool operationResult) => OperationResult = operationResult;

        public ReturnRequest(HttpStatusCode statusCode) => Status = statusCode;

        public ReturnRequest(T model) => Record = model;

        public ReturnRequest(List<T> models) => Records = models;
    }
}