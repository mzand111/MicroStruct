using IdentityModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace MicroStruct.Services.WorkflowApi.Controllers.Base
{
    [Authorize]
    public abstract class WorkflowBaseApiController : ControllerBase
    {
      
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
       
        public List<string>? LoweredUserRoleNames
        {
            get
            {
                if (User.Identity.IsAuthenticated)
                {

                    var claimsIdentity = User.Identity as System.Security.Claims.ClaimsIdentity;

                    if (claimsIdentity != null)
                    {
                        List<string> ret = new List<string>();
                        foreach (var claim in claimsIdentity.Claims)
                        {
                            if (claim.Type == JwtClaimTypes.Role)
                            {
                                ret.Add(claim.Value.ToLower());
                            }
                        }
                        return ret;

                    }
                }
                return null;

            }
        }
    }
}