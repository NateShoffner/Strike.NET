#region

using System;
using System.Collections.Generic;

#endregion

namespace StrikeNET
{
    /// <summary>
    ///     Represents a torrent Subcategory.
    /// </summary>
    public sealed class Subcategory : IComparable, IComparable<Subcategory>
    {
        /// <summary>
        ///     Initializes a new subcategory.
        /// </summary>
        /// <param name="name">The subcategory name.</param>
        public Subcategory(string name)
        {
            Name = name;
        }

        /// <summary>
        ///     The subcategory name.
        /// </summary>
        public string Name { get; private set; }

        public int CompareTo(object obj)
        {
            var other = obj as Subcategory;
            return CompareTo(other);
        }

        public int CompareTo(Subcategory other)
        {
            return other != null ? string.Compare(Name, other.Name, StringComparison.OrdinalIgnoreCase) : 0;
        }

        #region Hardcoded Subcategories

        /// <summary>
        ///     Highres Movies
        /// </summary>
        public static Subcategory HighresMovies { get; private set; }

        /// <summary>
        ///     Hentai
        /// </summary>
        public static Subcategory Hentai { get; private set; }

        /// <summary>
        ///     HD Video
        /// </summary>
        public static Subcategory HDVideo { get; private set; }

        /// <summary>
        ///     Handheld
        /// </summary>
        public static Subcategory Handheld { get; private set; }

        /// <summary>
        ///     Games
        /// </summary>
        public static Subcategory Games { get; private set; }

        /// <summary>
        ///     Fiction
        /// </summary>
        public static Subcategory Fiction { get; private set; }

        /// <summary>
        ///     English-translated
        /// </summary>
        public static Subcategory EnglishTranslated { get; private set; }

        /// <summary>
        ///     Ebooks
        /// </summary>
        public static Subcategory Ebooks { get; private set; }

        /// <summary>
        ///     Dubbed Movies
        /// </summary>
        public static Subcategory DubbedMovies { get; private set; }

        /// <summary>
        ///     Documentary
        /// </summary>
        public static Subcategory Documentary { get; private set; }

        /// <summary>
        ///     Concerts
        /// </summary>
        public static Subcategory Concerts { get; private set; }

        /// <summary>
        ///     Comics
        /// </summary>
        public static Subcategory Comics { get; private set; }

        /// <summary>
        ///     Books
        /// </summary>
        public static Subcategory Books { get; private set; }

        /// <summary>
        ///     Bollywood
        /// </summary>
        public static Subcategory Bollywood { get; private set; }

        /// <summary>
        ///     Audio books
        /// </summary>
        public static Subcategory Audiobooks { get; private set; }

        /// <summary>
        ///     Asian
        /// </summary>
        public static Subcategory Asian { get; private set; }

        /// <summary>
        ///     Anime Music Video
        /// </summary>
        public static Subcategory AnimeMusicVideo { get; private set; }

        /// <summary>
        ///     Animation
        /// </summary>
        public static Subcategory Animation { get; private set; }

        /// <summary>
        ///     Android
        /// </summary>
        public static Subcategory Android { get; private set; }

        /// <summary>
        ///     Academic
        /// </summary>
        public static Subcategory Academic { get; private set; }

        /// <summary>
        ///     AAC
        /// </summary>
        public static Subcategory AAC { get; private set; }

        /// <summary>
        ///     3D Movies
        /// </summary>
        public static Subcategory Movies3D { get; private set; }

        /// <summary>
        ///     XBOX360
        /// </summary>
        public static Subcategory XBOX360 { get; private set; }

        /// <summary>
        ///     Windows
        /// </summary>
        public static Subcategory Windows { get; private set; }

        /// <summary>
        ///     Wii
        /// </summary>
        public static Subcategory Wii { get; private set; }

        /// <summary>
        ///     Wallpapers
        /// </summary>
        public static Subcategory Wallpapers { get; private set; }

        /// <summary>
        ///     Video
        /// </summary>
        public static Subcategory Video { get; private set; }

        /// <summary>
        ///     Unsorted
        /// </summary>
        public static Subcategory Unsorted { get; private set; }

        /// <summary>
        ///     UNIX
        /// </summary>
        public static Subcategory UNIX { get; private set; }

        /// <summary>
        ///     UltraHD
        /// </summary>
        public static Subcategory UltraHD { get; private set; }

        /// <summary>
        ///     Tutorials
        /// </summary>
        public static Subcategory Tutorials { get; private set; }

        /// <summary>
        ///     Transcode
        /// </summary>
        public static Subcategory Transcode { get; private set; }

