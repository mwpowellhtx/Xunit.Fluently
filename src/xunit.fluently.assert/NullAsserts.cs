// ReSharper disable once IdentifierTypo
using System;

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

        /// <summary>
        /// Verifies that the <paramref name="value"/> <typeparamref name="T"/> class is Null.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="value"></param>
        /// <returns></returns>
#if XUNIT_NULLABLE
        public static T? AssertClassInstanceNull<T>(this T? value)
            where T : class
#else // Redundancy
        public static T AssertClassInstanceNull<T>(this T value)
            where T : class
#endif
        {
            Assert.Null(value);
            return value;
        }

        /// <summary>
        /// Verifies that the <paramref name="value"/> <typeparamref name="T"/> class is Not Null.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="value"></param>
        /// <returns></returns>
#if XUNIT_NULLABLE
        public static T? AssertClassInstanceNotNull<T>(this T? value)
            where T : class
#else // Redundancy
        public static T AssertClassInstanceNotNull<T>(this T value)
            where T : class
#endif
        {
            Assert.NotNull(value);
            return value;
        }

        /// <summary>
        /// Verifies that the <paramref name="value"/> <typeparamref name="U"/> gotten by
        /// <paramref name="getter"/> is Null. <typeparamref name="T"/> may be anything,
        /// which itself should also yield an <typeparamref name="U"/>.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="U"></typeparam>
        /// <param name="value"></param>
        /// <param name="getter"></param>
        /// <returns></returns>
#if XUNIT_NULLABLE
        public static T? AssertClassMemberNull<T, U>(this T? value, Func<T?, U?> getter)
            where T : class
#else // Redundancy
        public static T AssertClassMemberNull<T, U>(this T value, Func<T, U> getter)
            where T : class
#endif
        {
            Assert.Null(getter(value));
            return value;
        }

        /// <summary>
        /// Verifies that the <paramref name="value"/> <typeparamref name="U"/> gotten by
        /// <paramref name="getter"/> is Not Null. <typeparamref name="T"/> may be anything,
        /// which itself should also yield an <typeparamref name="U"/>.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="U"></typeparam>
        /// <param name="value"></param>
        /// <param name="getter"></param>
        /// <returns></returns>
#if XUNIT_NULLABLE
        public static T? AssertClassMemberNotNull<T, U>(this T? value, Func<T?, U?> getter)
            where T : class
#else // Redundancy
        public static T AssertClassMemberNotNull<T, U>(this T value, Func<T, U> getter)
            where T : class
#endif
        {
            Assert.NotNull(getter(value));
            return value;
        }

        /// <summary>
        /// Verifies that the <paramref name="value"/> <typeparamref name="U"/> gotten by
        /// <paramref name="getter"/> is Null. <typeparamref name="T"/> may be anything,
        /// which itself should also yield an <typeparamref name="U"/>.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="U"></typeparam>
        /// <param name="value"></param>
        /// <param name="getter"></param>
        /// <returns></returns>
#if XUNIT_NULLABLE
        public static T? AssertClassMemberStructNull<T, U>(this T? value, Func<T?, U?> getter)
            where T : class
            where U : struct
#else // Redundancy
        public static T AssertClassMemberStructNull<T, U>(this T value, Func<T, U?> getter)
            where T : class
            where U : struct
#endif
        {
            Assert.Null(getter(value));
            return value;
        }

        /// <summary>
        /// Verifies that the <paramref name="value"/> <typeparamref name="U"/> gotten by
        /// <paramref name="getter"/> is Not Null. <typeparamref name="T"/> may be anything,
        /// which itself should also yield an <typeparamref name="U"/>.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="U"></typeparam>
        /// <param name="value"></param>
        /// <param name="getter"></param>
        /// <returns></returns>
#if XUNIT_NULLABLE
        public static T? AssertClassMemberStructNotNull<T, U>(this T? value, Func<T?, U?> getter)
            where T : class
            where U : struct
#else // Redundancy
        public static T AssertClassMemberStructNotNull<T, U>(this T value, Func<T, U?> getter)
            where T : class
            where U : struct
#endif
        {
            Assert.NotNull(getter(value));
            return value;
        }
    }
}