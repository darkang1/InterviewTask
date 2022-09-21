using System.Text.Json.Serialization;

namespace InterviewTask
{
    public class SongResult
    {
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
        public ArtistCredit[] ArtistCredit { get; set; }
        // To get album name
        public Release[] Releases { get; set; }
    }

    public class ArtistCredit
    {
        public string Name { get; set; }
    }

    public class Release
    {
        // Album name
        public string Title { get; set; }

    }

}
