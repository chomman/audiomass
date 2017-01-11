using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace AudioMass.Handler.Spotlight.Models
{
    [DataContract]
    public class SpotlightResponse
    {
        [DataMember(Name = "artist")]
        public Artist Artist { get; set; }
        [DataMember(Name = "feed")]
        public FeedItem FeedItem { get; set; }
        [DataMember(Name = "event")]
        public Event Event { get; set; }
    }
}
