namespace InterviewTask
{
    public class Song
    {
        public string Id { get; private set; }
        public string Title { get; private set; }
        public string Artist { get; private set; }
        public string Album { get; private set; }
        public string UsedWord { get; private set; }

        public Song(string id = "N/A",  string title = "Record Not Found!", string artist = "", string album = "", string usedWord = "Unknown")
        {
            Id = id;
            Title = title;
            Artist = artist;
            Album = album;
            UsedWord = usedWord;
        }      
    }
}
