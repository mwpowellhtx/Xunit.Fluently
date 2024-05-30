using System;
using System.Collections;
using System.Collections.Generic;

// ReSharper disable once IdentifierTypo
namespace Xunit
{
    using Sdk;
    using System.Linq;

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
        /// Verifies that the <paramref name="collection"/> Contains Any elements that are
        /// aligned according to the <paramref name="filter"/> evaluation.
        /// </summary>
        /// <typeparam name="T">The type of the elements being verified.</typeparam>
        /// <param name="collection">The Collection being inspected.</param>
        /// <param name="filter">The expected <see cref="Predicate{T}"/> evaluating each element.</param>
        /// <returns>The <paramref name="collection"/> after having verified it Contains Any elements aligned to the predicate.</returns>
        /// <exception cref="ContainsException">Thrown when at none of the elements match the <paramref name="filter"/>.</exception>
        public static IEnumerable<T> AssertContainsAny<T>(this IEnumerable<T> collection, Predicate<T> filter)
        {
            Assert.Contains(collection, filter);
            return collection;
        }

        /// <summary>
        /// Verifies that the <paramref name="collection"/> Contains elements that are All
        /// aligned according to the <paramref name="filter"/> evaluation.
        /// </summary>
        /// <typeparam name="T">The type of the elements being verified.</typeparam>
        /// <param name="collection">The Collection being inspected.</param>
        /// <param name="filter">The expected <see cref="Predicate{T}"/> evaluating each element.</param>
        /// <returns>The <paramref name="collection"/> after having verified it Contains All elements aligned to the predicate.</returns>
        /// <exception cref="ContainsException">Thrown when at least one of the elements did not match the <paramref name="filter"/>.</exception>
        public static IEnumerable<T> AssertContainsAll<T>(this IEnumerable<T> collection, Predicate<T> filter)
        {
            Assert.Contains(collection, filter);
            return collection;
        }

        /// <summary>
        /// Verifies that the <paramref name="collection"/> Contains All of the
        /// <paramref name="expected"/>.
        /// </summary>
        /// <typeparam name="T">The type of the Elements to be verified.</typeparam>
        /// <param name="collection">The Collection being inspected.</param>
        /// <param name="expected">The Elements Expected to be in the Collection.</param>
        /// <returns>The <paramref name="collection"/> following successful Assertion.</returns>
        public static IEnumerable<T> AssertContainsAll<T>(this IEnumerable<T> collection, params T[] expected)
            => expected.Aggregate(collection, (g, x) =>
            {
                Assert.Contains(x, g);
                return g;
            });

        /// <summary>
        /// Verifies that the <paramref name="collection"/> Contains All of the
        /// <paramref name="expected"/>.
        /// </summary>
        /// <typeparam name="T">The type of the Elements to be verified.</typeparam>
        /// <param name="collection">The Collection being inspected.</param>
        /// <param name="comparer">An Equality Comparer.</param>
        /// <param name="expected">The Elements Expected to be in the Collection.</param>
        /// <returns>The <paramref name="collection"/> following successful Assertion.</returns>
        public static IEnumerable<T> AssertContainsAll<T>(this IEnumerable<T> collection, IEqualityComparer<T> comparer, params T[] expected)
            => expected.Aggregate(collection, (g, x) =>
            {
                Assert.Contains(x, g, comparer);
                return g;
            });

        /// <summary>
        /// Verifies that the <paramref name="collection"/> Contains elements matching the
        /// <paramref name="filter"/>.
        /// </summary>
        /// <typeparam name="T">The type of the Elements to be verified.</typeparam>
        /// <param name="collection">The Collection being inspected.</param>
        /// <param name="filter">The Filter to apply during the comparison.</param>
        /// <returns>The <paramref name="collection"/> following successful Assertion.</returns>
        public static IEnumerable<T> AssertContains<T>(this IEnumerable<T> collection, Predicate<T> filter)
        {
            Assert.Contains(collection, filter);
            return collection;
        }

        /// <summary>
        /// Verifies that the <paramref name="collection"/> Does Not Contain elements matching
        /// the <paramref name="filter"/>.
        /// </summary>
        /// <typeparam name="T">The type of the Elements to be verified.</typeparam>
        /// <param name="collection">The Collection being inspected.</param>
        /// <param name="filter">The Filter to apply during the comparison.</param>
        /// <returns>The <paramref name="collection"/> following successful Assertion.</returns>
        public static IEnumerable<T> AssertDoesNotContain<T>(this IEnumerable<T> collection, Predicate<T> filter)
        {
            Assert.DoesNotContain(collection, filter);
            return collection;
        }

