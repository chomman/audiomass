using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace AudioMass.Handler.Spotlight.Models
{
    [DataContract]
    public class Artist
    {
        [DataMember(Name="id")]
        public string Id { get; set; }
        [DataMember(Name = "image")]
        public string Image { get; set; }
        [DataMember(Name = "name")]
        public string Name { get; set; }
        [DataMember(Name = "genre")]
        public string[] Genre { get; set; }
    }
}
