using Insurance.Common;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;

namespace Insurance.Api
{
    /// <summary>
    /// Global exception handling middleware
    /// reference: https://weblog.west-wind.com/posts/2016/oct/16/error-handling-and-exceptionfilter-dependency-injection-for-aspnet-core-apis
    /// </summary>
    public class ApiExceptionFilter : ExceptionFilterAttribute
    {
        private readonly ILogger _logger;
        private IDictionary<Type, Action<ExceptionContext>> _exceptionHandlers;
        
        public ApiExceptionFilter(ILogger logger)
        {
            _logger = logger;
            InitializeExceptionHandlers();
        }

        private void InitializeExceptionHandlers()
        {
            _exceptionHandlers = new Dictionary<Type, Action<ExceptionContext>>()
            {
                { typeof(ProductTypeNotFoundException), HandleProductTypeNotFoundException},
                { typeof(ProductNotFoundException), HandleProductNotFoundException},
                { typeof(SurchargeRateProductTypeNotFoundException), HandleSurchargeRateProductTypeNotFoundException},
                { typeof(ProductTypeAlreadyHasSurchargeRateException), HandleProductTypeAlreadyHasSurchargeRateException},
                { typeof(CreateSurchareRateException), HandleCreateSurchareRateException}

            };
        }

        public override void OnException(ExceptionContext context)
        {
            HandelException(context);
            base.OnException(context);
        }

        private void HandelException(ExceptionContext context)
        {
            Type exceptionType = context.Exception.GetType();
            if (_exceptionHandlers.ContainsKey(exceptionType))
            {
                _exceptionHandlers[exceptionType].Invoke(context);
                return;
            }
            HandleOtherExceptionTypes(context);
        }

        /// <summary>
        /// Logs and sends Status400BadRequest with custom message in case of ProductTypeNotFoundException
        /// </summary>
        /// <param name="context"></param>
        private void HandleProductTypeNotFoundException(ExceptionContext context)
        {
            var exception = context.Exception as ProductTypeNotFoundException;
            _logger.LogException(exception, exception.Message);

            var customResultObject = new ProblemDetails
            {
                Status = StatusCodes.Status204NoContent,
                Title = $"Opps!!{exception.Message}"
            };
            context.Result = new ObjectResult(customResultObject);

            context.HttpContext.Response.StatusCode = StatusCodes.Status400BadRequest;
            context.ExceptionHandled = true;
        }

        /// <summary>
        /// Logs and sends Status400BadRequest with custom message in case of ProductNotFoundException
        /// </summary>
        /// <param name="context"></param>
        private void HandleProductNotFoundException(ExceptionContext context)
        {
            var exception = context.Exception as ProductNotFoundException;
            _logger.LogException(exception, exception.Message);

            var customResultObject = new ProblemDetails
            {
                Status = StatusCodes.Status204NoContent,
                Title = $"Opps!!{exception.Message}"
            };
            context.Result = new ObjectResult(customResultObject);

            context.HttpContext.Response.StatusCode = StatusCodes.Status400BadRequest;
            context.ExceptionHandled = true;
        }

        /// <summary>
        /// Logs and sends Status400BadRequest with custom message in case of SurchargeRateProductTypeNotFoundException
        /// </summary>
        /// <param name="context"></param>
        private void HandleSurchargeRateProductTypeNotFoundException(ExceptionContext context)
        {
            var exception = context.Exception as SurchargeRateProductTypeNotFoundException;
            _logger.LogException(exception, exception.Message);

            var customResultObject = new ProblemDetails
            {
                Status = StatusCodes.Status204NoContent,
                Title = $"Opps!! {exception.Message}"
            };
            context.Result = new ObjectResult(customResultObject);

            context.HttpContext.Response.StatusCode = StatusCodes.Status400BadRequest;
            context.ExceptionHandled = true;
        }

        /// <summary>
        /// Logs and sends Status400BadRequest with custom message in case of CreateSurchareRateException
        /// </summary>
        /// <param name="context"></param>
        private void HandleCreateSurchareRateException(ExceptionContext context)
        {
            var exception = context.Exception as CreateSurchareRateException;
            _logger.LogException(exception, exception.Message);

            var customResultObject = new ProblemDetails
            {
                Status = StatusCodes.Status204NoContent,
                Title = $"Opps!! {exception.Message}"
            };
            context.Result = new ObjectResult(customResultObject);

            context.HttpContext.Response.StatusCode = StatusCodes.Status400BadRequest;
            context.ExceptionHandled = true;
        }

        /// <summary>
        /// Logs and sends Status400BadRequest with custom message in case of ProductTypeAlreadyHasSurchargeRateException
        /// </summary>
        /// <param name="context"></param>
        private void HandleProductTypeAlreadyHasSurchargeRateException(ExceptionContext context)
        {
            var exception = context.Exception as ProductTypeAlreadyHasSurchargeRateException;
            _logger.LogException(exception, exception.Message);

            var customResultObject = new ProblemDetails
            {
                Status = StatusCodes.Status400BadRequest,
                Title = $"Opps!! {exception.Message}"
            };
            context.Result = new ObjectResult(customResultObject);

            context.HttpContext.Response.StatusCode = StatusCodes.Status400BadRequest;
            context.ExceptionHandled = true;
        }

        /// <summary>
        /// Logs and sends Status500InternalServerError with custom message in case of any unhandled exceptions.
        /// </summary>
        /// <param name="context"></param>
        private void HandleOtherExceptionTypes(ExceptionContext context)
        {
            if (context.Exception is AggregateException)
            {
                foreach (var innerException in ((AggregateException)(context.Exception)).Flatten().InnerExceptions)
                {
                    _logger.LogException(innerException, innerException.Message);
                }
            }
            else
            {
                _logger.LogException(context.Exception, context.Exception.Message);
            }
            
            var customResultObject = new ProblemDetails
            {
                Status = StatusCodes.Status500InternalServerError,
                Title = "Opps!! An error happended while processing the request."
            };
            context.Result = new ObjectResult(customResultObject);
            context.ExceptionHandled = true;
        }
    }
}
