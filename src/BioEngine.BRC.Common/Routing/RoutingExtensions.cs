using System;
using BioEngine.BRC.Common.Entities;
using BioEngine.BRC.Common.Entities.Abstractions;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Routing;

namespace BioEngine.BRC.Common.Routing
{
    public static class RoutingExtensions
    {
        public static Uri? GeneratePublicUrl(this LinkGenerator linkGenerator, IRoutable routable, Site? site = null)
        {
            if (string.IsNullOrEmpty(routable.PublicRouteName))
            {
                return null;
            }

            return linkGenerator.GenerateUrl(routable.PublicRouteName, new {url = routable.Url}, site);
        }

        public static Uri GenerateUrl(this LinkGenerator linkGenerator, string routeName, object routeParams,
            Site? site = null)
        {
            var path = linkGenerator.GetPathByName(routeName, routeParams);
            if (path == null)
            {
                throw new Exception($"Can't generate url for route {routeName} with params {routeParams}");
            }

            if (site != null)
            {
                return new Uri(site.Url + path, UriKind.Absolute);
            }

            return new Uri(path, UriKind.Relative);
        }

        public static IEndpointRouteBuilder MapRoute(this IEndpointRouteBuilder endpoints, string name, string pattern,
            string controller, string action)
        {
            endpoints.MapControllerRoute(name, pattern,
                new {controller, action});
            return endpoints;
        }
    }
}
