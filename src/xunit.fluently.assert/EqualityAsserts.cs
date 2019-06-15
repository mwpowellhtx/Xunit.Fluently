using System.Collections.Generic;

// ReSharper disable once IdentifierTypo
namespace Xunit
{
    public static partial class FluentlyExtensionMethods
    {
        // ReSharper disable RedundantTypeArgumentsOfMethod
        /// <summary>
        /// Verifies that <paramref name="actual"/> Equals <paramref name="expected"/>.
        /// </summary>
        /// <typeparam name="T">The type of the objects to be compared.</typeparam>
        /// <param name="actual">The Actual value.</param>
        /// <param name="expected">The Expected value.</param>
        /// <returns>The <paramref name="actual"/> value following successful Assertion.</returns>
        /// <see cref="Assert.Equal{T}(T,T)"/>
        public static T AssertEqual<T>(this T actual, T expected)
            => InvokeBinaryWithReturn<T>(Assert.Equal, actual, expected);

        /// <summary>
        /// Verifies that <paramref name="actual"/> Does Not Equal <paramref name="expected"/>.
        /// </summary>
        /// <typeparam name="T">The type of the objects to be compared.</typeparam>
        /// <param name="actual">The Actual value.</param>
        /// <param name="expected">The Expected value.</param>
        /// <param name="comparer">The Comparer used to Compare the two objects.</param>
        /// <returns>The <paramref name="actual"/> value following successful Assertion.</returns>
        /// <see cref="Assert.Equal{T}(T,T,IEqualityComparer{T})"/>
        public static T AssertEqual<T>(this T actual, T expected, IEqualityComparer<T> comparer)
            => InvokeBinaryWithReturn(Assert.Equal, actual, expected, comparer);

        /// <summary>
        /// Verifies that <paramref name="actual"/> Does Not Equal <paramref name="expected"/>.
        /// </summary>
        /// <typeparam name="T">The type of the objects to be compared.</typeparam>
        /// <param name="actual">The Actual value.</param>
        /// <param name="expected">The Expected value.</param>
        /// <returns>The <paramref name="actual"/> value following successful Assertion.</returns>
        /// <see cref="Assert.NotEqual{T}(T,T)"/>
        public static T AssertNotEqual<T>(this T actual, T expected)
            => InvokeBinaryWithReturn<T>(Assert.NotEqual, actual, expected);

        /// <summary>
        /// Verifies that <paramref name="actual"/> Does Not Equal <paramref name="expected"/>.
        /// </summary>
        /// <typeparam name="T">The type of the objects to be compared.</typeparam>
        /// <param name="actual">The Actual value.</param>
        /// <param name="expected">The Expected value.</param>
        /// <param name="comparer">The Comparer used to Compare the two objects.</param>
        /// <returns>The <paramref name="actual"/> value following successful Assertion.</returns>
        /// <see cref="Assert.NotEqual{T}(T,T,IEqualityComparer{T})"/>
        public static T AssertNotEqual<T>(this T actual, T expected, IEqualityComparer<T> comparer)
            => InvokeBinaryWithReturn(Assert.NotEqual, actual, expected, comparer);

        /// <summary>
        /// Verifies that <paramref name="actual"/> Equals <paramref name="expected"/>.
        /// </summary>
        /// <typeparam name="T">The type of the objects to be compared.</typeparam>
        /// <param name="actual">The Actual value.</param>
        /// <param name="expected">The Expected value.</param>
        /// <returns>The <paramref name="actual"/> value following successful Assertion.</returns>
        /// <see cref="Assert.Equal{T}(IEnumerable{T},IEnumerable{T})"/>
        public static IEnumerable<T> AssertEqual<T>(this IEnumerable<T> actual, IEnumerable<T> expected)
            => InvokeBinaryWithReturn<T>(Assert.Equal, actual, expected);

        // ReSharper disable PossibleMultipleEnumeration
        /// <summary>
        /// Verifies that <paramref name="actual"/> Equals <paramref name="expected"/>.
        /// </summary>
        /// <typeparam name="T">The type of the objects to be compared.</typeparam>
        /// <param name="actual">The Actual value.</param>
        /// <param name="expected">The Expected value.</param>
        /// <param name="comparer">The Comparer used to Compare the two objects.</param>
        /// <returns>The <paramref name="actual"/> value following successful Assertion.</returns>
        /// <see cref="Assert.Equal{T}(IEnumerable{T},IEnumerable{T},IEqualityComparer{T})"/>
        public static IEnumerable<T> AssertEqual<T>(this IEnumerable<T> actual, IEnumerable<T> expected, IEqualityComparer<T> comparer)
            => InvokeBinaryWithReturn(Assert.Equal, actual, expected, comparer);

        /// <summary>
        /// Verifies that <paramref name="actual"/> Does Not Equal <paramref name="expected"/>.
        /// </summary>
        /// <typeparam name="T">The type of the objects to be compared.</typeparam>
        /// <param name="actual">The Actual value.</param>
        /// <param name="expected">The Expected value.</param>
        /// <returns>The <paramref name="actual"/> value following successful Assertion.</returns>
        /// <see cref="Assert.NotEqual{T}(IEnumerable{T},IEnumerable{T})"/>
        public static IEnumerable<T> AssertNotEqual<T>(this IEnumerable<T> actual, IEnumerable<T> expected)
            => InvokeBinaryWithReturn<T>(Assert.NotEqual, actual, expected);

        /// <summary>
        /// Verifies that <paramref name="actual"/> Does Not Equal <paramref name="expected"/>.
        /// </summary>
        /// <typeparam name="T">The type of the objects to be compared.</typeparam>
        /// <param name="actual">The Actual value.</param>
        /// <param name="expected">The Expected value.</param>
        /// <param name="comparer">The Comparer used to Compare the two objects.</param>
        /// <returns>The <paramref name="actual"/> value following successful Assertion.</returns>
        /// <see cref="Assert.NotEqual{T}(IEnumerable{T},IEnumerable{T},IEqualityComparer{T})"/>
        public static IEnumerable<T> AssertNotEqual<T>(this IEnumerable<T> actual, IEnumerable<T> expected, IEqualityComparer<T> comparer)
            => InvokeBinaryWithReturn(Assert.NotEqual, actual, expected, comparer);
        // ReSharper restore PossibleMultipleEnumeration

        /// <summary>
        /// Verifies that <paramref name="actual"/> is Strictly Equal with
        /// <paramref name="expected"/>.
        /// </summary>
        /// <typeparam name="T">The type of the objects to be compared.</typeparam>
        /// <param name="actual">The Actual value.</param>
        /// <param name="expected">The Expected value.</param>
        /// <returns>The <paramref name="actual"/> value following successful Assertion.</returns>
        public static T AssertStrictEqual<T>(this T actual, T expected)
            => InvokeBinaryWithReturn<T>(Assert.StrictEqual, actual, expected);

        /// <summary>
        /// Verifies that <paramref name="actual"/> is Strictly Not Equal with
        /// <paramref name="expected"/>.
        /// </summary>
        /// <typeparam name="T">The type of the objects to be compared.</typeparam>
        /// <param name="actual">The Actual value.</param>
        /// <param name="expected">The Expected value.</param>
        /// <returns>The <paramref name="actual"/> value following successful Assertion.</returns>
        public static T AssertNotStrictEqual<T>(this T actual, T expected)
            => InvokeBinaryWithReturn<T>(Assert.NotStrictEqual, actual, expected);
        // ReSharper restore RedundantTypeArgumentsOfMethod
    }
}
