// ReSharper disable once IdentifierTypo
namespace Xunit
{
    public static partial class FluentlyExtensionMethods
    {
        /// <summary>
        /// Verifies that <paramref name="actual"/> Same as <paramref name="expected"/>.
        /// </summary>
        /// <typeparam name="T">The type of the Value being inspected.</typeparam>
        /// <param name="actual">The Actual value.</param>
        /// <param name="expected">The Expected value.</param>
        /// <returns>The <paramref name="actual"/> value following successful Assertion.</returns>
        /// <see cref="Assert.Same"/>
        public static T AssertSame<T>(this T actual, T expected)
            where T : class
        {
            Assert.Same(expected, actual);
            return actual;
        }

        /// <summary>
        /// Verifies that <paramref name="actual"/> Same as <paramref name="expected"/>.
        /// </summary>
        /// <typeparam name="T">The type of the Value being inspected.</typeparam>
        /// <param name="actual">The Actual value.</param>
        /// <param name="expected">The Expected value.</param>
        /// <returns>The <paramref name="actual"/> value following successful Assertion.</returns>
        /// <see cref="Assert.Same"/>
        public static T AssertNotSame<T>(this T actual, T expected)
            where T : class
        {
            Assert.NotSame(expected, actual);
            return actual;
        }
    }
}
