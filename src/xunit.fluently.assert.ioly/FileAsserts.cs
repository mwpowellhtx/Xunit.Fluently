using System;
using System.IO;

// ReSharper disable IdentifierTypo
namespace Xunit
{
    public static partial class IolyExtensionMethods
    {
        /// <summary>
        /// Verifies whether the <paramref name="path"/> File <see cref="File.Exists"/>.
        /// </summary>
        /// <param name="path">The Path of the file being inspected.</param>
        /// <returns>The <paramref name="path"/> following successful Assertion.</returns>
        public static string AssertFileExists(this string path)
        {
            new FileInfo(path).AssertFileSystemAssetExists(File.Exists);
            return path;
        }

        /// <summary>
        /// Verifies whether the <paramref name="path"/> Does Not <see cref="File.Exists"/>.
        /// </summary>
        /// <param name="path">The Path of the file being inspected.</param>
        /// <returns>The <paramref name="path"/> following successful Assertion.</returns>
        public static string AssertFileDoesNotExist(this string path)
        {
            new FileInfo(path).AssertFileSystemAssetDoesNotExist(File.Exists);
            return path;
        }

        /// <summary>
        /// Verifies whether the File specified by <paramref name="path"/> Contains the string
        /// <paramref name="expectedSubstring"/>. Implicitly asserts whether
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
        /// the string <paramref name="expectedSubstring"/>. Implicitly asserts whether
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
