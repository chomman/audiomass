using Amazon.Lambda.APIGatewayEvents;
using Amazon.Lambda.Core;
using AudioMass.Base;
using AudioMass.Extensions;
using AudioMass.Handler.Spotlight.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AudioMass.Handler.Spotlight
{
    public class Handler : Api
    {
        #region mock
        private List<Models.SpotlightResponse> mock = new List<Models.SpotlightResponse>()
        {
            new Models.SpotlightResponse
            {
                Artist = new Models.Artist {
                    Id = "1",
                    Image = "http://img2-ak.lst.fm/i/u/770x0/c5874804f3b54347c3e2f542a4a7fecd.jpg",
                    Name = "XavierWulf",
                    Genre = new string[] {
                        "Underground",
                        "Trap",
                        "Rap"
                    }
                },
                FeedItem = new Models.FeedItem {
                    Id = "918230198231",
                    Date = "12/12/32"
                },
                Event = new Models.EventSoundCloud {
                    Uri = "http://soundcloud.com/xavierwulf/xavier-wulf-wya-prod-surge",
                    Metadata = new Models.EventSoundCloudMeta {
                        SongName= "Where You At? Prod by Verde"
                    }
                }
            },

            new Models.SpotlightResponse
            {
                Artist = new Models.Artist {
                    Id = "1",
                    Image = "http://img2-ak.lst.fm/i/u/770x0/c5874804f3b54347c3e2f542a4a7fecd.jpg",
                    Name = "XavierWulf",
                    Genre = new string[] {
                        "Underground",
                        "Trap",
                        "Rap"
                    }
                },
                FeedItem = new Models.FeedItem {
                    Id = "918230198231",
                    Date = "12/12/32"
                },
                Event = new Models.EventBandsInTown {
                    Uri = "7730984",
                    Metadata = new Models.EventBandsInTownMeta {
                        LocalTourDate= "Xavier Wulf with Vohrtex and Plvxid at shakas live, Los Angeles"
                    }
                }
            },
            new Models.SpotlightResponse
            {
                Artist = new Models.Artist {
                    Id = "16",
                    Image = "http://i3.ytimg.com/vi/ezrVtBe6hAw/hqdefault.jpg",
                    Name = "My Ticket Home",
                    Genre = new string[] {
                        "Metal",
                        "Nu Metal",
                        "Hardcore"
                    }
                },
                FeedItem = new Models.FeedItem {
                    Id = "23432423",
                    Date = "12/12/32"
                },
                Event = new Models.EventYoutube {
                    Uri = "https://www.youtube.com/embed/ezrVtBe6hAw",
                    Metadata = new EventYoutubeMeta {
                        SongName= "Hot Soap (Official Music Video)"
                    }
                }
            },
            new Models.SpotlightResponse
            {
                Artist = new Models.Artist {
                    Id = "3",
                    Image = "https://i1.sndcdn.com/avatars-000253288059-howh5c-t500x500.jpg",
                    Name = "Lil Peep",
                    Genre = new string[] {
                    "Underground",
                    "Rap",
                    "Pop"
                    }
                },
                FeedItem = new Models.FeedItem {
                    Id = "5234234234",
                    Date = "12/12/32"
                },
                Event = new Models.EventSoundCloud {
                    Uri = "https://soundcloud.com/lil_peep/yesterday-prod-charlie-shuffler",
                    Metadata = new Models.EventSoundCloudMeta {
                        SongName= "yesterday (prod. charlie shuffler)"
                    }
                }
            },
        };
        #endregion
        private Models.SpotlightResponse[] GenerateMock()
        {
            return mock.ToArray();
        }
        public async Task<APIGatewayProxyResponse> Get(APIGatewayProxyRequest request, ILambdaContext context)
        {
            return GenerateMock().CreateResponse();

            //var session = GetSession(context);

            //return (await new Models.SpotlightResponse().Get("User", session.AccountId)).CreateResponse();
        }
    }
}
