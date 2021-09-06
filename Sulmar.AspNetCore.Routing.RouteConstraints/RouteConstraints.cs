using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using System;
using Validators.Abstractions;
using Validators.Polish;

namespace Sulmar.AspNetCore.Routing.RouteConstraints
{

    public class PeselValidatorRouteConstraint : RouteConstraints, IRouteConstraint
    {
        protected PeselValidatorRouteConstraint(string key = "pesel") : base(new PeselValidator(), key)
        {
        }
    }

    public class RegonValidatorRouteConstraint : RouteConstraints, IRouteConstraint
    {
        protected RegonValidatorRouteConstraint(string key = "regon") : base(new RegonValidator(), key)
        {
        }
    }

    public class NipValidatorRouteConstraint : RouteConstraints, IRouteConstraint
    {
        protected NipValidatorRouteConstraint(string key = "nip") : base(new NipValidator(), key)
        {
        }
    }


    public abstract class RouteConstraints : IRouteConstraint
    {
        private readonly IValidator validator;
        private readonly string pattern;

        protected RouteConstraints(IValidator validator, string pattern)
        {
            this.validator = validator;
            this.pattern = pattern;
        }

        public bool Match(HttpContext httpContext, IRouter route, string routeKey, RouteValueDictionary values, RouteDirection routeDirection)
        {
            if (values.TryGetValue(pattern, out object valueObject))
            {
                string value = valueObject.ToString();

                try
                {
                    return validator.IsValid(value);
                }
                catch (FormatException)
                {
                    return false;
                }
            }

            return false;
        }
    }

    
}
