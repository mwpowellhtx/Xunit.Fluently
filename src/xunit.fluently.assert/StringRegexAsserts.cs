using System;
using System.Text.RegularExpressions;

namespace Xunit
{
    public static partial class FluentlyExtensionMethods
    {
        /// <summary>
        /// Asserts, loosely speaking, the regular expression for intermediate use.
        /// </summary>
        /// <param name="actual">The actual string under consideration.</param>
        /// <param name="expectedPattern">The expected <see cref="Regex"/> pattern.</param>
        /// <returns></returns>
        public static Match AssertRegexMatch(this string actual, string expectedPattern)
            => Regex.Match(actual, expectedPattern);

        /// <summary>
        /// Asserts that the <paramref name="actual"/> <paramref name="evaluate"/> succeeds, that
        /// is, returns <code>true</code>.
        /// </summary>
        /// <param name="actual">The actual <see cref="Match"/> under consideration.</param>
        /// <param name="evaluate">The functional callback used to evaluate the <paramref name="actual"/> match.</param>
        public static Match AssertRegexMatch(this Match actual, Func<Match, bool> evaluate)
        {
            Assert.NotNull(evaluate);
            evaluate(actual);
            return actual;
        }

        /// <summary>
        /// Asserts that the <paramref name="actual"/> <see cref="string"/> Succeeds in matching
        /// the <see cref="Regex"/> <paramref name="expectedPattern"/>.
        /// </summary>
        /// <param name="actual">The actual string under consideration.</param>
        /// <param name="expectedPattern">The expected <see cref="Regex"/> pattern.</param>
        public static void AssertRegexSuccess(this string actual, string expectedPattern)
            => AssertRegexMatch(actual, expectedPattern).AssertRegexMatchSuccess();

        /// <summary>
        /// Asserts that the <paramref name="actual"/> <see cref="string"/> Fails to match the
        /// <see cref="Regex"/> <paramref name="expectedPattern"/>.
        /// </summary>
        /// <param name="actual">The actual string under consideration.</param>
        /// <param name="expectedPattern">The expected <see cref="Regex"/> pattern.</param>
        public static void AssertRegexFailure(this string actual, string expectedPattern)
            => AssertRegexMatch(actual, expectedPattern).AssertRegexMatchFailure();

        /// <summary>
        /// Asserts <paramref name="actual"/> <see cref="Match"/> success.
        /// </summary>
        /// <param name="actual">The actual <see cref="Match"/> under consideration.</param>
        /// <see cref="Match"/>
        /// <see cref="Group.Success"/>
        public static void AssertRegexMatchSuccess(this Match actual) => actual.Success.AssertTrue();

        /// <summary>
        /// Asserts <paramref name="actual"/> <see cref="Match"/> failure.
        /// </summary>
        /// <param name="actual">The actual <see cref="Match"/> under consideration.</param>
        /// <see cref="Match"/>
        /// <see cref="Group.Success"/>
        public static void AssertRegexMatchFailure(this Match actual) => actual.Success.AssertFalse();
    }
}