using Amazon.Lambda.Core;
using AudioMass.Session.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AudioMass.Base
{
    public class Api
    {
        private AuthSession _session = null;

        public AuthSession GetSession(ILambdaContext context)
        {
            if (_session == null)
                _session = Session.SessionService.GetSession("");

            return _session;
        }
    }
}
