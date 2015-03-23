#region

using System.Collections.Generic;

#endregion

namespace StrikeNET
{
    public class FileInfo
    {
        public List<string> FileNames { get; set; }
        public List<long> FileLengths { get; set; }
    }
}