#region

using System;
using System.Collections.Generic;

#endregion

namespace StrikeNET
{
    /// <summary>
    ///     Represents a torrent category.
    /// </summary>
    public sealed class Category : IComparable, IComparable<Category>
    {
        /// <summary>
        ///     Initializes a new category.
        /// </summary>
        /// <param name="name">The category name.</param>
        public Category(string name)
        {
            Name = name;
        }

        /// <summary>
        ///     The category name.
        /// </summary>
        public string Name { get; private set; }

        public int CompareTo(object obj)
        {
            var other = obj as Category;
            return CompareTo(other);
        }

        public int CompareTo(Category other)
        {
            return other != null ? string.Compare(Name, other.Name, StringComparison.OrdinalIgnoreCase) : 0;
        }

        #region Hardcoded Categories

        /// <summary>
        ///     Anime
        /// </summary>
        public static Category Anime { get; private set; }

        /// <summary>
        ///     Applications
        /// </summary>
        public static Category Applications { get; private set; }

        /// <summary>
        ///     Books
        /// </summary>
        public static Category Books { get; private set; }

        /// <summary>
        ///     Games
        /// </summary>
        public static Category Games { get; private set; }

        /// <summary>
        ///     Movies
        /// </summary>
        public static Category Movies { get; private set; }

        /// <summary>
        ///     Music
        /// </summary>
        public static Category Music { get; private set; }

        /// <summary>
        ///     Other
        /// </summary>
        public static Category Other { get; private set; }

        /// <summary>
        ///     TV
        /// </summary>
        public static Category TV { get; private set; }

        /// <summary>
        ///     XXX
        /// </summary>
        public static Category XXX { get; private set; }

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
            TV = new Category("TV");
            XXX = new Category("XXX");

            Categories = new List<Category>
            {
                Anime,
                Applications,
                Books,
                Games,
                Movies,
                Music, Other,
                TV,
                XXX
            };
        }

        /// <summary>
        ///     Returns a collection of categories.
        /// </summary>
        /// <returns>Returns an array of categories.</returns>
        public static Category[] GetCategories()
        {
            return Categories.ToArray();
        }

        /// <summary>
        ///     Gets a category by its display name.
        /// </summary>
        /// <param name="name">The category name</param>
        /// <returns>Returns respective category if found, otherwise null.</returns>
        public static Category GetCategoryByName(string name)
        {
            return Categories.Find(x => x.Name.Equals(name, StringComparison.OrdinalIgnoreCase));
        }

        #endregion

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
    }
}