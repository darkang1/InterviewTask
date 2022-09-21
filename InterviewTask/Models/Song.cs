namespace InterviewTask
{
    public class Song
    {
        public string Id { get; set; }
        public string Title { get; set; }
        public string Artist { get; set; }
        public string Album { get; set; }
        public string UsedWord { get; set; }

        public Song(string id = "N/A",  string title = "No recording found!", string artist = "", string album = "", string usedWord = "Unknown")
        {
            Id = id;
            Title = title;
            Artist = artist;
            Album = album;
            UsedWord = usedWord;
        }      
    }
}
