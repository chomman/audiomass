using Amazon.Lambda.APIGatewayEvents;
using Amazon.Lambda.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using AudioMass.Base;

namespace AudioMass.Extensions
{
    public static class Dynamo
    {
        public static async Task<T> Update<T>(this T model, string objectName, Api apiBase)
        {
            if(model == null)
            {
                return model;
            }
            
            return default(T);

            //todo: get dynamo client and create

            //SuccessResponse success = null;

            //if (typeof(T).GetRuntimeProperties().Any(p => p.Name == "Id"))
            //{
            //    var prop = typeof(T).GetRuntimeProperties().Where(p => p.Name == "Id").First();
            //    var value = prop.GetValue(model);

            //    if (value == null)
            //    {
            //        success = await client.CreateAsync(objectName, model);
            //        prop.SetValue(model, success.Id);
            //    }
            //    else
            //    {
            //        success = await client.UpdateAsync(objectName, value.ToString(), model);
            //    }
                
            //}
            //else
            //{
            //    success = await client.CreateAsync(objectName, model);
            //}

            //if (success.Success)
            //{
            //    return model;
            //}else
            //{
            //    return default(T);
            //}
        }
        public static async Task<T> Get<T>(this T model, string objectName, string id)
        {
            //todo: query dynamo
            //return await client.QueryByIdAsync<T>(objectName, id);
            return default(T);
        }

        public static async Task<T> Get<T>(this T model, string objectName, string field, string value)
        {
            //todo: query dynamo
            //return (await client.QueryByConstraintAsync<T>(objectName, field, "=", value)).FirstOrDefault();
            return default(T);
        }
        
        public static async Task<List<T>> Get<T>(this T model, string objectName, string field, string operand, string value)
        {
            //todo: query dynamo
            //return (await client.QueryByConstraintAsync<T>(objectName, field, operand, value));
            return new List<T>(new T[] { default(T) });
        }
    }
}
