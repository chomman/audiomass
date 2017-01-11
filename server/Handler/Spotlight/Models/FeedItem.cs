using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace AudioMass.Handler.Spotlight.Models
{
    [DataContract]
    public class FeedItem
    {
        [DataMember(Name = "id")]
        public string Id { get; set; }
        [DataMember(Name = "date")]
        public string Date { get; set; }
    }
}
