using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace AudioMass.Handler.Spotlight.Models
{
    [DataContract]
    public abstract class Event
    {
        [DataMember(Name = "type")]
        public abstract EventType Type { get; }
        [DataMember(Name = "uri")]
        public string Uri { get; set; }
    }

    public enum EventType
    {
        SoundCloud = 1,
        Youtube = 2,
        BandsInTown = 3
    }

    [DataContract]
    public class EventMeta
    {

    }

    [DataContract]
    public class EventSoundCloud : Event
    {
        public override EventType Type { get; } = EventType.SoundCloud;
        [DataMember(Name = "meta")]
        public EventSoundCloudMeta Metadata { get; set; }
    }

    [DataContract]
    public class EventSoundCloudMeta : EventMeta
    {
        [DataMember(Name = "songName")]
        public string SongName { get; set; }
    }


    [DataContract]
    public class EventYoutube : Event
    {
        public override EventType Type { get; } = EventType.Youtube;
        [DataMember(Name = "meta")]
        public EventYoutubeMeta Metadata { get; set; }
    }

    [DataContract]
    public class EventYoutubeMeta : EventMeta
    {
        

        [DataMember(Name = "songName")]
        public string SongName { get; set; }
    }

    [DataContract]
    public class EventBandsInTown : Event
    {
        public override EventType Type { get; } = EventType.BandsInTown;
        [DataMember(Name = "meta")]
        public EventBandsInTownMeta Metadata { get; set; }
    }
    [DataContract]
    public class EventBandsInTownMeta : EventMeta
    {
        [DataMember(Name = "localTourDate")]
        public string LocalTourDate { get; set; }
    }
}
