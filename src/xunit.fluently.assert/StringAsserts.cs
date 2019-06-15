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
        {
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
        /// <see cref="Assert.DoesNotContain(string,string)"/>
        /// <see cref="Assert.DoesNotContain(string,string,StringComparison)"/>
        public static string AssertDoesNotContain(this string actualString, string expectedSubstring, StringComparison? comparison)
        {
            switch (comparison)
            {
                case null:
                    Assert.DoesNotContain(expectedSubstring, actualString);
                    break;

                default:
                    Assert.DoesNotContain(expectedSubstring, actualString, comparison.Value);
                    break;
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
        /// <see cref="Assert.StartsWith(string,string)"/>
        /// <see cref="Assert.StartsWith(string,string,StringComparison)"/>
        public static string AssertStartsWith(this string actualString, string expectedSubstring, StringComparison? comparison)
        {
            switch (comparison)
            {
                case null:
                    Assert.StartsWith(expectedSubstring, actualString);
                    break;

                default:
                    Assert.StartsWith(expectedSubstring, actualString, comparison.Value);
                    break;
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
        /// <see cref="Assert.EndsWith(string,string)"/>
        /// <see cref="Assert.EndsWith(string,string,StringComparison)"/>
        public static string AssertEndsWith(this string actualString, string expectedSubstring, StringComparison? comparison)
        {
            switch (comparison)
            {
                case null:
                    Assert.EndsWith(expectedSubstring, actualString);
                    break;

                default:
                    Assert.EndsWith(expectedSubstring, actualString, comparison.Value);
                    break;
            }
            // ReSharper restore SwitchStatementMissingSomeCases

            return actualString;
        }

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
        {
            Assert.Equal(expected, actual, ignoreCase, ignoreLineEndingDifferences, ignoreWhiteSpaceDifferences);
            return actual;
        }
    }
}