        /// <summary>
        ///     Trailer
        /// </summary>
        public static Subcategory Trailer { get; private set; }

        /// <summary>
        ///     Textbooks
        /// </summary>
        public static Subcategory Textbooks { get; private set; }

        /// <summary>
        ///     Subtitles
        /// </summary>
        public static Subcategory Subtitles { get; private set; }

        /// <summary>
        ///     Soundtrack
        /// </summary>
        public static Subcategory Soundtrack { get; private set; }

        /// <summary>
        ///     Sound clips
        /// </summary>
        public static Subcategory Soundclips { get; private set; }

        /// <summary>
        ///     Radio Shows
        /// </summary>
        public static Subcategory RadioShows { get; private set; }

        /// <summary>
        ///     PSP
        /// </summary>
        public static Subcategory PSP { get; private set; }

        /// <summary>
        ///     PS3
        /// </summary>
        public static Subcategory PS3 { get; private set; }

        /// <summary>
        ///     PS2
        /// </summary>
        public static Subcategory PS2 { get; private set; }

        /// <summary>
        ///     Poetry
        /// </summary>
        public static Subcategory Poetry { get; private set; }

        /// <summary>
        ///     Pictures
        /// </summary>
        public static Subcategory Pictures { get; private set; }

        /// <summary>
        ///     PC
        /// </summary>
        public static Subcategory PC { get; private set; }

        /// <summary>
        ///     Other XXX
        /// </summary>
        public static Subcategory OtherXXX { get; private set; }

        /// <summary>
        ///     Other TV
        /// </summary>
        public static Subcategory OtherTV { get; private set; }

        /// <summary>
        ///     Other Music
        /// </summary>
        public static Subcategory OtherMusic { get; private set; }

        /// <summary>
        ///     Other Movies
        /// </summary>
        public static Subcategory OtherMovies { get; private set; }

        /// <summary>
        ///     Other Games
        /// </summary>
        public static Subcategory OtherGames { get; private set; }

        /// <summary>
        ///     Other Books
        /// </summary>
        public static Subcategory OtherBooks { get; private set; }

        /// <summary>
        ///     Other Applications
        /// </summary>
        public static Subcategory OtherApplications { get; private set; }

        /// <summary>
        ///     Other Anime
        /// </summary>
        public static Subcategory OtherAnime { get; private set; }

        /// <summary>
        ///     Non-fiction
        /// </summary>
        public static Subcategory Nonfiction { get; private set; }

        /// <summary>
        ///     Newspapers
        /// </summary>
        public static Subcategory Newspapers { get; private set; }

        /// <summary>
        ///     Music videos
        /// </summary>
        public static Subcategory Musicvideos { get; private set; }

        /// <summary>
        ///     Mp3
        /// </summary>
        public static Subcategory Mp3 { get; private set; }

        /// <summary>
        ///     Movie clips
        /// </summary>
        public static Subcategory Movieclips { get; private set; }

        /// <summary>
        ///     Magazines
        /// </summary>
        public static Subcategory Magazines { get; private set; }

        /// <summary>
        ///     Mac
        /// </summary>
        public static Subcategory Mac { get; private set; }

        /// <summary>
        ///     Lossless
        /// </summary>
        public static Subcategory Lossless { get; private set; }

        /// <summary>
        ///     Linux
        /// </summary>
        public static Subcategory Linux { get; private set; }

        /// <summary>
        ///     Karaoke
        /// </summary>
        public static Subcategory Karaoke { get; private set; }

        /// <summary>
        ///     iOS
        /// </summary>
        public static Subcategory iOS { get; private set; }

        #endregion

        #region Static Methods

        private static readonly List<Subcategory> Subcategories = new List<Subcategory>();

