using System.Collections;

namespace Task4
{
    class Song
    {
        public string Title { get; set; }
        public string Artist { get; set; }

        public Song(string title, string artist)
        {
            Title = title;
            Artist = artist;
        }

        public override string ToString()
        {
            return $"{Title} by {Artist}";
        }

        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }

            Song other = (Song)obj;
            return Title == other.Title && Artist == other.Artist;
        }

        public override int GetHashCode()
        {
            return Title.GetHashCode() ^ Artist.GetHashCode();
        }
    }

    class MusicDisc : IEnumerable<Song>
    {
        public string Title { get; set; }
        private List<Song> songs = new List<Song>();

        public MusicDisc(string title)
        {
            Title = title;
        }

        public void AddSong(Song song)
        {
            songs.Add(song);
        }

        public void RemoveSong(Song song)
        {
            songs.Remove(song);
        }

        public void Display()
        {
            Console.WriteLine($"Music disc: {Title}");
            foreach (Song song in songs)
            {
                Console.WriteLine(song);
            }
        }

        public IEnumerator<Song> GetEnumerator()
        {
            return songs.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }

    class MusicCatalog
    {
        private Hashtable discs = new Hashtable();

        public void AddDisc(string title)
        {
            discs[title] = new MusicDisc(title);
        }

        public void RemoveDisc(string title)
        {
            discs.Remove(title);
        }

        public void AddSongToDisc(string discTitle, Song song)
        {
            if (discs.ContainsKey(discTitle))
            {
                ((MusicDisc)discs[discTitle]).AddSong(song);
            }
            else
            {
                Console.WriteLine("Disc not found");
            }
        }

        public void RemoveSongFromDisc(string discTitle, Song song)
        {
            if (discs.ContainsKey(discTitle))
            {
                ((MusicDisc)discs[discTitle]).RemoveSong(song);
            }
            else
            {
                Console.WriteLine("Disc not found");
            }
        }

        public void DisplayCatalog()
        {
            foreach (MusicDisc disc in discs.Values)
            {
                disc.Display();
            }
        }

        public void SearchByArtist(string artist)
        {
            Console.WriteLine($"Result for '{artist}': ");
            foreach (MusicDisc disc in discs.Values)
            {
                foreach (Song song in disc)
                {
                    if (song.Artist.Equals(artist, StringComparison.OrdinalIgnoreCase))
                    {
                        Console.WriteLine($"Disc: {disc.Title}, \tSong: {song.Title}");
                    }
                }
            }
        }
    }

    class Program
    {
        public static void Main_Task4()
        {
            MusicCatalog catalog = new MusicCatalog();

            catalog.AddDisc("Best Hits");
            catalog.AddDisc("Rock Classics");

            catalog.AddSongToDisc("Best Hits", new Song("Song 1", "Artist A"));
            catalog.AddSongToDisc("Best Hits", new Song("Song 2", "Artist B"));
            catalog.AddSongToDisc("Rock Classics", new Song("Song 3", "Artist A"));
            catalog.AddSongToDisc("Rock Classics", new Song("Song 4", "Artist A"));

            catalog.DisplayCatalog();

            Console.WriteLine("\n");
            catalog.SearchByArtist("Artist A");

            Console.WriteLine("\n");
            catalog.SearchByArtist("Artist B");

            Console.WriteLine("\nRemove song:");
            catalog.RemoveSongFromDisc("Rock Classics", new Song("Song 3", "Artist A"));
            catalog.DisplayCatalog();

            catalog.RemoveDisc("Rock Classics");

            Console.WriteLine("\nRemove catalog: ");
            catalog.DisplayCatalog();
        }
    }
}