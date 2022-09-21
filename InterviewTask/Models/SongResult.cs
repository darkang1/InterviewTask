using System;
using System.Text.Json.Serialization;

namespace InterviewTask
{
    public class SongResult
    {
        public DateTime Created { get; set; }
        public Recording[] Recordings { get; set; }
        public string SerchedWord { get; set; }
    }

    public class Recording
    {
        public string Id { get; set; }
        // Song title
        public string Title { get; set; }
        // To get artist name
        [JsonPropertyName("artist-credit")]
        public ArtistCredit[] Artist_credit { get; set; }
        // To get album name
        public Release[] Releases { get; set; }
    }

    public class ArtistCredit
    {
        //public string joinphrase { get; set; }
        public string Name { get; set; }
    }

    public class Release
    {
        public string Id { get; set; }
        // Album name
        public string Title { get; set; }

    }

}
