namespace worldwidewhat.CommonTools.Files;

/// <summary>
/// Directory handling functions
/// Created: 2022-02-12
/// </summary>
public static class DirectoryHandler
{
    /// <summary>
    /// Get new directory path if path exists
    /// </summary>
    /// <param name="directoryPath">Directory path</param>
    /// <returns>new path</returns>
    public static string RenameIfFileExists(string directoryPath)
    {
        if (!Directory.Exists(directoryPath)) return directoryPath;
        return $"{directoryPath}_{DateTime.Now:yyyyMMddHHmmss}";
    }

    /// <summary>
    /// Clear directory for content
    /// </summary>
    /// <param name="directoryPath">Path to clear</param>
    /// <param name="recursive">Delete data recursive</param>
    public static void ClearContent(string directoryPath, bool recursive=false)
    {
        if (directoryPath == null) return;
        DirectoryInfo directoryInfo = new(directoryPath);
        foreach (FileInfo file in directoryInfo.GetFiles())
            file.Delete();
        if (!recursive) return;
        foreach (DirectoryInfo subDirectory in directoryInfo.GetDirectories())
            Directory.Delete(subDirectory.FullName, true);
    }
}
