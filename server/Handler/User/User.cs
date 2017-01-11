using Amazon.Lambda.APIGatewayEvents;
using Amazon.Lambda.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using AudioMass.Extensions;
using AudioMass.Base;

namespace AudioMass.Handler.User
{
    public class Handler : Api
    {
        public async Task<APIGatewayProxyResponse> Get(APIGatewayProxyRequest request, ILambdaContext context)
        {
            var session = GetSession(context);

            return (await new User.Models.User().Get("User", session.AccountId)).CreateResponse();
        }
        
        public async Task<APIGatewayProxyResponse> Update(APIGatewayProxyRequest request, ILambdaContext context)
        {
            var session = GetSession(context);

            var user = request.Body.FromJson<User.Models.User>();
            user.Id = session.AccountId;

            var success = await user.Update("User", this);
            
            return success.CreateResponse();
        }
    }
}
