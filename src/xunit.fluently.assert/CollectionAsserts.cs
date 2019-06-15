using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

// ReSharper disable once IdentifierTypo
namespace Xunit
{
    public static partial class FluentlyExtensionMethods
    {
        // ReSharper disable PossibleMultipleEnumeration
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
            Assert.Collection(collection, elementInspectors);
            return collection;
        }
        // ReSharper restore PossibleMultipleEnumeration

        /// <summary>
        /// Verifies that the <paramref name="collection"/> Contains All of the
        /// <paramref name="expectedElements"/>.
        /// </summary>
        /// <typeparam name="T">The type of the Elements to be verified.</typeparam>
        /// <param name="collection">The Collection being inspected.</param>
        /// <param name="expectedElements">The Elements Expected to be in the Collection.</param>
        /// <returns>The <paramref name="collection"/> following successful Assertion.</returns>
        public static IEnumerable<T> AssertContainsAll<T>(this IEnumerable<T> collection, params T[] expectedElements)
            => expectedElements.Aggregate(collection, (g, x) => InvokeCollectionWithReturn(Assert.Contains, g, x));

        /// <summary>
        /// Verifies that the <paramref name="collection"/> Contains All of the
        /// <paramref name="expectedElements"/>.
        /// </summary>
        /// <typeparam name="T">The type of the Elements to be verified.</typeparam>
        /// <param name="collection">The Collection being inspected.</param>
        /// <param name="comparer">An Equality Comparer.</param>
        /// <param name="expectedElements">The Elements Expected to be in the Collection.</param>
        /// <returns>The <paramref name="collection"/> following successful Assertion.</returns>
        public static IEnumerable<T> AssertContainsAll<T>(this IEnumerable<T> collection, IEqualityComparer<T> comparer, params T[] expectedElements)
            => expectedElements.Aggregate(collection, (g, x) => InvokeCollectionWithReturn(Assert.Contains, g, x, comparer));

        /// <summary>
        /// Verifies that the <paramref name="collection"/> Contains elements matching the
        /// <paramref name="filter"/>.
        /// </summary>
        /// <typeparam name="T">The type of the Elements to be verified.</typeparam>
        /// <param name="collection">The Collection being inspected.</param>
        /// <param name="filter">The Filter to apply during the comparison.</param>
        /// <returns>The <paramref name="collection"/> following successful Assertion.</returns>
        public static IEnumerable<T> AssertContains<T>(this IEnumerable<T> collection, Predicate<T> filter)
            => InvokeCollectionWithReturn(Assert.Contains, collection, filter);

        /// <summary>
        /// Verifies that the <paramref name="collection"/> Does Not Contain elements matching
        /// the <paramref name="filter"/>.
        /// </summary>
        /// <typeparam name="T">The type of the Elements to be verified.</typeparam>
        /// <param name="collection">The Collection being inspected.</param>
        /// <param name="filter">The Filter to apply during the comparison.</param>
        /// <returns>The <paramref name="collection"/> following successful Assertion.</returns>
        public static IEnumerable<T> AssertDoesNotContain<T>(this IEnumerable<T> collection, Predicate<T> filter)
            => InvokeCollectionWithReturn(Assert.DoesNotContain, collection, filter);

        /// <summary>
        /// Verifies that the <paramref name="collection"/> Does Not Contain Any of the
        /// <paramref name="expectedElements"/>.
        /// </summary>
        /// <typeparam name="T">The type of the Elements to be verified.</typeparam>
        /// <param name="collection">The Collection being inspected.</param>
        /// <param name="expectedElements">The Elements Expected to be in the Collection.</param>
        /// <returns>The <paramref name="collection"/> following successful Assertion.</returns>
        public static IEnumerable<T> AssertDoesNotContainAny<T>(this IEnumerable<T> collection, params T[] expectedElements)
            => expectedElements.Aggregate(collection, (g, x) => InvokeCollectionWithReturn(Assert.DoesNotContain, g, x));

        /// <summary>
        /// Verifies that the <paramref name="collection"/> Does Not Contain Any of the
        /// <paramref name="expectedElements"/>.
        /// </summary>
        /// <typeparam name="T">The type of the Elements to be verified.</typeparam>
        /// <param name="collection">The Collection being inspected.</param>
        /// <param name="comparer">An Equality Comparer.</param>
        /// <param name="expectedElements">The Elements Expected to be in the Collection.</param>
        /// <returns>The <paramref name="collection"/> following successful Assertion.</returns>
        public static IEnumerable<T> AssertDoesNotContainAny<T>(this IEnumerable<T> collection, IEqualityComparer<T> comparer, params T[] expectedElements)
            => expectedElements.Aggregate(collection, (g, x) => InvokeCollectionWithReturn(Assert.DoesNotContain, g, x, comparer));

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
            => InvokeUnaryWithReturn(x => Assert.Empty(x), collection);

        /// <summary>
        /// Verifies that the <paramref name="collection"/> is Not Empty.
        /// </summary>
        /// <typeparam name="T">The Type of Collection.</typeparam>
        /// <param name="collection">The Collection being inspected.</param>
        /// <returns>The <paramref name="collection"/> following successful Assertion.</returns>
        /// <see cref="Assert.NotEmpty"/>
        public static T AssertNotEmpty<T>(this T collection)
            where T : IEnumerable
            => InvokeUnaryWithReturn(x => Assert.NotEmpty(x), collection);

        /// <summary>
        /// Verifies that <paramref name="actual"/> Equals <paramref name="expected"/>.
        /// </summary>
        /// <typeparam name="T">The Type of the Elements in the collections.</typeparam>
        /// <param name="actual">The Actual collection being inspected.</param>
        /// <param name="expected">The Expected collection being inspected.</param>
        /// <returns>The <paramref name="actual"/> collection following successful Assertion.</returns>
        /// <see cref="Assert.Equal{T}(IEnumerable{T},IEnumerable{T})"/>
        public static IEnumerable<T> Equal<T>(this IEnumerable<T> actual, IEnumerable<T> expected)
            => InvokeBinaryWithReturn<T>(Assert.Equal, actual, expected);

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
            => InvokeBinaryWithReturn(Assert.Equal, actual, expected, comparer);

        /// <summary>
        /// Verifies that <paramref name="actual"/> Does Not Equal <paramref name="expected"/>.
        /// </summary>
        /// <typeparam name="T">The Type of the Elements in the collections.</typeparam>
        /// <param name="actual">The Actual collection being inspected.</param>
        /// <param name="expected">The Expected collection being inspected.</param>
        /// <returns>The <paramref name="actual"/> collection following successful Assertion.</returns>
        /// <see cref="Assert.NotEqual{T}(IEnumerable{T},IEnumerable{T})"/>
        public static IEnumerable<T> NotEqual<T>(this IEnumerable<T> actual, IEnumerable<T> expected)
            => InvokeBinaryWithReturn<T>(Assert.NotEqual, actual, expected);

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
            => InvokeBinaryWithReturn(Assert.NotEqual, actual, expected, comparer);

        // TODO: TBD: public static object Single(IEnumerable collection)
        // TODO: TBD: public static void Single(IEnumerable collection, object expected)
        // TODO: TBD: public static T Single<T>(IEnumerable<T> collection)
        // TODO: TBD: public static T Single<T>(IEnumerable<T> collection, Predicate<T> predicate)

    }
}