        /// <summary>
        /// Verifies that the <paramref name="collection"/> Does Not Contain Any elements that
        /// align with the <paramref name="filter"/> evaluation.
        /// </summary>
        /// <typeparam name="T">The type of the elements being verified.</typeparam>
        /// <param name="collection">The Collection being inspected.</param>
        /// <param name="filter">The expected <see cref="Predicate{T}"/> evaluating each element.</param>
        /// <returns>The <paramref name="collection"/> after having verified it Does Not Contain Any elements aligned to the predicate.</returns>
        /// <exception cref="DoesNotContainException">Thrown when at least one element did not match the <paramref name="filter"/>.</exception>
        public static IEnumerable<T> AssertDoesNotContainAny<T>(this IEnumerable<T> collection, Predicate<T> filter)
        {
            Assert.DoesNotContain(collection, filter);
            return collection;
        }

        /// <summary>
        /// Verifies that the <paramref name="collection"/> Does Not Contain Any of the
        /// <paramref name="expected"/>.
        /// </summary>
        /// <typeparam name="T">The type of the Elements to be verified.</typeparam>
        /// <param name="collection">The Collection being inspected.</param>
        /// <param name="expected">The Elements Expected to be in the Collection.</param>
        /// <returns>The <paramref name="collection"/> following successful Assertion.</returns>
        public static IEnumerable<T> AssertDoesNotContainAny<T>(this IEnumerable<T> collection, params T[] expected)
            => expected.Aggregate(collection, (g, x) =>
            {
                Assert.DoesNotContain(x, g);
                return g;
            });

        /// <summary>
        /// Verifies that the <paramref name="collection"/> Does Not Contain Any of the
        /// <paramref name="expected"/>.
        /// </summary>
        /// <typeparam name="T">The type of the Elements to be verified.</typeparam>
        /// <param name="collection">The Collection being inspected.</param>
        /// <param name="comparer">An Equality Comparer.</param>
        /// <param name="expected">The Elements Expected to be in the Collection.</param>
        /// <returns>The <paramref name="collection"/> following successful Assertion.</returns>
        public static IEnumerable<T> AssertDoesNotContainAny<T>(this IEnumerable<T> collection, IEqualityComparer<T> comparer, params T[] expected)
            => expected.Aggregate(collection, (g, x) =>
            {
                Assert.DoesNotContain(x, g, comparer);
                return g;
            });

        // TODO: public static TValue Contains<TKey, TValue>(TKey expected, IReadOnlyDictionary<TKey, TValue> collection)
        // TODO: public static TValue Contains<TKey, TValue>(TKey expected, IDictionary<TKey, TValue> collection)
        // TODO: public static void DoesNotContain<TKey, TValue>(TKey expected, IReadOnlyDictionary<TKey, TValue> collection)
        // TODO: public static void DoesNotContain<TKey, TValue>(TKey expected, IDictionary<TKey, TValue> collection)

