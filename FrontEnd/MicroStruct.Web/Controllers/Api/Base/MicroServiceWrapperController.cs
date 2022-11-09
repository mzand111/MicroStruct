using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MZBase.Microservices.HttpServices;
using MZSimpleDynamicLinq.Core;

namespace MicroStruct.Web.Controllers.API.Base
{
    [Authorize]
    public abstract class MicroServiceWrapperController<TService> : MicroStructBaseApiController
        where TService : IMicroServiceProxy
    {
        protected readonly ILogger<TService> _logger;

        public MicroServiceWrapperController(ILogger<TService> logger, IHostEnvironment hostEnvironment, int baseActionID) : base(hostEnvironment, baseActionID)
        {
            _logger = logger;
        }
        protected void LogMultipleGetFailure(Exception exception, LinqDataRequest? request = null, string? methodName = null, string? message=null)
        {
            LogMultipleGet(LogPurposeType.Failure, methodName, message,request,null,exception);
        }
        protected void LogMultipleGet(LogPurposeType purpose = LogPurposeType.Access, string? methodName = null, string? message = null, LinqDataRequest? request = null, int? code = null, Exception? exception = null)
        {
            string s = "";
            if (message == null)
            {
                if (purpose == LogPurposeType.Access)
                {
                    s = "Accessed to a controller method to get multiple items of service" + typeof(TService).FullName;
                }
                else if (purpose == LogPurposeType.Success)
                {
                    s = "Successfully called a controller method to get multiple items of service" + typeof(TService).FullName;
                }
                else
                {
                    s = "Failed to called a controller method to get multiple items of service" + typeof(TService).FullName;
                }
            }
            else
            {
                s = message;
            }
            Log(purpose, methodName, s, request, code ?? 1, exception);
        }
        protected void LogPostFailure(string message)
        {
            string s = "Failed to called a controller method to post to service" + typeof(TService).FullName;
            s += ",reason:" + message;
            LogPost(LogPurposeType.Failure, null, s);
        }
        protected void LogPostFailure(Exception exception)
        {
            LogPost(LogPurposeType.Failure, null, null, null, null, exception);
        }
        
        protected void LogPost(LogPurposeType purpose = LogPurposeType.Access, string? methodName = null, string? message = null, LinqDataRequest? request = null, int? code = null, Exception? exception = null)
        {
            string s = "";
            if (message == null)
            {
                if (purpose == LogPurposeType.Access)
                {
                    s = "Accessed to a controller method to post to service" + typeof(TService).FullName;
                }
                else if (purpose == LogPurposeType.Success)
                {
                    s = "Successfully called a controller method to post to service" + typeof(TService).FullName;
                }
                else
                {
                    s = "Failed to called a controller method to post to service" + typeof(TService).FullName;
                }
            }
            else
            {
                s = message;
            }
            Log(purpose, methodName, s, request, code ?? 1, exception);
        }
        protected void LogPutFailure(string message)
        {
            string s = "Failed to called a controller method to put to service" + typeof(TService).FullName;
            s += ",reason:" + message;
            LogPut(LogPurposeType.Failure, null, s);
        }
        protected void LogPutFailure(Exception exception)
        {
            LogPut(LogPurposeType.Failure, null, null, null, null, exception);
        }
        protected void LogPut(LogPurposeType purpose = LogPurposeType.Access, string? methodName = null, string? message = null, LinqDataRequest? request = null, int? code = null, Exception? exception = null)
        {
            string s = "";
            if (message == null)
            {
                if (purpose == LogPurposeType.Access)
                {
                    s = "Accessed to a controller method to put to service" + typeof(TService).FullName;
                }
                else if (purpose == LogPurposeType.Success)
                {
                    s = "Successfully called a controller method to put to service" + typeof(TService).FullName;
                }
                else
                {
                    s = "Failed to called a controller method to put to service" + typeof(TService).FullName;
                }
            }
            else
            {
                s = message;
            }
            Log(purpose, methodName, s, request, code ?? 3, exception);
        }
        protected void LogDeleteFailure(string message)
        {
            string s = "Failed to called a controller method to delete to service" + typeof(TService).FullName;
            s += ",reason:" + message;
            LogDelete(LogPurposeType.Failure, null, s);
        }
        protected void LogDeleteFailure(Exception exception)
        {
            LogDelete(LogPurposeType.Failure, null, null, null, null, exception);
        }
        protected void LogDelete(LogPurposeType purpose = LogPurposeType.Access, string? methodName = null, string? message = null, LinqDataRequest? request = null, int? code = null, Exception? exception = null)
        {
            string s = "";
            if (message == null)
            {
                if (purpose == LogPurposeType.Access)
                {
                    s = "Accessed to a controller method to delete to service" + typeof(TService).FullName;
                }
                else if (purpose == LogPurposeType.Success)
                {
                    s = "Successfully called a controller method to delete to service" + typeof(TService).FullName;
                }
                else
                {
                    s = "Failed to called a controller method to delete to service" + typeof(TService).FullName;
                }
            }
            else
            {
                s = message;
            }
            Log(purpose, methodName, s, request, code ?? 4,exception);
        }

        protected void LogRetrieveSingleFailure(string message)
        {
            string s = "Failed to called a controller method to retrieve single item from service" + typeof(TService).FullName;
            s += ",reason:" + message;
            LogRetrieveSingle(LogPurposeType.Failure, null, s);
        }
        protected void LogRetrieveSingleFailure(Exception exception)
        {
            LogRetrieveSingle(LogPurposeType.Failure, null, null, null, null, exception);
        }
        protected void LogRetrieveSingle(LogPurposeType purpose = LogPurposeType.Access, string? methodName = null, string? message = null, LinqDataRequest? request = null, int? code = null, Exception? exception = null)
        {
            string s = "";
            if (message == null)
            {
                if (purpose == LogPurposeType.Access)
                {
                    s = "Accessed to a controller method to retrieve single item from service" + typeof(TService).FullName;
                }
                else if (purpose == LogPurposeType.Success)
                {
                    s = "Successfully called a controller method to retrieve single item from service" + typeof(TService).FullName;
                }
                else
                {
                    s = "Failed to called a controller method to retrieve single item from service" + typeof(TService).FullName;
                }
            }
            else
            {
                s = message;
            }
            Log(purpose, methodName, s, request, code ?? 2, exception);
        }

        protected void Log(LogPurposeType purpose = LogPurposeType.Access, string? methodName = null, string? message = null, LinqDataRequest? request = null, int? code = null,Exception? exception=null)
        {
             Log(_logger, purpose, methodName, message, request, code , exception);
        }
    }

   
}
