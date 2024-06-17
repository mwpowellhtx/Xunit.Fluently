using System.IO;

// ReSharper disable IdentifierTypo
namespace Xunit
{
    public static partial class IolyExtensionMethods
    {
        private delegate bool FileSystemAssetExistsCallback(string path);

        // ReSharper restore IdentifierTypo
        /// <summary>
        /// Verifies whether the asset represented by the <paramref name="info"/> Exists.
        /// </summary>
        /// <typeparam name="T">The Type of File System asset.</typeparam>
        /// <param name="info">The Informational record being inspected.</param>
        /// <returns>The <paramref name="info"/> following successful Assertion.</returns>
        /// <param name="callback"></param>
        private static T AssertFileSystemAssetExists<T>(this T info, FileSystemAssetExistsCallback callback)
            where T : FileSystemInfo
        {
            Assert.NotNull(callback);
            Assert.True(callback.Invoke(Assert.IsType<T>(info).FullName));
            return info;
        }

        /// <summary>
        /// Verifies whether the asset represented by the <paramref name="info"/> Does Not Exist.
        /// </summary>
        /// <typeparam name="T">The Type of File System asset.</typeparam>
        /// <param name="info">The Informational record being inspected.</param>
        /// <returns>The <paramref name="info"/> following successful Assertion.</returns>
        /// <param name="callback"></param>
        private static T AssertFileSystemAssetDoesNotExist<T>(this T info, FileSystemAssetExistsCallback callback)
            where T : FileSystemInfo
        {
            Assert.NotNull(callback);
            Assert.False(callback.Invoke(Assert.IsType<T>(info).FullName));
            return info;
        }
    }
}