        static Subcategory()
        {
            HighresMovies = new Subcategory("Highres Movies");
            Hentai = new Subcategory("Hentai");
            HDVideo = new Subcategory("HD Video");
            Handheld = new Subcategory("Handheld");
            Games = new Subcategory("Games");
            Fiction = new Subcategory("Fiction");
            EnglishTranslated = new Subcategory("English-translated");
            Ebooks = new Subcategory("Ebooks");
            DubbedMovies = new Subcategory("Dubbed Movies");
            Documentary = new Subcategory("Documentary");
            Concerts = new Subcategory("Concerts");
            Comics = new Subcategory("Comics");
            Books = new Subcategory("Books");
            Bollywood = new Subcategory("Bollywood");
            Audiobooks = new Subcategory("Audiobooks");
            Asian = new Subcategory("Asian");
            AnimeMusicVideo = new Subcategory("Anime Music Video");
            Animation = new Subcategory("Animation");
            Android = new Subcategory("Android");
            Academic = new Subcategory("Academic");
            AAC = new Subcategory("AAC");
            Movies3D = new Subcategory("3D Movies");
            XBOX360 = new Subcategory("XBOX360");
            Windows = new Subcategory("Windows");
            Wii = new Subcategory("Wii");
            Wallpapers = new Subcategory("Wallpapers");
            Video = new Subcategory("Video");
            Unsorted = new Subcategory("Unsorted");
            UNIX = new Subcategory("UNIX");
            UltraHD = new Subcategory("UltraHD");
            Tutorials = new Subcategory("Tutorials");
            Transcode = new Subcategory("Transcode");
            Trailer = new Subcategory("Trailer");
            Textbooks = new Subcategory("Textbooks");
            Subtitles = new Subcategory("Subtitles");
            Soundtrack = new Subcategory("Soundtrack");
            Soundclips = new Subcategory("Soun dclips");
            RadioShows = new Subcategory("Radio Shows");
            PSP = new Subcategory("PSP");
            PS3 = new Subcategory("PS3");
            PS2 = new Subcategory("PS2");
            Poetry = new Subcategory("Poetry");
            Pictures = new Subcategory("Pictures");
            PC = new Subcategory("PC");
            OtherXXX = new Subcategory("Other XXX");
            OtherTV = new Subcategory("Other TV");
            OtherMusic = new Subcategory("Other Music");
            OtherMovies = new Subcategory("Other Movies");
            OtherGames = new Subcategory("Other Games");
            OtherBooks = new Subcategory("Other Books");
            OtherApplications = new Subcategory("Other Applications");
            OtherAnime = new Subcategory("Other Anime");
            Nonfiction = new Subcategory("Non-fiction");
            Newspapers = new Subcategory("Newspapers");
            Musicvideos = new Subcategory("Musicvideos");
            Mp3 = new Subcategory("Mp3");
            Movieclips = new Subcategory("Movie clips");
            Magazines = new Subcategory("Magazines");
            Mac = new Subcategory("Mac");
            Lossless = new Subcategory("Lossless");
            Linux = new Subcategory("Linux");
            Karaoke = new Subcategory("Karaoke");
            iOS = new Subcategory("iOS");

            Subcategories = new List<Subcategory>
            {
                HighresMovies,
                Hentai,
                HDVideo,
                Handheld,
                Games,
                Fiction,
                EnglishTranslated,
                Ebooks,
                DubbedMovies,
                Documentary,
                Concerts,
                Comics,
                Books,
                Bollywood,
                Audiobooks,
                Asian,
                AnimeMusicVideo,
                Animation,
                Android,
                Academic,
                AAC,
                Movies3D,
                XBOX360,
                Windows,
                Wii,
                Wallpapers,
                Video,
                Unsorted,
                UNIX,
                UltraHD,
                Tutorials,
                Transcode,
                Trailer,
                Textbooks,
                Subtitles,
                Soundtrack,
                Soundclips,
                RadioShows,
                PSP,
                PS3,
                PS2,
                Poetry,
                Pictures,
                PC,
                OtherXXX,
                OtherTV,
                OtherMusic,
                OtherMovies,
                OtherGames,
                OtherBooks,
                OtherApplications,
                OtherAnime,
                Nonfiction,
                Newspapers,
                Musicvideos,
                Mp3,
                Movieclips,
                Magazines,
                Mac,
                Lossless,
                Linux,
                Karaoke,
                iOS,
            };
        }

        /// <summary>
        ///     Returns a collection of subcategories.
        /// </summary>
        /// <returns>Returns an array of subcategories.</returns>
        public static Subcategory[] GetSubcategories()
        {
            return Subcategories.ToArray();
        }

        /// <summary>
        ///     Gets a subcategory by its display name.
        /// </summary>
        /// <param name="name">The subcategory name</param>
        /// <returns>Returns respective subcategory if found, otherwise null.</returns>
        public static Subcategory GetSubcategoryByName(string name)
        {
            return Subcategories.Find(x => x.Name.Equals(name, StringComparison.OrdinalIgnoreCase));
        }

        #endregion

        public override string ToString()
        {
            return Name;
        }

        public static bool operator ==(Subcategory a, Subcategory b)
        {
            if (ReferenceEquals(a, b))
                return true;

            if (((object) a == null) || ((object) b == null))
                return false;

            return a.Name == b.Name;
        }

        public static bool operator !=(Subcategory x, Subcategory y)
        {
            return !(x == y);
        }

        public bool Equals(Subcategory other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return Equals(other.Name, Name);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != typeof (Subcategory)) return false;
            return Equals((Subcategory) obj);
        }
    }
}