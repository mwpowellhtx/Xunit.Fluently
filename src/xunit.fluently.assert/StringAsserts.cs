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
        /// <see cref="Assert.Contains(string,string)"/>
        /// <see cref="Assert.Contains(string,string,StringComparison)"/>
        public static string AssertContains(this string actualString, string expectedSubstring, StringComparison? comparison = null)
            => comparison == null
                ? InvokeBinaryWithReturn(Assert.Contains, actualString, expectedSubstring)
                : InvokeStringComparison(Assert.Contains, actualString, expectedSubstring, comparison.Value);

        /// <summary>
        /// Verifies that <paramref name="actualString"/> Contains
        /// <paramref name="expectedSubstring"/>.
        /// </summary>
        /// <param name="actualString">The Actual String being inspected.</param>
        /// <param name="expectedSubstring">The Expected Substring.</param>
        /// <param name="comparison">An optional Comparison.</param>
        /// <returns>The <paramref name="actualString"/> following successful Assertion.</returns>
        /// <see cref="Assert.DoesNotContain(string,string)"/>
        /// <see cref="Assert.DoesNotContain(string,string,StringComparison)"/>
        public static string AssertDoesNotContain(this string actualString, string expectedSubstring, StringComparison? comparison)
            => comparison == null
                ? InvokeBinaryWithReturn(Assert.DoesNotContain, actualString, expectedSubstring)
                : InvokeStringComparison(Assert.DoesNotContain, actualString, expectedSubstring, comparison.Value);

        /// <summary>
        /// Verifies that <paramref name="actualString"/> Starts With
        /// <paramref name="expectedSubstring"/>.
        /// </summary>
        /// <param name="actualString">The Actual String being inspected.</param>
        /// <param name="expectedSubstring">The Expected Substring.</param>
        /// <param name="comparison">An optional Comparison.</param>
        /// <returns>The <paramref name="actualString"/> following successful Assertion.</returns>
        /// <see cref="Assert.StartsWith(string,string)"/>
        /// <see cref="Assert.StartsWith(string,string,StringComparison)"/>
        public static string AssertStartsWith(this string actualString, string expectedSubstring, StringComparison? comparison)
            => comparison == null
                ? InvokeBinaryWithReturn(Assert.StartsWith, actualString, expectedSubstring)
                : InvokeStringComparison(Assert.StartsWith, actualString, expectedSubstring, comparison.Value);

        /// <summary>
        /// Verifies that <paramref name="actualString"/> Ends With
        /// <paramref name="expectedSubstring"/>.
        /// </summary>
        /// <param name="actualString">The Actual String being inspected.</param>
        /// <param name="expectedSubstring">The Expected Substring.</param>
        /// <param name="comparison">An optional Comparison.</param>
        /// <returns>The <paramref name="actualString"/> following successful Assertion.</returns>
        /// <see cref="Assert.EndsWith(string,string)"/>
        /// <see cref="Assert.EndsWith(string,string,StringComparison)"/>
        public static string AssertEndsWith(this string actualString, string expectedSubstring, StringComparison? comparison)
            => comparison == null
                ? InvokeBinaryWithReturn(Assert.EndsWith, actualString, expectedSubstring)
                : InvokeStringComparison(Assert.EndsWith, actualString, expectedSubstring, comparison.Value);

        /// <summary>
        /// Verifies that <paramref name="actual"/> Equals <paramref name="expected"/>.
        /// </summary>
        /// <param name="actual">The Actual value.</param>
        /// <param name="expected">The Expected value.</param>
        /// <returns>The <paramref name="actual"/> value following successful Assertion.</returns>
        /// <see cref="Assert.Equal(string,string,bool,bool,bool)">With False for defaults.</see>
        public static string AssertEqual(this string actual, string expected)
        {
            Assert.Equal(expected, actual, false);
            return actual;
        }

        // TODO: TBD: was this intentional? maybe an oversight?
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
        /// <returns>The <paramref name="actual"/> value following successful Assertion.</returns>
        /// <see cref="Assert.Equal(string,string,bool,bool,bool)"/>
        public static string AssertEqual(this string actual, string expected, bool ignoreCase = false
            , bool ignoreLineEndingDifferences = false, bool ignoreWhiteSpaceDifferences = false)
            => InvokeStringComparison(Assert.Equal, actual, expected, ignoreCase, ignoreLineEndingDifferences
                , ignoreWhiteSpaceDifferences);
    }
}
