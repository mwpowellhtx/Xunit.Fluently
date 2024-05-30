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
        /// <see cref="Assert.Null(object?)"/>
#if XUNIT_NULLABLE
        public static object? AssertNull(this object? value)
#else
        public static object AssertNull(this object value)
#endif
        {
            Assert.Null(value);
            return value;
        }

        /// <summary>
        /// Verifies that the <paramref name="value"/> is Null.
        /// </summary>
        /// <typeparam name="T">The type of the Value being inspected.</typeparam>
        /// <param name="value">The Value being inspected.</param>
        /// <returns>The <paramref name="value"/> following successful Assertion.</returns>
        /// <see cref="Assert.Null{T}(T?)"/>
#if XUNIT_NULLABLE
        public static T? AssertNull<T>(this T? value)
            where T : struct
#else // It looks redundant but just in case there should ever be a difference
        public static T? AssertNull<T>(this T? value)
            where T : struct
#endif
        {
            Assert.Null(value);
            return value;
        }

        /// <summary>
        /// Verifies that the <paramref name="value"/> is Not Null.
        /// </summary>
        /// <param name="value">The Value being inspected.</param>
        /// <returns>The <paramref name="value"/> following successful Assertion.</returns>
        /// <see cref="Assert.NotNull(object?)"/>
#if XUNIT_NULLABLE
        public static object? AssertNotNull(this object? value)
#else
        public static object AssertNotNull(this object value)
#endif
        {
            Assert.NotNull(value);
            return value;
        }

        /// <summary>
        /// Verifies that the <paramref name="value"/> is Not Null.
        /// </summary>
        /// <typeparam name="T">The type of the Value being inspected.</typeparam>
        /// <param name="value">The Value being inspected.</param>
        /// <returns>The <paramref name="value"/> following successful Assertion.</returns>
        /// <see cref="Assert.NotNull{T}(T?)"/>
#if XUNIT_NULLABLE
        public static T? AssertNotNull<T>(this T? value)
            where T : struct
#else // Ditto redundancy just in case
        public static T? AssertNotNull<T>(this T? value)
            where T : struct
#endif
        {
            Assert.NotNull(value);
            return value;
        }
    }
}