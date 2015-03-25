#region

using System.IO;

#endregion

namespace StrikeNET
{
    /// <summary>
    ///     Represents an individual file within a torrent.
    /// </summary>
    public class TorrentFileInfo
    {
        /// <summary>
        ///     Initializes a new TorrentFileInfo.
        /// </summary>
        /// <param name="fileName">The file name.</param>
        /// <param name="size">The file size.</param>
        public TorrentFileInfo(string fileName, long size)
        {
            FileName = fileName;
            Size = size;
        }

        /// <summary>
        ///     The file name.
        /// </summary>
        public string FileName { get; private set; }

        /// <summary>
        ///     The file size.
        /// </summary>
        public long Size { get; private set; }

        /// <summary>
        ///     Returns a FileInfo instance of the TorrentFileInfo filename.
        /// </summary>
        /// <returns>Returns a FileInfo instance.</returns>
        public FileInfo ToFileInfo()
        {
            return new FileInfo(FileName);
        }
    }
}