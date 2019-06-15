using System;
using System.IO;

// ReSharper disable IdentifierTypo
namespace Xunit
{
    public static partial class IolyExtensionMethods
    {
        // ReSharper restore IdentifierTypo
        /// <summary>
        /// Verifies whether the asset represented by the <paramref name="info"/> Exists.
        /// </summary>
        /// <typeparam name="T">The Type of File System asset.</typeparam>
        /// <param name="info">The Informational record being inspected.</param>
        /// <returns>The <paramref name="info"/> following successful Assertion.</returns>
        public static T AssertFileSystemAssetExists<T>(this T info)
            where T : FileSystemInfo
        {
            Assert.True(File.Exists(Assert.IsType<FileInfo>(info).FullName));
            return info;
        }

        /// <summary>
        /// Verifies whether the <paramref name="path"/> File Exists.
        /// </summary>
        /// <param name="path">The Path of the file being inspected.</param>
        /// <returns>The <paramref name="path"/> following successful Assertion.</returns>
        public static string AssertFileExists(this string path)
        {
            new FileInfo(path).AssertFileSystemAssetExists();
            return path;
        }

        /// <summary>
        /// Verifies whether the asset represented by the <paramref name="info"/> Does Not Exist.
        /// </summary>
        /// <typeparam name="T">The Type of File System asset.</typeparam>
        /// <param name="info">The Informational record being inspected.</param>
        /// <returns>The <paramref name="info"/> following successful Assertion.</returns>
        public static T AssertFileSystemAssetDoesNotExist<T>(this T info)
            where T : FileSystemInfo
        {
            Assert.False(File.Exists(Assert.IsType<FileInfo>(info).FullName));
            return info;
        }

        /// <summary>
        /// Verifies whether the <paramref name="path"/> File Does Not Exist.
        /// </summary>
        /// <param name="path">The Path of the file being inspected.</param>
        /// <returns>The <paramref name="path"/> following successful Assertion.</returns>
        public static string AssertFileDoesNotExist(this string path)
        {
            new FileInfo(path).AssertFileSystemAssetDoesNotExist();
            return path;
        }

        /// <summary>
        /// Verifies whether the File specified by <paramref name="path"/> Contains the string
        /// <paramref name="s"/>. Implicitly asserts whether
        /// <see cref="AssertFileExists(string)"/>.
        /// </summary>
        /// <param name="path">The File Path being inspected.</param>
        /// <param name="expectedSubstring">The Expected Substring.</param>
        /// <param name="comparison">An optional Comparison.</param>
        /// <returns>The <paramref name="path"/> following successful Assertion.</returns>
        public static string AssertFileContains(this string path, string expectedSubstring, StringComparison? comparison = null)
        {
            var actualString = File.ReadAllText(path.AssertFileExists());

            // ReSharper disable SwitchStatementMissingSomeCases
            switch (comparison)
            {
                case null:
                    Assert.Contains(expectedSubstring, actualString);
                    break;

                default:
                    Assert.Contains(expectedSubstring, actualString, comparison.Value);
                    break;
            }

            return path;
        }

        /// <summary>
        /// Verifies whether the File specified by <paramref name="path"/> Does Not Contain
        /// the string <paramref name="s"/>. Implicitly asserts whether
        /// <see cref="AssertFileExists(string)"/>.
        /// </summary>
        /// <param name="path">The File Path being inspected.</param>
        /// <param name="expectedSubstring">The Expected Substring.</param>
        /// <param name="comparison">An optional Comparison.</param>
        /// <returns>The <paramref name="path"/> following successful Assertion.</returns>
        public static string AssertFileDoesNotContain(this string path, string expectedSubstring, StringComparison? comparison = null)
        {
            var actualString = File.ReadAllText(path.AssertFileExists());

            switch (comparison)
            {
                case null:
                    Assert.DoesNotContain(expectedSubstring, actualString);
                    break;

                default:
                    Assert.DoesNotContain(expectedSubstring, actualString, comparison.Value);
                    break;
            }
            // ReSharper restore SwitchStatementMissingSomeCases

            return path;
        }
    }
}
