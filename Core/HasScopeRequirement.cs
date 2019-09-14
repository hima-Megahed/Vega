using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;

namespace Vega.Core
{
    public class HasScopeRequirement : IAuthorizationRequirement
    {
        public string Issuer { get; }
        public string Permission { get; }

        public HasScopeRequirement(string permission, string issuer)
        {
            Permission = permission ?? throw new ArgumentNullException(nameof(permission));
            Issuer = issuer ?? throw new ArgumentNullException(nameof(issuer));
        }
    }
}
