using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using BioEngine.BRC.Common.IPB.Models;
using BioEngine.BRC.Common.Users;
using Microsoft.AspNetCore.Http;

namespace BioEngine.BRC.Common.IPB.Auth
{
    public abstract class IPBCurrentUserProvider : ICurrentUserProvider
    {
        protected readonly IHttpContextAccessor HttpContextAccessor;

        protected IPBCurrentUserProvider(IHttpContextAccessor httpContextAccessor)
        {
            HttpContextAccessor = httpContextAccessor;
        }

        public IUser? CurrentUser
        {
            get
            {
                var user = new User
                {
                    Id =
                        HttpContextAccessor.HttpContext.User.Claims
                            .FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value,
                    Name =
                        HttpContextAccessor.HttpContext.User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Name)
                            ?.Value,
                    PhotoUrl =
                        HttpContextAccessor.HttpContext.User.Claims.FirstOrDefault(c => c.Type == "photo")?.Value,
                    ProfileUrl = HttpContextAccessor.HttpContext.User.Claims
                        .FirstOrDefault(c => c.Type == ClaimTypes.Webpage)?.Value
                };
                if (!string.IsNullOrEmpty(HttpContextAccessor.HttpContext.User.Claims
                    .FirstOrDefault(c => c.Type == ClaimTypes.PrimaryGroupSid)?.Value))
                {
                    if (int.TryParse(HttpContextAccessor.HttpContext.User.Claims
                        .FirstOrDefault(c => c.Type == ClaimTypes.PrimaryGroupSid)?.Value, out var groupId))
                    {
                        user.PrimaryGroup = new Group {Id = groupId};
                    }
                }

                var secondaryGroupIds = HttpContextAccessor.HttpContext.User.Claims
                    .Where(c => c.Type == ClaimTypes.GroupSid).Select(c => c.Value).ToList();
                if (secondaryGroupIds.Any())
                {
                    var groups = new List<Group>();
                    foreach (var secondaryGroupId in secondaryGroupIds)
                    {
                        if (int.TryParse(secondaryGroupId, out var groupId))
                        {
                            groups.Add(new Group {Id = groupId});
                        }
                    }

                    user.SecondaryGroups = groups.ToArray();
                }

                return user;
            }
        }


        public abstract Task<string> GetAccessTokenAsync();
    }
}
