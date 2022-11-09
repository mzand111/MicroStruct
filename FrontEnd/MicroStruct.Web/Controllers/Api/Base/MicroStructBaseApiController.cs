using IdentityModel;
using Microsoft.AspNetCore.Mvc;
using MZSimpleDynamicLinq.Core;
using System.Net;
using System.Security.Claims;

namespace MicroStruct.Web.Controllers.API.Base
{
    public class MicroStructBaseApiController : ControllerBase
    {

        protected readonly IHostEnvironment _hostEnvironment;
        protected readonly int _baseActionID;

        public MicroStructBaseApiController(IHostEnvironment hostEnvironment,int baseActionID)
        {
            _hostEnvironment = hostEnvironment;
            _baseActionID = baseActionID;
        }
        public int BaseActionID
        {
            get { return _baseActionID; }
        }
        public string? UserFirstName
        {
            get
            {
                if (User.Identity != null && User.Identity.IsAuthenticated)
                {
                    if (User.Identity is ClaimsIdentity claimsIdentity)
                    {
                        return claimsIdentity.FindFirst(JwtClaimTypes.GivenName)?.Value;
                    }
                }
                return null;

            }
        }
        public string? UserLastName
        {
            get
            {
                if (User.Identity != null && User.Identity.IsAuthenticated)
                {
                    if (User.Identity is ClaimsIdentity claimsIdentity)
                    {
                        return claimsIdentity.FindFirst(JwtClaimTypes.FamilyName)?.Value;
                    }
                }
                return null;

            }
        }
        public string? UserName
        {
            get
            {
                if (User.Identity != null && User.Identity.IsAuthenticated)
                {
                    if (User.Identity is ClaimsIdentity claimsIdentity)
                    {
                        return claimsIdentity.FindFirst(JwtClaimTypes.Name)?.Value;
                    }
                }
                return null;

            }
        }
        public string? UserCompanyNationalID
        {
            get
            {
                if (User.Identity != null && User.Identity.IsAuthenticated)
                {
                    if (User.Identity is ClaimsIdentity claimsIdentity)
                    {
                        return claimsIdentity.FindFirst("CompanyNationalID")?.Value;
                    }
                }
                return null;

            }
        }


        protected IActionResult GetActionByException(Exception ex)
        {
            string msg = ex.Message;
            var msgLow = msg.ToLower();
            if (!string.IsNullOrWhiteSpace(msg) && (msgLow.Contains("service_exception_code:") || msgLow.Contains("service_exception_message:")))
            {
                string code = "";
                string message = "";
                var vals = msg.Split(',');
                foreach (var val in vals)
                {
                    if (!string.IsNullOrEmpty(val))
                    {
                        var gg = val.Split(':');
                        if (gg.Length >= 2)
                        {
                            if (gg[0].ToLower() == "service_exception_code")
                            {
                                code = gg[1];
                            }
                            else if (gg[0].ToLower() == "service_exception_message")
                            {
                                message = gg[1];
                            }
                        }

                    }

                }
                if (_hostEnvironment.IsDevelopment())
                {
                    return StatusCode((int)HttpStatusCode.InternalServerError, "service_exception_code:" + code + ",service_exception_message:" + message);
                }
                return StatusCode((int)HttpStatusCode.InternalServerError, "service_exception_code:" + code);


            }
            if (_hostEnvironment.IsDevelopment())
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }
            return StatusCode((int)HttpStatusCode.InternalServerError);
        }

        protected void Log<T>(ILogger<T> logger,LogPurposeType purpose = LogPurposeType.Access, string? methodName = null, string? message = null, LinqDataRequest? request = null, int? code = null, Exception? exception = null)
        {
            string fromMethod = "";
            string requestDetails = "";
            string details;
            if (!string.IsNullOrEmpty(methodName))
            {
                fromMethod = " from method: '" + methodName + "' ";
            }
            if (!string.IsNullOrEmpty(message))
            {
                details = message;
            }
            else
            {
                details = "Accessed to get multiple items of service " + typeof(T).FullName;
            }
            if (request != null)
            {
                requestDetails = " ,requestDetails:[ take:" + request.Take + ", skip:" + request.Skip + ",sort:" + request.Sort?.ToString() + "]";
            }
            if (purpose == LogPurposeType.Failure)
            {
                if (exception != null)
                {
                    logger.LogError(exception, details + fromMethod + requestDetails + " logcode:{UserActionID}", _baseActionID + (code ?? 5));
                }
                else
                {
                    logger.LogError(details + fromMethod + requestDetails + " logcode:{UserActionID}", _baseActionID + (code ?? 5));
                }
            }
            else
            {
                logger.LogInformation(details + fromMethod + requestDetails + " logcode:{UserActionID}", _baseActionID + (code ?? 5));
            }
        }


        public enum LogPurposeType
        {
            Access,
            Success,
            Failure,
        }
    }
}
