using worldwidewhat.CommonTools.Extensions;

namespace worldwidewhat.CommonTools.Files;

/// <summary>
/// File handling functions
/// Created: 2022-02-12
/// </summary>
public static class FileHandler
{
    /// <summary>
    /// Create new file name if file already exists
    /// </summary>
    /// <param name="filePath">File path</param>
    /// <returns>New file path</returns>
    public static string RenameIfFileExists(string filePath)
    {
        if (!File.Exists(filePath)) return filePath;

        return Path.Combine(
                    Path.GetDirectoryName(filePath)!,
                    $"{Path.GetFileNameWithoutExtension(filePath)}_{DateTime.Now.ToTimestampString()}{Path.GetExtension(filePath)}");
    }
}
