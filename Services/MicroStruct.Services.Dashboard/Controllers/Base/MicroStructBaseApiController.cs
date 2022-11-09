using IdentityModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace MicroStruct.Services.Dashboard.Controllers.Base
{
    [Authorize]
    public class MicroStructBaseApiController : ControllerBase
    {
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
       
        public Guid? UserDepartmentID
        {
            get
            {
                if (User.Identity != null && User.Identity.IsAuthenticated)
                {
                    if (User.Identity is ClaimsIdentity claimsIdentity)
                    {
                        var f = claimsIdentity.FindFirst("DepartmentID");
                        if (f == null || string.IsNullOrEmpty(f.Value))
                        {
                            return null;
                        }
                        return new Guid(f.Value);
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
