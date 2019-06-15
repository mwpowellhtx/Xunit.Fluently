using System.Collections.Generic;

// ReSharper disable once IdentifierTypo
namespace Xunit
{
    public static partial class FluentlyExtensionMethods
    {
        /// <summary>
        /// Verifies that <paramref name="actual"/> Equals <paramref name="expected"/>.
        /// </summary>
        /// <typeparam name="T">The type of the objects to be compared.</typeparam>
        /// <param name="actual">The Actual value.</param>
        /// <param name="expected">The Expected value.</param>
        /// <returns>The <paramref name="actual"/> value following successful Assertion.</returns>
        /// <see cref="Assert.Equal{T}(T,T)"/>
        public static T AssertEqual<T>(this T actual, T expected)
            where T : class
        {
            Assert.Equal(expected, actual);
            return actual;
        }

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
            where T : class
        {
            Assert.Equal(expected, actual, comparer);
            return actual;
        }

        /// <summary>
        /// Verifies that <paramref name="actual"/> Does Not Equal <paramref name="expected"/>.
        /// </summary>
        /// <typeparam name="T">The type of the objects to be compared.</typeparam>
        /// <param name="actual">The Actual value.</param>
        /// <param name="expected">The Expected value.</param>
        /// <returns>The <paramref name="actual"/> value following successful Assertion.</returns>
        /// <see cref="Assert.NotEqual{T}(T,T)"/>
        public static T AssertNotEqual<T>(this T actual, T expected)
            where T : class
        {
            Assert.NotEqual(expected, actual);
            return actual;
        }

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
            where T : class
        {
            Assert.NotEqual(expected, actual, comparer);
            return actual;
        }

        /// <summary>
        /// Verifies that <paramref name="actual"/> Equals <paramref name="expected"/>.
        /// </summary>
        /// <typeparam name="T">The type of the objects to be compared.</typeparam>
        /// <param name="actual">The Actual value.</param>
        /// <param name="expected">The Expected value.</param>
        /// <returns>The <paramref name="actual"/> value following successful Assertion.</returns>
        /// <see cref="Assert.Equal{T}(IEnumerable{T},IEnumerable{T})"/>
        public static IEnumerable<T> AssertEqual<T>(this IEnumerable<T> actual, IEnumerable<T> expected)
            where T : class
        {
            // ReSharper disable PossibleMultipleEnumeration
            Assert.Equal(expected, actual);
            return actual;
            // ReSharper restore PossibleMultipleEnumeration
        }

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
            where T : class
        {
            Assert.Equal(expected, actual, comparer);
            return actual;
        }

        /// <summary>
        /// Verifies that <paramref name="actual"/> Does Not Equal <paramref name="expected"/>.
        /// </summary>
        /// <typeparam name="T">The type of the objects to be compared.</typeparam>
        /// <param name="actual">The Actual value.</param>
        /// <param name="expected">The Expected value.</param>
        /// <returns>The <paramref name="actual"/> value following successful Assertion.</returns>
        /// <see cref="Assert.NotEqual{T}(IEnumerable{T},IEnumerable{T})"/>
        public static IEnumerable<T> AssertNotEqual<T>(this IEnumerable<T> actual, IEnumerable<T> expected)
            where T : class
        {
            Assert.NotEqual(expected, actual);
            return actual;
        }

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
            where T : class
        {
            Assert.NotEqual(expected, actual, comparer);
            return actual;
        }
        // ReSharper restore PossibleMultipleEnumeration

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T">The type of the objects to be compared.</typeparam>
        /// <param name="actual">The Actual value.</param>
        /// <param name="expected">The Expected value.</param>
        /// <returns>The <paramref name="actual"/> value following successful Assertion.</returns>
        public static T AssertStrictEqual<T>(this T actual, T expected)
            where T : class
        {
            Assert.StrictEqual(expected, actual);
            return actual;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T">The type of the objects to be compared.</typeparam>
        /// <param name="actual">The Actual value.</param>
        /// <param name="expected">The Expected value.</param>
        /// <returns>The <paramref name="actual"/> value following successful Assertion.</returns>
        public static T AssertNotStrictEqual<T>(this T actual, T expected)
            where T : class
        {
            Assert.NotStrictEqual(expected, actual);
            return actual;
        }
    }
}
