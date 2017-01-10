using AudioMass.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AudioMass.Session
{
    public class SessionService
    {
        public static AuthSession GetSession(string bearerToken)
        {
            return new AuthSession
            {
                AccountId = "0014100000CQnTw"
            };
        }
    }
}
