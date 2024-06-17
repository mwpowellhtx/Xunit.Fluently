using System;

// ReSharper disable once IdentifierTypo
namespace Xunit
{
    public static partial class FluentlyExtensionMethods
    {
        /// <summary>
        /// Verifies that <paramref name="actualString"/> Contains
        /// <paramref name="expectedSubstring"/>.
        /// </summary>
        /// <param name="actualString">The Actual String being inspected.</param>
        /// <param name="expectedSubstring">The Expected Substring.</param>
        /// <param name="comparison">An optional Comparison.</param>
        /// <returns>The <paramref name="actualString"/> following successful Assertion.</returns>
        /// <see cref="Assert.Contains(string,string?)"/>
        /// <see cref="Assert.Contains(string,string?,StringComparison)"/>
#if XUNIT_NULLABLE
        public static string? AssertContains(this string? actualString, string expectedSubstring, StringComparison? comparison = null)
#else
        public static string AssertContains(this string actualString, string expectedSubstring, StringComparison? comparison = null)
#endif
        {
            if (comparison is null)
            {
                Assert.Contains(expectedSubstring, actualString);
            }
            else
            {
                Assert.Contains(expectedSubstring, actualString, comparison.Value);
            }

            return actualString;
        }

        /// <summary>
        /// Verifies that <paramref name="actualString"/> Contains
        /// <paramref name="expectedSubstring"/>.
        /// </summary>
        /// <param name="actualString">The Actual String being inspected.</param>
        /// <param name="expectedSubstring">The Expected Substring.</param>
        /// <param name="comparison">An optional Comparison.</param>
        /// <returns>The <paramref name="actualString"/> following successful Assertion.</returns>
        /// <see cref="Assert.DoesNotContain(string,string?)"/>
        /// <see cref="Assert.DoesNotContain(string,string?,StringComparison)"/>
#if XUNIT_NULLABLE
        public static string? AssertDoesNotContain(this string? actualString, string expectedSubstring, StringComparison? comparison = null)
#else
        public static string AssertDoesNotContain(this string actualString, string expectedSubstring, StringComparison? comparison = null)
#endif
        {
            if (comparison is null)
            {
                Assert.DoesNotContain(expectedSubstring, actualString);
            }
            else
            {
                Assert.DoesNotContain(expectedSubstring, actualString, comparison.Value);
            }

            return actualString;
        }

        /// <summary>
        /// Verifies that <paramref name="actualString"/> Starts With
        /// <paramref name="expectedSubstring"/>.
        /// </summary>
        /// <param name="actualString">The Actual String being inspected.</param>
        /// <param name="expectedSubstring">The Expected Substring.</param>
        /// <param name="comparison">An optional Comparison.</param>
        /// <returns>The <paramref name="actualString"/> following successful Assertion.</returns>
        /// <see cref="Assert.StartsWith(string?,string?)"/>
        /// <see cref="Assert.StartsWith(string?,string?,StringComparison)"/>
#if XUNIT_NULLABLE
        public static string? AssertStartsWith(this string? actualString, string? expectedSubstring, StringComparison? comparison = null)
#else
        public static string AssertStartsWith(this string actualString, string expectedSubstring, StringComparison? comparison = null)
#endif
        {
            if (comparison is null)
            {
                Assert.StartsWith(expectedSubstring, actualString);
            }
            else
            {
                Assert.StartsWith(expectedSubstring, actualString, comparison.Value);
            }

            return actualString;
        }

        /// <summary>
        /// Verifies that <paramref name="actualString"/> Ends With
        /// <paramref name="expectedSubstring"/>.
        /// </summary>
        /// <param name="actualString">The Actual String being inspected.</param>
        /// <param name="expectedSubstring">The Expected Substring.</param>
        /// <param name="comparison">An optional Comparison.</param>
        /// <returns>The <paramref name="actualString"/> following successful Assertion.</returns>
        /// <see cref="Assert.EndsWith(string?,string?)"/>
        /// <see cref="Assert.EndsWith(string?,string?,StringComparison)"/>
#if XUNIT_NULLABLE
        public static string? AssertEndsWith(this string? actualString, string? expectedSubstring, StringComparison? comparison = null)
#else
        public static string AssertEndsWith(this string actualString, string expectedSubstring, StringComparison? comparison = null)
#endif
        {
            if (comparison is null)
            {
                Assert.EndsWith(expectedSubstring, actualString);
            }
            else
            {
                Assert.EndsWith(expectedSubstring, actualString, comparison.Value);
            }

            return actualString;
        }

        /// <summary>
        /// Verifies that <paramref name="actual"/> Equals <paramref name="expected"/>.
        /// </summary>
        /// <param name="actual">The Actual value.</param>
        /// <param name="expected">The Expected value.</param>
        /// <returns>The <paramref name="actual"/> value following successful Assertion.</returns>
        /// <see cref="Assert.Equal(string?,string?,bool,bool,bool,bool)"/>
#if XUNIT_NULLABLE
        public static string? AssertEqual(this string? actual, string? expected)
#else
        public static string AssertEqual(this string actual, string expected)
#endif
        {
            Assert.Equal(expected, actual, false);
            return actual;
        }

        // ReSharper disable once MethodOverloadWithOptionalParameter
        /// <summary>
        /// Verifies that <paramref name="actual"/> Equals <paramref name="expected"/> including
        /// several optional assertion conditions.
        /// </summary>
        /// <param name="actual">The Actual value.</param>
        /// <param name="expected">The Expected value.</param>
        /// <param name="ignoreCase">Whether to Ignore Case during the Assertion.</param>
        /// <param name="ignoreLineEndingDifferences">Whether to Ignore Line Ending Differences.</param>
        /// <param name="ignoreWhiteSpaceDifferences">Whether to Ignore White Space Differences.</param>
        /// <param name="ignoreAllWhiteSpaces">Whether to Ignore All White Spaces.</param>
        /// <returns>The <paramref name="actual"/> value following successful Assertion.</returns>
        /// <see cref="Assert.Equal(string?,string?,bool,bool,bool,bool)"/>
#if XUNIT_NULLABLE
        public static string? AssertEqual(this string? actual
            , string? expected
            , bool ignoreCase = false
            , bool ignoreLineEndingDifferences = false
            , bool ignoreWhiteSpaceDifferences = false
            , bool ignoreAllWhiteSpaces = false)
#else
        public static string AssertEqual(this string actual
            , string expected
            , bool ignoreCase = false
            , bool ignoreLineEndingDifferences = false
            , bool ignoreWhiteSpaceDifferences = false
            , bool ignoreAllWhiteSpaces = false)
#endif
        {
            Assert.Equal(expected, actual, ignoreCase, ignoreLineEndingDifferences, ignoreWhiteSpaceDifferences, ignoreAllWhiteSpaces);
            return actual;
        }
    }
}