// ReSharper disable once IdentifierTypo
namespace Xunit
{
    public static partial class FluentlyExtensionMethods
    {
        /// <summary>
        /// Verifies that <paramref name="actual"/> Same as <paramref name="expected"/>.
        /// </summary>
        /// <param name="actual">The Actual value.</param>
        /// <param name="expected">The Expected value.</param>
        /// <returns>The <paramref name="actual"/> value following successful Assertion.</returns>
        /// <see cref="Assert.Same(object?,object?)"/>
#if XUNIT_NULLABLE
        public static object? AssertSame(this object? actual, object? expected)
#else
        public static object AssertSame(this object actual, object expected)
#endif
        {
            Assert.Same(expected, actual);
            return actual;
        }

        /// <summary>
        /// Verifies that <paramref name="actual"/> Same as <paramref name="expected"/>.
        /// </summary>
        /// <param name="actual">The Actual value.</param>
        /// <param name="expected">The Expected value.</param>
        /// <returns>The <paramref name="actual"/> value following successful Assertion.</returns>
        /// <see cref="Assert.NotSame(object?,object?)"/>
#if XUNIT_NULLABLE
        public static object? AssertNotSame(this object? actual, object? expected)
#else
        public static object AssertNotSame(this object actual, object expected)
#endif
        {
            Assert.NotSame(expected, actual);
            return actual;
        }
    }
}