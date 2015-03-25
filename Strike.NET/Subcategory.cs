#region

using System;
using System.Collections.Generic;

#endregion

namespace StrikeNET
{
    /// <summary>
    ///     Represents a torrent Subcategory.
    /// </summary>
    public sealed class Subcategory
    {
        public Subcategory(string name)
        {
            Name = name;
        }

        public string Name { get; private set; }

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

        public override int GetHashCode()
        {
            return (Name != null ? Name.GetHashCode() : 0);
        }

        #region Hardcoded Subcategories

        public static Subcategory HighresMovies { get; private set; }
        public static Subcategory Hentai { get; private set; }
        public static Subcategory HDVideo { get; private set; }
        public static Subcategory Handheld { get; private set; }
        public static Subcategory Games { get; private set; }
        public static Subcategory Fiction { get; private set; }
        public static Subcategory EnglishTranslated { get; private set; }
        public static Subcategory Ebooks { get; private set; }
        public static Subcategory DubbedMovies { get; private set; }
        public static Subcategory Documentary { get; private set; }
        public static Subcategory Concerts { get; private set; }
        public static Subcategory Comics { get; private set; }
        public static Subcategory Books { get; private set; }
        public static Subcategory Bollywood { get; private set; }
        public static Subcategory Audiobooks { get; private set; }
        public static Subcategory Asian { get; private set; }
        public static Subcategory AnimeMusicVideo { get; private set; }
        public static Subcategory Animation { get; private set; }
        public static Subcategory Android { get; private set; }
        public static Subcategory Academic { get; private set; }
        public static Subcategory AAC { get; private set; }
        public static Subcategory Movies3D { get; private set; }
        public static Subcategory XBOX360 { get; private set; }
        public static Subcategory Windows { get; private set; }
        public static Subcategory Wii { get; private set; }
        public static Subcategory Wallpapers { get; private set; }
        public static Subcategory Video { get; private set; }
        public static Subcategory Unsorted { get; private set; }
        public static Subcategory UNIX { get; private set; }
        public static Subcategory UltraHD { get; private set; }
        public static Subcategory Tutorials { get; private set; }
        public static Subcategory Transcode { get; private set; }
        public static Subcategory Trailer { get; private set; }
        public static Subcategory Textbooks { get; private set; }
        public static Subcategory Subtitles { get; private set; }
        public static Subcategory Soundtrack { get; private set; }
        public static Subcategory Soundclips { get; private set; }
        public static Subcategory RadioShows { get; private set; }
        public static Subcategory PSP { get; private set; }
        public static Subcategory PS3 { get; private set; }
        public static Subcategory PS2 { get; private set; }
        public static Subcategory Poetry { get; private set; }
        public static Subcategory Pictures { get; private set; }
        public static Subcategory PC { get; private set; }
        public static Subcategory OtherXXX { get; private set; }
        public static Subcategory OtherTV { get; private set; }
        public static Subcategory OtherMusic { get; private set; }
        public static Subcategory OtherMovies { get; private set; }
        public static Subcategory OtherGames { get; private set; }
        public static Subcategory OtherBooks { get; private set; }
        public static Subcategory OtherApplications { get; private set; }
        public static Subcategory OtherAnime { get; private set; }
        public static Subcategory Nonfiction { get; private set; }
        public static Subcategory Newspapers { get; private set; }
        public static Subcategory Musicvideos { get; private set; }
        public static Subcategory Mp3 { get; private set; }
        public static Subcategory Movieclips { get; private set; }
        public static Subcategory Magazines { get; private set; }
        public static Subcategory Mac { get; private set; }
        public static Subcategory Lossless { get; private set; }
        public static Subcategory Linux { get; private set; }
        public static Subcategory Karaoke { get; private set; }
        public static Subcategory iOS { get; private set; }

        #endregion

        #region Static Methods

        private static readonly List<Subcategory> Subcategories = new List<Subcategory>();

        static Subcategory()
        {
            HighresMovies = new Subcategory("HighresMovies");
            Hentai = new Subcategory("Hentai");
            HDVideo = new Subcategory("HDVideo");
            Handheld = new Subcategory("Handheld");
            Games = new Subcategory("Games");
            Fiction = new Subcategory("Fiction");
            EnglishTranslated = new Subcategory("English-translated");
            Ebooks = new Subcategory("Ebooks");
            DubbedMovies = new Subcategory("DubbedMovies");
            Documentary = new Subcategory("Documentary");
            Concerts = new Subcategory("Concerts");
            Comics = new Subcategory("Comics");
            Books = new Subcategory("Books");
            Bollywood = new Subcategory("Bollywood");
            Audiobooks = new Subcategory("Audiobooks");
            Asian = new Subcategory("Asian");
            AnimeMusicVideo = new Subcategory("AnimeMusicVideo");
            Animation = new Subcategory("Animation");
            Android = new Subcategory("Android");
            Academic = new Subcategory("Academic");
            AAC = new Subcategory("AAC");
            Movies3D = new Subcategory("3DMovies");
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
            Soundclips = new Subcategory("Soundclips");
            RadioShows = new Subcategory("RadioShows");
            PSP = new Subcategory("PSP");
            PS3 = new Subcategory("PS3");
            PS2 = new Subcategory("PS2");
            Poetry = new Subcategory("Poetry");
            Pictures = new Subcategory("Pictures");
            PC = new Subcategory("PC");
            OtherXXX = new Subcategory("OtherXXX");
            OtherTV = new Subcategory("OtherTV");
            OtherMusic = new Subcategory("OtherMusic");
            OtherMovies = new Subcategory("OtherMovies");
            OtherGames = new Subcategory("OtherGames");
            OtherBooks = new Subcategory("OtherBooks");
            OtherApplications = new Subcategory("OtherApplications");
            OtherAnime = new Subcategory("OtherAnime");
            Nonfiction = new Subcategory("Non-fiction");
            Newspapers = new Subcategory("Newspapers");
            Musicvideos = new Subcategory("Musicvideos");
            Mp3 = new Subcategory("Mp3");
            Movieclips = new Subcategory("Movieclips");
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

        public static Subcategory[] GetCategories()
        {
            return Subcategories.ToArray();
        }

        public static Subcategory GetCategoryByName(string name)
        {
            return Subcategories.Find(x => x.Name.Equals(name, StringComparison.OrdinalIgnoreCase));
        }

        #endregion
    }
}