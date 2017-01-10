using Amazon.Lambda.APIGatewayEvents;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace AudioMass.Extensions
{
    public static class Response
    {
        private static Amazon.Lambda.Serialization.Json.JsonSerializer Serializer = new Amazon.Lambda.Serialization.Json.JsonSerializer();

        public static string ToJson(this object obj)
        {
            using (StringWriter sw = new StringWriter())
            {
                JsonSerializer serializer = new JsonSerializer();
                serializer.Serialize(sw, obj);

                return sw.ToString();
            }
        }

        public static T FromJson<T>(this string serializedObject)
        {

            T body;
            //--- Deserialize
            using (StringReader sr = new StringReader(serializedObject))
            using (JsonTextReader tr = new JsonTextReader(sr))
            {
                tr.Read();

                var ds = new Newtonsoft.Json.JsonSerializer();

                ds.ConstructorHandling = ConstructorHandling.AllowNonPublicDefaultConstructor;

                body = ds.Deserialize<T>(tr);
            }

            return body;

        }

        public static APIGatewayProxyResponse CreateResponse(this object model)
        {
            return new APIGatewayProxyResponse
            {
                StatusCode = (int)(model == null ? HttpStatusCode.NoContent : HttpStatusCode.OK),
                Body = ToJson(model ?? ""),
                Headers = new Dictionary<string, string> {
                    { "Content-Type", "application/json" },
                    { "Access-Control-Allow-Origin", "*"  }
                }


            };
        }

        public static APIGatewayProxyResponse CreateErrorResponse<T>(this T model)
        {
            return new APIGatewayProxyResponse
            {
                StatusCode = (int)(HttpStatusCode.BadRequest),
                Body = ToJson(model),
                Headers = new Dictionary<string, string> { { "Content-Type", "application/json" } }
            };
        }
    }
}