        /// <summary>
        /// Verifies that the <paramref name="collection"/> is Empty.
        /// </summary>
        /// <typeparam name="T">The Type of Collection.</typeparam>
        /// <param name="collection">The Collection being inspected.</param>
        /// <returns>The <paramref name="collection"/> following successful Assertion.</returns>
        /// <see cref="Assert.Empty"/>
        public static T AssertCollectionEmpty<T>(this T collection)
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
        public static T AssertCollectionNotEmpty<T>(this T collection)
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
        /// <see cref="Assert.Equal{T}(IEnumerable{T}?,IEnumerable{T}?)"/>
#if XUNIT_NULLABLE
        public static IEnumerable<T>? AssertCollectionEqual<T>(this IEnumerable<T>? actual, IEnumerable<T>? expected)
#else
        public static IEnumerable<T> AssertCollectionEqual<T>(this IEnumerable<T> actual, IEnumerable<T> expected)
#endif
        {
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
        /// <see cref="Assert.Equal{T}(IEnumerable{T}?,IEnumerable{T}?,IEqualityComparer{T})"/>
#if XUNIT_NULLABLE
        public static IEnumerable<T>? AssertCollectionEqual<T>(this IEnumerable<T>? actual, IEnumerable<T>? expected, IEqualityComparer<T> comparer)
#else
        public static IEnumerable<T> AssertCollectionEqual<T>(this IEnumerable<T> actual, IEnumerable<T> expected, IEqualityComparer<T> comparer)
#endif
        {
            Assert.Equal(expected, actual, comparer);
            return actual;
        }

        /// <summary>
        /// Verifies that <paramref name="actual"/> Equals <paramref name="expected"/>.
        /// </summary>
        /// <typeparam name="T">The Type of the Elements in the collections.</typeparam>
        /// <param name="actual">The Actual collection being inspected.</param>
        /// <param name="expected">The Expected collection being inspected.</param>
        /// <returns>The <paramref name="actual"/> collection following successful Assertion.</returns>
        /// <see cref="Assert.Equal{T}(IEnumerable{T}?,IEnumerable{T}?)"/>
#if XUNIT_NULLABLE
        public static IEnumerable<T>? AssertCollectionEqual<T>(this IEnumerable<T>? actual, params T[]? expected)
#else
        public static IEnumerable<T> AssertCollectionEqual<T>(this IEnumerable<T> actual, params T[] expected)
#endif
        {

#if XUNIT_NULLABLE
            GuardArgumentNotNull(nameof(expected), expected);
#endif

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
        /// <see cref="Assert.Equal{T}(IEnumerable{T}?,IEnumerable{T}?,IEqualityComparer{T})"/>
#if XUNIT_NULLABLE
        public static IEnumerable<T>? AssertCollectionEqual<T>(this IEnumerable<T>? actual, IEqualityComparer<T> comparer, params T[]? expected)
#else
        public static IEnumerable<T> AssertCollectionEqual<T>(this IEnumerable<T> actual, IEqualityComparer<T> comparer, params T[] expected)
#endif
        {

#if XUNIT_NULLABLE
            GuardArgumentNotNull(nameof(expected), expected);
#endif

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
        /// <see cref="Assert.NotEqual{T}(IEnumerable{T}?,IEnumerable{T}?)"/>
#if XUNIT_NULLABLE
        public static IEnumerable<T>? AssertCollectionNotEqual<T>(this IEnumerable<T>? actual, IEnumerable<T>? expected)
#else
        public static IEnumerable<T> AssertCollectionNotEqual<T>(this IEnumerable<T> actual, IEnumerable<T> expected)
#endif
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
        /// <see cref="Assert.Equal{T}(IEnumerable{T}?,IEnumerable{T}?,IEqualityComparer{T})"/>
#if XUNIT_NULLABLE
        public static IEnumerable<T>? AssertCollectionNotEqual<T>(this IEnumerable<T>? actual, IEnumerable<T>? expected, IEqualityComparer<T> comparer)
#else
        public static IEnumerable<T> AssertCollectionNotEqual<T>(this IEnumerable<T> actual, IEnumerable<T> expected, IEqualityComparer<T> comparer)
#endif
        {
            Assert.NotEqual(expected, actual, comparer);
            return actual;
        }

        /// <summary>
        /// Verifies that <paramref name="actual"/> Does Not Equal <paramref name="expected"/>.
        /// </summary>
        /// <typeparam name="T">The Type of the Elements in the collections.</typeparam>
        /// <param name="actual">The Actual collection being inspected.</param>
        /// <param name="expected">The Expected collection being inspected.</param>
        /// <returns>The <paramref name="actual"/> collection following successful Assertion.</returns>
        /// <see cref="Assert.NotEqual{T}(IEnumerable{T}?,IEnumerable{T}?)"/>
#if XUNIT_NULLABLE
        public static IEnumerable<T>? AssertCollectionNotEqual<T>(this IEnumerable<T>? actual, params T[]? expected)
#else
        public static IEnumerable<T> AssertCollectionNotEqual<T>(this IEnumerable<T> actual, params T[] expected)
#endif
        {

#if XUNIT_NULLABLE
            GuardArgumentNotNull(nameof(expected), expected);
#endif

            Assert.NotEqual(expected, actual);
            return actual;
        }

        /// <summary>
        /// Verifies that <paramref name="actual"/> Does Not Equal <paramref name="expected"/>.
        /// </summary>
        /// <typeparam name="T">The Type of the Elements in the collections.</typeparam>
        /// <param name="actual">The Actual collection being inspected.</param>
        /// <param name="comparer">An Equality Comparer used during inspection.</param>
        /// <param name="expected">The Expected collection being inspected.</param>
        /// <returns>The <paramref name="actual"/> collection following successful Assertion.</returns>
        /// <see cref="Assert.Equal{T}(IEnumerable{T}?,IEnumerable{T}?,IEqualityComparer{T})"/>
#if XUNIT_NULLABLE
        public static IEnumerable<T>? AssertCollectionNotEqual<T>(this IEnumerable<T>? actual, IEqualityComparer<T> comparer, params T[]? expected)
#else
        public static IEnumerable<T> AssertCollectionNotEqual<T>(this IEnumerable<T> actual, IEqualityComparer<T> comparer, params T[] expected)
#endif
        {

#if XUNIT_NULLABLE
            GuardArgumentNotNull(nameof(expected), expected);
#endif

            Assert.NotEqual(expected, actual, comparer);
            return actual;
        }

        // TODO: public static object Single(IEnumerable collection)
        // TODO: public static void Single(IEnumerable collection, object expected)
        // TODO: public static T Single<T>(IEnumerable<T> collection)
        // TODO: public static T Single<T>(IEnumerable<T> collection, Predicate<T> predicate)
    }
}