using System;
using System.Collections;
using System.Collections.Generic;
using Generic.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.AspNetCore.Server.Kestrel.Core.Internal.Http;

namespace Generic.Functions
{
    public sealed class ObjectResultHandler : ControllerBase
    {
        [NonAction]
        public static ObjectResult ReturnData([ActionResultObjectValue] object result, HttpMethod method)
        {
            switch (method)
            {
                case HttpMethod.Get:
                    if (result is not IEnumerable)
                        return result is null ? new NotFoundObjectResult(new object()) : new OkObjectResult(result);

                    var size = new List<object>(result as IEnumerable<object> ?? Array.Empty<object>()).Count;
                    return size > 0 ? new OkObjectResult(result) : new NotFoundObjectResult(new object());

                case HttpMethod.Post:
                    return result is null
                        ? new BadRequestObjectResult(ResponseErrorMessage.WrongBodyContent())
                        : new OkObjectResult(result);
                
                case HttpMethod.Put:
                    return result is null
                        ? new BadRequestObjectResult(ResponseErrorMessage.NotFound())
                        : new OkObjectResult(result);
            }

            return new ObjectResult(result);
        }
    }
}