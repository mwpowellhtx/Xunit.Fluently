// ReSharper disable once IdentifierTypo
namespace Xunit
{
    public static partial class FluentlyExtensionMethods
    {
        /// <summary>
        /// Verifies that the <paramref name="value"/> is Null.
        /// </summary>
        /// <typeparam name="T">The type of the Value being inspected.</typeparam>
        /// <param name="value">The Value being inspected.</param>
        /// <returns>The <paramref name="value"/> following successful Assertion.</returns>
        /// <see cref="Assert.Null"/>
        public static T AssertNull<T>(this T value)
            where T : class
        {
            Assert.Null(value);
            // ReSharper disable once ExpressionIsAlwaysNull
            return value;
        }

        /// <summary>
        /// Verifies that the <paramref name="value"/> is Not Null.
        /// </summary>
        /// <typeparam name="T">The type of the Value being inspected.</typeparam>
        /// <param name="value">The Value being inspected.</param>
        /// <returns>The <paramref name="value"/> following successful Assertion.</returns>
        /// <see cref="Assert.NotNull"/>
        public static T AssertNotNull<T>(this T value)
            where T : class
        {
            Assert.NotNull(value);
            return value;
        }
    }
}
