using System;
using System.Collections;
using System.Collections.Generic;

// ReSharper disable once IdentifierTypo
namespace Xunit
{
    public static partial class FluentlyExtensionMethods
    {
        /// <summary>
        /// Verifies that the <paramref name="collection"/> contains exactly the number of
        /// elements aligned with <paramref name="elementInspectors"/>, and which meet the
        /// criteria furnished by the same Inspectors.
        /// </summary>
        /// <typeparam name="T">The type of the elements being verified.</typeparam>
        /// <param name="collection">The Collection being inspected.</param>
        /// <param name="elementInspectors">The Element Inspectors, which inspect each element. The
        /// number of Inspectors must match the number of Elements in the Collection exactly.</param>
        /// <returns>The <paramref name="collection"/> following successful Assertion.</returns>
        public static IEnumerable<T> AssertCollection<T>(this IEnumerable<T> collection, params Action<T>[] elementInspectors)
        {
            // ReSharper disable PossibleMultipleEnumeration
            Assert.Collection(collection, elementInspectors);
            return collection;
        }

        /// <summary>
        /// Verifies that the <paramref name="collection"/> Contains All of the
        /// <paramref name="expectedElements"/>.
        /// </summary>
        /// <typeparam name="T">The type of the Elements to be verified.</typeparam>
        /// <param name="collection">The Collection being inspected.</param>
        /// <param name="expectedElements">The Elements Expected to be in the Collection.</param>
        /// <returns>The <paramref name="collection"/> following successful Assertion.</returns>
        public static IEnumerable<T> AssertContainsAll<T>(IEnumerable<T> collection, params T[] expectedElements)
        {
            foreach (var x in expectedElements)
            {
                Assert.Contains(x, collection);
            }

            return collection;
        }

        /// <summary>
        /// Verifies that the <paramref name="collection"/> Contains All of the
        /// <paramref name="expectedElements"/>.
        /// </summary>
        /// <typeparam name="T">The type of the Elements to be verified.</typeparam>
        /// <param name="collection">The Collection being inspected.</param>
        /// <param name="comparer">An Equality Comparer.</param>
        /// <param name="expectedElements">The Elements Expected to be in the Collection.</param>
        /// <returns>The <paramref name="collection"/> following successful Assertion.</returns>
        public static IEnumerable<T> AssertContainsAll<T>(IEnumerable<T> collection, IEqualityComparer<T> comparer, params T[] expectedElements)
        {
            foreach (var x in expectedElements)
            {
                Assert.Contains(x, collection, comparer);
            }

            return collection;
            // ReSharper restore PossibleMultipleEnumeration
        }

        /// <summary>
        /// Verifies that the <paramref name="collection"/> Contains elements matching the
        /// <paramref name="predicate"/>.
        /// </summary>
        /// <typeparam name="T">The type of the Elements to be verified.</typeparam>
        /// <param name="collection">The Collection being inspected.</param>
        /// <param name="predicate">The Collection being inspected.</param>
        /// <returns>The <paramref name="collection"/> following successful Assertion.</returns>
        public static IEnumerable<T> AssertContains<T>(IEnumerable<T> collection, Predicate<T> predicate)
        {
            // ReSharper disable PossibleMultipleEnumeration
            Assert.Contains(collection, predicate);
            return collection;
        }

        /// <summary>
        /// Verifies that the <paramref name="collection"/> Does Not Contain elements matching
        /// the <paramref name="predicate"/>.
        /// </summary>
        /// <typeparam name="T">The type of the Elements to be verified.</typeparam>
        /// <param name="collection">The Collection being inspected.</param>
        /// <param name="predicate">The Collection being inspected.</param>
        /// <returns>The <paramref name="collection"/> following successful Assertion.</returns>
        public static IEnumerable<T> AssertDoesNotContain<T>(IEnumerable<T> collection, Predicate<T> predicate)
        {
            Assert.DoesNotContain(collection, predicate);
            return collection;
        }

        /// <summary>
        /// Verifies that the <paramref name="collection"/> Does Not Contain Any of the
        /// <paramref name="expectedElements"/>.
        /// </summary>
        /// <typeparam name="T">The type of the Elements to be verified.</typeparam>
        /// <param name="collection">The Collection being inspected.</param>
        /// <param name="expectedElements">The Elements Expected to be in the Collection.</param>
        /// <returns>The <paramref name="collection"/> following successful Assertion.</returns>
        public static IEnumerable<T> AssertDoesNotContainAny<T>(IEnumerable<T> collection, params T[] expectedElements)
        {
            foreach (var x in expectedElements)
            {
                Assert.DoesNotContain(x, collection);
            }

            return collection;
        }

        /// <summary>
        /// Verifies that the <paramref name="collection"/> Does Not Contain Any of the
        /// <paramref name="expectedElements"/>.
        /// </summary>
        /// <typeparam name="T">The type of the Elements to be verified.</typeparam>
        /// <param name="collection">The Collection being inspected.</param>
        /// <param name="comparer">An Equality Comparer.</param>
        /// <param name="expectedElements">The Elements Expected to be in the Collection.</param>
        /// <returns>The <paramref name="collection"/> following successful Assertion.</returns>
        public static IEnumerable<T> AssertDoesNotContainAny<T>(IEnumerable<T> collection, IEqualityComparer<T> comparer, params T[] expectedElements)
        {
            foreach (var x in collection)
            {
                Assert.DoesNotContain(x, collection, comparer);
            }

            return collection;
            // ReSharper restore PossibleMultipleEnumeration
        }

