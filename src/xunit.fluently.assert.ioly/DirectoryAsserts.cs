using System.IO;

// ReSharper disable IdentifierTypo
namespace Xunit
{
    public static partial class IolyExtensionMethods
    {
        /// <summary>
        /// Verifies whether the <paramref name="path"/> Directory <see cref="Directory.Exists"/>.
        /// </summary>
        /// <param name="path">The Path of the directory being inspected.</param>
        /// <returns>The <paramref name="path"/> following successful Assertion.</returns>
        public static string AssertDirectoryExists(this string path)
        {
            new DirectoryInfo(path).AssertFileSystemAssetExists(Directory.Exists);
            return path;
        }

        /// <summary>
        /// Verifies whether the <paramref name="path"/> Directory Does Not
        /// <see cref="Directory.Exists"/>.
        /// </summary>
        /// <param name="path">The Path of the directory being inspected.</param>
        /// <returns>The <paramref name="path"/> following successful Assertion.</returns>
        public static string AssertDirectoryDoesNotExist(this string path)
        {
            new DirectoryInfo(path).AssertFileSystemAssetDoesNotExist(Directory.Exists);
            return path;
        }
    }
}