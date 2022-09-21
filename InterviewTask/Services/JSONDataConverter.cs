namespace InterviewTask
{
    public static class JSONDataConverter
    {
        public static Song SongResultToSong(SongResult result, string searchWord)
        {
            if (result == null)
                return new Song();

            string id = result?.Recordings?[0]?.Id;
            string title = result?.Recordings?[0].Title ?? "Record not found!";
            string artist = result?.Recordings?[0].ArtistCredit?[0].Name ?? "Unknown";
            string album = result?.Recordings?[0].Releases?[0].Title ?? "Unknown";

            // Checking if song is found by looking at its song id
            if (string.IsNullOrWhiteSpace(id) || id.Equals(GlobalConstants.InvalidSongId))
                return new Song(usedWord: searchWord);

            return new Song(id, title, artist, album, searchWord);
        }

    }
}
