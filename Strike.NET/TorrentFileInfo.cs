namespace StrikeNET
{
    public class TorrentFileInfo
    {
        public TorrentFileInfo(string fileName, long size)
        {
            FileName = fileName;
            Size = size;
        }

        public string FileName { get; private set; }
        public long Size { get; private set; }
    }
}