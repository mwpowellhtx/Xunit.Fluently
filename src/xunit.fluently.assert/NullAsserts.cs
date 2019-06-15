// ReSharper disable once IdentifierTypo
namespace Xunit
{
    public static partial class FluentlyExtensionMethods
    {
        /// <summary>
        /// Verifies that the <paramref name="value"/> is Null.
        /// </summary>
        /// <param name="value">The Value being inspected.</param>
        /// <returns>The <paramref name="value"/> following successful Assertion.</returns>
        /// <see cref="Assert.Null"/>
        public static object AssertNull(this object value)
            => InvokeUnaryWithReturn(Assert.Null, value);

        /// <summary>
        /// Verifies that the <paramref name="value"/> is Null.
        /// </summary>
        /// <typeparam name="T">The type of the Value being inspected.</typeparam>
        /// <param name="value">The Value being inspected.</param>
        /// <returns>The <paramref name="value"/> following successful Assertion.</returns>
        /// <see cref="Assert.Null"/>
        public static T AssertNull<T>(this T value)
            => InvokeUnaryWithReturn(x => Assert.Null(x), value);

        /// <summary>
        /// Verifies that the <paramref name="value"/> is Not Null.
        /// </summary>
        /// <param name="value">The Value being inspected.</param>
        /// <returns>The <paramref name="value"/> following successful Assertion.</returns>
        /// <see cref="Assert.NotNull"/>
        public static object AssertNotNull(this object value)
            => InvokeUnaryWithReturn(Assert.NotNull, value);

        /// <summary>
        /// Verifies that the <paramref name="value"/> is Not Null.
        /// </summary>
        /// <typeparam name="T">The type of the Value being inspected.</typeparam>
        /// <param name="value">The Value being inspected.</param>
        /// <returns>The <paramref name="value"/> following successful Assertion.</returns>
        /// <see cref="Assert.NotNull"/>
        public static T AssertNotNull<T>(this T value)
            => InvokeUnaryWithReturn(x => Assert.NotNull(x), value);
    }
}
