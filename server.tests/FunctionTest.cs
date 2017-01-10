using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Xunit;
using Amazon.Lambda.Core;
using Amazon.Lambda.TestUtilities;

using AudioMass;
using System.IO;

namespace AudioMass.Tests
{
    public class FunctionTest
    {
        public FunctionTest()
        {
            Environment.SetEnvironmentVariable("Test", "test");
        }

        [Fact]
        public async void UpdateUser()
        {
            var body = File.ReadAllText("user.json");

            // Invoke the lambda function and confirm the string was upper cased.
            var function = new Handler.User();
            await function.Update(new Amazon.Lambda.APIGatewayEvents.APIGatewayProxyRequest
            {
                Body = body
            }, new TestLambdaContext());
        }
    }
}
