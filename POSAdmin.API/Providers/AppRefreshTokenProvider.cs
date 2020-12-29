using Microsoft.Owin.Security.Infrastructure;
using Newtonsoft.Json;
using POSWeb.POSAdmin.API.Helpers;
using POSWeb.POSAdmin.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace POSWeb.POSAdmin.API.Providers
{
    public class AppRefreshTokenProvider : IAuthenticationTokenProvider
    {

        public AppRefreshTokenProvider()
        {
        }

        public void Create(AuthenticationTokenCreateContext context)
        {
            throw new NotImplementedException();
        }

        public async Task CreateAsync(AuthenticationTokenCreateContext context)
        {
        }

        public void Receive(AuthenticationTokenReceiveContext context)
        {
            throw new NotImplementedException();
        }

        public async Task ReceiveAsync(AuthenticationTokenReceiveContext context)
        {
        }
    }
}