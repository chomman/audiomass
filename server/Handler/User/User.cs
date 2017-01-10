using Amazon.Lambda.APIGatewayEvents;
using Amazon.Lambda.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using AudioMass.Extensions;
using AudioMass.Helpers;
using AudioMass.Base;

namespace AudioMass.Handler
{
    public class User : Api
    {
        public async Task<APIGatewayProxyResponse> Get(APIGatewayProxyRequest request, ILambdaContext context)
        {
            var session = GetSession(context);

            return (await new Model.User().Get("User", session.AccountId)).CreateResponse();
        }
    }
}