        // TODO: TBD: public static TValue Contains<TKey, TValue>(TKey expected, IReadOnlyDictionary<TKey, TValue> collection)
        // TODO: TBD: public static TValue Contains<TKey, TValue>(TKey expected, IDictionary<TKey, TValue> collection)
        // TODO: TBD: public static void DoesNotContain<TKey, TValue>(TKey expected, IReadOnlyDictionary<TKey, TValue> collection)
        // TODO: TBD: public static void DoesNotContain<TKey, TValue>(TKey expected, IDictionary<TKey, TValue> collection)

        /// <summary>
        /// Verifies that the <paramref name="collection"/> is Empty.
        /// </summary>
        /// <typeparam name="T">The Type of Collection.</typeparam>
        /// <param name="collection">The Collection being inspected.</param>
        /// <returns>The <paramref name="collection"/> following successful Assertion.</returns>
        /// <see cref="Assert.Empty"/>
        public static T AssertEmpty<T>(this T collection)
            where T : IEnumerable
        {
            Assert.Empty(collection);
            return collection;
        }

        /// <summary>
        /// Verifies that the <paramref name="collection"/> is Not Empty.
        /// </summary>
        /// <typeparam name="T">The Type of Collection.</typeparam>
        /// <param name="collection">The Collection being inspected.</param>
        /// <returns>The <paramref name="collection"/> following successful Assertion.</returns>
        /// <see cref="Assert.NotEmpty"/>
        public static T AssertNotEmpty<T>(this T collection)
            where T : IEnumerable
        {
            Assert.NotEmpty(collection);
            return collection;
        }

        /// <summary>
        /// Verifies that <paramref name="actual"/> Equals <paramref name="expected"/>.
        /// </summary>
        /// <typeparam name="T">The Type of the Elements in the collections.</typeparam>
        /// <param name="actual">The Actual collection being inspected.</param>
        /// <param name="expected">The Expected collection being inspected.</param>
        /// <returns>The <paramref name="actual"/> collection following successful Assertion.</returns>
        /// <see cref="Assert.Equal{T}(IEnumerable{T},IEnumerable{T})"/>
        public static IEnumerable<T> Equal<T>(this IEnumerable<T> actual, IEnumerable<T> expected)
        {
            // ReSharper disable PossibleMultipleEnumeration
            Assert.Equal(expected, actual);
            return actual;
        }

        /// <summary>
        /// Verifies that <paramref name="actual"/> Equals <paramref name="expected"/>.
        /// </summary>
        /// <typeparam name="T">The Type of the Elements in the collections.</typeparam>
        /// <param name="actual">The Actual collection being inspected.</param>
        /// <param name="expected">The Expected collection being inspected.</param>
        /// <param name="comparer">An Equality Comparer used during inspection.</param>
        /// <returns>The <paramref name="actual"/> collection following successful Assertion.</returns>
        /// <see cref="Assert.Equal{T}(IEnumerable{T},IEnumerable{T},IEqualityComparer{T})"/>
        public static IEnumerable<T> Equal<T>(this IEnumerable<T> actual, IEnumerable<T> expected, IEqualityComparer<T> comparer)
        {
            Assert.Equal(expected, actual, comparer);
            return actual;
        }

        /// <summary>
        /// Verifies that <paramref name="actual"/> Does Not Equal <paramref name="expected"/>.
        /// </summary>
        /// <typeparam name="T">The Type of the Elements in the collections.</typeparam>
        /// <param name="actual">The Actual collection being inspected.</param>
        /// <param name="expected">The Expected collection being inspected.</param>
        /// <returns>The <paramref name="actual"/> collection following successful Assertion.</returns>
        /// <see cref="Assert.NotEqual{T}(IEnumerable{T},IEnumerable{T})"/>
        public static IEnumerable<T> NotEqual<T>(this IEnumerable<T> actual, IEnumerable<T> expected)
        {
            Assert.NotEqual(expected, actual);
            return actual;
        }

        /// <summary>
        /// Verifies that <paramref name="actual"/> Does Not Equal <paramref name="expected"/>.
        /// </summary>
        /// <typeparam name="T">The Type of the Elements in the collections.</typeparam>
        /// <param name="actual">The Actual collection being inspected.</param>
        /// <param name="expected">The Expected collection being inspected.</param>
        /// <param name="comparer">An Equality Comparer used during inspection.</param>
        /// <returns>The <paramref name="actual"/> collection following successful Assertion.</returns>
        /// <see cref="Assert.Equal{T}(IEnumerable{T},IEnumerable{T},IEqualityComparer{T})"/>
        public static IEnumerable<T> NotEqual<T>(this IEnumerable<T> actual, IEnumerable<T> expected, IEqualityComparer<T> comparer)
        {
            Assert.NotEqual(expected, actual, comparer);
            return actual;
            // ReSharper restore PossibleMultipleEnumeration
        }

        // TODO: TBD: public static object Single(IEnumerable collection)
        // TODO: TBD: public static void Single(IEnumerable collection, object expected)
        // TODO: TBD: public static T Single<T>(IEnumerable<T> collection)
        // TODO: TBD: public static T Single<T>(IEnumerable<T> collection, Predicate<T> predicate)

    }
}
