#region

using System;
using System.Collections.Generic;

#endregion

namespace StrikeNET
{
    /// <summary>
    ///     Represents a torrent category.
    /// </summary>
    public sealed class Category
    {
        public Category(string name)
        {
            Name = name;
        }

        public string Name { get; private set; }

        public override string ToString()
        {
            return Name;
        }

        public static bool operator ==(Category a, Category b)
        {
            if (ReferenceEquals(a, b))
                return true;

            if (((object) a == null) || ((object) b == null))
                return false;

            return a.Name == b.Name;
        }

        public static bool operator !=(Category x, Category y)
        {
            return !(x == y);
        }

        public bool Equals(Category other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return Equals(other.Name, Name);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != typeof (Category)) return false;
            return Equals((Category) obj);
        }

        public override int GetHashCode()
        {
            return (Name != null ? Name.GetHashCode() : 0);
        }

        #region Natively Supported Types

        public static Category Anime { get; private set; }
        public static Category Applications { get; private set; }
        public static Category Books { get; private set; }
        public static Category Games { get; private set; }
        public static Category Movies { get; private set; }
        public static Category Music { get; private set; }
        public static Category Other { get; private set; }
        public static Category Tv { get; private set; }
        public static Category Xxx { get; private set; }

        #endregion

        #region Static Methods

        private static readonly List<Category> Categories = new List<Category>();

        static Category()
        {
            Anime = new Category("Anime");
            Applications = new Category("Applications");
            Books = new Category("Books");
            Games = new Category("Games");
            Movies = new Category("Movies");
            Music = new Category("Music");
            Other = new Category("Other");
            Tv = new Category("TV");
            Xxx = new Category("XXX");

            Categories = new List<Category>
            {
                Anime,
                Applications,
                Books,
                Games,
                Movies,
                Music, Other, Tv, Xxx
            };
        }

        public static Category[] GetCategories()
        {
            return Categories.ToArray();
        }

        public static Category GetTypeByName(string name)
        {
            return Categories.Find(x => x.Name.Equals(name, StringComparison.OrdinalIgnoreCase));
        }

        #endregion
    }
}