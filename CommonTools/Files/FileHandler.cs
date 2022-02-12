namespace worldwidewhat.CommonTools.Files
{
    public static class FileHandler
    {
        public static string RenameIfFileExists(string filePath)
        {
            if (!File.Exists(filePath)) return filePath;

            return Path.Combine(
                        Path.GetDirectoryName(filePath),
                        $"{Path.GetFileNameWithoutExtension(filePath)}_{DateTime.Now.ToTimestampString()}{Path.GetExtension(filePath)}");
        }
    }
}
